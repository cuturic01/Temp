using System;
using System.Collections.Generic;
using Temp.Core.Payments.Model;
using Temp.Core.Payments.Repository;
using Temp.Core.PriceLists.Service;
using Temp.Core.TollStations.Service;

namespace Temp.Core.Payments.Service
{
    public interface IPaymentService
    {
        List<Payment> Payments { get; }

        public IPriceListService PriceListService { get; }

        public IPaymentRepo PaymentRepo { get; }

        public ITollStationService TollStationService { get; }

        void Add(Payment payment);

        Payment FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        float CheckSpeed(Payment payment, float distance);

        Tuple<float, float> FindSumOfPayments(int tollStationId, DateTime start, DateTime end);

        Tuple<float, float> FindSumOfPayments(DateTime start, DateTime end);
    }
}