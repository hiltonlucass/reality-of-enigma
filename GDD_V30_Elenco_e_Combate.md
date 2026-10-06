# Reality Of Enigma — GDD de atualização V30

## Campanha e elenco
- Fase50: **Velmora — Flor do Veneno**. Mantém o kit floral e o identificador interno `nerathis` para compatibilidade.
- Fase60: **Maltherion — Carrasco do Eclipse**, chefe original com duas formas. Sem recrutamento no gacha.
- **Sevrin — Lâminas do Crepúsculo**: herói Espadachim de Força, dano e controle; disponível no recrutamento por Gold e na ficha com botão de teste. Não exige compra com dinheiro real.
- Sevrin guardava a última ponte dos arquivos solares. Procura as identidades apagadas por Nhal’Zor. Maltherion é o carrasco cujo corpo mantém fragmentos de um eclipse aprisionado.

## Fenrath e apresentação
Retrato original com patas apoiadas em rocha e fundo também na miniatura. Espirais do Corpo e Espírito percorrem curvas entre os alvos e orientam o desenho conforme a trajetória. Golpes continuam sincronizados com seus impactos, cinco por forma. Valores de Sangramento e Dualidade preservados.
Números de dano sobem com pequeno movimento por dígito; físico vermelho, Essência roxa, cura verde. Crítico leva exclamação compacta. Ícones de bônus usam símbolos claros pequenos; detalhes aparecem ao apontar. Novas habilidades recebem imagens próprias de lâminas, sangue, machado, escudo e eclipse.

## Maltherion
Aos50% de HP a ascensão é permanente, sem restaurar vida. Força passa a140%, defesa de120% para160%, velocidade de90% para110%, resistência a controle de70% para80%, crítico de15% para20%, dano crítico de150% para180%.
Carnificina: limite5, cada carga +5 pontos de crítico e +8 pontos de dano crítico; ascensão: limite7, +6 e +10 pontos. Dois rounds sem acertar removem2 cargas. Ascendido ignora20% da defesa. Ao atingir7 recebe proteção de30% e roubo de vida de10% por2 turnos.
A segunda forma troca Machado Cortante por Lâmina de Ossos e acrescenta Três Cortes e Aniquilação Final. Conserva Esmagamento, Corpo e Juízo com seus efeitos evoluídos.

## Sevrin
Ataques principais aplicam Sangramento; cinco cargas próprias por vítima, com duração independente. O segundo corte de Corte Rápido não aplica novas cargas. Sangramento de Fenrath continua separado por origem e respeita seu limite10. As técnicas que contam Sangramento reconhecem a família do efeito.
Na frente: -25% dano recebido de atacantes acima de70%HP. Velocidade global +5% por Sangramento inimigo, até25%. O bônus condicionado ao alvo usa até5 cargas: +8% velocidade e +6 pontos de crítico por carga. Para ordenar o próximo round, considera a maior quantidade de cargas entre inimigos vivos; no ataque o crítico usa o alvo real.
Quando um inimigo morre sangrando, inclusive pelo último tick, Sevrin vivo cura15% e reduz todas as recargas em1, uma vez por vítima. Cura respeita redução de cura.

## Habilidades implementadas

### Sevrin

- **Corte da Cicatriz** (recarga 0): 100% Força. Aplica uma carga de Sangramento por 2 turnos.

- **Corte Rápido** (recarga 2): 220% Força. 70% de aplicar uma carga adicional de Sangramento. Contra alvo já sangrando: segundo corte de 120%, sem novas cargas.

- **Corte Sangrento** (recarga 3): 180% Força +8% da vida máxima do alvo. Sangramento profundo por 3 turnos: 8% da vida por turno. Reduz dano causado em 25% por 2 turnos. Com 3 cargas: +40% dano.

- **Passo da Frente** (recarga 4): Apenas na frente. 250% Força +10% da vida máxima dos inimigos da coluna escolhida. Sangramento e -30% dano causado por 2 turnos.

- **Lâminas do Crepúsculo** (recarga 5): 300% Força +12% da vida máxima de cada inimigo. +8% dano por Sangramento (máx.40%). Sangramento profundo e -30% dano causado por 3 turnos.

### Maltherion

- **Talho do Eclipse** (recarga 0): 100% Força. Acumula Carnificina ao acertar.

- **Machado Cortante** (recarga 2): 220% Força +5% vida máxima. Acertos consecutivos: +15% dano, até45%. Críticos: Sangramento de 3% da vida por 2 turnos.

- **Esmagamento do Abismo** (recarga 3): 180% Força +7% vida máxima. 30% de atordoar por 2 turnos; ao despertar, -20% ataque por 1 turno. Ascensão: chance50% e -20% defesa.

- **Corpo do Eclipse** (recarga 4): Reduz dano recebido em 30% e +25 pontos de resistência a controle por 2 turnos. +3% defesa por 10% vida perdida, máximo30%. Ascensão: regeneração de 3% por rodada (até3 cargas). Recarga4 provisória.

- **Juízo da Fenda** (recarga 5): Todos: 250% Força +10% vida máxima; +10% por Carnificina (máx.50%). -25% dano por 2 turnos. Ascensão: 300% +12% vida e redução40%.

- **Lâmina de Ossos** (recarga 2): 280% Força +8% vida máxima. +10% por Carnificina (máx.70%). Crítico: Fratura, -30% defesa por 2 turnos.

- **Três Cortes do Abismo** (recarga 4): Três golpes de 100% Força. Último:40% de atordoar por 1 turno. Cada golpe:15% de aplicar -20% dano por 2 turnos.

- **Aniquilação Final** (recarga 6): 500% Força +15% vida máxima em todos. Por 2 turnos: -40% dano, -20% velocidade, +30% dano recebido. Ao derrotar: cura15% da vida e +1 Carnificina.

## Decisões V1 e limites
As fichas foram adaptadas a Força/Essência e às três camadas do jogo. Passo da Frente atravessa a coluna escolhida. Corpo do Eclipse usa recarga4 provisória; regeneração dura6 turnos por carga, máximo3. Sangramento comum de Sevrin usa15% da Força de origem; profundo usa8% da vida da vítima. Esses valores completam lacunas das referências e precisam de balanceamento.
A resistência a Sagrado citada na ficha ainda não é aplicada: o combate atual distingue dano físico e Essência, sem canal Sagrado. A mecânica de errar ataques reinicia a sequência quando um golpe falha/não causa dano; ainda não há sistema de esquiva/acerto separado.
Os sprites novos têm12 poses desenhadas por forma e transições interpoladas; ainda não são animações longas de produção. Retratos têm movimento de câmera, não rig facial. A velocidade de Sevrin segue a interpretação documentada acima porque a ficha fornece dois bônus distintos.
Atributos, recargas, escalas, efeitos e parte dos parâmetros de passiva ficam em JSON; regras especiais ainda têm parâmetros em C# a extrair para dados numa revisão posterior.

## Validação
237 verificações de regras, incluindo todos os golpes novos, fases, Sangramento, cura por morte e recargas. Teste visual automatizado do executável com save isolado e capturas de retratos, espirais, dano e formas do chefe. Valores V1 não equivalem a balanceamento final da campanha.
