# Arena jogável V3

## Combate manual

Uma borda verde indica o próximo personagem. Clique em um combatente para selecionar o alvo (borda dourada) e em uma habilidade disponível. Ataques exigem inimigo vivo; curas exigem aliado vivo; Quebrar Limites não exige alvo. Habilidades indisponíveis explicam o motivo na dica ao passar o mouse.

Uma seleção inválida não avança a rodada, não consome a vez e não inicia recarga. No turno inimigo ou em uma oportunidade perdida por controle, use Avançar. Auto continua resolvendo todas as ações, e Esc pausa. Os botões de aplicar controles continuam limitados à Arena de efeitos.

## Lyra

- Estilhaço: 100% de Essência e uma carga.
- Chuva Glacial: 140%, CD 3, duas cargas na fileira escolhida.
- Prisão Invernal: 180%, CD 4, três cargas em um alvo.
- Reino Congelado: 170%, CD 6 e inicial 2, duas cargas em todos e redução independente de 10% da velocidade por duas oportunidades.

O limiar de cinco cargas e a imunidade continuam como na V2. O Slow da habilidade é separado do Slow de 15% aplicado a chefes no limiar. Os efeitos somam com cargas até o teto provisório de 50%. Reaplicar o mesmo Slow renova duração e conserva a maior intensidade, sem multiplicação ilimitada.

## Kael

Corte Duplo tem dois acertos e Investida tem quatro, com rolagens críticas separadas. No caminho marcial, habilidades são definidas no catálogo, respeitando CD, estágio mínimo e nível. Punho Ascendente muda quantidade e força dos acertos no IV e VII; Fera Carmesim exige VI; Último Impacto aparece no VIII, somente a partir do nível 70, e mantém uso único e autocusto.

Bloqueio e Desvio continuam pendentes, portanto as propriedades de ignorar Bloqueio ainda não têm efeito. O restante dos kits de Kael base e Arsenal não foi completado nesta etapa.

## Treinamento

Onda 1: três inimigos. Onda 2: cinco inimigos. Onda 3: chefe. Quantidades e atributos são propostas de laboratório. A equipe mantém vida, controles, estágios e recargas ao passar de onda; mortos não revivem entre ondas.

Recompensas só aparecem na conclusão das três ondas e são concedidas uma única vez por execução. Em Auto, marcar Repetir treino ao vencer inicia uma nova execução após vitória, recriando a equipe. Pausar ou perder interrompe a repetição. Não existe custo para Auto; simulação conserva o custo de ticket e o requisito de conclusão anterior.

A separação entre campanha e treinamento é mantida. Varkhan exige fase 20 concluída e Solarius exige conclusão do ato. O modo de testes automatizados usa estado em memória e não altera o save do usuário.

## Validação e limites

97 verificações do núcleo aprovadas. Compilação sem erros ou avisos. No Godot, foram exercitados ataques manuais de Kael, habilidade de Lyra, três ondas completas, concessão única e repetição com parada.

Arte e animações permanecem na etapa V2: um sprite isolado de Kael, retratos aprovados para os demais e movimentos simples. Este incremento prioriza controle tático e farm funcional; não representa a campanha completa ou o balanceamento final.
