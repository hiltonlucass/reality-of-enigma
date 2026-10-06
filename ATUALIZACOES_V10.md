# Arena V10 — animações por quadros

## Implementado
84 desenhos em sete folhas de 12 quadros: Kael base/Arsenal, Savor, Aelia, Lyra, Brakk, Varkhan e inimigos que reutilizam o Predador da Fenda.

Cada folha contém repouso, preparação, ataque/conjuração, recuperação, reação a dano e queda. O impacto visual coincide com o início do dano; o estado caído mantém o último desenho. Escala constante por personagem e ancoragem nos pés. Os recortes estão no manifesto Godot/Data/animations.json. O controlador de quadros está separado dos efeitos e das regras de combate.

Congelamento e stun param o repouso. Reações a novos golpes têm prioridade durante o impacto. Turnos, cores dos danos, buffs, recompensas e treinamento foram preservados.

## Limites desta versão
Solarius, Raizen e Kael marcial ainda usam a apresentação anterior. As habilidades de um mesmo personagem compartilham a sequência corporal, enquanto os efeitos de poderes continuam específicos. São sequências curtas, ainda precisam de quadros intermediários e polimento artístico para acabamento comercial. O conjunto não inclui corrida completa, áudio ou combate em tempo real.

## Validação
Compilação sem avisos ou erros. Testes no executável verificaram a sequência de quadros, o impacto, reação, queda final e bloqueio do repouso por controles. Capturas revisadas de combate e derrota. Testes anteriores de menus, cura, linha de três camadas, treinamento de três ondas e recompensa única continuam aprovados. O teste usa save em memória.

## Jogar
Extraia todo o ZIP Windows e abra ProjectVaelorn.exe. Mantenha ProjectVaelorn.pck e a pasta data junto dele. Não precisa instalar Godot ou .NET. Entre em Batalha de demonstração e use Automático para acompanhar as sequências.

## Arte
Geração integrada image_gen, preservando a arte original do projeto. Prompts e referências documentados em Godot/Art/PROMPTS_V10.md. PNGs das folhas em Godot/Art/*-frames-v10.png.
