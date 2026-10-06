# Trabalho colaborativo — Reality Of Enigma

## Antes de alterar qualquer arquivo
- Verifique `git status`, a branch atual e alterações locais. Preserve trabalho de outras pessoas.
- Execute `git fetch origin` e compare sua base com `origin/main`.
- Consulte os pull requests abertos e identifique arquivos compartilhados antes de iniciar uma tarefa. Se não houver acesso ao GitHub, informe que a sincronização não foi verificada; não trate a cópia local como atualizada.
- Comece uma branch específica a partir da base atualizada. Não desenvolva diretamente em `main`.
- Não use reset destrutivo, force push, nem descarte alterações de colaboradores.

## Durante a entrega
- Faça commits pequenos com objetivo claro. Combine alterações em catalog.json, animations.json, JourneyData e Main antes de sobrepor trabalho de outra branch.
- Faça novo fetch antes de publicar; integre mudanças da base e resolva conflitos preservando ambos os trabalhos.
- Rode testes relevantes quando modificar regras ou integração. Documentação isolada não exige retestar o jogo.
- Envie a branch e abra um pull request com resumo, validação e capturas quando houver mudança visual. Anexe o PR ao chat quando a ferramenta estiver disponível.
- Não faça merge em `main` sem autorização do responsável. Não altere proteção ou visibilidade do repositório por conta própria.
- Releases recebem tags; não mova tags já publicadas. V30 é a referência inicial, identificada pela tag `v0.30.0`.

IDs persistentes e saves devem ser preservados. Consulte CONTRIBUTING.md e docs/COLABORACAO.md.
