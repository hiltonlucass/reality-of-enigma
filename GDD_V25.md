# Reality Of Enigma

Documento de design de jogo — base V1 com atualização V25

04 de outubro de 2026 | Português | Planejamento para equipe

RPG offline de equipes, coleção e progressão por farm, com combate em turnos e formação 3×3. A direção visual migra da base pixel art para ilustração anime original; o protótipo ainda combina esses estilos. O primeiro ato acompanha Kael e seus aliados da explosão em Vaelorn à derrota e ao perdão de Solarius. A coleção cresce por recrutamento com Gold e por fragmentos de chefes elegíveis.

Este documento orienta narrativa, programação, arte e balanceamento. As decisões finais estabelecem o ápice marcial de Kael no nível 70, chefes repetíveis somente no treinamento e arquétipos separados das funções de combate. O protótipo começa por uma fatia funcional; este GDD descreve também sistemas ainda por implementar.

Convenções de leitura

- DEFINIDO: decisão do projeto consolidada nesta versão.
- PROPOSTA V1: regra operacional ou número inicial para teste, sem aprovação definitiva.
- PENDENTE: escolha que ainda precisa ser feita. Não deve ser tratada como conteúdo final.
- Todos os coeficientes de combate, taxas e recompensas são sujeitos a balanceamento. Preços de 1.000 e 9.000 Gold e marcos narrativos preservam as decisões atuais.

## 01 Visão e pilares

O jogador organiza cinco combatentes, avança por fases, investe em níveis e estrelas e ajusta a composição para superar encontros. Vencer permite registrar inimigos no treinamento e, em casos específicos, reconstruir chefes como aliados. O tempo offline fornece Gold e XP sem limite de horas de acúmulo.

Os pilares são progressão acessível por farm, personagens com identidades mecânicas claras, evolução que muda o modo de jogar e aprendizado gradual por meio da campanha. O jogo não depende de ranking, PvP, energia paga nem conexão permanente para sua progressão principal.

O destino comercial pretendido é PC via Steam. Cosméticos podem ser vendidos no futuro, mas não devem fornecer atributos, acelerar obrigatoriamente a progressão ou tornar personagens de múltiplos arquétipos exclusivos de pagamento. “Premium” descreve excepcionalidade de design e raridade; o acesso a poder permanece possível jogando.

O ciclo principal é campanha, combate, recompensa, investimento, composição e novo avanço. Treinamento e idle sustentam esse ciclo. Gacha de personagens e, após o Ato I, obtenção de equipamentos são sistemas separados.

### Escopo de produção

V1 de design: Ato I até o marco de nível 70, cinco integrantes permanentes após o prólogo, Raizen como integrante temporário e futuro antagonista, três chefes recrutáveis planejados e bifurcação de Kael no nível 30.

Protótipo inicial: interface de laboratório em Godot, combate automático por rodadas, catálogo externo, treinamento, fragmentos, invocação com Gold, evolução, idle e salvamento local. Não representa ainda a campanha completa, arte final ou balanceamento comercial.

### Organização do documento

As seções 02 a 05 cobrem a história e a campanha; 06 a 12, combate e personagens; 13 a 17, progressão e economia; 18 a 21, arte, tecnologia, roadmap e pendências. O apêndice registra naming e decisões substituídas.

## 02 Lore da ruptura em Vaelorn

Uma explosão rasga a Floresta de Vaelorn. Árvores são destruídas e uma cratera passa a emitir energia de outra dimensão. Kael, veterano de guerra que vive com a esposa e a filha nas proximidades, sai para investigar, temendo que a ruptura alcance sua família.

Na floresta ele encontra Savor, Aelia, Brakk e Raizen. Os quatro mercenários procuram o filho de um governador, desaparecido há duas semanas. Savor lidera o grupo. Aelia e Brakk o recebem de forma amistosa; Raizen mantém distância, trata os demais com desprezo e revela sua obsessão por superioridade. Kael se junta à investigação.

O caminho até a cratera serve como tutorial de dez encontros. Criaturas vindas das fendas atacam a região: cães deformados e predadores dimensionais. “Demogorgon” permanece apenas como referência interna de silhueta; o produto usará criaturas originais. PROPOSTA V1: chamar o inimigo de treino de nível 7 de Predador da Fenda.

Na cratera está Solarius, o Rei do Sol. Seu deslocamento entre dimensões causou a explosão e trouxe criaturas junto dele. Ele deixa escapar informações sobre o Devorador de Mundos, uma entidade da qual conseguiu escapar. As pistas ainda não revelam toda a natureza da ameaça.

Raizen sente a força de Solarius e o provoca para testar seus limites. Solarius passa a considerar o grupo uma ameaça. No primeiro turno conjura Sol Esmagador. O jogador recebe uma janela de ação enquanto o ataque carrega; no turno seguinte, o sol detona e derruba a equipe. Esta derrota é um evento narrativo do prólogo, não uma falha que exige grind nem um chefe recrutável liberado.

Uma fada encontra os sobreviventes e restaura suas queimaduras e feridas. Ela deixa quatro recursos de ascensão específicos e um Coringa. Kael, Savor, Aelia e Brakk chegam a 3 estrelas por concessão do tutorial. Esses recursos não são equipamentos: o sistema de equipamentos só começa após o Ato I.

Raizen abandona o grupo para perseguir a fonte daquele poder. Os demais procuram respostas e um quinto integrante. O destino do filho do governador, a identidade da fada e a razão exata de sua intervenção ainda estão PENDENTES; a V1 não inventa uma resolução para esses fios narrativos.

## 03 Lore da reconstrução e da perda

Savor apresenta o Contrato dos Mercenários, justificativa narrativa para o recrutamento. A primeira invocação é gratuita e garante Lyra. Ela substitui a função de dano de Essência em área deixada por Raizen, acrescentando controle e manipulação de velocidade. Um tutorial conduz o uso do Coringa para sua segunda estrela.

O grupo aprende a recriar inimigos registrados na Zona de Treinamento. Os primeiros registros têm baixo rendimento, como o Predador da Fenda de nível 7. Avançar pelos rastros da ruptura libera registros melhores; permanecer no início continua permitido.

No marco de nível 20, Varkhan, o Perfurador Abissal, impede a passagem. Guerreiro de Essência originalmente não maligno, ele teve a mente parcialmente devorada e é usado como sentinela. Sua Lança do Horizonte atravessa as três camadas e demonstra que a retaguarda não é sempre o lugar mais seguro.

Após sua derrota, a corrupção perde força e o corpo se desfaz em Fragmentos de Alma. O grupo acredita inicialmente que ele morreu. A reconstrução por fragmentos revela Varkhan livre da influência. Ele relata que a entidade começa devorando a mente. A identidade persiste na reconstrução; não surgem múltiplas pessoas quando o jogador obtém cópias mecânicas.

PROPOSTA V1 para coerência do farm: a Sala de Treinamento recria ecos registrados do encontro e estabiliza resíduos de alma. Repetir um eco não mata novamente o personagem nem repete eventos da história. Fragmentos adicionais aprofundam a reconstrução e aumentam estrelas.

