Versão atual: Reality Of Enigma V29. Veja GDD_V29_Fenrath_Nerathis.md para o novo chefe e Presas do Vendaval. Veja ATUALIZACOES_V28.md para os sons fornecidos e a nova arte de Varkas. Veja ATUALIZACOES_V27.md para recompensas, Sangramento e áudio revisado. Veja ATUALIZACOES_V26.md para a nova interface, artes, animações e sons. ATUALIZACOES_V25.md registra o sistema de Varkas. GDD_V25.md contém o documento editável consolidado; Godot/Art/PROMPTS_V26.md registra os novos ativos. O pacote RealityOfEnigma_Windows_V29.zip já inclui o executável e suas dependências: extraia inteiro e abra RealityOfEnigma.exe. As instruções de Godot e .NET abaixo são para editar o projeto. As seções seguintes preservam o histórico das versões anteriores.

# Arena V12

Formação 3×3 antes da batalha, corrida e alinhamento ao alvo. Consulte ATUALIZACOES_V12.md.

# Arena V11

Elenco revisado e panela exclusiva dos buffs de Savor. Veja ATUALIZACOES_V11.md.

# Arena V10

Animações por quadros integradas para sete personagens/criaturas. Consulte ATUALIZACOES_V10.md.

# Arena V9

Veja ATUALIZACOES_V9.md para a atualização da apresentação do combate. Turnos preservados; tempo real futuro.

# Interface e derrota V8

Consulte ATUALIZACOES_V8.md. Pacote jogável: ProjectVaelorn_Windows_V8.zip.

# Reações e dano V7

Consulte ATUALIZACOES_V7.md. Pacote jogável: ProjectVaelorn_Windows_V7.zip.

# Poderes V6

Consulte ATUALIZACOES_V6.md. Pacote jogável: ProjectVaelorn_Windows_V6.zip.

# Atualização visual V5

Consulte ATUALIZACOES_V5.md. Executável independente disponível no pacote ProjectVaelorn_Windows_V5.zip. As instruções abaixo documentam também versões anteriores.

# Project Vaelorn — arena jogável V3

**Atualização V3:** escolha manual de habilidades e alvos, quatro habilidades de Lyra, rotação marcial de Kael com recargas e treinamento de três ondas com repetição automática. Leia **ATUALIZACOES_V3.md** para os detalhes atuais. ATUALIZACOES_V2.md e VALIDACAO.md registram entregas anteriores.

Laboratório inicial em Godot 4.4.1 .NET e C#/.NET 8. O GDD fica ao lado desta pasta. Este projeto inicia a implementação; não é o jogo completo nem uma versão comercial.

## Abrir o jogo no Windows

1. Instale o **SDK .NET 8 x64**, não apenas o Runtime: https://dotnet.microsoft.com/download/dotnet/8.0
2. Baixe o **Godot 4.4.1 .NET para Windows x64**: https://godotengine.org/download/archive/4.4.1-stable/ . A edição Standard não executa C#.
3. Extraia o editor em uma pasta. Mantenha Core e Godot lado a lado dentro de ProjectVaelorn.
4. Abra o Godot, escolha **Importar** e selecione `Godot/project.godot`.
5. Pressione **Compilar** e depois **F6/F5** para executar a cena/projeto. A primeira compilação precisa de internet para restaurar os pacotes oficiais do NuGet.

Alternativa pelo PowerShell, a partir desta pasta:

```powershell
dotnet build .\Godot\ProjectVaelorn.csproj
& 'C:\caminho\Godot_v4.4.1-stable_mono_win64.exe' --path .\Godot
```

Na máquina onde este material foi criado, o .NET SDK 8.0.400 já estava instalado. Uma cópia portátil do Godot foi usada para validação; ela não integra o ZIP do código. Não é necessário instalar editor de código para jogar o laboratório.

## O que experimentar

- **Próxima fase** inicia o próximo encontro, sem repetir fases concluídas. Clique no alvo e na habilidade do aliado da vez para jogar manualmente. **Avançar / ação automática** resolve uma ação com a escolha da IA; **Auto / parar** reproduz as ações. Esc pausa. A borda verde marca o personagem da vez e a dourada marca o alvo selecionado.
- **Teste Kael VIII** abre um confronto isolado com Kael marcial nível 70 no ápice. Não concede prêmio nem altera a campanha. Usa o retrato conceitual da evolução e uma aura de teste.
- Ao concluir a fase 20, **Treinar Varkhan** libera um encontro de três ondas, com o chefe na última. A primeira conclusão completa libera **Simular Varkhan**, que consome um ticket. Cada conclusão dá um fragmento de Varkhan e um de protagonista. Marque **Repetir treino ao vencer** e ative Auto para farmar; Esc para antes de iniciar outra repetição.
- **Invocar** cobra 1.000 ou 9.000 Gold. Pool temporário: Kael, Savor, Aelia, Brakk e Lyra, 20% cada. Varkhan e Solarius nunca entram nesse pool.
- Escolha um personagem na lista para **+1 nível**, **+1 estrela** ou **Reconstruir**. A lista inclui não recrutados, que precisam primeiro de fragmentos. Uma promoção exige nível máximo da estrela e cópia ou Coringa.
- Após recrutar Varkhan, selecione-o e use **Usar no slot 5** para colocá-lo na formação. Os primeiros quatro slots são fixos nesta fatia.
- **Kael Lutador / Kael Arsenal** exige nível 30. Troca livre é uma conveniência de laboratório; a regra final de reversão está pendente.
- **Coletar idle** recebe Gold e XP acumulados em minutos inteiros, sem teto de horas. Valores de laboratório não representam a economia final.

