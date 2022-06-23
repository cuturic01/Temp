using System.Text.Json.Serialization;
using Temp.Core.Locations.Model;

namespace Temp.Core.Users.Model
{
    public class User : Person
    {
        UserType userType;
        Account account;

        public User() { }

        public User(string jmbg, string name, string lastName, string phone, string mail, Adress adress,
            UserType userType, Account account) : base(jmbg, name, lastName, phone, mail, adress)
        {
            this.userType = userType;
            this.account = account;
        }

        [JsonPropertyName("userType")]
        public UserType UserType { get => userType; set => userType = value; }

        [JsonPropertyName("account")]
        public Account Account { get => account; set => account = value; }

        public override string ToString()
        {
            return "User[jmbg: " + jmbg + ", name: " + name + ", lastName: " + lastName + ", phone: " + phone +
                ", mail: " + mail + ", adress: " + adress.ToString() + ", userType" + userType.ToString()
                + ", account: " + account.ToString() + "]";
        }
    }
}
