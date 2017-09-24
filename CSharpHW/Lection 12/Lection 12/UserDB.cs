using System;
using System.Text;


namespace Lection_12
{
    class User : IUser, IValidator
    {
        
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public DateTime LastEnter { get; private set; }

        public User() { }

        public User(IUser user)
        {
            this.Name = user.Name;
            this.Password = user.Password;
            this.Email = user.Email;

            this.LastEnter = DateTime.Now;
        }
        public User(string name, string password, string email)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;

            this.LastEnter = DateTime.Now;
        }

        public string GetFullInfo()
        {
            var info = new StringBuilder();

            info.Append("User:" + Name + " Email: " + Email + "\n LastEnter to the system: " + LastEnter);

            return info.ToString();
        }

        public bool ValidateUser(IUser user)
        {
            if (this.Name.Equals(user.Name) && this.Password.Equals(user.Password))
            {
                this.LastEnter = DateTime.Now;
                return true;
            }
            else if (this.Email.Equals(user.Email) && this.Password.Equals(user.Password))
            {
                this.LastEnter = DateTime.Now;
                return true;
            }
            else return false;
        }
    }
}
