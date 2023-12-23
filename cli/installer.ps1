# Restore dependencies
dotnet restore --configuration Release --verbosity detailed

# Compile the project
dotnet build --configuration Release
 
# Packaging the project
dotnet pack --configuration Release .\src\Semicrol.Arco.Core.Cli\Semicrol.Arco.Core.Cli.csproj
 
# Uninstall the existing global version of the tool
dotnet tool uninstall -g Semicrol.Arco.Core.Cli

# Install the global tool from the local package
dotnet tool install --global --add-source ./src/Semicrol.Arco.Core.Cli/nupkg Semicrol.Arco.Core.Cli

# Wait for user confirmation
Read-Host -Prompt "Press Enter to continue..."