Entre os marcos 20 e 30, Kael recebe notícias de um ataque à sua vila. Ao voltar para casa, encontra a esposa e a filha mortas. Um demônio ocupa o território como soberano e usa uma criatura menor como fonte de armas. O confronto do marco 30 encerra essa ocupação e abre a escolha de evolução.

O pequeno demônio afirma que também estava sendo usado. Kael pode eliminá-lo e abandonar as espadas, transformando o luto em combate marcial; ou aceitar sua força e carregar um Arsenal Vivo, buscando vingança com crescente obsessão. A tragédia deve ser tratada com peso narrativo, sem depender de violência gráfica. Nomes e designs dos dois demônios continuam PENDENTES.

## 04 Lore do ápice e do perdão

Os segmentos intermediários conduzem o grupo até Solarius. Há chefes nos marcos 40, 50 e 60, mas seus personagens, kits e cenas ainda não foram definidos. Um segundo chefe recrutável está reservado para aproximadamente o nível 50. Os demais podem existir apenas como obstáculos narrativos ou mecânicos.

No confronto final do Ato I, no nível 70, o grupo chega disposto a lutar. Solarius também não quer conversar. Ele começa a preparar novamente Sol Esmagador, repetindo a ameaça do prólogo. Desta vez a equipe tem os recursos e a força conquistados durante a jornada.

No caminho marcial, Kael atinge o VIII estágio antes da detonação. Sua aura fica vermelha, o corpo adquire volume muscular muito maior e seu golpe extremo derrota Solarius. O VIII estágio e Último Impacto desbloqueiam no nível 70, nunca no 80. A encenação preserva esses acontecimentos, mas não precisa copiar pose, enquadramento ou efeito de qualquer anime.

O grupo decide poupar Solarius. Só então acontece a conversa. Ele revela a ameaça do Devorador de Mundos e explica que Raizen se aproximou da entidade em busca de poder. A entidade está entrando nele, preparando a tomada de seu corpo. A vingança de Kael cede espaço à compreensão de que ainda pode proteger quem está ao seu lado.

Solarius torna-se elegível para farm e recrutamento na Sala de Treinamento somente depois de concluído o ato e registrada a conversa. A luta da campanha não pode ser repetida para gerar fragmentos. A versão recrutada deve ter parâmetros próprios; o ataque invencível do prólogo não é transferido ao jogador.

### Bifurcação e cena final

PENDENTE CRÍTICO: o golpe marcial obrigatório descrito para o final não pode apagar silenciosamente a escolha de Arsenal Vivo. A cena acima é o final definido para o caminho marcial. Para Arsenal Vivo, a equipe deve aprovar uma cena equivalente com seu próprio golpe, ou uma manifestação narrativa transitória que não troque permanentemente arquétipos. O protótipo não impõe uma dessas soluções como cânone.

Também falta definir como a cena protege a continuidade de Kael se o custo de vida do golpe for letal. PROPOSTA V1: resolver a vitória narrativa antes do custo final e realizar uma intervenção de Aelia na cena, sem conceder imortalidade nas lutas comuns de treinamento.

## 05 Campanha e marcos

DEFINIDO: fases sequenciais, com chefes a cada décima fase. Fase e nível são campos distintos; a numeração da fase não altera automaticamente o nível do personagem. PROPOSTA V1: alinhar a fase 70 ao marco recomendado de nível 70 no primeiro ato.

| Segmento | Conteúdo | Resultado principal |
| --- | --- | --- |
| Prólogo 1 a 10 | Floresta e Solarius impossível | Resgate e saída de Raizen |
| Fases 1 a 10 do ato | Rastros e consolidação do grupo | Chefe de identidade pendente |
| Fases 11 a 20 | Sentinela dominada | Varkhan e treino recrutável |
| Fases 21 a 30 | Retorno à vila | Bifurcação de Kael |
| Fases 31 a 40 | Expansão da ameaça | Chefe pendente |
| Fases 41 a 50 | Nova barreira | Segundo recrutável pendente |
| Fases 51 a 60 | Aproximação do Rei do Sol | Chefe pendente |
| Fases 61 a 70 | Confronto final | Solarius poupado e Ato II |

A separação do prólogo em dez encontros próprios é PROPOSTA V1 para conciliar o tutorial antigo com os novos blocos numerados. Deve ser confirmada antes da escrita final das fases. O encontro impossível não conta como derrota registrada de Solarius e não libera treinamento.

Uma fase concluída registra a vitória uma única vez e libera a seguinte. Após derrotar um chefe, o progresso aponta para o segmento seguinte. Recompensas de primeira conclusão não podem ser obtidas outra vez recarregando a tela.

Somente chefes marcados como elegíveis aparecem na aba de chefes recrutáveis. Varkhan no 20 e Solarius no 70 estão definidos; o 50 permanece reservado. Chefes 10, 30, 40 e 60 não recebem recrutamento automaticamente.

O salvamento mantém flags separadas para fase vencida, registro de treino e ato concluído. A derrota do prólogo avança o roteiro de tutorial, mas não aciona o fluxo normal de vitória. A interface deve diferenciar “nível recomendado” de “número da fase”.

## 06 Combate e posicionamento

DEFINIDO: combate em turnos de até cinco aliados contra cinco inimigos. Cada personagem tem ataque básico, passiva e três habilidades com recargas; habilidades especiais podem exigir estado, nível ou uso único. Velocidade determina a ordem de ação.

PROPOSTA V1: rodada é uma passagem em que cada unidade viva tem uma oportunidade de agir. A ordem é calculada no início da rodada; mudanças de velocidade passam a influenciar a rodada seguinte. Empates usam posição e identificador estáveis. Mortos saem da fila. Estados não criam turnos extras por padrão.

O campo possui frente, meio e retaguarda, com posições em colunas. Uma equipe ocupa até cinco posições sem sobreposição. “Linha perfurante” percorre a mesma coluna da frente à retaguarda; “fileira” atinge uma camada inteira; “área” atinge todos os adversários vivos. Essa distinção evita interpretar a Lança do Horizonte como três alvos aleatórios.

Força é o atributo ofensivo físico, mostrado em vermelho. Essência é o atributo de técnicas e energia, mostrado em roxo. Não são classes. Vida, Defesa, Velocidade, chance crítica, dano crítico, Bloqueio e Desvio completam a base. Precisão é uma ideia antiga ainda não aprovada como atributo independente.

Bloqueio atua sobre dano de Força; Desvio atua sobre dano de Essência. PROPOSTA V1: bloqueio reduz 50% do dano e desvio evita integralmente o acerto. Defesa usa mitigação de 100 dividido por 100 mais Defesa. Crítico inicial multiplica por 1,5. Chances são limitadas ao intervalo de 0 a 100%.

Ordem proposta: escolher alvo e escala, calcular bônus, sortear crítico e defesa específica, aplicar Defesa e reduções, absorver barreira, redirecionar dano elegível, reduzir HP e disparar reações. Dano efetivo é HP realmente removido, limitado à vida restante. Sobre-dano não alimenta a Lança do Horizonte. Bloqueio/desvio, barreiras e redirecionamento devem aparecer no log.

