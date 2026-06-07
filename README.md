📦 About ModCenterSFS ##

ModCenterSFS is not just a file collection — it acts as a **structured JSON-based mod database**.

📁 Structure

- **`repo.json`**  
  The central index of all available mods.  
  Acts as the “brain” of the system.

- **`Mods/`**  
  Contains individual mod definition files.

📄 Example mod.json

json
{
  "nome": "Mod Name",
  "autor": "Author",
  "versao": "1.0.0",
  "descricao": "Description",
  "tipo": "Parts / DLL / Texture / System",
  "dependencias": [],
  "conflitos": [],
  "download": "URL",
  "tamanho": "MB"
}

translation:

nome -> Name 
autor -> Author 
verção -> Version 
descrição -> Description 
tipo -> Type 
dependencias -> Dependencies  
comflitos -> Conflicts 
baixar -> Download 
tamanho -> Size 

🖥️ About SCAN ###

SCAN is a Python-based installer that reads this repository in real-time and automates mod installation.

### ⚙️ Responsibilities ###
- Fetch mod data from repo.json
- Resolve dependencies
- Detect conflicts
- Install files in correct directories
- 
### 🛠️ Features ###
- Automatically checks for new versions on startup
- Dependency Management
- Installs required mods automatically
- Conflict Detection
- Warns about incompatible mods
- Smart Folder Mapping
- Mod Type	SFS Destination


DLL	/Mods
Parts	/Custom Assets/Parts
Textures	/Custom Assets/Texture Packs
Solar Systems	/Spaceflight Simulator_Data/Custom Solar Systems


### 🤝 Contributing ###
Contributions are welcome and encouraged.

### 🔀 Workflow ###
- Fork the repository
- Create a branch
- Add or modify mod files
- Commit your changes
- Push to your fork
- Open a Pull Request

## 💻 Commands ## 
- git checkout -b my-feature
- git commit -m "Add new mod"
- git push origin my-feature
- 
### ➕ Adding a Mod ###
Create a .json file inside Mods/
Follow the standard structure
Ensure:
Download link works
Dependencies are valid
No conflicts missing

## ⚠️ Rules ##
Do not upload broken links
Keep JSON valid
Avoid duplicate mods
Clearly define dependencies

## 🧠 Architecture Overview ##

ModCenterSFS (this repo)
        ↓
     repo.json
        ↓
      SCAN
        ↓
Installs mods into SFS


## 👨‍💻 Credits ##
Lead Developer: Del

## ⚠️ Disclaimer ##

**Spaceflight Simulator is a registered trademark of **Stefo Mai Morojna.**
This project is not affiliated with the official developers.**
