using System.Collections.Generic;
using Temp.Core.Payments.Model;
using Temp.Core.Payments.Repository;
using System;
using Temp.Core.PriceLists.Model;
using Temp.Core.PriceLists.Service;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Service;

namespace Temp.Core.Payments.Service
{
    public class PaymentService : IPaymentService
    {
        IPaymentRepo paymentRepo;
        private IPriceListService priceListService;
        private ITollStationService tollStationService;

        public PaymentService(IPaymentRepo paymentRepo, IPriceListService priceListService, ITollStationService tollStationService)
        {
            this.paymentRepo = paymentRepo;
            this.priceListService = priceListService;
            this.tollStationService = tollStationService;
        }

        public List<Payment> Payments { get => paymentRepo.Payments; }

        public IPaymentRepo PaymentRepo => paymentRepo;

        public IPriceListService PriceListService => priceListService;

        public ITollStationService TollStationService => tollStationService;

        public int GenerateId()
        {
            return paymentRepo.GenerateId();
        }

        public Payment FindById(int id)
        {
            return paymentRepo.FindById(id);
        }

        public void Load()
        {
            paymentRepo.Load();
        }

        public void Serialize()
        {
            paymentRepo.Serialize();
        }

        public void Add(Payment payment)
        {
            paymentRepo.Add(payment);
        }

        public float CheckSpeed(Payment payment, float distance)
        {
            TimeSpan ts = payment.ExitDate - payment.EntranceDate;
            float myTime = ts.Hours * 60 + ts.Minutes;

            float speedLimit = 120 / 60;  //km per minut
            float minTime = distance / speedLimit;


            return minTime - myTime;
        }

        public Tuple<float,float> FindSumOfPayments(int tollStationId, DateTime start, DateTime end)
        {
            float sumDin = 0;
            float sumEur = 0;
            foreach (Payment payment in Payments)
            {
                if (payment.StationId == tollStationId && payment.ExitDate>start && payment.ExitDate<end)
                {
                    Price price = priceListService.GetPriceBySectionId(payment.SectionId, payment.VehicleType);
                    sumDin += price.PriceDin;
                    sumEur += price.PriceEur;
                }
            }

            return Tuple.Create(sumDin, sumEur);
        }

        public Tuple<float, float> FindSumOfPayments(DateTime start, DateTime end)
        {
            float sumDin = 0;
            float sumEur = 0;
            foreach (TollStation tollStation in tollStationService.TollStations)
            {
                Tuple<float, float> price = FindSumOfPayments(tollStation.Id, start, end);
                sumDin += price.Item1;
                sumEur += price.Item2;
            }

            return Tuple.Create(sumDin, sumEur);
        }


    }
}
