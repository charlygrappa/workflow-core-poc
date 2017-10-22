param(
[string]$repo,
[string]$tag
)

$file = "$tag.zip"
$dir = "$repo".Split("/")[1]
$temp_dir = "C:\MMD\deploy\_temp\$tag"
$final_dir = "C:\MMD\deploy\$dir"
# Descargar el release de gitub

$releases = "https://api.github.com/repos/$repo/releases"

$download = "https://github.com/$repo/releases/download/$tag/$file"

Write-Host Downloading $file from github

Invoke-WebRequest $download -Out $file

Expand-Archive $file -Force -DestinationPath $temp_dir
Pause

# Detener Application Pool de IIS

# Mover a la carpeta destino

Write-Host Copying new version
Remove-Item $final_dir\$tag -Recurse -Force -ErrorAction SilentlyContinue
Move-Item $temp_dir\$tag\ -Destination $final_dir -Force

# Limpiar archivos temporales
Write-Host Cleaning up
Remove-Item $temp_dir -Recurse -Force -ErrorAction SilentlyContinue 
Remove-Item $file -Force -ErrorAction SilentlyContinue 

# Reiniciar Application Pool de IIS
