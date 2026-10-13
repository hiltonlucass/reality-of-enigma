param([string]$EngineRoot = 'D:\Epic\UE_5.8')
$ErrorActionPreference = 'Stop'
$project = Join-Path $PSScriptRoot 'EnigmaScene'
$editor = Join-Path $EngineRoot 'Engine\Binaries\Win64\UnrealEditor-Cmd.exe'
if (-not (Test-Path -LiteralPath $editor)) { throw "UnrealEditor-Cmd nao encontrado em $EngineRoot" }
# Preserva caminhos de pacote originais para as referencias dos materiais.
$tree = Join-Path $EngineRoot 'Templates\TemplateResources\Standard\ArchVis\Content\SampleScene\Tree'
$dest = Join-Path $project 'Content\SampleScene\Tree'
if (-not (Test-Path -LiteralPath $tree)) { throw 'Instale os recursos de templates do Unreal.' }
New-Item -ItemType Directory -Force -Path $dest | Out-Null
Copy-Item -Path (Join-Path $tree '*') -Destination $dest -Recurse -Force
$uproject = Join-Path $project 'EnigmaScene.uproject'
$script = Join-Path $PSScriptRoot 'Scripts\build_scene.py'
& $editor $uproject '-unattended' '-run=pythonscript' "-script=$script" '-nosplash' '-stdout' '-FullStdOutLogOutput'
if ($LASTEXITCODE -ne 0) { throw "Construcao falhou: $LASTEXITCODE. Veja EnigmaScene/Saved/Logs." }
if (-not (Test-Path (Join-Path $project 'Content\Enigma\Maps\ForestArena.umap'))) { throw 'Mapa nao foi gerado.' }
Write-Host 'Arena salva. Abra EnigmaScene/EnigmaScene.uproject no Unreal.'
