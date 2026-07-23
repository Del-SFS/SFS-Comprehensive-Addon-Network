# 🏗️ Arquitetura do SCAN

Visão geral da arquitetura técnica do SCAN - SFS Comprehensive Addon Network.

## 📐 Visão Geral

```
┌─────────────────────────────────────────────────────────┐
│                    UI Layer (WinForms)                  │
│  ┌──────────────┬──────────────┬──────────────┐        │
│  │ Dashboard    │ Mod Browser  │ My Mods      │ ...   │
│  └──────────────┴──────────────┴──────────────┘        │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│              Business Logic Layer                       │
│  ┌──────────────┬──────────────┬──────────────┐        │
│  │ ModManager   │ DependencyRes│ ConflictDete │        │
│  │              │olver        │ ctor         │        │
│  └──────────────┴──────────────┴──────────────┘        │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│              Data Access Layer                          │
│  ┌──────────────┬──────────────┬──────────────┐        │
│  │ Local DB     │ Mod DataCent │ File System  │        │
│  │ (Mods List)  │ er (Remote)  │ Operations  │        │
│  └──────────────┴──────────────┴──────────────┘        │
└────────────────────┬────────────────────────────────────┘
                     │
         ┌───────────┴───────────┐
         │                       │
    ┌────▼──────┐          ┌────▼──────┐
    │   Local   │          │  DataCent │
    │   Storage │          │   er API  │
    └───────────┘          └───────────┘
```

## 🗂️ Estrutura de Pastas

```
SFS-Comprehesive-Addon-Network/
├── UI/                          # Interface WinForms
│   ├── MainForm.cs
│   ├── Forms/
│   │   ├── ModBrowserForm.cs
│   │   ├── MyModsForm.cs
│   │   └── SettingsForm.cs
│   └── Components/
│       └── ModCard.cs
│
├── Services/                    # Lógica de negócios
│   ├── ModManager.cs
│   ├── DependencyResolver.cs
│   ├── ConflictDetector.cs
│   ├── DownloadService.cs
│   └── LocalStorageService.cs
│
├── Data/                        # Acesso a dados
│   ├── DataCenterClient.cs
│   ├── LocalDatabase.cs
│   └── Models/
│       ├── Mod.cs
│       ├── ModMetadata.cs
│       └── Installation.cs
│
├── Utilities/                   # Utilitários
│   ├── Logger.cs
│   ├── FileHelper.cs
│   └── Validators.cs
│
├── Program.cs                   # Entrada
└── SCAN.csproj

```

## 🔄 Fluxo de Instalação

```
Usuário clica "Instalar"
        │
        ▼
┌──────────────────────┐
│  Obter detalhes do   │
│  mod do DataCenter   │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Resolver            │
│  dependências        │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Detectar            │
│  conflitos           │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Pedir confirmação   │ ◄─── Usuário aprova/rejeita
│  do usuário          │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Baixar arquivo(s)   │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Extrair na pasta    │
│  do SFS              │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Atualizar           │
│  registro local      │
└──────────┬───────────┘
           │
        ▼
┌──────────────────────┐
│  Sucesso! ✓          │
└──────────────────────┘
```

## 📊 Componentes Principais

### 1. ModManager
**Responsabilidade**: Orquestração geral

```csharp
public class ModManager
{
    public async Task InstallAsync(Mod mod)
    public async Task UninstallAsync(Mod mod)
    public async Task UpdateAsync(Mod mod)
    public List<Mod> GetInstalledMods()
    public async Task<List<Mod>> FetchAvailableModsAsync()
}
```

### 2. DependencyResolver
**Responsabilidade**: Resolver dependências

```csharp
public class DependencyResolver
{
    public List<Mod> ResolveDependencies(Mod mod)
    public bool HasUnmetDependencies(Mod mod)
    public List<Mod> GetDependencyChain(Mod mod)
}
```

### 3. ConflictDetector
**Responsabilidade**: Detectar incompatibilidades

```csharp
public class ConflictDetector
{
    public List<Mod> FindConflicts(Mod mod)
    public bool IsCompatible(Mod mod1, Mod mod2)
    public ConflictReport GenerateReport(Mod mod)
}
```

### 4. DataCenterClient
**Responsabilidade**: Comunicação com DataCenter remoto

```csharp
public class DataCenterClient
{
    public async Task<List<Mod>> FetchAllModsAsync()
    public async Task<Mod> FetchModAsync(int id)
    public async Task<byte[]> DownloadModAsync(string url)
}
```

## 🗄️ Modelo de Dados

### Mod
```csharp
public class Mod
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
    public ModType Type { get; set; }
    public List<int> Dependencies { get; set; }
    public List<int> Conflicts { get; set; }
    public string DownloadUrl { get; set; }
    public string Size { get; set; }
}
```

### Installation
```csharp
public class Installation
{
    public int ModId { get; set; }
    public string Version { get; set; }
    public DateTime InstalledAt { get; set; }
    public string Location { get; set; }
    public bool IsEnabled { get; set; }
}
```

## 🌐 Integração com DataCenter

### Endpoint Base
```
https://raw.githubusercontent.com/Del-SFS/Mod-DataCenter-SFS/main
```

### Recursos

**Obter índice de mods**
```
GET /repo.json
Response: {version, mods[]}
```

**Obter metadados do mod**
```
GET /mods/{id}.json
Response: {id, name, author, version, ...}
```

**Obter schema**
```
GET /schema.json
Response: Validação de formato
```

## 🔐 Segurança

### Validação
- ✓ Validar JSON contra schema
- ✓ Verificar URLs antes de download
- ✓ Validar checksums (se disponível)

### Segurança de Arquivo
- ✓ Extrair em pasta isolada
- ✓ Verificar permissões antes de instalação
- ✓ Backup automático antes de desinstalação

### Privacidade
- ✓ Sem coleta de dados pessoal
- ✓ Logs apenas locais
- ✓ Transparência total

## 🧪 Testes

### Cobertura Esperada
```
Services/       -> 80%+ (lógica crítica)
UI/            -> 30%+ (cobertura básica)
Data/          -> 70%+ (persistência)
```

### Tipos de Teste
- **Unit Tests**: Componentes individuais
- **Integration Tests**: DataCenter + Local storage
- **UI Tests**: Fluxos do usuário

## 📈 Escalabilidade

### Cache Local
```
~1000 mods em cache
~50MB espaço em disco
Sincronização a cada 24h
```

### Performance
```
Resolver dependências: <100ms
Detectar conflitos: <100ms
Download: Depende da internet
Extração: ~1-10s por mod
```

## 🔮 Futuro

### Planejado
- [ ] API REST local
- [ ] Sistema de plugins
- [ ] Sincronização em nuvem
- [ ] Multiplayer mod sharing
- [ ] Rollback automático

### Considerações
- Modularização maior
- Suporte Linux/Mac (future)
- Integração com launcher oficial

---

**Quer entender melhor um componente específico?**  
Abra uma [Discussion](https://github.com/Del-SFS/SFS-Comprehesive-Addon-Network/discussions)!
