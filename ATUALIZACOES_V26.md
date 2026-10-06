# Reality Of Enigma — V26

## Menu e identidade
Seis cenas originais independentes de 1536×1024 substituem os pequenos recortes ampliados da V25. Incluem Kael, Savor, Aelia, Brakk, Lyra e Raizen, com paisagem contínua atrás das opções. O recorte mantém proporções e a filtragem é linear.

Opções com letras mais encorpadas, sem sublinhados e sem os tentáculos procedurais antigos. Uma espada ilustrada acompanha o foco do mouse/teclado. O contador de ato/fases foi removido do início; Gold aparece no alto, com bolsa de moedas original. A tipografia é uma variação encorpada de Cinzel; a logo continua sendo uma ilustração, não uma fonte idêntica para todo o alfabeto.

## Combate
- Retrato de quem age acima das habilidades, substituindo a frase “Vez de...”. A descrição continua aparecendo ao consultar uma habilidade ou passiva.
- Espada violeta indica o combatente ativo; espada rubra indica alvo ofensivo. Cura e suporte usam um símbolo verde diferente. Buffs de equipe destacam todos os aliados aplicáveis.
- O nome selecionado recebe fundo escuro e cor violeta/verde. Vida e nível usam placas menores, discretas, de borda chanfrada.
- Buffs usam símbolos minimalistas de bota, punho e escudo. Detalhes aparecem somente sobre o ícone e omitem parcelas zeradas. O campo inteiro não abre mais o tooltip de bônus do personagem selecionado.

## Animação de retorno
80 desenhos novos: oito poses para Kael, Savor, Aelia, Brakk, Raizen, Lyra, Varkhan, Varkas, Solarius e a criatura da floresta. Preparação, impulso, recolhimento do corpo, inversão, descida, pouso e recuperação são desenhos distintos. A criatura recua com um salto quadrúpede. A rotação integral de 360 graus foi retirada.

As poses acompanham uma trajetória interpolada; ainda são oito desenhos, não animação comercial a 24 quadros únicos por segundo. A evolução marcial de Kael mantém o modelo anterior, sem giro integral; estas poses correspondem à sua aparência base. A corrida existente continua sendo utilizada na aproximação e saída do campo.

## Vitória e navegação
Emblema original de tentáculos e espadas sobre o campo. Sem faixa horizontal nem caixa “Caminho livre”. À direita, espada-seta animada com “Próxima fase”; no alto à esquerda, “Voltar”. Avançar mantém a corrida para fora do campo e inicia o encontro seguinte. O encerramento narrativo dos chefes permanece separado.

## Som
Efeitos PCM sintetizados originais, sem amostras de jogos comerciais. Passos distinguem calçado leve, couro, metal e garras. Ataques usam transientes e ressonâncias de lâmina, chute, impacto pesado, gelo, essência, fogo, cura e fera. O catálogo Data/audio.json define o perfil por personagem e exceções por habilidade. Os impactos respeitam o instante visual de cada golpe, inclusive a sequência de Lança do Horizonte. O volume geral das configurações controla todos os efeitos.

## Verificação
174 verificações de regras aprovadas. Testes do executável cobrem menu, bolsa, marcadores ofensivos/suporte, consulta de passiva, ausência de bônus zerados, oito fases da animação, disparo de sons, vitória com controles laterais, avanço de fase, Varkas e regressões anteriores de combate. As capturas e partidas de teste usam progresso isolado.

## Arquivos
Godot/Art/PROMPTS_V26.md registra os prompts completos e os dezessete ativos gerados pela ferramenta image_gen integrada. Os novos desenhos estão em Godot/Art; definições de quadros em Data/animations.json. Os números e regras do Varkas permanecem os da V25. GDD_V25.md preserva o documento de design anterior; esta nota registra a atualização de apresentação.
