using System;
using System.Text.Json.Serialization;

namespace Temp.Core.SpeedingPenalties.Model
{
    public class SpeedingPenalty
    {
        int id;
        int paymentId;
        DateTime date;
        float overdraft;

        public SpeedingPenalty() { }

        public SpeedingPenalty(int id, int paymentId, DateTime date, float overdraft)
        {
            this.id = id;
            this.paymentId = paymentId;
            this.date = date;
            this.overdraft = overdraft;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("paymentId")]
        public int PaymentId { get => paymentId; set => paymentId = value; }

        [JsonPropertyName("date")]
        public DateTime Date { get => date; set => date = value; }

        [JsonPropertyName("overdraft")]
        public float Overdraft { get => overdraft; set => overdraft = value; }

        public override string ToString()
        {
            return "SpeedingPenalty[id: " + id + ", paymentId: " + paymentId
                + ", date: " + date.ToString("dd-MM-yyyy") + ", overdraft: " + overdraft + "]";
        }
    }
}
