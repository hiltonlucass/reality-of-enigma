# Cena experimental Unreal

Projeto separado do Godot, Unreal Engine 5.8.3. Nao representa uma migracao concluida.

## Preparar

No PowerShell, na pasta `Unreal`, execute `./prepare.ps1 -EngineRoot 'D:\Epic\UE_5.8'`.
O script utiliza o template ArchVis instalado junto do Unreal para copiar a arvore
com suas dependencias. Gera materiais, arena, ruinas, iluminacao e camera no mapa
`/Game/Enigma/Maps/ForestArena`. Abra `EnigmaScene/EnigmaScene.uproject` no editor.

A primeira execucao pode demorar devido a compilacao de shaders. Consulte
`EnigmaScene/Saved/Logs` em caso de erro.

## Estado e limites

- Ambiente e camera: gerados pelo script, editaveis no Unreal.
- Personagens originais, animacoes de ataque e habilidades: ainda pendentes.
- Nao apresentar os manequins do motor como modelos finais de Kael.
- O conceito de imagem aprovado e uma meta artistica, nao um render deste projeto.
- Ainda nao ha combate jogavel nem build distribuivel nesta pasta.

## Colaboracao e assets

Conteudo Epic permanece local em Content e nao e publicado no repositorio.
Cada colaborador deve gerar a cena a partir de sua instalacao licenciada do Unreal.
Arvore: Epic, template ArchVis/SampleScene/Tree. Materiais e composicao da arena:
gerados por `Scripts/build_scene.py`. Revise os termos Epic antes de redistribuir assets.

O script recria somente o mapa gerado ForestArena. Salve alteracoes manuais em outro
mapa antes de executar novamente. Nao altera IDs, saves, dados ou cenas do Godot.
Antes de acrescentar modelos aprovados, definir armazenamento de binarios (LFS ou
pacote de assets separado) e documentar origem/licenca. Nao commitar caches do editor.