Recarga é contada por rodadas completas. Uma habilidade CD 3 usada na rodada 1 volta na rodada 4. CD inicial 2 libera na rodada 3. PROPOSTA V1: durações contam oportunidades do afetado, com imunidades e estados aplicados no mesmo turno protegidos contra expiração imediata. A regra deverá ser uniforme em todos os kits.

## 07 Controles e efeitos de estado

| Efeito | Comportamento V1 | Chefes |
| --- | --- | --- |
| Carga de Gelo | Até 5; cada uma reduz 3% de Velocidade | Converte limiar em Slow |
| Congelamento | Perde 1 oportunidade; remove cargas | Imune ao bloqueio de ação |
| Imunidade ao gelo | 2 oportunidades após descongelar | Janela também proposta para chefe |
| Slow | Reduz velocidade por duração | Permitido com limites |
| Queimadura | Dano periódico de Essência | Permitida |
| Sangramento | Dano periódico de Força | Permitido |
| Stun | Perde oportunidade de agir | Resistência ainda pendente |
| Silêncio | Bloqueia habilidades ativas | Resistência ainda pendente |
| Provocação | Restringe alvos ofensivos | Resistência ainda pendente |
| Medo e Sono | Controle futuro | Regras pendentes |
| Enraizamento | Requer sistema de movimento significativo | Fora do primeiro protótipo |

Lyra já define a primeira família completa de controles. Ao chegar a cinco cargas, um inimigo comum congela por um turno e recebe imunidade por dois turnos após o controle. Contra chefe, o limiar aplica menos 15% de Velocidade por dois turnos em vez de congelar.

PROPOSTA V1: cargas não se acumulam durante a imunidade; atingir o limiar sempre as consome. Slow de mesma origem renova duração e mantém o maior valor, evitando crescimento ilimitado. Reduções de velocidade combinadas ficam limitadas a 50% até que testes indiquem outro teto.

O motor deve separar definição de efeito e instância ativa. Uma instância armazena origem, intensidade, cargas, duração e regras de renovação. Efeitos periódicos registram a escala no momento da aplicação, salvo exceção explícita no kit. Remover um debuff não remove passivas, estágios de Kael nem estado narrativo.

O protótipo cobre dano, cura e o ciclo de gelo como base. Os demais controles devem ser implementados por operadores específicos, sem fingir que uma string no catálogo equivale a uma mecânica funcional. Testes devem verificar duração, imunidade, limite de cargas, morte e interação com chefes.

## 08 Kits de Savor e Kael base

### Savor Chef de Batalha

Função: suporte de buffs e dano secundário. Escala: Força. Arquétipo Lutador é PROPOSTA V1. Visual próprio de cozinheiro de guerra, roupas práticas e utensílios; não reproduzir traje ou silhueta de referência.

- Básico Service Kick: 100% de Força em um inimigo.
- Passiva Ladies First: mais 10% de Força por aliada feminina na formação, até 40%. Usar tag explícita de personagem, sem inferência visual.
- First Fish, CD 3: aumenta em 10% a Velocidade atual de todos os aliados por duas rodadas. Reaplicações renovam o efeito; não multiplicam indefinidamente o próprio bônus.
- Chef’s Pride, CD 5: se Savor tiver a maior Força da equipe, concede mais 50% de Força e Essência a todos por duas rodadas. Caso contrário, concede mais 50% do atributo ofensivo principal ao aliado cujo atributo principal for maior. Empate no alvo individual usa sorteio. PROPOSTA V1: empate de Savor na maior Força também satisfaz a condição; avaliar antes de aplicar o buff.
- Blazing Heel, CD 4: 230% de Força na coluna das três camadas, com mais 15 pontos percentuais de chance crítica.

### Kael Lâmina da Vanguarda

Função: dano em alvo único e execução. Escala: Força. Arquétipo: Espadachim. É um veterano ágil com duas lâminas curtas e mobilidade própria do universo.

- Básico Corte Duplo: dois acertos de 55% de Força no mesmo alvo.
- Passiva Predador Ágil: mais 3% de dano a cada 10% de HP perdido pelo alvo, até 24%. PROPOSTA V1: avaliar antes de cada acerto.
- Investida Relâmpago, CD 3: quatro acertos de 55% de Força; crítico independente por acerto.
- Ponto Cego, CD 4: 280% de Força, não bloqueável; mais 20 pontos percentuais de crítico se o alvo estiver abaixo de 50% de HP.
- Execução, CD 6: 400% de Força; abaixo de 25% de HP do alvo, dano aumentado em 50%. Contra chefe, esse aumento é 20%. É multiplicador de dano, não morte instantânea.

Os nomes dos golpes consolidados são nomes de trabalho. Tradução integral para português e revisão de originalidade fazem parte da etapa editorial. Estatísticas absolutas, raridade final e animações ainda precisam de validação.

## 09 Kits de Aelia e Brakk

### Aelia Tecelã da Vida

Função: cura e proteção. Escala: Essência. Arquétipo Tecelão é PROPOSTA V1, separado da função de suporte. Sua identidade visual usa fios de energia vital e conexões entre aliados.

- Básico Pulso Etéreo: 90% de Essência contra um inimigo.
- Passiva Fios da Vida: quando um aliado cai abaixo de 30% de HP, cura 80% da Essência de Aelia. Uma ativação por aliado a cada quatro rodadas. Não ressuscita um alvo já morto.
- Costurar Feridas, CD 3: cura 250% de Essência no aliado com menor percentual de HP e remove um debuff. PROPOSTA V1: empate por posição e remoção do debuff mais antigo removível.
- Elo Vital, CD 4: por duas rodadas, um aliado recebe mais 20% de resistência a dano e mais 20% de cura recebida. Quinze por cento do dano que ele recebe converte-se em cura para Aelia; essa cura não inicia um novo ciclo de conversão.
- Renovação, CD 6: cura todos em 160% de Essência, com mais 80% para quem estiver abaixo de 30% de HP na avaliação inicial da habilidade.

A cura é limitada ao HP máximo. PROPOSTA V1: Aelia pode selecionar a si mesma quando o texto disser aliado; Elo Vital sobre si não converte autocusto de Kael, dano redirecionado ou cura em novos eventos de dano.

### Brakk BRK 01

Função: tanque e protetor. Escala: Força, com investimento em Defesa. Arquétipo Autômato é PROPOSTA V1. Robô pesado de mineração e guerra, com peças recuperadas e leitura clara de blindagem.

- Básico Punho Hidráulico: 100% de Força e uma Carga de Blindagem, máximo três.
- Passiva Chassi Reforçado: recebe 15% menos dano de Força. Ao bloquear, recupera 3% do HP máximo.
- Protocolo Guarda, CD 3: durante duas rodadas, absorve 60% do dano de Força destinado ao aliado escolhido. Não protege inicialmente contra Essência.
- Blindagem Reativa, CD 4: consome todas as cargas; cada uma concede mais 10 pontos percentuais de Bloqueio e 8% de redução de dano durante duas rodadas. Com três cargas: 30 pontos de Bloqueio e 24% de redução.
- Impacto Sísmico, CD 5: 180% de Força na primeira fileira inimiga; reduz a Força dos atingidos em 20% por duas rodadas.

