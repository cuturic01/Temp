using System.Collections.Generic;
using Temp.Core.Payments.Model;

namespace Temp.Core.Payments.Service
{
    public interface IPaymentService
    {
        List<Payment> Payments { get; }

        void Add(Payment payment);

        Payment FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        bool CheckSpeed(Payment payment, float distance);
    }
}