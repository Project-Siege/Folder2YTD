# Folder2YTD

Folder2YTD is an enhanced tool that allows for the automated conversion of image folders into `.ytd` files directly from the file browser. This version builds upon the original by introducing command-line capabilities that integrate seamlessly with file management tools like OneCommander.

## New Features

- **Command-Line Interface (CLI) Support**: Folder2YTD now supports command-line arguments, enabling automation and integration with other software.
- **Integration with OneCommander's File Automator**: Users can now automate the conversion of folders to `.ytd` files directly within OneCommander, enhancing workflow efficiency.

## Getting Started

### Prerequisites

- Ensure that Folder2YTD.exe is either added to your system's PATH or accessible from the directory where you intend to run the script.
- OneCommander installed with File Automator feature.

### Installation

1. Clone the repository and build following the original build steps. I will update the release with a built version soon!
2. If desired, add the Folder2YTD executable's directory to your system's PATH:
   
   Alternatively, you can directly reference the executable's path in the automation scripts.

### Usage

#### Automating with OneCommander

To use Folder2YTD with OneCommander's File Automator:

1. Open OneCommander and navigate to the File Automator section.
2. Create a new automation script with the following command: Folder2YTD.exe -folder "$SourceFile" -file "$SourceFile"

      Replace `Folder2YTD.exe` with the full path to the executable if not added to PATH.

#### Command-Line Usage

You can also use Folder2YTD directly from the command line: Folder2YTD.exe -folder "path_to_folder" -file "output_path"


## Benefits

- **Streamlined Workflow**: Automate the conversion process directly within the file browser, reducing manual steps and saving time.
- **Flexibility**: Works with individual folders or multiple selections, providing versatility in how you manage file conversions.
- **Integration**: Seamlessly integrates into existing file management workflows with minimal setup.