PROPOSTA V1: Guarda divide o dano já mitigado pelo destinatário, sem segunda rolagem de bloqueio nem redirecionamento recursivo. Reduções próprias de Brakk no dano transferido precisam de teste; não permitir cadeia infinita entre protetores.

## 10 Kits de Raizen e Lyra

### Raizen Olho das Cinzas

Função: dano em área. Escala: Essência. Arquétipo Canalizador é PROPOSTA V1. Integrante temporário do prólogo, depois ausente da equipe da campanha. Sua eventual disponibilidade no gacha durante essa ausência é PENDENTE; o protótipo o exclui do banner padrão.

- Chama Sombria: básico de 100% de Essência.
- Olho das Cinzas: dano de Essência concede uma Marca Ocular, até cinco. Cada marca concede 3% de Essência; cinco marcas concedem mais 10 pontos de crítico. Persistem até o fim da luta. PROPOSTA V1: uma marca por habilidade que causar dano, para evitar ambiguidade em área; o kit ainda precisa de confirmação desse limite.
- Chamas Negras, CD 3: 180% de Essência em uma fileira e Queimadura de 30% de Essência por duas rodadas.
- Tempestade das Cinzas, CD 4: 150% de Essência em todos os inimigos; cada alvo atingido tem 20% de chance de conceder marca adicional.
- Avatar da Ruína, CD 6 e inicial 3: 250% de Essência em todos. Manifestação por duas rodadas com mais 30% de Essência, 20 pontos de Desvio e 25% de dano de Chamas Negras.

Evoluções futuras podem separar dano remoto de Essência e combate híbrido de lâmina, mas não possuem kit aprovado. O avatar e o motivo ocular exigem desenvolvimento visual original.

### Lyra Dama do Inverno

Função: controle e dano em área. Escala: Essência. Arquétipo Canalizador é PROPOSTA V1. Primeiro recrutamento garantido após a saída de Raizen.

- Estilhaço: básico de 100% de Essência e uma Carga de Gelo.
- Zero Absoluto: cada carga reduz 3% de Velocidade, até cinco. No limiar, congela por um turno, remove cargas e concede imunidade por dois turnos. Chefe recebe Slow de 15% por dois turnos.
- Chuva Glacial, CD 3: 140% de Essência em uma fileira e duas cargas por alvo atingido.
- Prisão Invernal, CD 4: 180% de Essência em um alvo e três cargas. O limite continua sendo cinco; atingir ou ultrapassar o limiar resolve o congelamento uma única vez.
- Reino Congelado, CD 6 e inicial 2: 170% de Essência em todos, duas cargas e menos 10% de Velocidade por duas rodadas.

PROPOSTA V1: um ataque desviado não aplica suas cargas. A versão evoluída de Lyra no nível 30 foi sugerida visualmente, mas ainda não tem mudanças mecânicas aprovadas.

## 11 Evolução bifurcada de Kael

A escolha ocorre após o confronto do nível 30. Caminhos são mutuamente exclusivos na formação: uma unidade não conta duas vezes por manter dados da versão anterior. Permanência ou reversão da escolha é PENDENTE. O laboratório permite trocar para testar; isso não define o custo do produto final.

### Caminho Arsenal Vivo

Kael aceita a criatura menor como fonte de armas. Mantém Espadachim e a possibilidade futura de usar espada, lança, corrente e adaga. Cargas do arsenal podem modular crítico, penetração, controle e múltiplos acertos. O personagem se torna mais frio e obcecado, mas a reconciliação final recupera sua ligação com o grupo.

Não há kit numérico aprovado para este caminho. No protótipo ele conserva o kit básico como placeholder explicitamente identificado. Não atribuir automaticamente Essência ou segundo arquétipo só por carregar uma criatura.

### Caminho marcial dos Oito Selos

Kael rejeita a criatura, abandona as espadas e passa de Espadachim a Lutador, com ícone de punho. “Portões” é a referência mecânica interna; “Oito Selos” é um nome de trabalho para uma linguagem própria. A progressão reinicia no estágio zero em cada combate.

Abre um estágio a cada duas rodadas completas. Cruza 75%, 50% e 25% de HP pela primeira vez na batalha: cada limiar abre mais um. Uma queda de 80% para 45% abre dois. Curar e cruzar novamente não repete a recompensa. Antes do nível 70 o limite é VII; no 70 o VIII e o golpe extremo ficam disponíveis. Não acumular estágios ocultos além do limite.

- Limites Quebrados: por estágio, mais 8% de Força e 4% de Velocidade.
- Punho Ascendente: básico de 110% de Força; a partir do IV, dois acertos de 65%; a partir do VII, três de 55%.
- Quebrar Limites, CD 4: abre um estágio e custa 8% do HP atual, sem matar. O custo pode cruzar um limiar e abrir outro estágio.
- Impacto Ascendente, CD 3: 220% de Força mais 20 pontos percentuais por estágio. VIII resulta em 380%.
- Fera Carmesim, CD 6 e requisito VI: 350% no VI, 450% no VII e 550% no VIII; ignora 30% do Bloqueio.

No VIII recebe mais 25% de Força, 20 pontos de crítico, 30% de Velocidade e imunidade a Slow. Perde 10% do HP máximo ao fim de cada turno próprio; esse custo pode matar. PROPOSTA V1: bônus percentuais de estágio e VIII somam sobre a base para evitar multiplicação oculta.

Último Impacto substitui temporariamente Quebrar Limites no VIII: uso único por batalha, 800% de Força, ignora 50% do Bloqueio e 30% da Defesa; custa 50% do HP máximo e pode matar. As porcentagens de ignorar Bloqueio reduzem a chance proporcionalmente, como regra provisória.

## 12 Varkhan e catálogo de chefes

Varkhan, o Perfurador Abissal, é o primeiro chefe recrutável, no nível 20. Sua função é dano de Essência e pressão de posicionamento. Facção/arquétipo e restante do kit continuam PENDENTES; não tratá-lo como o tanque original descartado.

### Lança do Horizonte

CD 5. Atravessa uma coluna da frente à retaguarda, atingindo até três camadas. A base é 150% da Essência de Varkhan. Cada acerto usa como acréscimo o dano efetivamente causado no alvo anterior, e não a soma paralela de todos os resultados anteriores.

| Etapa | Dano bruto antes das defesas | Exemplo sem mitigação |
| --- | --- | --- |
| Primeiro alvo | Base | 150 com Essência 100 |
| Segundo alvo | Base mais dano efetivo do primeiro | 300 |
| Terceiro alvo | Base mais dano efetivo do segundo | 450 |

Se o primeiro tiver apenas 40 HP, o acréscimo para o segundo é 40. Se o segundo receber efetivamente 120, o terceiro parte de base mais 120. Desvio integral produz zero de acréscimo para o próximo. PROPOSTA V1: posições vazias são ignoradas; o próximo alvo vivo da mesma coluna recebe a cadeia. Não saltar para outra coluna.

