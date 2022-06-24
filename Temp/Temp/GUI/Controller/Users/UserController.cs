using System.Collections.Generic;
using Temp.Core.Users.Model;
using Temp.Core.Users.Service;

namespace Temp.GUI.Controller.Users
{
    public class UserController
    {
        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public List<User> Users { get => userService.Users; }

        public void Add(User user)
        {
            userService.Add(user);
        }

        public User FindByJmbg(string jmbg)
        {
            return userService.FindByJmbg(jmbg);
        }

        public void Load()
        {
            userService.Load();
        }

        public void Serialize()
        {
            userService.Serialize();
        }

    }
}
