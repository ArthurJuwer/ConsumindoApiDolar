using Newtonsoft.Json;

namespace ConsumindoApi
{
    public class Market
    {
        // propriedades finais 
        // nivel 1

        public Market()
        {
            this.Currency = new Currency();
            // toda vez que estaciar currency, estancia o Currency
        }
        [JsonProperty(PropertyName = "currencies")]
        public Currency Currency { get; set; }
        // Currency classe criada
    }
}
