using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Repository
{
    public class UserRepo : IUserRepo
    {
        List<User> users;
        string path;

        public List<User> Users { get => users; }

        public UserRepo()
        {
            path = "../../../Data/Users.json";
            Load();
        }

        public void Load()
        {
            users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string usersJson = JsonSerializer.Serialize(users,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, usersJson);
        }

        public User FindByJmbg(string jmbg)
        {
            foreach (User user in users)
                if (user.Jmbg == jmbg)
                    return user;

            return null;
        }

        public void Add(User user)
        {
            users.Add(user);
            Serialize();
        }
    }
}
