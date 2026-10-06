# Arena V6 — poderes

Nova folha de efeitos com transparência: corte, gelo, fogo, cura, essência e impacto marcial. Texturas combinadas com trajetórias, partículas, crescimento e dissipação.

- Kael: cortes alternados em sequência, segundo a quantidade de golpes.
- Lyra: estilhaço em trajetória, chuva, cristais da prisão e efeito ampliado do reino.
- Aelia: fio luminoso, selo de cura e partículas douradas/lilás.
- Varkhan: feixe contínuo pela linha e impactos nos três alvos.
- Savor: fogo e brasas. Brakk: impacto e onda no chão.
- Kael marcial, Solarius e Raizen: impactos temáticos; artes de personagem ainda provisórias.

Janela visual de 1,65 s, impacto em 0,65 s e automático a cada 1,85 s. Os cálculos de combate continuam imediatos internamente, e o valor de HP desenhado é atrasado até o impacto. Não houve rebalanceamento. Ainda faltam áudio e animações corporais específicas dos demais personagens.

## Verificação
Build sem avisos/erros. Executável Windows testado: linha temporal, menus, Lyra manual, três ondas, recompensa única e parada do farm. Testes adicionais de cura e dano nos três alvos da Lança do Horizonte. Capturas de quatro efeitos revisadas. Log final sem erros de renderização.

## Arte
Gerada com a ferramenta integrada image_gen. Arquivo Godot/Art/skill-effects-v6.png; prompt em Godot/Art/PROMPTS_V6.md.
