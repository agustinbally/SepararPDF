function RemoveFile( $file )
{
    if (Test-Path $file) {
        Remove-Item $file
}
}

function RemoveFolder( $folder )
{
    If (Test-Path $folder)
    {
	    Remove-Item $folder -recurse
    }
}

function ZipFiles( $zipfilename, $sourcedir )
{
   Add-Type -Assembly System.IO.Compression.FileSystem
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,
        $zipfilename, $compressionLevel, $false)
}

$MyDir = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)
$SolutionPath = $MyDir + "\..\SepararPDF.sln"
$NuevoDirectorio = $MyDir + "\SepararPDF"
$NuevoDirectorioZip = $NuevoDirectorio + ".zip"
$DirectorioCompilacion = $MyDir + "\..\SeparadorPdfApp\bin\Release\*"

msbuild $SolutionPath /t:Build /p:Configuration=Release /m

RemoveFolder $NuevoDirectorio
New-Item -ItemType directory -Path $NuevoDirectorio

Copy-Item -Path $DirectorioCompilacion -Destination $NuevoDirectorio

$Vshost = $NuevoDirectorio + "\*.vshost.*"
$Pdb = $NuevoDirectorio + "\*.pdb"
Remove-Item $Vshost
Remove-Item $Pdb
RemoveFile $NuevoDirectorioZip

ZipFiles $NuevoDirectorioZip $NuevoDirectorio

RemoveFolder $NuevoDirectorio

