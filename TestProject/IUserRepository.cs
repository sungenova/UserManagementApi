using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiModels;

namespace UserApiWeb
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(string iin);
        User Get(string iin);
        List<User> GetUsers();
        void Update(User user);
    }
}
