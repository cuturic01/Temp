using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Payments.Model;

namespace Temp.Core.Payments.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        List<Payment> payments;
        string path;

        public PaymentRepo()
        {
            path = "../../../Data/Payments.json";
            Load();
        }

        public List<Payment> Payments { get => payments; }

        public void Load()
        {
            payments = JsonSerializer.Deserialize<List<Payment>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string paymentsJson = JsonSerializer.Serialize(payments,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, paymentsJson);
        }

        public int GenerateId()
        {
            return payments[^1].Id + 1;
        }

        public Payment FindById(int id)
        {
            foreach (Payment payment in payments)
                if (payment.Id == id)
                    return payment;

            return null;
        }

        public void Add(Payment payment)
        {
            payments.Add(payment);
            Serialize();
        }
    }
}
