using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Json
{
    public class JsonMain
    {
        Person p = new Person { Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
        public JsonMain()
        {
            //DefaultValueHandlingFunction();
            LimitPropsContractResolverFunction();
            Console.ReadLine();
        }

        public void DefaultValueHandlingFunction()
        {
           
            JsonSerializerSettings jsetting = new JsonSerializerSettings();

            jsetting.DefaultValueHandling = DefaultValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
        }

        public void LimitPropsContractResolverFunction()
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.ContractResolver = new LimitPropsContractResolver(new string[] { "Age",  },false);
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
        }

        public void DefaultSettingsFunction()
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //高级用法九中的Bool类型转换 设置
                setting.Converters.Add(new BoolConvert("是,否"));

                return setting;
            });
        }
    }

    
}
