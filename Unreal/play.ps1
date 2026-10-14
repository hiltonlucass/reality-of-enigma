param([string]$EngineRoot = 'D:\Epic\UE_5.8', [switch]$Editor)
$ErrorActionPreference = 'Stop'
$project = Join-Path $PSScriptRoot 'EnigmaScene\EnigmaScene.uproject'
$executable = Join-Path $EngineRoot 'Engine\Binaries\Win64\UnrealEditor.exe'
if (-not (Test-Path $executable)) { throw 'Unreal nao encontrado. Informe -EngineRoot.' }
if (-not (Test-Path (Join-Path $PSScriptRoot 'EnigmaScene\Content\Enigma\Maps\ForestArena.umap'))) {
    throw 'Execute prepare.ps1 primeiro.'
}
$arguments = '"' + $project + '"'
if (-not $Editor) { $arguments += ' -game -windowed -ResX=1280 -ResY=720' }
# Janela visivel intencional: este script abre a demonstracao solicitada.
Start-Process -FilePath $executable -ArgumentList $arguments
