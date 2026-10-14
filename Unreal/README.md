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
- Demonstracao automatica de 10 segundos em loop: espera, deslocamento, ataque,
  reacao do alvo, retorno e efeito glacial. Pressione Play no editor.
- Modelos articulados e animacoes: Manny e clips do template Characters da Epic.
  Sao substitutos temporarios autorizados, nao os personagens originais.
- Efeitos: arco de essencia em malha afilada e erupcao de cristais sincronizados
  por Sequencer. Ainda nao sao habilidades interativas ou regras do Core.
- Nao apresentar os manequins do motor como modelos finais de Kael.
- O conceito de imagem aprovado e uma meta artistica, nao um render deste projeto.
- Ainda nao ha combate interativo, dano calculado ou build distribuivel nesta pasta.
- Configuracao Windows DX12/SM6, sombras virtuais e Lumen com distance fields.
- Validacao: geracao com UnrealEditor-Cmd 5.8.3, verificacao de bindings da sequencia
  e inspecao da janela de execucao. Qualidade artistica ainda e de estudo tecnico.

## Colaboracao e assets

Conteudo Epic permanece local em Content e nao e publicado no repositorio.
Cada colaborador deve gerar a cena a partir de sua instalacao licenciada do Unreal.
Arvore: Epic, template ArchVis/SampleScene/Tree. Materiais e composicao da arena:
gerados por `Scripts/build_scene.py`. Revise os termos Epic antes de redistribuir assets.
Personagens: Epic, TemplateResources/High/Characters. Arquivos sao copiados localmente
com os caminhos originais para preservar referencias. Nao foram publicados no GitHub.

O script recria somente o mapa gerado ForestArena. Salve alteracoes manuais em outro
mapa antes de executar novamente. Nao altera IDs, saves, dados ou cenas do Godot.
Antes de acrescentar modelos aprovados, definir armazenamento de binarios (LFS ou
pacote de assets separado) e documentar origem/licenca. Nao commitar caches do editor.
