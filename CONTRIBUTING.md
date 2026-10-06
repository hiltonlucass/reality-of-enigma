# Contribuição

1. Atualize `main` antes de iniciar.
2. Crie uma branch por entrega: `personagens/nome`, `cutscenes/cena` ou `fix/descricao`.
3. Combine a área de trabalho para evitar duas pessoas editando o mesmo JSON ou arquivo Main ao mesmo tempo.
4. Abra um pull request com objetivo, arquivos alterados, captura/vídeo e validação. Não envie diretamente a main depois do snapshot inicial.
5. O responsável pelo projeto revisa antes de integrar. A proteção automática da branch não está configurada nesta entrega.

Antes de iniciar e antes de publicar, execute `git fetch origin` e verifique os pull requests em andamento. Não substitua arquivos de outra pessoa por uma cópia antiga. Conflitos devem ser resolvidos na branch da entrega; não use force push como atalho.

Consulte também `AGENTS.md`, que registra estas regras para assistentes de desenvolvimento. A referência inicial V30 usa a tag `v0.30.0`. Novas tags identificam releases aprovadas e nunca devem ser movidas para outro commit.

Quem tiver acesso de leitura pode baixar uma cópia. Num repositório público, contribuições externas devem vir por fork e pull request. Apenas colaboradores convidados podem enviar branches diretamente; acesso ao link não concede escrita no projeto principal.

Não altere IDs existentes sem migração de save. `varkas` identifica Fenrath e `nerathis` identifica Velmora internamente. Não versione `.godot`, `bin`, `obj`, saves, credenciais ou builds. Preserve os `.uid` e arquivos de importação do Godot que já acompanham os assets.

Para regras, rode `dotnet run --project Tests`. Para integração, rode `dotnet build Godot/ProjectVaelorn.csproj`. Confira visualmente as cenas alteradas. Não renomeie/remove artes antigas até verificar todas as referências. Use nomes de arquivo em minúsculas e caminhos `res://` com capitalização consistente.

Toda arte entregue precisa indicar origem, resolução, licença/autorização aplicável e método de criação. Nenhum personagem de anime deve ser copiado diretamente para o produto.
