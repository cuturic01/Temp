using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Temp.Core.PriceLists.Model
{
    public class PriceList
    {
        int id;
        DateTime startDate;
        List<Price> prices;

        public PriceList()
        {
            prices = new List<Price>();
        }

        public PriceList(int id, DateTime startDate, List<Price> prices)
        {
            this.id = id;
            this.startDate = startDate;
            this.prices = prices;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get => startDate; set => startDate = value; }

        [JsonPropertyName("prices")]
        public List<Price> Prices { get => prices; set => prices = value; }

        public override string ToString()
        {
            return "PriceList[id: " + id + ", startDate: " + startDate
                + "prices: " + prices + "]";
        }
    }
}
