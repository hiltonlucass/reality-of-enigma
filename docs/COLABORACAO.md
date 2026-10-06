# Personagens e cutscenes

## Personagem
1. Defina nome original, ID estável, função, atributo, arquétipos e história. Valores são V1 e devem indicar lacunas.
2. Cadastre em `Godot/Data/catalog.json`: Characters, Skills e StatusEffects quando necessário. Personagens recrutáveis por Gold entram em Summon; bosses ficam fora desse pool.
3. Implemente regras novas em `Core`, reaproveitando origem de status, cargas independentes e formas vinculadas. Teste habilidades, cooldown, morte e alvo inválido em `Tests/Program.cs`.
4. Arte: PNG com alfa real, poses completas e pés alinhados. O atlas base tem12 quadros, corrida4, ação8, recuo8; `Battlefield.Frames.cs` valida contagens. Consulte `Data/animations.json`: textura e retângulos x/y/largura/altura, com âncora opcional. PoseFrame e ActionFrame definem a sequência; não presuma que qualquer ordem de atlas serve. Não estique sprites baixos para criar retratos.
5. Registre ícones em `Data/skill-icons.json` e a textura correta em `SkillIconButton.cs`. Associe áudio em `Data/audio.json` e `audio-samples.json`.
6. Para ficha: `hero-stories.json`, `JourneyData.Revealed`, `HeroBanner.cs` e `Main.CharacterCards.cs`. Existem escolhas visuais por índice; atualize-as conscientemente. Não basta acrescentar o ID à lista.
7. Entregue captura da ficha, ataque, reação, derrota e teste de formação. Preserve os demais heróis.

## Cutscene
O prólogo atual é uma sequência de ilustrações com câmera/texto em `OpeningScene.cs`, não um editor de timeline completo. As oito tomadas cobrem campo, explosão, roupa de combate, floresta, encontro dos mercenários e inimigos.

- `Main.Opening.cs` integra os eventos Finished/Leave e grava OpeningSeen/ForestEncounterSeen. Preserve conclusão, pular e voltar sem duplicar recompensas ou entrada na fase.
- Para roteiro inicial, altere as falas e mapeamento de tomadas no OpeningScene; para ampliar, prefira uma cena/arquivo novo em vez de aumentar Main.cs.
- As imagens atuais são `Art/prologue-v21.png` e `Art/encounter-v22.png`. Áudio deve parar ao sair/pular.
- `regions.json` contém resumo e final de cada um dos sete cenários. `Main.Journey.cs` abre encerramento ao vencer boss e libera a próxima região.
- Uma evolução útil é mover tomadas/duração/fala/arte/som para JSON, preservando os callbacks e os saves existentes. Não foi implementada uma timeline nova nesta preparação do GitHub.

## Validar sem perder progresso
Use save isolado nos testes. Não apague o save principal para rever cenas. Os métodos `Main.*Qa.cs` mostram modos existentes de captura; os testes automatizados não concedem recompensas à campanha do jogador.

## Evitar conflitos
Pessoa A: artes/poses do personagem e metadados dedicados. Pessoa B: cutscene nova e roteiro. Responsável principal: integração final em catalog.json, JourneyData e Main. Cada PR deve listar os pontos de integração necessários; nunca sobrescreva o trabalho de outra branch copiando a pasta toda.
