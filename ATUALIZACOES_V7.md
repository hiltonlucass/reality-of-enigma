# Arena V7 — reações e números de combate

## Apresentação
- Recuo e inclinação com retorno após cada golpe; reação de essência com elevação breve.
- Respiração e balanço em espera, preparação, aproximação no ataque físico e retorno.
- Queda visual depois do acerto fatal, em vez de achatar a imagem imediatamente.
- Números flutuantes por acerto: FÍSICO em laranja, ESSÊNCIA em violeta e CURA em verde.
- Crítico verdadeiro com número maior e identificação própria. Contornos para legibilidade.
- Golpes múltiplos escalonados; barras de vida acompanham os impactos apresentados.

## Integração
Battle publica CombatImpact com alvo, dano efetivo, tipo, crítico e índice do acerto. Cura e Lança do Horizonte também publicam resultados. Custos de HP não são apresentados como ataques físicos. Sem mudanças de multiplicadores, chances ou regras de combate.

## Verificação
105 verificações do núcleo passaram, incluindo valores efetivos, tipos, golpes múltiplos, cura limitada ao HP faltante e críticos correspondentes ao resultado real. Executável validado com os testes de menus, animação, Lyra, cura, linha de três alvos, treinamento e recompensa única. Log final sem erros de renderização; capturas revisadas.

## Limitações
Reações usam transformações dos sprites existentes (deslocamento, rotação e escala). Kael mantém suas quatro poses próprias. Ainda não há sequências desenhadas de reação individuais para todo o elenco, nem áudio.
