using Newtonsoft.Json;

namespace ConsumindoApi
{   
    public class Currency
    {
        // subpropriedades
        // nivel 2

        [JsonProperty(PropertyName = "name")] // nome da propriedade do Json
        public string Name { get; set; }

        [JsonProperty(PropertyName = "buy")] // nome da propriedade do Json
        public decimal Buy { get; set; }

        [JsonProperty(PropertyName = "sell")] // nome da propriedade do Json
        public decimal Sell { get; set; }

        [JsonProperty(PropertyName = "variation")] // nome da propriedade do Json
        public decimal Variation { get; set; }
    }
}
