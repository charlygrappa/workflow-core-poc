param(
[string]$repo,
[string]$tag
)

$file = "$tag-deploy.zip"
$dir = "$repo".Split("/")[1]
$temp_dir = "C:\MMD\deploy\_temp-$tag"

# Descargar el release de gitub

$releases = "https://api.github.com/repos/$repo/releases"

$download = "https://github.com/$repo/releases/download/$tag/$file"

Write-Host Downloading $file from github

Invoke-WebRequest $download -Out $file

Expand-Archive $file -Force -DestinationPath $temp_dir

# Detener Application Pool de IIS

# Descompirmir en la carpeta destino

# Reiniciar Application Pool de IIS
