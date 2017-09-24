using System;
using System.Collections.Generic;

namespace Lection_12
{
    class DatabaseOfUsers
    {
        public List<User> users;

        public DatabaseOfUsers()
        {
            this.users = new List<User>();
        }
        public DatabaseOfUsers(User user)
        {
            this.users = new List<User>(); ;
            users.Add(user);
        }

        public string ValidateUser(IUser user)
        {
            foreach (User dbUser in users)
            {
                if (dbUser.ValidateUser(user))
                {
                    return "\nUser was found \n"+ dbUser.GetFullInfo();
                }
            }
            var newUser = new User(user);
            users.Add(newUser);

            return "\nNew user was added \nInfo: "+newUser.GetFullInfo();
        }

        public void PrintAllUsersInfo()
        {
            Console.WriteLine("Printing users::");
            foreach (User user in users)
            {
                Console.WriteLine("\n {0} \n",user.GetFullInfo());
            }
        }
    }
}
