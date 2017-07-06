## Building the code generator
The codegenerators need to be installed to the target project as NuGet package references.
1. Run `dotnet restore`
2. Run `dotnet build`
3. Create a NuGet package by running `dotnet pack`

## Using the codegenerator in an ASP.NET Core project

1. Install NuGet packages to the target ASP.NET Core project:
    - `Microsoft.VisualStudio.Web.CodeGeneration.Design`
    - `CustomAspNetCodeGeneratorTemplate` created by `dotnet pack` above.
2. Install the DotNetCliTool for scaffolding
    - Add `<DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="1.0.1" />` to the .csproj file.
3. Run `dotnet restore` on the target ASP.NET Core project
4. Run `dotnet aspnet-codegenerator customalias [options]`

## Reference
Check out the implementation of built-in ASP.NET Core MVC scaffolders on github at:
- Controller Generator https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/Controller/CommandLineGenerator.cs
- View Generator https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/View/ViewGenerator.cs
- Area Generator https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/Areas/AreaGenerator.cs