## Implementado e limitações

Implementado: catálogo JSON externo; modelos Character, Skill, StatusEffect, Enemy, Stage, Boss, Equipment, Inventory, Faction, Archetype e Summon; ordem por velocidade; dano, crítico, cura e mitigação por Defesa; gelo/congelamento; fórmula encadeada de Varkhan; estados do Kael e bloqueio do VIII abaixo do 70; contagem e bônus cumulativos de Lutadores; níveis, estrelas, duplicados, Coringas, fragmentos; progresso sequencial; treinamento e simulação; idle e save local com backup.

Os dados incluem 70 **fases de laboratório**, com inimigos repetidos e chefes provisórios. Isso não implementa 70 fases narrativas. Os marcos 10/30/40/50/60 usam placeholders não recrutáveis. O recrutável 50 ainda precisa ser criado. Solarius libera após o marcador de conclusão do ato, mas a conversa/cutscene ainda não existe.

Lyra possui Estilhaço, Chuva Glacial, Prisão Invernal e Reino Congelado, com cargas, congelamento, imunidade e lentidão independente. Kael base agora tem acertos separados em Corte Duplo e Investida. Os demais kits continuam parciais: buffs de Savor, Guarda/passivas de Brakk, Elo Vital/passivas de Aelia, marcas de Raizen, Bloqueio e Desvio ainda não estão implementados. A Lança encadeia HP removido após Defesa. Blazing Heel agora percorre a coluna escolhida, mas o crítico adicional ainda falta.

Kael marcial possui o básico com múltiplos acertos conforme estágio, Quebrar Limites, Impacto Ascendente com CD 3, Fera Carmesim com CD 6 e requisito VI, além do extremo único no VIII a partir do nível 70. As habilidades ficam no JSON. Penetração de Bloqueio depende da futura implementação dessa defesa. O Arsenal conserva o kit base enquanto aguarda design.

Treinamento executa três ondas e pode repetir automaticamente após vitória. Vida, estados, estágios e recargas persistem entre ondas; uma nova repetição recria a equipe. Derrota encerra o farm e não concede fragmentos. Treino separado de inimigos comuns ainda não existe. O botão de simulação existe apenas para Varkhan; o serviço também aceita Solarius. Equipamentos têm modelo e checagem de compatibilidade, sem inventário de itens ou efeitos aplicados.

Ainda não há arte final, animações por quadros completas, áudio, cenas narrativas, editor completo de formação, integração Steam ou monetização. A V2 inclui um sprite isolado de Kael, retratos dos conceitos aprovados e animação procedural de ataque/impacto. Nenhum sprite de anime foi incluído.

## Estrutura

```text
Core/                  regras independentes do Godot
  Models.cs            definições e estado salvo
  Combat.cs            unidades, sinergias e combate
  Progression.cs       economia, progresso, idle e persistência
Godot/
  Data/catalog.json    catálogo e fases provisórias
  Main.cs              interface do laboratório
  Main.tscn            cena de entrada
  project.godot        importar este arquivo
Tests/                 testes de regras sem bibliotecas externas
```

Para criar conteúdo, adicione identificadores e valores ao catálogo. Para criar uma mecânica nova, acrescente um operador no núcleo e testes; não basta inventar um valor de Operator no JSON. Os operadores atuais são hit, heal, row, aoe e horizon. A progressão de atributos usa uma curva provisória de 3% da base por nível; velocidade não cresce com nível. Dados e definições devem continuar separados do estado mutável.

## Testes

```powershell
dotnet run --project .\Tests\Vaelorn.Tests.csproj
```

O resultado esperado é **97 assertions passed**. Os testes cobrem dano, controles, progressão, gacha, treino, persistência, habilidades manuais, seleção de alvo, recargas, Lyra, Kael marcial e recompensa única ao final das três ondas. Os arquivos temporários de teste ficam na pasta de saída dos testes; não usam o save do jogo.

Se o sistema negar a operação de substituição atômica do arquivo de teste, rode em uma pasta local gravável fora de sandbox. A execução agora encerra com mensagem legível e código 1; não deixa uma exceção sem tratamento abrir o depurador do Windows. Não desative proteção do computador para rodar o projeto.

## Salvamento

O jogo usa `user://save-v1.json`, resolvido pelo Godot na pasta de dados do aplicativo. A versão anterior fica em `.bak`. Para localizar, consulte a pasta de dados de usuário do projeto no Godot. Para recomeçar, feche o jogo e renomeie o save; preserve a cópia antiga se quiser recuperar.

Se o JSON for inválido ou tiver versão incompatível, a UI informa o erro e não sobrescreve o arquivo. Não há migração automática entre versões ainda. Salvamentos iniciam após o tutorial, com quatro heróis 3 estrelas e Lyra 2 estrelas. Campanha e evolução narrativa completa não foram executadas para produzir esse estado inicial.

## Verificação desta entrega

- Compilação C# e projeto Godot: zero erros e zero avisos.
- Testes de regras: 97 verificações aprovadas.
- Inicialização do Godot 4.4.1 .NET validada.
- GDD: PDF de 23 páginas com fonte Markdown editável.

Documentação oficial: https://docs.godotengine.org/en/4.4/tutorials/scripting/c_sharp/c_sharp_basics.html

## Próximo incremento

Completar os kits restantes, Bloqueio/Desvio e proteção de Brakk; produzir os sprites isolados e quadros de animação dos demais aliados; implementar cena do prólogo; decidir o final do Arsenal Vivo e a exceção de promoção de Lyra. Use o GDD como referência e registre novos números como propostas até a validação.
