using System.Text.Json.Serialization;

namespace Temp.Core.Users.Model
{
    public class Account
    {
        string username;
        string password;

        public Account() { }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [JsonPropertyName("username")]
        public string Username { get => username; set => username = value; }

        [JsonPropertyName("password")]
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return "Accoutn[username: " + username + ", password: " + password + "]";
        }
    }
}