O efeito pode ser muito forte. Testar alvos de alta Defesa na frente, desvio, barreiras, pouca vida e proteção. Um teto de transferência só será introduzido como mudança de balanceamento explícita. Os exemplos não confirmam equilíbrio.

### Recrutamento dos chefes

Varkhan 20: definido. Chefe 50: vaga planejada, nome, função e kit pendentes. Solarius 70: definido como recrutável após conclusão do ato, com kit de aliado pendente. Demais chefes: recrutamento desabilitado até decisão específica.

Sol Esmagador tem duas representações futuras: evento narrativo inevitável no prólogo e habilidade telegráfica enfrentável no final. A versão de laboratório usa números reduzidos e não substitui o roteiro. O jogador deve ver a preparação antes da detonação.

Chefes controlados expressam a ação do Devorador sobre a mente. Solarius escapou da entidade e não deve ser reescrito como um dominado comum. O treino de Solarius após o perdão é um eco ou treinamento consentido; sua justificativa final ainda requer aprovação.

## 13 Facções arquétipos e sinergias

Função de combate descreve o que a unidade faz: dano, tanque, cura, suporte ou controle. Arquétipo descreve pertencimento e elegibilidade de sinergia/equipamento: Espadachim, Lutador e outros grupos a definir. Facção narrativa pode existir como campo separado para organizações do mundo, sem ser confundida com função.

Comuns normalmente têm um arquétipo; raros podem ter dois; personagens excepcionalmente premium podem ter até três. Cada membro conta uma única vez para cada grupo ao qual pertence e participa de todas as sinergias aplicáveis. Uma unidade Espadachim/Lutador contribui um para cada contador, nunca dois para Lutador.

DEFINIDO: Kael base e Arsenal Vivo permanecem Espadachim. Kael marcial troca para Lutador e perde a contagem de Espadachim. A UI mostra a alteração antes de confirmar a evolução.

| Lutadores na formação | Benefício | Situação |
| --- | --- | --- |
| 2 | Mais 10% de dano para toda a equipe | Tipo definido; valor proposto |
| 3 | Mais 30 pontos percentuais de chance crítica aos Lutadores | Valor inicial definido |
| 4 | Lutadores recebem 12% menos dano | Proposta V1 |
| 5 | Lutadores recebem mais 15% de Velocidade | Proposta V1 |

PROPOSTA V1: patamares são cumulativos; 5 ativa também 2, 3 e 4. Todos os números estão sujeitos a balanceamento. O bônus de dano para o time não aumenta cura nem autocusto. A contagem considera a formação inicial, preservando bônus durante a batalha mesmo quando um membro cai; a alternativa de contagem só de vivos exige teste posterior.

Espadachim, Canalizador, Tecelão e Autômato são campos de catálogo iniciais; apenas o primeiro e Lutador estão firmemente vinculados à decisão do Kael. PROPOSTA V1 para testes futuros: Espadachim favorece dano em alvo único; Canalizador, técnicas; Tecelão, sustentação; Autômato, resistência. Não publicar valores desses grupos como aprovados.

Equipes mistas devem completar o Ato I sem personagens de três grupos. Avaliar composições de cinco Lutadores contra a equipe gratuita e composições híbridas. A dupla ou tripla afiliação precisa de contrapartidas de kit ou estatísticas, e nunca de pagamento obrigatório.

## 14 Níveis estrelas e evolução

Nível representa investimento em XP; estrela define o limite de nível. Evolução de caminho muda identidade e kit em marcos narrativos. Raridade é outra dimensão e ainda não tem tabela final. Não usar esses três sistemas como sinônimos.

| Estrelas | Nível máximo | Condição para próxima estrela |
| --- | --- | --- |
| 1 | 20 | Nível 20 e uma cópia ou equivalente |
| 2 | 30 | Nível 30 e uma cópia ou equivalente |
| 3 | 40 | Nível 40 e uma cópia ou equivalente |
| 4 | 50 | Nível 50 e uma cópia ou equivalente |
| 5 | 60 | Nível 60 e uma cópia ou equivalente |
| 6 | 70 | Limite do Ato I |

Uma cópia permite avançar uma estrela, mas não remove o requisito de nível. Se o personagem ainda não alcançou o limite atual, a cópia fica guardada. Não consumir antecipadamente nem elevar automaticamente ao receber um duplicado.

Após a fada, Kael, Savor, Aelia e Brakk ficam em 3 estrelas. Lyra entra com uma e usa o Coringa para duas. PROPOSTA V1: o tutorial possui uma concessão única que ignora somente o requisito de nível dessa promoção de Lyra; o jogo explica a exceção e registra uma flag. Alternativa ainda possível: conceder XP suficiente antes da promoção. O laboratório começa depois desse tutorial.

Personagens em 6 estrelas transformam cópias excedentes em Coringas. A taxa final é PENDENTE. PROPOSTA V1 de laboratório: uma cópia excedente gera um Coringa e um Coringa substitui uma cópia na promoção. O valor fica em configuração para testar outras relações sem alterar salvamentos.

Fragmentos de chefe formam uma cópia equivalente; dez fragmentos por reconstrução é PROPOSTA V1. A primeira cópia desbloqueia a unidade em uma estrela; as seguintes permitem promoção, respeitando nível. O farm não tem limite artificial de horas, mas as estrelas nunca dispensam XP.

Alguns personagens poderão evoluir até três vezes em níveis distintos, mas somente a bifurcação do Kael aos 30 está definida. Acima de 6 estrelas ou do nível 70 requer desenho do Ato II; não extrapolar a curva como fato.

## 15 Economia e recrutamento

Recursos centrais: Gold, garrafas de XP, materiais de facção, fragmentos específicos e Coringas. Equipamentos e seu recurso de obtenção entram depois do Ato I. Evitar dezenas de moedas com funções redundantes.

DEFINIDO: uma invocação custa 1.000 Gold; dez custam 9.000. O primeiro recrutamento narrativo garante Lyra gratuitamente. Bosses recrutáveis por treinamento nunca participam do gacha principal. Compras cosméticas não alteram probabilidades ou atributos.

O pool permanente inicial proposto contém Savor, Kael, Aelia, Brakk e Lyra. Raizen participa do prólogo e seu recrutamento posterior precisa de decisão narrativa. Raridades, pesos, pity e banners especiais são PENDENTES. O protótipo usa cinco pesos iguais, informa 20% por personagem e não simula raridades inexistentes.

Uma invocação deve validar saldo, descontar uma única vez e conceder resultados de forma atômica. Cada resultado ou desbloqueia uma unidade, ou acrescenta uma cópia, ou converte o excesso de 6 estrelas. O lote de dez não pode gerar cobrança parcial silenciosa. A mesma ação não é repetida ao carregar o save.

### Fontes e gastos

| Recurso | Fontes | Gastos |
| --- | --- | --- |
| Gold | Campanha, treino, idle, futuras missões | Invocação e futuros serviços |
| XP engarrafado | Treino e idle | Nível escolhido pelo jogador |
| Fragmento de chefe | Vitória no treino elegível | Reconstrução e cópias |
| Fragmento de protagonista | Recompensa de chefe inicial | Cópias da equipe gratuita |
| Coringa | Tutorial e excedentes em 6 estrelas | Substituir cópia |
| Material de facção | Idle e encontros futuros | Uso final pendente |

