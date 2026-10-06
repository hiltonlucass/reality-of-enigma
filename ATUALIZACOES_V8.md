# Arena V8 — crítico, buffs e derrota

- Removidos os nomes FÍSICO, ESSÊNCIA e CURA dos números flutuantes.
- Físico vermelho, essência roxa, cura verde com sinal +.
- Crítico real em balão contornado com cauda; única identificação escrita nos números.
- Bônus existentes indicados em azul: bota para velocidade, punho para dano/força, escudo para proteção. Ícones refletem sinergias de Lutadores e portões de Kael; não adicionam bônus novos. Selecionar o personagem permite consultar a descrição pelo tooltip do campo.
- Derrota com queda e permanência do sprite opaco no chão até a mudança de encontro/onda.
- Aliados caídos; inimigos comuns mortos; chefes e personagens marcados StoryProtected derrotados sem morte narrativa. Flag configurável no catálogo. Não adiciona ressurreição ou diálogo automaticamente.
- Controles e indicadores de bônus deixam de aparecer sobre derrotados.

## Validação
109 verificações do núcleo passaram. Executável testado sem erros de renderização. Capturas de crítico real, três ícones ativos e permanência de aliado/inimigo/chefe após 2,5 segundos revisadas. Mantidos testes de cura, perfuração de três alvos, treinamento, recompensa e menus.

## Arte
Ícones e balão desenhados no Godot. Queda usa transformação das artes atuais; poses desenhadas específicas para derrotas continuam pendentes. Nenhuma nova geração de imagem nesta atualização.
