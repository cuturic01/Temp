using System;
using System.Collections.Generic;
using Temp.Core.PriceLists.Model;
using Temp.Core.PriceLists.Service;

namespace Temp.GUI.Controller.PriceLists
{
    public class PriceListController
    {
        IPriceListService priceListService;

        public PriceListController(IPriceListService priceListService)
        {
            this.priceListService = priceListService;
        }

        public List<PriceList> PriceLists { get => priceListService.PriceLists; }

        public void Add(PriceList priceList)
        {
            priceListService.Add(priceList);
        }

        public PriceList FindById(int id)
        {
            return priceListService.FindById(id);
        }

        public int GenerateId()
        {
            return priceListService.GenerateId();
        }

        public void Load()
        {
            priceListService.Load();
        }

        public void Serialize()
        {
            priceListService.Serialize();
        }

        public Price GetPriceBySectionId(int sectionId, VehicleType vt)
        {
            return priceListService.GetPriceBySectionId(sectionId, vt);
        }

        public PriceList GetActive(DateTime date)
        {
            return priceListService.GetActive(date);
        }
    }
}
