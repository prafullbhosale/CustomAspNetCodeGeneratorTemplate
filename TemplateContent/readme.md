## Building the code generator
The codegenerators need to be installed to the target project as NuGet package references.
1. Run `dotnet restore CustomAspNetCodeGeneratorTemplate/CustomAspNetCodeGeneratorTemplate.csproj`
2. Run `dotnet build CustomAspNetCodeGeneratorTemplate/CustomAspNetCodeGeneratorTemplate.csproj`
3. Create a NuGet package by running `dotnet pack CustomAspNetCodeGeneratorTemplate/CustomAspNetCodeGeneratorTemplate.csproj -o artifacts`

## Using the codegenerator in an ASP.NET Core project

1. Run `dotnet restore` on the target ASP.NET Core project
2. From within the target project's directory run `dotnet aspnet-codegenerator customalias [options]`

## Reference
ASP.NET Core Scaffolding on github: https://github.com/aspnet/scaffolding

Custom ASP.NET CodeGenerator Template project on github: https://github.com/prafullbhosale/CustomAspNetCodeGeneratorTemplate
Check out the implementation of built-in ASP.NET Core MVC scaffolders on github at:
- [Controller Generator](https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/Controller/CommandLineGenerator.cs)
- [View Generator](https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/View/ViewGenerator.cs)
- [Area Generator](https://github.com/aspnet/Scaffolding/blob/dev/src/Microsoft.VisualStudio.Web.CodeGenerators.Mvc/Areas/AreaGenerator.cs)
