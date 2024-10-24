using LearnReflection.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LearnReflection.Test
{
    public class TestReflection
    {
        public async Task TestReflectionMain(bool io = false)
        {
            if (io)
            {
                Console.WriteLine($"GetType().Assembly: {GetType().Assembly}\n");
                
                var moduleName = typeof(Dog).Module;
                Console.WriteLine($"module: {moduleName}\n");

                Assembly assembly = typeof(Dog).Module.Assembly;
                Console.WriteLine($"assembly: {assembly}\n");

                var assemblyName = assembly.GetName().Name;
                Console.WriteLine($"assemblyName: {assemblyName}\n");

                Assembly assemblyData = Assembly.LoadFrom(assemblyName);
                Console.WriteLine($"assemblyData: {assemblyData}\n");

                Console.WriteLine($"assemblyNameType: {assemblyName.GetType()}\n");


                Type dogType = Type.GetType("LearnReflection.Source.Dog");
                Console.WriteLine($"dogType.GetType():{dogType.GetType()}");
                MethodInfo dogMethodInfo = dogType.GetMethod("SayHi");
                Console.WriteLine(dogType.FullName + "." + dogMethodInfo.Name);

                object dogInstance = Activator.CreateInstance(dogType);
                dogMethodInfo.Invoke(dogInstance, null);

                string assemblyPath = "C:\\Users\\User_\\source\\repos\\LearnModule\\TestWantDelete\\bin\\Debug\\net8.0\\ConsoleApplicationLearnEFCoreMigration.dll";
                Assembly externalDll = Assembly.LoadFrom(assemblyPath);
                Type[] externalDllTypes = externalDll.GetTypes();
                foreach (Type t in externalDllTypes)
                {
                    Console.WriteLine($"---------------------------------------------------");
                    Console.WriteLine($"type: {t.FullName}\n");

                    //var myMemberInfo = t.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                    //var myMemberInfo = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);  这里的参数起过滤
                    var tMemberInfo = t.GetMembers(); //Member 成员

                    for (int i = 0; i < tMemberInfo.Length; i++)
                    {
                        // Display name and type of the member of 'MyClass'.
                        Console.WriteLine($"'{tMemberInfo[i].Name}' is a {tMemberInfo[i].MemberType}");
                    }
                    Console.WriteLine();

                    // 获取所有构造函数
                    ConstructorInfo[] tconstructorsInfo = t.GetConstructors();

                    foreach (var ctor in tconstructorsInfo)
                    {
                        // 获取构造函数的参数
                        ParameterInfo[] parameters = ctor.GetParameters();

                        Console.WriteLine($"Constructor: {ctor.Name}");
                        foreach (var param in parameters)
                        {
                            Console.WriteLine($" - Parameter: {param.Name} of Type: {param.ParameterType}");
                        }
                    }


                }



                Console.ReadKey();
            }
        }
    }
}
