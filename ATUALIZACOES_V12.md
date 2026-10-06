# V12 — formação 3×3 e deslocamento

## Como testar
Extraia todo o ZIP Windows e abra ProjectVaelorn.exe. O encontro começa na preparação. Arraste um aliado para uma das nove casas ou clique nele e depois na casa. Casas ocupadas trocam seus integrantes. Clique em Iniciar combate quando terminar. Depois escolha alvo e habilidade ou use Automático.

A equipe continua com cinco integrantes, distribuídos entre nove casas: três posições laterais × três camadas (Frente, Meio e Fundo). As posições da equipe são salvas para campanha, demonstração e treinamento. A prévia do elenco não sobrescreve essa formação. Não é possível reorganizar após iniciar; as ondas do treinamento preservam a formação. Saves antigos recebem posições padrão, e células inválidas/duplicadas são normalizadas.

## Movimento e animação
Corrigido o deslocamento que só alterava X e descartava Y dos sprites. Ataques físicos agora chegam ao lado do alvo na sua fileira, inclusive no fundo e em trajetórias diagonais longas, e retornam à casa de origem. Não existe mais o limite de 350 pixels que interrompia a aproximação longe do alvo. Sombras e ordem de desenho acompanham o trajeto.

16 quadros novos de corrida, em ciclos de quatro poses para Kael base, Savor, Brakk e predador da fenda. Ida acelera/desacelera suavemente; retorno vira o personagem para a origem. Respiração, balanço, recuo e inclinação são aplicados também às folhas de quadros, corrigindo outra perda de movimento da versão anterior. Golpes múltiplos alternam poses no ritmo dos impactos. Efeitos partem da posição atual do atacante. Magias e buffs permanecem à distância; panela continua exclusiva de buffs.

## Validação
136 verificações das regras aprovadas. Testes adicionais no executável cobrem arraste pela entrada da interface, nove casas, bloqueio antes do primeiro turno, trajetória longa nos dois sentidos, alinhamento e retorno. Capturas de formação, corrida, impacto e retorno revisadas. Sem alteração das regras de dano por fileira/coluna ou da composição máxima de cinco aliados.

## Limites
São ciclos curtos, ainda sujeitos a polimento artístico. Esta versão não entrega animação de estúdio nem corrida nova para todas as formas especiais; Kael marcial mantém o desenho anterior. As trajetórias são diretas com ordenação de profundidade, sem desvio físico de obstáculos/personagens. O combate continua por turnos.

## Fontes
Novas artes geradas pela ferramenta integrada image_gen, com prompts em Godot/Art/PROMPTS_V12.md. Código e manifesto incluídos no ZIP de fontes.
