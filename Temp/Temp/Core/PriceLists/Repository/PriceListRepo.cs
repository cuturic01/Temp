using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.PriceLists.Model;

namespace Temp.Core.PriceLists.Repository
{
    public class PriceListRepo : IPriceListRepo
    {
        List<PriceList> priceLists;
        string path;

        public List<PriceList> PriceLists { get => priceLists; }

        public PriceListRepo()
        {
            path = "../../../Data/PriceLists.json";
            Load();
        }

        public void Load()
        {
            priceLists = JsonSerializer.Deserialize<List<PriceList>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string priceListsJson = JsonSerializer.Serialize(priceLists,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, priceListsJson);
        }

        public int GenerateId()
        {
            return priceLists[^1].Id + 1;
        }

        public PriceList FindById(int id)
        {
            foreach (PriceList priceList in priceLists)
                if (priceList.Id == id)
                    return priceList;

            return null;
        }

        public void Add(PriceList priceList)
        {
            priceLists.Add(priceList);
            Serialize();
        }
    }
}
