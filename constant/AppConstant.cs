using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews
{
    public class AppConstant
    {

        public class DEFINE_TEXT
        {
            public static string C_AND_C_PLUS_PLUS = "C/C++";
            public static string JAVA = "Java";
            public static string PYTHON = "Python";
            public static string C_SHAP = "C#";
            public static string RUBY = "Ruby";
            public static string JAVASCRIPT = "Javascript";
            public static string CSS = "Css";
            public static string PHP = "Php";
            public static string GO = "Go";
            public static string SWIFT = "Swift";
            public static string HTML = "Html";
            public static string BACK_LINK = "Backlink";
            public static string WRITE_CONTENT = "Viết Content";
            public static string GOOGLE_ADS = "Google Ads";
            public static string SEO = "SEO";
        }


        public class JSON
        {
            public static string ConfiguratingJson<T> (T obj)
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                return JsonConvert.SerializeObject(obj, settings);
            }
        }
    }
}