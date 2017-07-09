using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace CustomAspNetCodeGeneratorTemplate
{
    /// <summary>
    /// This class defines the command line options to be used with the 'customaspnetcodegenerator'.
    /// </summary>
    public class CommandLineModel
    {
        [Option(Name="viewName", ShortName="n", Description="Name of the file to be generated.")]
        public string ViewName { get; set; }

        [Option(Name="relativeFolderPath", ShortName="outDir", Description="Output path relative to the csproj file.")]
        public string RelativeFolderPath { get; set; }

        [Option(Name="force", ShortName="f", Description="Specify this option to overwrite existing files.")]
        public bool Force { get; internal set; }
    }
}