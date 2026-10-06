# Atualização V9 — apresentação do combate

Combate por turnos e três camadas preservados. Tempo real continua no roadmap, não implementado nesta versão. O idle existente continua separado do combate ativo.

- Números de dano flutuantes, inclinados, com contorno e entrada elástica; removida a caixa de fala do crítico.
- Crítico maior, com legenda dourada e brilho breve. Dano físico vermelho, essência roxa e cura verde, sem rótulos de tipo.
- Golpes múltiplos distribuídos em posições diferentes; nomes deixam espaço para os números durante o impacto.
- Painel de equipe com retratos, vida sincronizada com o impacto e indicação do próximo personagem. Clique no retrato para selecionar um aliado, inclusive para cura.
- Habilidades com ícones e recargas/restrições na dica ao passar o mouse.
- Apresentação das ações 16% mais rápida; automático avança a cada 1,55 s respeitando a animação.
- Preservados stun, congelamento, buffs azuis e personagens derrotados no chão.

## Referência e originalidade
Last Cloudia foi consultado como referência de apresentação, números flutuantes e interface de equipe: https://lastcloudia.com/en/system/ . Arte e efeitos usados são os originais do projeto; não foram importados recursos do jogo de referência.

## Limites atuais
Ainda é um protótipo. Esta versão melhora apresentação, não entrega a qualidade final de Last Cloudia. A maioria dos personagens ainda usa transformação de poses estáticas; Kael tem quatro poses. Animações completas quadro a quadro, áudio, novos cenários e câmera cinematográfica permanecem pendentes. Retratos reutilizam a arte existente; personagens sem retrato próprio usam a inicial do nome.

## Validação
109 verificações de regras aprovadas. Executável Windows testado com ataques físicos, essência, cura, crítico, congelamento, derrotas persistentes, menus, três ondas e recompensa única. Testes usam save temporário em memória.

## Rodar
Extraia TODO o ZIP Windows em uma pasta e abra ProjectVaelorn.exe. Mantenha o arquivo .pck e a pasta data junto do executável. Não precisa instalar Godot ou .NET. Para o código-fonte, consulte README.md.
