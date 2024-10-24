using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute.Source
{
    [MyCustomAttribute("这是一个示例类 特性是一种元数据的标记方式")]
    public class SampleClass
    {
        [MyCustomAttribute("这是一个示例方法")]
        public void SampleMethod()
        {
            // 方法逻辑
        }
    }
}
