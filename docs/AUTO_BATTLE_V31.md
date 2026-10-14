# V31 — combate automático com apresentação contínua

O combate mantém rodadas internas. Depois da preparação, a equipe escolhe ações e
alvos sem comandos individuais. A apresentação não espera mais um intervalo fixo
de 1,75 segundo além da animação: o próximo personagem pode avançar enquanto o
anterior retorna. Todos os impactos de uma ação são exibidos antes da próxima
resolução lógica, inclusive os golpes sequenciais de Fenrath e Varkhan.

## Executar

Godot 4.4.1 .NET e SDK .NET 8. Compilar `Godot/ProjectVaelorn.csproj` e executar
`Godot/project.godot`. No menu: **COMBATE AUTOMÁTICO • 5×5**. Arrastar os cinco
aliados no tabuleiro, selecionar cada aliado para escolher seu perfil, iniciar.
Os controles de reprodução permitem pausar e alternar 1×, 2× e 3×.

`--auto-demo` após `--` inicia uma demonstração automaticamente e usa um save em
memória. `--qa-auto CAMINHO_ABSOLUTO` executa a verificação visual, salva imagens
com esse prefixo e encerra após o combate. Nenhuma dessas opções grava progresso.
A demonstração usa cinco aliados e cinco inimigos; não concede recompensas.
Campanha e treinamento mantêm suas regras de recompensas e encontros existentes,
inclusive chefes únicos. Não são adicionados inimigos artificiais à campanha.

## Decisões da IA

`Godot/Data/auto-battle.json` define perfis e padrões por personagem. Cada perfil
pode ter `skills`, uma lista de IDs em ordem de preferência. Condições de nível,
recarga, limite de usos, Portões, HP mínimo e primeira fileira são verificadas
antes da seleção. Curas exigem um aliado abaixo de `healBelow`; buffs não são
reaplicados quando todos os aliados vivos já possuem aquele efeito.

Perfis disponíveis: equilibrado, agressivo, defensivo, suporte e controle.
Agressivo procura o menor HP na camada frontal ocupada; os demais priorizam a
frente e a coluna correspondente. A configuração da preparação vale para o
encontro atual, sem alterar o formato de saves. O kit e os multiplicadores não
foram substituídos. Corpo e Espírito continuam sendo uma vaga de equipe.

## Separação de responsabilidades

- `Core/AutoBattleAI.cs`: decisão sem interface ou relógio, com desempates estáveis.
- `Core/Battle.cs`: execução, RNG da batalha, cooldowns, rodadas e status existentes.
- `Godot/Battlefield.Flow.cs`: liberação após impactos e retorno sobreposto.
- `Godot/Main.AutoBattle.cs`: preparação, perfis e demonstração visual.

Velocidade de reprodução não altera dano, duração em turnos ou sorteios. A mesma
semente e a mesma formação produzem o mesmo resultado. QA legado mantém comandos
manuais somente para validar habilidades isoladas.

## Limites desta entrega

Esta versão entrega o fluxo automático 5×5 e o ritmo contínuo solicitado. O motor
de perseguições (Queda/Repelimento/Flutuação), prévia de cadeias, interceptações
novas e kit de Drakhar do documento de design ainda não foram implementados.
Os sprites e quantidades de quadros são os existentes; não é uma atualização de
arte nem uma migração para Unreal. A próxima ação sobrepõe o retorno, não dois
cálculos simultâneos de dano. Balanceamento dos perfis é V1.

## Validação

`dotnet run --project Tests/Vaelorn.Tests.csproj` cobre a regressão existente e
novos casos de cura, buffs, proteção frontal, prioridades configuradas, combate
5×5 completo e equivalência determinística entre processamento por ação/rodada.
`dotnet build Godot/ProjectVaelorn.csproj` valida a integração visual.
