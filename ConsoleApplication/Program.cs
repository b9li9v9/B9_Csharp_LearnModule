
using LearnMediatR.Source;
using System.Security.Claims;
using System.Text.RegularExpressions;
using ConsoleApplication.OutAndIn;
using ConsoleApplication.OutRefIn;

namespace ConsoleApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var testMediatR = new LearnMediatR.Test.TestMediatR();
            await testMediatR.TestMediatRMain(false);

            var testConfig = new LearnConfig.Test.TestConfig();
            await testConfig.TestConfigMain(false);

            var testLinq = new LearnLinq.Test.TestLinq();
            await testLinq.TestLinqMain(false);

            var testDI = new LearnDI.Test.TestDI();
            await testDI.TestDIMain(false);

            var testReflection = new LearnReflection.Test.TestReflection();
            await testReflection.TestReflectionMain(false);

            var testAttribute = new LearnAttribute.Test.TestAttribute();
            await testAttribute.TestAttributeMain(false);

            var testJWT = new LearnJWT.Test.TestJWT();
            await testJWT.TestJWTMain(false);

            var testActionAndFunc = new LearnActionAndFunc.Test.TestActionAndFunc();
            await testActionAndFunc.TestActionAndFuncMain(false);

            string a = nameof(a);
            Console.WriteLine(a);

            var ap = new AppPermission("string Feature", "string Action", "string Group", "string Description");
            Console.WriteLine(ap.Feature);

            Out.OutRun();
            Ref.RefRun();
            ClassStaticMetho.sayhi();
        }

    }

    public record AppPermission(string Feature, string Action, string Group, string Description, bool IsBasic = false)
    {
        public string Name => NameFor(Feature, Action);

        public static string NameFor(string feature, string action)
        {
            return $"Permissions.{feature}.{action}";
        }
    }
}
