# Reality Of Enigma — complemento V29

## Fenrath — A Fera de Duas Almas
Novo nome público de Varkas. O identificador interno permanece varkas para preservar saves, fragmentos e referências. Ficha com floresta lunar ilustrada, névoa ciano e ruínas.

Presas do Vendaval mantém cinco ataques aleatórios do Corpo, 55% da Força por golpe. Na Dualidade, o Espírito repete cinco ataques com 60% do dano e sua aplicação de status original. A apresentação dura 3,5 segundos: dois redemoinhos desenhados, com oito quadros próprios por forma, saltam pelas posições dos alvos realmente atingidos. Sem Dualidade há apenas um redemoinho. Valores mecânicos e chances de Sangramento preservados.

## Nerathis — Flor do Veneno
Identidade original para o chefe floral proposto na referência. Corpo de casca escura, pétalas bordô/violetas, raízes e bolsas de veneno luminosas. O nome Zhu Jin fica apenas na referência recebida.

Posição provisória: fim do quinto cenário, fase 50, nível 50. A expressão “nível 5” aguarda confirmação; a imagem indica nível 80, não aplicado automaticamente à campanha. Disponível também em Nerathis • teste, sem recompensas. Não entra no gacha nem recebe recrutamento nesta versão.

### Kit implementado
- Essência da Flor Venenosa: dano direto aplica Veneno. Máximo cinco cargas; cada uma causa 2% da vida máxima da vítima no início de seu turno. Ao atingir cinco, Envenenamento Profundo por dois turnos: +25% de dano recebido da instância de Nerathis que aplicou o efeito.
- Pétalas Incandescentes: 8% da vida máxima do alvo + 180% de Força, em área, antes da mitigação. Alvos abaixo de 40% de vida recebem +30%. Queimadura Venenosa por dois turnos: 4% da vida máxima + 50% da Força original do aplicador por turno; dano causado pelo alvo reduzido em 20%.
- Espinhos da Flor Negra: 250% de Força em um alvo; três cargas de Veneno, além da passiva; defesa reduzida em 15% e cura recebida em 10% por dois turnos. Se havia três ou mais cargas antes do golpe, +40% de dano.
- Sono da Flor do Paraíso: tentativa de sono em todos os adversários, chance-base de 35%, dois turnos sem agir. Alvos afetados recebem +20% de dano dessa Nerathis. Chefes/imunes recebem apenas um turno e metade da potência dos efeitos.
- Flor Carmesim: ao cair abaixo de 50%, ganha +20% de dano e +15% de velocidade; suas habilidades ofensivas aplicam uma carga adicional de Veneno. Redução de dano de Pétalas sobe de 20% para 30%. Fase permanece ativada se receber cura.
- Florescimento: abaixo de 25%, todos os oponentes vivos perdem 2% da vida máxima por rodada por veneno. Aplica metade contra chefes/imunes. Mantém Flor Carmesim.

Resistência a controle: 60%; resistência à aplicação de Veneno: 50%; crítico 15%, dano crítico 150%. Efeitos de veneno e penalidades aplicados por ela têm metade da potência em chefes/imunes. Sono é exceção explícita à imunidade normal dos chefes.

### Decisões provisórias onde a imagem não especifica valores
Veneno básico: três turnos por carga. Recargas: Pétalas 4, Espinhos 3, Sono 5; Sono começa indisponível por duas rodadas. Ataque básico adicional Toque do Pólen, 100% de Força, permite agir quando as técnicas recarregam. Vida-base 9.500, Força 180, Essência 180, Defesa 75 e Velocidade 110, com crescimento normal por nível. A imagem fornece proporções de atributos, não valores absolutos: estes números precisam de balanceamento.

Os campos Character.Floral, Skill e StatusEffect no catálogo permitem ajustar o kit. Estados independentes preservam a origem e a Força inicial dos efeitos; sono, redução de cura/defesa/dano e vulnerabilidade ao aplicador podem ser reutilizados.

## Verificação
196 verificações de regras passaram. Teste visual dedicado cobre ficha, duas fontes de ataque e dez impactos, trajetórias e fases de Nerathis. O teste utiliza saves isolados.
