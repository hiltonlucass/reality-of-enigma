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
