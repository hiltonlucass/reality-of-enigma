# V13 — repouso contínuo, ataques em área e estados

## Mudanças
- Repouso com deformação contínua em 24 faixas da arte: respiração do tronco, pequeno balanço dos ombros/cabeça e movimento secundário. Substitui a troca brusca entre duas poses. Preserva roupas aprovadas e panela apenas nos buffs de Savor.
- Golpes com operador de fileira deixam um rastro sísmico dourado entre as três posições, incluindo casas vazias. O rastro acompanha a camada realmente atingida; os impactos individuais continuam sincronizados com o dano.
- Congelados ficam azuis, sem respiração, corrida, inclinação ou recuo de dano; apenas os cristais externos brilham.
- Derrota durante congelamento gera explosão de fragmentos com queda e resíduos no chão. Aliados e personagens protegidos pela história reaparecem caídos após a quebra do gelo, preservando sua participação na narrativa. Inimigos comuns ficam em fragmentos.
- Atordoamento usa pose curvada, balanço lateral e inclinação próprios, além das estrelas.

## Como jogar
Extraia TODO o ZIP e abra ProjectVaelorn.exe. Não precisa instalar Godot ou .NET. Use Batalha de demonstração, organize os personagens nas nove casas e clique Iniciar combate. Brakk usa Impacto Sísmico para atingir a fileira escolhida. Lyra acumula gelo para congelar inimigos comuns; chefes mantêm sua resistência prevista nas regras. Controles existentes expiram conforme os turnos.

## Validação
136 verificações das regras aprovadas. Executável Windows rodou a sequência de testes com saída 0, sem mensagens de erro. Inclui formação, corrida, buffs, campanha/treinamento, três alvos atingidos pelo golpe de fileira, bloqueio da pose congelada mesmo com impacto e derrota congelada. Capturas de controles, fileira e estilhaçamento revisadas.

## Escopo artístico
O repouso é uma animação procedural sobre os sprites existentes, não novos quadros desenhados à mão. Continua sendo um protótipo por turnos. Kael marcial conserva o desenho procedural anterior. Os novos efeitos não alteram dano, imunidades, duração de controles ou economia.