A decisão original de um fragmento garantido de protagonista no primeiro chefe recrutável é preservada. PROPOSTA V1: cada vitória de Varkhan no treino dá um fragmento dele e um de um protagonista permanente sorteado. Dez completam uma cópia. Chance de fragmento extra ainda não definida; não substituir garantia por chance sem aprovação.

Curvas de XP, Gold por minuto, recompensas de fase e taxas raras exigem simulação. Medir tempo até primeira invocação paga, primeira reconstrução, 4 estrelas e conclusão do ato. Nenhum desses tempos tem meta aprovada ainda.

## 16 Sala de Treinamento e idle

Treinamento possui registros de inimigos e uma aba específica de chefes recrutáveis. O registro preserva o nível encontrado; um inimigo do nível 7 não sobe junto com a equipe. Ganhos menores tornam avanço atraente sem proibir grind.

O chefe só aparece após vitória legítima na campanha e cumprimento das condições narrativas. Solarius exige conclusão do Ato I. A campanha não oferece botão de repetir o chefe. Uma simulação nunca libera um registro ainda não vencido.

DEFINIDO: Auto joga o encontro de verdade, com duas ondas e chefe na terceira; Simular entrega o resultado instantaneamente com custo. O recurso desse custo é PENDENTE. PROPOSTA V1: tickets de simulação conquistados jogando, com primeira vitória manual ou automática registrada antes de permitir simular. Auto pode repetir enquanto o jogador desejar; deve haver botão de parar e relatório de ganhos.

Derrota não concede fragmentos de vitória nem desbloqueios. A UI deve explicar que Auto pode perder, enquanto Simular é uma conveniência sobre encontro já dominado. Não cobrar dinheiro para manter o progresso principal viável.

### Acúmulo offline

O menu principal apresenta uma pequena luta decorativa e um baú. O rendimento depende da última área concluída, não de uma fase apenas visitada. O baú acumula Gold e garrafas de XP sem limite de horas; materiais de facção ocasionais permanecem planejados.

PROPOSTA V1: contabilizar intervalos completos por timestamp UTC e preservar frações de tempo. Antes de mudar a taxa por avanço, liquidar o intervalo anterior com a taxa antiga. Isso impede que dias passados na área 7 sejam pagos retroativamente como área 70.

Se o relógio voltar, o intervalo negativo concede zero e não desloca o marco para trás. Como o jogo é offline, edição de relógio e save não será tratada como segurança competitiva. Prevenir overflow e corrupção continua necessário. “Infinito” significa sem teto de tempo de design, sujeito aos limites técnicos de armazenamento.

O protótipo entrega a contabilidade de Gold/XP e coleta local. Animação de idle, materiais ocasionais, missões e fila de repetição com três ondas ficam como expansão explicitamente documentada.

## 17 Equipamentos após o Ato I

DEFINIDO: o primeiro ato se resolve com personagens, níveis, estrelas, habilidades e composição. “Totalmente equipado” na preparação para Solarius significa desenvolvido, não equipado com um sistema que ainda não foi liberado.

Após o ato surgem Arma, Roupa, Botas, Luvas, Amuleto e Anel. O banner ou sistema Arsenal é separado do recrutamento de personagens e usa recursos conquistados em chefes posteriores. A frase anterior “a cada 10 bosses” é ambígua: confirmar se significa cada décima fase ou dez chefes completos; não codificar essa cadência ainda.

Armas respeitam arquétipos. Kael Espadachim usa espadas; o caminho marcial utiliza manoplas, faixas ou itens marciais. Slots universais continuam possíveis. Se uma evolução tornar um item incompatível, devolver ao inventário, nunca destruir ou vender automaticamente.

| Slot | Atributos exemplares | Observação |
| --- | --- | --- |
| Espada | Força e chance crítica | Espadachim |
| Manopla | Força e atributos marciais | Lutador |
| Roupa | Defesa e Desvio | Compatibilidade configurável |
| Botas | Velocidade | Valores pendentes |
| Luvas | Velocidade e Desvio | Valores pendentes |
| Amuleto e Anel | Variações de atributos | Valores pendentes |

Lendários ficam acima de S e podem conceder habilidade adicional. Nomenclatura da raridade e probabilidades finais são PENDENTES. Exemplos de trabalho: críticos aplicam Sangramento; execução de inimigos comuns sob limiar de HP. A execução instantânea nunca funciona em chefes.

Cortadora Carmesim e Lâmina do Carrasco são propostas de itens, não catálogo aprovado. Os números antigos de mais 240 Força, 12 pontos de crítico e Sangramento de 40% por dois turnos são referências para teste, não metas de poder do lançamento.

Equipamentos comuns não exigem redesenhar o sprite. Um lendário pode adicionar aura laranja nos pés. A aura vermelha do VIII estágio deve continuar distinguível por forma e localização, sem depender apenas da cor. O protótipo contém o modelo e validação de compatibilidade; drops, banner e efeitos de equipamento não estão completos.

## 18 Arte interface e áudio

Direção: pixel art legível, personagens com silhuetas próprias e efeitos econômicos. PROPOSTA V1: sprites em grade 64 por 64, com espaço extra para efeitos e formas ampliadas; não esticar o mesmo desenho para representar o ápice de Kael. Animações previstas: idle, ataque, habilidades, impacto e queda.

Estágios de Kael precisam de leitura progressiva. PROPOSTA V1 de cores: I e II tom âmbar discreto, III e IV dourado, V e VI branco quente, VII carmim e VIII vermelho intenso. Somente o vermelho final e o aumento muscular estão definidos; a paleta intermediária é ajustável. O contador em algarismos romanos comunica o estágio mesmo sem perceber a cor.

Savor usa linguagem de cozinha de campanha; Aelia, fios vitais; Brakk, construção industrial própria; Lyra, padrões de gelo autorais; Varkhan, energia perfurante de geometria própria; Solarius, símbolos solares e traje próprios. Raizen precisa de uma linguagem ocular e manifestação distintas das referências internas.

Fluxos de UI: campanha, formação, coleção, detalhes do personagem, recrutamento, Zona de Treinamento, baú idle e opções. Antes de liberar um sistema, mostrar somente o necessário ao tutorial. Exibir chances do banner, custo, condições de estrela, fragmentos acumulados e por que um botão está indisponível.

Controles previstos para PC: mouse para selecionar e confirmar, teclado para navegação e atalhos, Esc para pausar/fechar, indicador de foco. No laboratório, botões explícitos avançam rodada, alternam auto, invocam, treinam e coletam. A interface definitiva ainda será produzida.

Acessibilidade: texto escalável, ícones junto das cores, controle de volume separado, redução de flashes, opção de velocidade de combate e log dos eventos. A cena de Sol Esmagador não deve exigir flash branco intenso para funcionar.

