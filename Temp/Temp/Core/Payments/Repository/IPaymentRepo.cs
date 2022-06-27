using System.Collections.Generic;
using Temp.Core.Payments.Model;

namespace Temp.Core.Payments.Repository
{
    public interface IPaymentRepo
    {
        List<Payment> Payments { get; }

        int GenerateId();

        Payment FindById(int id);

        void Load();

        void Serialize();

        void Add(Payment payment);
    }
}