using MongoDB.Bson;

namespace passstore
{
    public abstract class UserBase
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string MasterPassword { get; set; }
        public string Salt { get; set; }

        /// <summary>
        /// Get user requires Username is set on the user object
        /// </summary>
        public abstract UserBase GetUser(string username);

        /// <summary>
        /// Auth requires Username and Password is set on the user object
        /// </summary>
        public void Auth()
        {
            var user = GetUser(Username);

            if (user != null)
            {
                MasterPassword = new Hash().HashPassword(MasterPassword, user.Salt);

                if (MasterPassword == user.MasterPassword)
                {
                    _id = user._id;
                    Username = Username;
                    Name = Crypto.Decrypt(user.Name, user.MasterPassword);
                    Salt = user.Salt;
                }
                else
                {
                    MasterPassword = null;
                }
            }
            else
            {
                MasterPassword = null;
            }
        }
    }
}
