using System.Collections.Generic;
using Temp.Core.Users.Model;
using Temp.Core.Users.Repository;

namespace Temp.Core.Users.Service
{
    public class UserService : IUserService
    {
        IUserRepo userRepo;

        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<User> Users { get => userRepo.Users; }

        public void Add(User user)
        {
            userRepo.Add(user);
        }

        public User FindByJmbg(string jmbg)
        {
            return userRepo.FindByJmbg(jmbg);
        }

        public void Load()
        {
            userRepo.Load();
        }

        public void Serialize()
        {
            userRepo.Serialize();
        }
    }
}
