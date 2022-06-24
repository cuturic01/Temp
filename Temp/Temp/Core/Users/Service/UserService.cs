using System.Collections.Generic;
using Temp.Core.Users.Model;
using Temp.Core.Users.Repository;

namespace Temp.Core.Users.Service
{
    public class UserService : IUserService
    {
        IUserRepo userRepo;
        IBossService bossService;

        public UserService(IUserRepo userRepo, IBossService bossService)
        {
            this.userRepo = userRepo;
            this.bossService = bossService;
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

        public User Login(string username, string password)
        {
            foreach (User user in Users)
                if (user.Account.Username == username && user.Account.Password == password)
                    return user;

            foreach (Boss boss in bossService.Bosses)
                if (boss.Account.Username == username && boss.Account.Password == password)
                    return boss;

            return null;
        }
    }
}
