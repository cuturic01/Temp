using System.Text.Json.Serialization;
using Temp.Core.Tags.Model;

namespace Temp.Core.Users.Model
{
    class TagUser : Person
    {
        Tag tag;

        public TagUser() { }

        public TagUser(string jmbg, string name, string lastName, string phone, string mail, Adress adress,
            Tag tag) : base(jmbg, name, lastName, phone, mail, adress)
        {
            this.tag = tag;
        }

        [JsonPropertyName("tag")]
        internal Tag Tag { get => tag; set => tag = value; }

        public override string ToString()
        {
            return "TagUser[jmbg: " + jmbg + ", name: " + name + ", lastName: " + lastName + ", phone: " + phone +
                ", mail: " + mail + ", adress: " + adress.ToString() + ", tag: " + tag.ToString() + "]";
        }
    }
}
