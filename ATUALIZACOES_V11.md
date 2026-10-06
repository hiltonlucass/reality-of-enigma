# V11 — figurinos e cozinha de suporte

## Revisão visual
Kael e seus quadros permanecem preservados. Savor agora usa conjunto social escuro e camisa clara. Aelia usa roupa leve e cabelo acobreado solto. Lyra usa túnica marcial escura, faixa azul e espada de gelo. Brakk tem rosto e tronco humanos com grandes braços mecânicos. Varkhan usa capa branca e traje marcial violeta. Raizen usa roupa ágil de gola alta; Solarius destaca o porte muscular e a identidade solar com menos armadura.

As referências internas orientam a leitura das silhuetas; nomes, desenhos e detalhes do projeto continuam próprios. Esta revisão substitui as diretrizes visuais anteriores que afastavam excessivamente os figurinos das referências. A mudança visual de Brakk para ciborgue exige harmonização futura de sua biografia; nenhuma regra de combate ou arquétipo foi alterada por essa troca.

## Panela e buffs
A panela aparece apenas durante a animação ativa das habilidades de buff de Savor. Não aparece em repouso, chutes, reação, queda ou retrato. Folhas separadas para corpo a corpo e cozinha; dano/controle/derrota têm prioridade e interrompem a cozinha.

Foram integradas as duas habilidades já descritas no GDD:
- Primeiro Prato: +10% Velocidade para aliados vivos, CD 3, duração 2 rodadas.
- Orgulho do Chef: se Savor tiver a maior Força entre aliados vivos, +50% Força e Essência para todos os vivos; caso contrário, +50% do atributo ofensivo principal ao aliado de maior atributo principal. Empates individuais usam sorteio com a semente da batalha. CD 5, duração 2 rodadas.

A rodada de aplicação conta como a primeira. Reaplicar a mesma habilidade renova/substitui seu bônus, sem multiplicar indefinidamente. Buffs usam ícones azuis e não geram números falsos de dano ou cura. Duração e valores continuam sujeitos a balanceamento.

## Testar
Extraia todo o ZIP Windows e abra ProjectVaelorn.exe. Use Prévia do elenco para ver os sete figurinos revisados juntos, sem recompensas. Use Automático ou avance até a vez de Savor e escolha Primeiro Prato/Orgulho do Chef; não precisa selecionar alvo. Batalha de demonstração continua incluindo Kael.

Não precisa instalar Godot ou .NET. Preserve o .pck e a pasta data ao lado do executável.

## Validação e limites
119 verificações das regras aprovadas; compilação sem avisos/erros. Executável encerrou com código 0 e registro de erros vazio. Conferidas capturas do elenco, da panela durante o buff e de sua ausência após a ação. Congelamento, dano, crítico, cura, derrotas, treinamento e menus continuam passando.

Sequências ainda são curtas e precisam de refinamento artístico. Kael marcial mantém a apresentação anterior. A passiva de Savor e detalhes parciais dos kits não foram completados nesta revisão. GDD PDF V1 é um documento histórico; consulte este adendo para as decisões visuais atuais.

## Arquivos de arte
Godot/Art/*-frames-v11.png; Godot/Data/animations.json; Godot/Art/PROMPTS_V11.md. Arte criada pela ferramenta integrada image_gen a partir das artes originais do projeto. Código-fonte inclui os prompts completos.
