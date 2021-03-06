using System;
using System.Collections.Generic;
using Temp.Core.PriceLists.Model;

namespace Temp.Core.PriceLists.Service
{
    public interface IPriceListService
    {
        List<PriceList> PriceLists { get; }

        void Add(PriceList priceList);

        PriceList FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        Price GetPriceBySectionId(int sectionId, VehicleType vt);

        List<PriceList> SortedByStartDate();

        PriceList GetActive(DateTime date);

        List<Price> GetPricesBySection(int sectionId);
    }
}