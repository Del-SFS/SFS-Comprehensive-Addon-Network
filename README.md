# 🚀 SCAN - SFS Comprehensive Addon Network

Um gerenciador de mods moderno e inteligente para **Spaceflight Simulator**, inspirado no famoso CKAN do Kerbal Space Program.

## ✨ O que é SCAN?

SCAN é uma solução completa para gerenciar mods no SFS que vai muito além de um simples instalador:

- 🎯 **Gerenciamento de Dependências** - Instala automaticamente mods necessários
- 🚫 **Detecção de Conflitos** - Identifica mods incompatíveis antes de instalar
- 📦 **Interface Intuitiva** - Fácil de usar, mesmo para iniciantes
- 🔄 **Atualizações Automáticas** - Mantenha seus mods sempre atualizados
- 🗂️ **Organização Central** - Um repositório unificado de todos os mods disponíveis

## 🎮 Como Funciona?

```
┌─────────────────────────────────────┐
│  SCAN Interface (WinForms/WPF)      │
│  - Browse mods                      │
│  - Install/Uninstall                │
│  - Manage dependencies              │
└──────────────┬──────────────────────┘
               │
        ┌──────▼────────┐
        │  SCAN Engine  │
        │  - Resolução  │
        │  - Validação  │
        │  - Instalação │
        └──────┬────────┘
               │
        ┌──────▼──────────────┐
        │  Mod DataCenter     │
        │  (Schema + Index)   │
        └─────────────────────┘
```

## 🛠️ Recursos Planejados Status

✅ = Pronto
📅 = Planejado
🛠️ = Em progresso

- 🛠️ Versão Console
- 📅 Interface gráfica (WPF)
- 📅 API REST para integração
- 📅 Sistema de cache local
- 📅 Seletor de Versão do SFS
- 📅 Motor de resolução de dependências
- 📅 API REST para integração
- 📅 Suporte a múltiplas versões de mods
- 📅 Seletor de Versão do SFS
- 📅 Sistema de cache local
- 📅 Rollback de atualizações

## 📋 Requisitos

- **.NET 9.0** ou superior
- **Windows 7+**
- Spaceflight Simulator instalado

## 🚀 Começando

### Instalação

1. Baixe a versão mais recente em [Releases](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/releases)
2. Execute o instalador
3. Aponte para sua pasta do SFS
4. Pronto! 🎉

### Uso Básico

```
1. Abra SCAN
2. Navegue pelos mods disponíveis
3. Clique em "Instalar" no mod desejado
4. SCAN cuida do resto (dependências, conflitos, etc)
```

## 📚 Documentação

- [Como usar SCAN](./docs/USAGE.md)
- [Adicionar um mod](./docs/CONTRIBUTING.md)
- [Estrutura do projeto](./docs/ARCHITECTURE.md)

## 🔗 Links Importantes

- [Mod DataCenter](https://github.com/Del-SFS/Mod-DataCenter-SFS) - Banco de dados central de mods
- [SFS no Steam](https://steamcommunity.com/app/1718870/)
- [CKAN (Inspiração)](https://github.com/KSP-CKAN/CKAN)

## 🤝 Contribuindo

Você pode contribuir de várias formas:

### Adicionando Mods
Veja [CONTRIBUTING.md](./CONTRIBUTING.md) para adicionar seu mod ao DataCenter

### Reportando Bugs
[Abra uma issue](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/issues) descrevendo o problema

### Desenvolvendo
Quer contribuir com código? Faça um fork, crie uma branch e envie um PR!

```bash
git clone https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network.git
cd SFS-Comprehesive-Addon-Network
dotnet build
```

## 📝 Licença

Este projeto está licenciado sob a [MIT License](./LICENSE).

## ⚖️ Aviso Legal

Spaceflight Simulator é uma marca registrada de [Team Curiosity](https://teamcuriosity.com).  
Este projeto **NÃO é afiliado** aos desenvolvedores oficiais.

## 💬 Suporte

- **Forum**: [SFS Forum](https://sfsforum.com)
- **Issues**: [GitHub Issues](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/issues)

---

**Made with ❤️ by Del**

![Static Badge](https://img.shields.io/badge/Language-C%23-purple)
![Static Badge](https://img.shields.io/badge/Framework-.NET-purple)
![Static Badge](https://img.shields.io/badge/Status-Active%20Development-green)
