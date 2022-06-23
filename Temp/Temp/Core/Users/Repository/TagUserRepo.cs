using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Repository
{
    public class TagUserRepo : ITagUserRepo
    {
        List<TagUser> tagUsers;
        string path;

        public List<TagUser> TagUsers { get => tagUsers; }

        public TagUserRepo()
        {
            path = "../../../Data/TagUsers.json";
            Load();
        }

        public void Load()
        {
            tagUsers = JsonSerializer.Deserialize<List<TagUser>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string tagUsersJson = JsonSerializer.Serialize(tagUsers,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, tagUsersJson);
        }

        public TagUser FindByJmbg(string jmbg)
        {
            foreach (TagUser tagUser in tagUsers)
                if (tagUser.Jmbg == jmbg)
                    return tagUser;

            return null;
        }

        public void Add(TagUser tagUser)
        {
            tagUsers.Add(tagUser);
            Serialize();
        }
    }
}
