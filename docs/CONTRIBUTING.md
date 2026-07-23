# 🤝 Guia de Contribuição

Obrigado por estar interessado em contribuir para SCAN! Este guia explica como você pode ajudar.

## 🎯 Como Contribuir

### 1. Adicionando Seu Mod ao DataCenter

Quer adicionar seu mod ao SCAN? Siga estas etapas:

#### Pré-requisitos
- Seu mod deve estar funcional e testado
- Você deve ser o criador ou ter permissão do criador
- Seu mod não deve ser duplicado

#### Passo a Passo

1. **Fork o repositório do DataCenter**
   ```bash
   Fork: https://github.com/Del-SFS/Mod-DataCenter-SFS
   ```

2. **Clone seu fork**
   ```bash
   git clone https://github.com/SEU_USUARIO/Mod-DataCenter-SFS.git
   cd Mod-DataCenter-SFS
   ```

3. **Crie seu arquivo de mod**
   
   Crie um arquivo `mods/seumod.json`:
   ```json
   {
     "id": 3,
     "name": "Your Mod Name",
     "author": "Your Name",
     "version": "1.0.0",
     "description": "Descrição breve do seu mod",
     "type": "mod",
     "dependencies": [],
     "conflicts": [],
     "download": "https://seu-link-de-download.com/mod.zip",
     "size": "5.2MB"
   }
   ```

   > Veja `schema.json` para validar seu arquivo

4. **Atualize `repo.json`**
   
   Adicione seu mod ao índice:
   ```json
   {
     "id": 3,
     "name": "Your Mod Name",
     "path": "mods/seumod.json"
   }
   ```

5. **Valide seus arquivos**
   ```bash
   # Verifique que JSON é válido
   # Confirme que segue schema.json
   ```

6. **Faça um Pull Request**
   - Escreva uma descrição clara
   - Mencione o mod que está adicionando
   - Linkue para a página do mod se houver

### 2. Reportando Bugs

Encontrou um problema? Abra uma [Issue](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/issues)!

**Informações úteis:**
- Versão do SCAN
- Versão do SFS
- Sistema operacional
- Passos para reproduzir
- Screenshot/Video (se aplicável)

### 3. Sugerindo Features

Tem uma ideia legal? Abra uma discussão ou issue com tag `enhancement`.

**Descreva:**
- O que quer adicionar
- Por quê seria útil
- Exemplos de uso

### 4. Melhorando Documentação

Achou algo confuso ou incompleto na documentação?
- Edite diretamente arquivos `.md`
- Faça um PR com suas melhorias
- Todas as contribuições são bem-vindas!

### 5. Desenvolvendo Código

Quer contribuir com código? Ótimo! 🎉

#### Setup

```bash
# Clone o repositório
git clone https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network.git
cd SFS-Comprehesive-Addon-Network

# Instale dependências
dotnet restore

# Build
dotnet build

# Execute testes
dotnet test
```

#### Padrões de Código

- Use **C# 10+** features
- Siga **C# coding guidelines**
- Escreva **testes unitários**
- Código bem comentado

#### Processo de PR

1. **Crie uma branch**
   ```bash
   git checkout -b feature/sua-feature
   ```

2. **Faça suas mudanças**
   - Commits claros e descritivos
   - Teste localmente
   - Siga padrões de código

3. **Push para seu fork**
   ```bash
   git push origin feature/sua-feature
   ```

4. **Abra um Pull Request**
   - Descrição clara
   - Linkue issues relacionadas
   - Screenshots se UI mudou

5. **Code Review**
   - Responda aos comentários
   - Faça ajustes se necessário
   - Aguarde aprovação

6. **Merge**
   - Seu código está na main! 🚀

## 📋 Checklist para PRs

- [ ] Código segue padrões do projeto
- [ ] Testes foram adicionados/atualizados
- [ ] Documentação foi atualizada
- [ ] Commits têm mensagens claras
- [ ] Sem conflitos com `main`
- [ ] Build passa em CI/CD

## 🏆 Tipos de Contribuição

### 🐛 Bug Fixes
- Crítico: Resolvido ASAP
- Alto: Resolvido na próxima release
- Normal: Na fila regular

### ✨ Novas Features
- Discussão primeiro (pode rejeitar)
- Design review
- Implementation
- Testing
- Merge quando aprovado

### 📚 Documentação
- Sempre bem-vindo
- Sem necessidade de review longo
- Merge rápido

### 🎨 Melhorias UI/UX
- Screenshots do before/after
- Justifique as mudanças
- Considere acessibilidade

## 💬 Comunidade

- Seja respeitoso
- Aprecie feedback
- Ajude outros contribuidores
- Celebre os sucessos!

## 📜 Licença

Ao contribuir, você concorda que seu código será licenciado sob MIT License.

## 🤔 Perguntas?

- Abra uma [Discussion](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/discussions)
- Veja [Issues abertas](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/issues)
- Procure no [Documentação](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/tree/main/docs)

---

**Muito obrigado por contribuir! ❤️**
