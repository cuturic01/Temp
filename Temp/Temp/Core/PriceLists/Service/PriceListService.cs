using System;
using System.Collections.Generic;
using System.Linq;
using Temp.Core.PriceLists.Model;
using Temp.Core.PriceLists.Repository;

namespace Temp.Core.PriceLists.Service
{
    public class PriceListService : IPriceListService
    {
        IPriceListRepo priceListRepo;

        public PriceListService(IPriceListRepo priceListRepo)
        {
            this.priceListRepo = priceListRepo;
        }

        public List<PriceList> PriceLists { get => priceListRepo.PriceLists; }

        public PriceList FindById(int id)
        {
            return priceListRepo.FindById(id);
        }

        public int GenerateId()
        {
            return priceListRepo.GenerateId();
        }

        public void Load()
        {
            priceListRepo.Load();
        }

        public void Serialize()
        {
            priceListRepo.Serialize();
        }

        public void Add(PriceList priceList)
        {
            priceListRepo.Add(priceList);
        }

        public Price GetPriceBySectionId(int sectionId, VehicleType vt)
        {

            foreach(Price price in PriceLists[0].Prices)
            {
                if (price.SectionId == sectionId && price.VehicleType1 == vt)
                    return price;
            }

            return null;
        }

        public List<PriceList> SortedByStartDate()
        {
            return priceListRepo.PriceLists.OrderByDescending(x => x.StartDate).ToList();
        }

        public PriceList GetActive(DateTime date)
        {
            foreach (PriceList priceList in SortedByStartDate())
            {
                if (priceList.StartDate <= date) return priceList;
            }
            return null;
        }

        public List<Price> GetPricesBySection(int sectionId)
        {
            PriceList activePriceList = GetActive(DateTime.Today);
            List<Price> prices = new();
            foreach (Price price in activePriceList.Prices)
            {
                if (price.SectionId == sectionId) prices.Add(price);
            }
            return prices;
        }
    }
}