Referências a Sanji, Levi, Orihime, Franky, Sasuke, Rukia, Piccolo, Might Guy e Toji ficam apenas no material interno de pesquisa. Produto comercial exige nomes, sprites, história visual, animações e habilidades apresentados de forma original. Nenhum asset dessas obras integra o protótipo. Revisão de identidade e cadeia de direitos é tarefa futura de publicação, sem afirmação de liberação jurídica nesta V1.

## 19 Arquitetura e recorte técnico

Base escolhida para reprodução do protótipo: Godot 4.4.1 .NET e C# em .NET 8. A versão é fixada para compatibilidade, sem alegação de ser a mais recente. Dados ficam em JSON; o núcleo de regras não depende do Godot e pode ser testado por console.

| Modelo | Responsabilidade |
| --- | --- |
| Character | Identidade, atributos, função, arquétipos e skills |
| Skill | Escala, multiplicador, alvos, cooldown e operador |
| StatusEffect | Definição de cargas, duração e categoria |
| Enemy | Referência de combatente e nível do encontro |
| Stage | Fase, inimigos, recompensa e próximo marco |
| Boss | Elegibilidade, fragmento e condição de desbloqueio |
| Equipment | Slot, compatibilidade e atributos |
| Inventory | Moedas, XP, cópias e fragmentos |
| Faction e Archetype | Pertencimento e patamares de sinergia |
| Summon | Pool, pesos, custo e concessão de duplicados |

Separar definições imutáveis de instâncias em batalha e estado salvo. O catálogo não armazena HP atual de uma luta. Eventos de combate alimentam o log e futuramente animações; a apresentação não decide recompensa.

Serviços: combate, campanha, treinamento, recrutamento, progressão, idle e persistência. Identificadores estáveis conectam arquivos; nomes traduzidos não são chaves. Validar referências, limites de arquétipos, pesos positivos e exclusão de chefes do banner ao carregar.

Persistência local com versão de schema, arquivo temporário e substituição atômica, cópia de segurança e tratamento explícito de JSON inválido. Salvamento não deve avançar campanha após derrota. RNG com semente injetável permite reproduzir casos de teste.

A fatia inicial usa arte geométrica e texto, dados de laboratório e habilidades selecionadas. O GDD descreve o destino; o README do protótipo informa exatamente o que funciona. Não confundir o catálogo de todos os kits com implementação integral de cada interação.

Fontes técnicas: documentação C# do Godot 4.4 em https://docs.godotengine.org/en/4.4/tutorials/scripting/c_sharp/c_sharp_basics.html e versão fixada em https://godotengine.org/download/archive/4.4.1-stable/. Links de download e comandos completos acompanham o projeto.

## 20 Roadmap e critérios de aceite

### M0 Base executável

Carregar catálogo, abrir uma cena local, executar combate de teste, conceder recompensa uma vez, salvar e reabrir. Testes do núcleo cobrem o golpe em cadeia, estágios do Kael, exclusão de chefes do gacha, limites de estrelas, sinergias, campanha e idle. Entrega: projeto importável e instruções.

### M1 Fatia de combate

Formação editável de cinco unidades em três camadas, seleção manual de alvos, Auto, kits completos de Savor, Kael base, Aelia, Brakk e Lyra, estados e log. Aceite: repetir o mesmo combate por semente e explicar cada dano e controle. Varkhan demonstra a cadeia com mitigação real.

### M2 Progressão jogável

Tutorial da fada e Lyra, curva de XP, promoção com cópia/Coringa, recrutamento com chances visíveis, fragmentos e treinamento de três ondas. Aceite: equipe gratuita progride sem compra; derrota não concede recompensa; chefes vencidos saem da campanha e entram apenas no treino elegível.

### M3 Ato I

Prólogo e 70 fases, conteúdo dos chefes pendentes, diálogo e cenas, bifurcação completa e conclusão de Solarius. Aceite: cena marcial ocorre no nível 70; caminho Arsenal tem final aprovado; nenhuma escolha torna a campanha impossível.

### M4 Arte e experiência

Sprites originais, animações, interface final, som, localização, acessibilidade, salvamento robusto e ajustes por sessões de teste. Aceite: linguagem visual própria e leitura dos estados sem depender somente de cor.

### M5 Pós ato e publicação

Equipamentos, drop/Arsenal, lendários, expansões de elenco e integração de distribuição. Investigar nome e marcas, licenças de assets, requisitos atuais da Steam e modelo de cosméticos somente nesta etapa. Não há data de lançamento ou estimativa de custo aprovada.

Não implementar simultaneamente dezenas de heróis antes de validar a equipe inicial. Cada novo operador de habilidade exige exemplo reproduzível e teste de interação; cada conteúdo só numérico deve ser adicionado pelos dados.

## 21 Pendências e registro de decisões

### Resolver antes da campanha completa

1. Aprovar final equivalente do Arsenal Vivo e destino de Kael após o custo extremo.
2. Confirmar se prólogo tem dez encontros separados das fases 1 a 70.
3. Nomear e escrever chefes 10, 30, 40, 50 e 60; decidir o recrutável 50.
4. Resolver filho do governador, identidade da fada e expansão da ameaça de Raizen.
5. Finalizar kit Arsenal Vivo e kit recrutado de Solarius; definir evolução de Lyra.
6. Confirmar exceção de estrela de Lyra ou concessão prévia de XP.

### Resolver por balanceamento e produção

Pool de Raizen, raridades, pity, taxa de Coringa, fragmentos por cópia, custo de simulação, curvas de XP e Gold, valores de atributos, defesas, ordem de efeitos e interação de redirecionamento. Aprovar facções além de Lutador/Espadachim e seus bônus. Definir troca de evolução e progressão acima do nível 70.

### Decisões antigas substituídas

- Nível 80 para o extremo do Kael foi substituído por 70.
- Morte definitiva de Solarius foi substituída por derrota, misericórdia e conversa.
- Repetição de chefe na campanha foi substituída por treino após desbloqueio.
- Todos os chefes recrutáveis foi substituído por seleção explícita de elegíveis.
- Piccolo como tanque inicial foi descartado; Brakk ocupa a função. Varkhan é um personagem original com outro papel.
- Combo marcial inspirado em adaptação foi substituído pelos oito estágios aprovados.
- Equipamentos no começo foram adiados para depois do Ato I.
- Facções baseadas somente em funções foram separadas dos arquétipos de sinergia.
- Réplicas diretas de anime foram substituídas pela exigência de identidades comerciais originais.

Fonte de decisões: conversa “Criar jogo gacha pixelado” e instruções finais de consolidação de 01 de outubro de 2026. Propostas técnicas deste documento são identificadas para não se tornarem cânone por acidente. A próxima versão deve registrar mudanças por seção e manter compatibilidade dos dados quando possível.

## 22 Naming e identidade futura

Project Vaelorn é um codinome neutro de produção. Não é o título comercial decidido. As opções abaixo foram solicitadas para avaliação de tom e conexão com a história; nenhuma teve disponibilidade ou marca verificada.

