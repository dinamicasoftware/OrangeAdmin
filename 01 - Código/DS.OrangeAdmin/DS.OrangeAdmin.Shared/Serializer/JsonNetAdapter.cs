using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aq.ExpressionJsonSerializer;
using System.Reflection;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Shared.Serializer
{
    public static class JsonNetAdapter
    {
        private static readonly JsonSerializerSettings _settings;

        static JsonNetAdapter()
        {
            var defaultSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
            defaultSettings.Converters.Add(new ExpressionJsonConverter(Assembly.GetAssembly(typeof(IClient))));
            _settings = defaultSettings;
        }

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj, _settings);

        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json, _settings);
    }
}
