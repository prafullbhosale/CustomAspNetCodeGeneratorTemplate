using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.ProjectModel;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;

namespace CustomAspNetCodeGeneratorTemplate
{
    [Alias("customalias")]
    public class CustomAspNetCodeGenerator : ICodeGenerator
    {
        private const string generatedFileExtension = ".html";
        private IProjectContext _projectContext;
        private IApplicationInfo _applicationInfo;
        private ICodeGeneratorActionsService _codeGeneratorActionsService;
        private IServiceProvider _serviceProvider;
        private ILogger _logger;
        private string scaffolderName = "";

        /*
            Modify the collection below to include the template folders in the nuget package to search.
            Eg. The below would cause the templating to include <NugetPackageFolder>\Templates\Views\ 
            folder to be included in the search for the template.
         */
        private string[] _baseTemplateFolders = new[] { "Views" };

        public CustomAspNetCodeGenerator(
            IProjectContext projectContext,
            IApplicationInfo applicationInfo,
            ICodeGeneratorActionsService codeGeneratorActionsService,
            IServiceProvider serviceProvider,
            ILogger logger)
        {
            _projectContext = projectContext ?? throw new ArgumentNullException(nameof(projectContext));
            _applicationInfo = applicationInfo ?? throw new ArgumentNullException(nameof(applicationInfo));
            _codeGeneratorActionsService = codeGeneratorActionsService ?? throw new ArgumentNullException(nameof(codeGeneratorActionsService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var alias = this.GetType().GetTypeInfo().GetCustomAttribute(typeof(AliasAttribute)) as AliasAttribute;
            scaffolderName = alias.Alias;
        }

        /*
            This is the main entry point for the code generator.
         */
        public async Task GenerateCode(CommandLineModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.ViewName))
            {
                throw new ArgumentException("Please specify the name of file to be generated using the --name option");
            }

            var templateModel = new CustomAspNetCodeGeneratorTemplateModel()
            {
                ScaffolderName = this.scaffolderName
            };

            var outputFolder = string.IsNullOrEmpty(model.RelativeFolderPath)
                    ? _applicationInfo.ApplicationBasePath
                    : Path.Combine(_applicationInfo.ApplicationBasePath, model.RelativeFolderPath);

            var outputPath = Path.Combine(outputFolder, model.ViewName) + generatedFileExtension;

            if (File.Exists(outputPath) && !model.Force)
            {
                throw new InvalidOperationException($"File already exists '{outputPath}' use -f to force over write.");
            }

            await _codeGeneratorActionsService.AddFileFromTemplateAsync(outputPath, "View.cshtml", TemplateFolders, templateModel);

            _logger.LogMessage($"Added: {outputPath.Substring(_applicationInfo.ApplicationBasePath.Length)}");
        }

        protected IEnumerable<string> TemplateFolders
        {
            get
            {
                return TemplateFoldersUtilities.GetTemplateFolders(
                    containingProject: this.GetType().GetTypeInfo().Assembly.GetName().Name,
                    applicationBasePath: _applicationInfo.ApplicationBasePath,
                    baseFolders: _baseTemplateFolders,
                    projectContext: _projectContext);
            }
        }
    }
}
