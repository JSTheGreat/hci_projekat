using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Users
    {
        public List<User> users;

        public Users(List<User> users)
        {
            this.users = users;
        }

        public bool userExists(User user)
        {
            foreach(User u in this.users)
            {
                if (user.username.Equals(u.username) && user.password.Equals(u.password))
                    return true;
            }
            return false;
        }
    }
}
