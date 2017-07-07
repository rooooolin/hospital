using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Model
{
    public class JsonHelper
    {
        public JsonHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public static string GetJson<T>(T obj)
    {
       
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            json.WriteObject(ms, obj);
            string szJson = Encoding.UTF8.GetString(ms.ToArray());
            return szJson;
        }
    }
    
    protected static T GetObject<T>()
    {
        if (typeof(T).IsValueType || typeof(T) == typeof(string))
        {
            return default(T);
        }
        else
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
    public static T ParseFormJson<T>(string szJson)
    {
        T obj = GetObject<T>();
        using (MemoryStream ms = new MemoryStream (Encoding.UTF8.GetBytes(szJson)))
        {
            DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
            return (T)dcj.ReadObject(ms);
        }
    }
    }
}
