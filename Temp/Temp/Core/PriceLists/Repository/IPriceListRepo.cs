using System.Collections.Generic;
using Temp.Core.PriceLists.Model;

namespace Temp.Core.PriceLists.Repository
{
    public interface IPriceListRepo
    {
        List<PriceList> PriceLists { get; }

        PriceList FindById(int id);

        int GenerateId();
        
        void Load();
        
        void Serialize();

        void Add(PriceList priceList);
    }
}