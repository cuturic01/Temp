using System.Collections.Generic;
using Temp.Core.Payments.Model;
using Temp.Core.Payments.Repository;
using System;

namespace Temp.Core.Payments.Service
{
    public class PaymentService : IPaymentService
    {
        IPaymentRepo paymentRepo;

        public PaymentService(IPaymentRepo paymentRepo)
        {
            this.paymentRepo = paymentRepo;
        }

        public List<Payment> Payments { get => paymentRepo.Payments; }

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

        public bool CheckSpeed(Payment payment, float distance)
        {
            int minTime = (payment.ExitDate - payment.EntranceDate).Minutes;
            Console.WriteLine(minTime);

            float speedLimit = 120 / 60;  //km per minut
            float myTime = distance / speedLimit;
            Console.WriteLine(myTime);


            if (myTime < minTime)
            {
                return true;
            }

            return false;
        }

    }
}
