using Newtonsoft.Json;

namespace AvaTradeMobile
{
    public class FW
    {

        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");
        public static FwConfig Config => _configuration ?? throw new NullReferenceException("_configuration is null. Call FW.SetConfig() first");

        private static FwConfig _configuration;

        public static void SetConfig()
        {
            if(_configuration == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/AvaTrade/config.json");
                _configuration = JsonConvert.DeserializeObject<FwConfig>(jsonStr);
            }
        }
    }
}
