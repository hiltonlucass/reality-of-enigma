# V14 — contato com o chão e gelo delicado

- Removidos deslocamento vertical, rotação e escala global da respiração. Os 28% inferiores do sprite ficam imóveis no repouso; o movimento suave fica no tronco e cabeça.
- Atordoamento conserva a pose curvada e o balanço da parte superior, sem deslocar os pés.
- Sombras de contato mais escuras, com bordas suaves e pequenos núcleos sob os pés. O círculo de seleção não preenche mais a sombra com cor.
- Congelamento mantém a coloração azul e a imobilidade. Removidos bloco poligonal e grandes cristais sobrepostos. Pequenos fragmentos translúcidos se desprendem ao longo do corpo, caem lentamente e desaparecem; alguns têm um brilho breve.
- Estilhaçamento na derrota e golpe de fileira mantidos.

Extraia todo o ZIP Windows e abra ProjectVaelorn.exe. Use a Batalha de demonstração para observar o repouso e o congelamento. A formação 3×3 e as regras de combate permanecem as mesmas.

O repouso continua procedural sobre os sprites existentes. Corrida, recuo de impactos e ataques ainda podem levantar os pés intencionalmente; o bloqueio de movimento vale para repouso e congelamento.

Validação: executável Windows encerrou os testes com código 0 e sem erros. Verificados bloqueio da deformação nos pés, pose congelada sob impacto, controles, formação, buffs, golpes em fileira e estilhaçamento. Captura revisada visualmente.
