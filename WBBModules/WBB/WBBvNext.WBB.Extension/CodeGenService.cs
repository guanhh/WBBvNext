using System.IO;
using System.Linq;
using System.Text;
using WBBvNext.Base;
using WBBvNext.WBB.Abstract;

namespace WBBvNext.WBB.Extension
{
    public class CodeGenService : ISingletonService, ICodeGenService
    {
        private string PageVMReferenceStr = "<ProjectReference Include=\"..\\WBBvNext.$PlugName$.ViewModel\\WBBvNext.$PlugName$.ViewModel.csproj\" />";
        private string PageAbstractReferenceStr = "<ProjectReference Include=\"..\\WBBvNext.$PlugName$.Abstract\\WBBvNext.$PlugName$.Abstract.csproj\" />";

        public void DoGen(CodeGenSetting setting)
        {
            GeneratePage(setting);

            if (setting.IsExistDb)
            {
                GenerateModel(setting);
                GenerateViewModel(setting);
                GenerateDataAccess(setting);
                GenerateTest(setting);
            }

            GenerateAbstract(setting);
            GenerateExtension(setting);
        }


        private void GenerateDataAccess(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.DataAccess";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var csproj = GetResource("contextcsproj.txt", "DataAccess").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);

            var context = GetResource("context.txt", "DataAccess").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{setting.PlugName}DBContext.cs", context, Encoding.UTF8);
        }

        private void GenerateAbstract(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.Abstract";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var csproj = GetResource("abstractcsproj.txt", "Abstract").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);
        }

        private void GenerateExtension(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.Extension";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var module = GetResource("module.txt", "Extension").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{setting.PlugName}Module.cs", module, Encoding.UTF8);

            var csproj = GetResource("extensioncsproj.txt", "Extension").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);
        }

        private void GenerateModel(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.Model";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var csproj = GetResource("modelcsproj.txt", "Model").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);
        }

        private void GeneratePage(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.Page";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            string csproj;
            if (setting.IsExistDb)
            {
                csproj = GetResource("pagecsproj.txt", "Page").Replace("$PageVMReferenceStr$", PageVMReferenceStr);
            }
            else
            {
                csproj = GetResource("pagecsproj.txt", "Page").Replace("$PageVMReferenceStr$", "");
            }

            csproj = csproj.Replace("$PageAbstractReferenceStr$", PageAbstractReferenceStr).Replace("$PlugName$", setting.PlugName);

            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);

            var imports = GetResource("imports.txt", "Page");
            File.WriteAllText($"{dir}/_Imports.razor", imports, Encoding.UTF8);

            //Locales
            var localesDir = Directory.CreateDirectory($"{dir.FullName}/Locales");
            var zh = GetResource("zh.json", "Page");
            File.WriteAllText($"{localesDir}/zh.json", zh, Encoding.UTF8);

            var en = GetResource("en.json", "Page");
            File.WriteAllText($"{localesDir}/en.json", en, Encoding.UTF8);
        }

        private void GenerateTest(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.Test";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var csproj = GetResource("testcsproj.txt", "Test").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);
        }

        private void GenerateViewModel(CodeGenSetting setting)
        {
            var libName = $"WBBvNext.{setting.PlugName}.ViewModel";
            var dir = Directory.CreateDirectory($"{setting.ProjectDir}/{libName}");

            var csproj = GetResource("vmcsproj.txt", "ViewModel").Replace("$PlugName$", setting.PlugName);
            File.WriteAllText($"{dir}/{libName}.csproj", csproj, Encoding.UTF8);
        }

        public string GetResource(string fileName, string subdir = "")
        {
            var assembly = ModuleHelper.GetPlugAssemblies().FirstOrDefault(m => m.GetName().Name == "WBBvNext.WBB.Extension");

            string loc = "";
            if (string.IsNullOrEmpty(subdir))
            {
                loc = $"WBBvNext.WBB.Extension.GeneratorFiles.{fileName}";
            }
            else
            {
                loc = $"WBBvNext.WBB.Extension.GeneratorFiles.{subdir}.{fileName}";
            }
            var textStreamReader = new StreamReader(assembly.GetManifestResourceStream(loc));
            string content = textStreamReader.ReadToEnd();
            textStreamReader.Close();
            return content;
        }

    }
}
