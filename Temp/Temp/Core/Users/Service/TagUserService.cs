using System.Collections.Generic;
using Temp.Core.Users.Model;
using Temp.Core.Users.Repository;

namespace Temp.Core.Users.Service
{
    public class TagUserService : ITagUserService
    {
        ITagUserRepo tagUserRepo;

        public TagUserService(ITagUserRepo tagUserRepo)
        {
            this.tagUserRepo = tagUserRepo;
        }

        public List<TagUser> TagUsers { get => tagUserRepo.TagUsers; }

        public void Add(TagUser tagUser)
        {
            tagUserRepo.Add(tagUser);
        }

        public TagUser FindByJmbg(string jmbg)
        {
            return tagUserRepo.FindByJmbg(jmbg);
        }

        public void Load()
        {
            tagUserRepo.Load();
        }

        public void Serialize()
        {
            tagUserRepo.Serialize();
        }
    }
}