| Opção | Conexão com a proposta |
| --- | --- |
| Vaelorn Fractured Worlds | Lugar de origem e dimensões fragmentadas |
| Shards Beyond | Fragmentos e o que existe além da ruptura |
| Riftbound | Personagens ligados à fenda |
| Echoes of Vaelorn | Ecos, memória e reconstrução |
| Worldshard | Mundo e coleção de fragmentos |
| Ashes Beyond the Rift | Perda, cinzas e travessia dimensional |
| Fragments of the Fallen | Aliados reconstruídos após a queda |
| Riftborn Chronicles | Jornada episódica nascida da ruptura |

O título “Vaelorn: Fractured Worlds” pode manter dois-pontos na marca candidata. A grafia simplificada da tabela não altera a opção solicitada.

Avaliar futuramente clareza de pronúncia em português e inglês, força visual do logotipo, facilidade de busca, adequação ao tom e possibilidade de expansão por atos. Depois realizar busca de títulos existentes, domínios e marcas nos mercados pretendidos, com revisão apropriada. Esta V1 não afirma exclusividade, disponibilidade ou registrabilidade de nenhuma opção.

O nome definitivo deve ser escolhido junto da identidade visual original. A capa, os arquivos e o protótipo permanecem como Project Vaelorn até essa decisão.


## V25 — Varkas, A Fera de Duas Almas

Personagem provisório, original visual e narrativamente. As referências internas Lycan e Kiba/Akamaru descrevem somente a fantasia de fera e cooperação; não integram a identidade final do produto. Atributo principal: Força. Arquétipos: Lutador / Predador. Função: DPS de alvo único e Sangramento. Aparência: humanoide lupino com crina cinza-clara, pele acobreada, chifres curtos de obsidiana, ombreira de bronze assimétrica, vestes índigo e um selo turquesa partido no peito.

### História proposta
Varkas vigiava os desfiladeiros onde a névoa repetia as vozes dos desaparecidos. Ao resgatar uma caravana de uma ruptura, sua alma se dividiu entre carne e espírito. Aprendeu a reunir as duas metades, mas a separação cobra sua resistência. Agora procura os rastros de Nhal’Zor para descobrir se as vozes ainda podem ser salvas. Esta expansão narrativa é provisória.

### Kit V1
- Rasgar: 100% da Força, um alvo, sem recarga. Pode ativar Feridas Abertas.
- Feridas Abertas: passiva ativa. Cada impacto direto bem-sucedido tem 40% de chance de aplicar uma carga de Sangramento.
- Dualidade Feral: recarga 6; exige ao menos 70% de vida e permite uma utilização por batalha. Corpo recebe 60% da vida atual; Espírito recebe 40%. Seus limites de vida também são proporcionais para evitar cura acima do total original. As formas são alvos separados, mas compartilham um proprietário, buffs, facções, progressão e vaga da equipe. O Espírito não recebe um turno extra: repete as ações ofensivas do Corpo com 60% do dano e 100% da capacidade de aplicar status. Quando qualquer forma morre, a outra deixa de existir separadamente e Varkas retorna imediatamente com 30% da vida máxima original.
- Presas do Vendaval: recarga 4. Cinco impactos, cada um com 55% da Força, escolhendo um inimigo vivo aleatório por impacto. Chance-base de Sangramento multiplicada por 1,5: 40% vira 60%. Em Dualidade, o Espírito realiza outros cinco impactos aleatórios com 60% do dano.
- Marcado para Morrer: recarga 4. Um alvo, 180% da Força, multiplicado por 1 + 0,10 por carga de Sangramento. Zero cargas: 180%; cinco: 270%; dez: 360%. Não consome cargas. A quantidade de cargas é capturada no começo da ação para manter o mesmo multiplicador na cópia do Espírito.
- Dilacerar: recarga 5. 250% da Força; na Dualidade, Corpo 250% e Espírito 150%. Aplica Ferida Exposta por dois turnos da vítima. Desbloqueio provisório no nível 30, configurável; o nível definitivo ainda precisa de balanceamento.

Combo pretendido: Dualidade Feral, Dilacerar, Presas do Vendaval, acumulação de Sangramento e Marcado para Morrer. Varkas prepara uma presa durante várias ações; não deve competir com Kael somente por dano imediato.

## V25 — Status e formas vinculadas reutilizáveis

### Sangramento
Cada carga causa dano direto de status igual a 15% da Força de origem no início do turno da vítima, durante três turnos, com duração independente e limite total de dez cargas. Funciona em chefes; não usa teste de crítico ou defesa. A Força é capturada quando a carga é aplicada, antes de qualquer redução de dano da cópia espiritual. Mudanças posteriores nos atributos do aplicador não alteram cargas existentes. Ao atingir o limite, novas cargas são recusadas sem renovar as anteriores.

Cada carga armazena: definição do efeito, identificador único da instância aplicadora, ID do personagem, Força capturada e turnos restantes. Dois Varkas são origens diferentes. A morte do aplicador não remove automaticamente suas cargas.

### Ferida Exposta
Dura dois turnos da vítima, não acumula consigo mesma e uma reaplicação renova a duração. Aumenta em 25 pontos percentuais a chance de receber Sangramento: 40% vira 65%; 60% vira 85%. Aplica-se após o impacto de Dilacerar, beneficiando os impactos subsequentes, inclusive a cópia espiritual.

### Regras de integração
O Corpo e o Espírito têm listas próprias de status prejudiciais e recebem os respectivos danos periódicos no início da oportunidade do proprietário. Atordoamento ou congelamento do Espírito pode impedir sua cópia, sem conceder um turno independente. Buffs positivos pertencem ao personagem e são compartilhados sem aplicação duplicada. Ao recompor, efeitos prejudiciais restantes do Espírito são transferidos para o proprietário, respeitando limites e sem renovar duração. A recomposição não cria uma nova oportunidade de usar Dualidade.

Os parâmetros de chances, duração, limites, percentuais de HP, cópia, recargas e nível mínimo ficam no catálogo. A implementação usa StatusStack para instâncias independentes e LinkedForm para formas vinculadas; a mecânica não depende do nome Varkas.

## V25 — Apresentação, acesso e pendências

Varkas tem ficha, arte original de poses, cinco ícones próprios e uma batalha de teste acessível por “Varkas • teste”. Seu recrutamento, sua raridade e sua presença em banners ainda não foram definidos; ele não foi inserido silenciosamente no gacha ou no salvamento do jogador. Predador está cadastrado, mas seu bônus de sinergia permanece pendente.

No combate, a interface passa a usar contraste roxo, níveis maiores e texto de habilidades ampliado. O retorno após o choque inicial recebe mortal, aterrissagem e recuperação. A mudança de estágio de Kael recebe aura ascendente e som original de evolução. Essa apresentação não concede níveis ou experiência extras. A vitória comum mantém o campo; a seta de avanço faz o grupo correr à direita antes da próxima fase. O botão Voltar abre o mapa da região. Chefes continuam usando suas revelações narrativas.

Os banners do menu continuam sendo ilustrações animadas por movimento procedural. A tipografia recebe ornamentos orgânicos de tentáculos; não é uma nova família completa de glifos desenhados à mão. Animações exclusivas de retorno para cada personagem, encenação completa dos chefes e ajustes finais de arte permanecem em desenvolvimento. Todos os valores de Varkas são V1.
