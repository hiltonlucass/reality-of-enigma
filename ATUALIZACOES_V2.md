# Arena visual V2

Esta entrega continua o protótipo V1 no mesmo projeto e preserva seu nome interno para manter o caminho do save.

## Como experimentar

Importe Godot/project.godot, compile e execute. A primeira tela já abre a Arena de efeitos, uma simulação 5 contra 5 sem recompensas. Kael usa um sprite isolado novo; os demais personagens usam os conceitos aprovados em retratos. Os Ecos da Fenda são representações geométricas provisórias.

Clique em um combatente para selecioná-lo. Os três botões de teste aplicam stun, uma carga de gelo ou cinco cargas. Esses botões só funcionam na Arena de efeitos. Clique em Próxima ação para acompanhar o combate ou em Auto / parar para reproduzir. Esc pausa o Auto. O alvo selecionado nesta versão serve à inspeção e aos testes de controle; a inteligência automática ainda escolhe os alvos dos ataques.

Ataques têm um movimento curto, dano mostra número e impacto, cura mostra número verde, repouso tem movimento sutil, e unidades derrotadas ficam esmaecidas. Isso é animação procedural de protótipo, não uma sequência desenhada de quadros. Kael possui uma única imagem de repouso; ataques/habilidades/queda desenhados quadro a quadro ainda não foram produzidos.

## Regras dos controles

- Stun impede uma oportunidade de agir. Reaplicações renovam para a maior duração, não somam. A definição Skill aceita o campo Stun para habilidades futuras. Nenhum kit aprovado foi alterado para ganhar stun sem uma decisão de design; os botões da arena permitem validar a mecânica agora.
- Stun e congelamento simultâneos consomem a mesma oportunidade, sem duplicar a punição.
- Gelo acumula até cinco cargas com menos 3% de velocidade por carga. No limiar, congela por uma oportunidade e limpa as cargas.
- Após o congelamento, a imunidade dura duas oportunidades completas do alvo. O contador não é reduzido no próprio turno em que nasce.
- Chefes convertem gelo em menos 15% de velocidade por duas oportunidades. A janela de imunidade evita reaplicação imediata.
- Chefes são imunes a stun por padrão PROVISÓRIO. O construtor de Unit aceita stunImmune para sobrescrever essa regra. A decisão final de resistência ainda está pendente.
- Personagens mortos rejeitam os controles. Estágio VIII do Kael mantém a proteção inicial contra gelo/Slow no laboratório.

Ícones: estrelas amarelas orbitam o alvo com stun; cristal azul envolve o congelado; pequenos flocos mostram as cargas de gelo. A legenda e o painel de inspeção exibem números, para não depender somente de cor.

## Validação

69 verificações automatizadas aprovadas: as 51 anteriores e 18 novas sobre controles, imunidade, configuração de stun por habilidade e equivalência entre avanço por ação e rodada inteira. Compilação sem avisos ou erros. A arena foi executada no Godot 4.4.1 .NET e percorreu 30 ações sem erros no log.

## Próximos passos

Produzir os quadros de ataque e habilidade de Kael; substituir os retratos por sprites isolados dos outros quatro aliados; implementar seleção manual de habilidade e alvo; completar kits e três ondas do treinamento. O GDD V1 permanece como referência de design, com esta nota documentando o avanço técnico.
