using System;
using System.Collections.Generic;
using Temp.Core.Payments.Model;
using Temp.Core.Payments.Service;

namespace Temp.GUI.Controller.Payments
{
    public class PaymentController
    {
        IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public List<Payment> Payments { get => paymentService.Payments; }

        public void Add(Payment payment)
        {
            paymentService.Add(payment);
        }

        public Payment FindById(int id)
        {
            return paymentService.FindById(id);
        }

        public int GenerateId()
        {
            return paymentService.GenerateId();
        }
       
        public void Load()
        {
            paymentService.Load();
        }

        public void Serialize()
        {
            paymentService.Serialize();
        }

        public float CheckSpeed(Payment payment, float distance)
        {
            return paymentService.CheckSpeed(payment, distance);
        }

        public Tuple<float, float> FindSumOfPayments(int tollStationId, DateTime start, DateTime end)
        {
            return paymentService.FindSumOfPayments(tollStationId, start, end);
        }

        public Tuple<float, float> FindSumOfPayments(DateTime start, DateTime end)
        {
            return paymentService.FindSumOfPayments(start, end);
        }
    }
}
