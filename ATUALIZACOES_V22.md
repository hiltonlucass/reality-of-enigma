# Project Vaelorn — V22

## Como experimentar

Extraia o ZIP Windows inteiro e abra `ProjectVaelorn.exe`. Mantenha o arquivo `.pck` e a pasta de bibliotecas junto do executável.

No menu inicial, escolha **PRÓLOGO + PRIMEIRO COMBATE** para rever a abertura e experimentar a floresta sem alterar o save ou receber recompensas. Na campanha, a fase 1 apresenta a abertura antes da formação. Saves que já passaram dessa fase continuam no progresso existente.

1. A abertura tem oito cenas ilustradas: campo, explosão, roupa de combate, partida, entrada na floresta, encontro com Savor, apresentação dos mercenários e aparição dos predadores. Avançar, pausar, voltar e pular continuam disponíveis.
2. Organize os aliados nos círculos e pressione **Iniciar combate**. Aguarde a animação de entrada.
3. Escolha um ícone na roda inferior central. A descrição aparece acima. Clique no alvo na arena e confirme abaixo dos ícones. Habilidades de grupo usam confirmação sem alvo individual.
4. Clique no ícone com **PASSIVA** acima para consultar a situação real da habilidade. Isso não gasta o turno.

## Entregue nesta versão

- 23 imagens distintas, uma para cada habilidade atualmente definida no catálogo, além de uma imagem para consulta das passivas.
- Habilidades organizadas em arco no centro inferior, dentro da arena. Os ícones permanecem visíveis durante a escolha do alvo.
- Cenário de floresta para o começo da campanha e para o replay do primeiro encontro.
- Grupo narrativo do primeiro combate: Kael, Savor, Aelia, Brakk e Raizen. Raizen participa temporariamente e não é concedido ao inventário. O replay não troca sua equipe salva.
- Faixa animada de entrada, revelação de vitória/derrota e partículas de encerramento. O encerramento espera o último efeito de combate terminar.
- 48 novos desenhos de ação: oito para cada um de Kael, Savor, Brakk, Lyra, Aelia e Raizen. Preparação, impacto e recuperação usam sequências próprias. Pés ancorados; congelamento e atordoamento interrompem essas sequências. A panela continua restrita aos buffs de Savor.
- Correção do efeito sísmico que podia tentar desenhar um círculo de tamanho zero.

## Todas as habilidades já estão ativas?

**Não.** Os ícones mostram as ações implementadas, respeitando recargas e requisitos. Não representam a conclusão de todos os kits do GDD.

| Personagem | Ações disponíveis nesta versão | Pendências principais |
|---|---|---|
| Kael base / Arsenal | Corte Duplo, Investida Relâmpago | Predador Ágil e kit completo do Arsenal |
| Kael marcial | Cinco ações, estágios e golpe extremo no nível 70 | Balanceamento e animação dedicada completa |
| Savor | Chute, golpe em coluna, Primeiro Prato e Orgulho do Chef | Ladies First; completar particularidades do golpe em coluna |
| Aelia | Pulso Etéreo e cura de alvo escolhido | Fios da Vida e demais habilidades |
| Brakk | Punho e impacto em fileira | Chassi Reforçado, bloqueio e demais habilidades |
| Lyra | Estilhaço, Chuva Glacial, Prisão Invernal, Reino Congelado | Passiva própria; balanceamento |
| Raizen | Chama Sombria e ataque em área | Restante do kit e passiva |
| Varkhan | Ataque de Essência e Lança do Horizonte | Restante do kit e passiva |
| Solarius | Ataque e especial de laboratório | Kit narrativo definitivo |

O sistema automático de cargas de gelo já funciona: redução de velocidade, congelamento, imunidade temporária e resistência de chefes. Os estágios do Kael marcial também funcionam. Passivas individuais pendentes estão explicitamente marcadas; consultá-las não aplica um bônus fictício.

## Limites atuais

A abertura é uma sequência de ilustrações com câmera, transições e diálogos, não um filme com atuação animada. Os 48 desenhos novos ampliam as ações de seis personagens; corrida, repouso, inimigos, chefes e Kael marcial ainda precisam de novas séries e polimento. Não há equivalência de produção com Epic Seven.

O encontro inicial foi integrado à história. As fases posteriores ainda usam a estrutura de laboratório; a sequência completa da cratera, derrota narrativa, fada e recrutamento de Lyra permanece por implementar. Não se deve interpretar as 70 fases existentes como uma campanha narrativa finalizada.

## Validação

- 136 verificações das regras de combate, progressão, persistência e economia.
- Teste visual do executável: efeitos, gelo somente após impacto, linha de Varkhan, formação, estados, oito cenas, roda central, ícones distintos, consulta de passiva, grupo da floresta e replay sem alteração do save.
- Fontes em `Godot/` e `Core/`; dados em `Godot/Data/`. Artes originais e registro de geração em `Godot/Art/PROMPTS_V22.md`.
