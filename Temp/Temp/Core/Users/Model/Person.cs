using System.Text.Json.Serialization;
using Temp.Core.Locations.Model;

namespace Temp.Core.Users.Model
{
    public abstract class Person
    {
        protected string jmbg;
        protected string name;
        protected string lastName;
        protected string phone;
        protected string mail;
        protected Adress adress;

        public Person() { }

        public Person(string jmbg, string name, string lastName, string phone, string mail, Adress adress)
        {
            this.jmbg = jmbg;
            this.name = name;
            this.lastName = lastName;
            this.phone = phone;
            this.mail = mail;
            this.adress = adress;
        }

        [JsonPropertyName("jmbg")]
        public string Jmbg { get => jmbg; set => jmbg = value; }

        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }

        [JsonPropertyName("lastName")]
        public string LastName { get => lastName; set => lastName = value; }

        [JsonPropertyName("phone")]
        public string Phone { get => phone; set => phone = value; }

        [JsonPropertyName("mail")]
        public string Mail { get => mail; set => mail = value; }

        [JsonPropertyName("adress")]
        public Adress Adress { get => adress; set => adress = value; }

    }
}
