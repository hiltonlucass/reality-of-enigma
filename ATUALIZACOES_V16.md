# V16 — alvos, Lança do Horizonte e crítico

## Controles
No turno de um aliado, clique na habilidade e depois em um dos botões de alvo. Os botões mostram nome e posição (posição lateral/camada). Isso evita depender dos sprites sobrepostos. Cancelar retorna às habilidades. Buffs, ações sem alvo e ataques a todos os inimigos continuam diretos. Automático e Próxima ação continuam escolhendo ações automaticamente.

## Varkhan
A escolha define a coluna de três camadas. Mesmo escolhendo o último integrante, a Lança começa no primeiro vivo, atravessa o segundo e termina no terceiro. O feixe, impacto, recuo, HP e números de dano são escalonados em intervalos de 0,23 s. O cálculo acumulado de dano permanece intacto.

## Apresentação
Crítico usa balão pontudo com exclamação, borda dourada e cores de dano preservadas. Transições breves entre poses suavizam trocas de desenho durante corrida e ataques. Congelados não recebem essas transições.

Esta versão não acrescenta novos desenhos ao atlas; suaviza a apresentação dos quadros existentes. Animações autorais mais extensas por habilidade ainda precisam de produção artística.

## Validação
Exportação concluída e executável testado com saída 0, sem erros. Testado que escolher a habilidade aguarda seleção, e que selecionar o fundo com Varkhan mantém a ordem frente/meio/fundo. Capturas do feixe e crítico revisadas. Formação, estados, buffs, treinamento e fichas passaram pela sequência de verificação.

Extraia o ZIP inteiro e abra ProjectVaelorn.exe.
