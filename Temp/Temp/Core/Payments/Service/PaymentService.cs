﻿using System.Collections.Generic;
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

        public float CheckSpeed(Payment payment, float distance)
        {
            int myHours = (payment.ExitDate - payment.EntranceDate).Hours;
            int myMinutes = (payment.ExitDate - payment.EntranceDate).Minutes;
            float myTime = myHours * 60 + myMinutes;

            float speedLimit = 120 / 60;  //km per minut
            float minTime = distance / speedLimit;


            return minTime - myTime;
   

        }

    }
}
