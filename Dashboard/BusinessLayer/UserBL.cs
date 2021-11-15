using System.Linq;
using EntityLayer;
using System.Text;
using SecurityLayer;
using DataAccessLayer;
using System.Collections.Generic;


namespace BusinessLayer
{
    public class UserBL
    {
        #region Patron Singleton
        private static UserBL businessUser = null;
        private UserBL() { }

        public static UserBL getInstance() {
            return businessUser == null ? new UserBL() : businessUser;
        }
        #endregion

        public User searchUSer(string name) {
            return AccessUserData.getInstance().readerUser(new Dictionary<object, object> { {"@name", name} });
        }

        public bool isValidUser(string name, string password) {
            var user = searchUSer(name);

            if (!string.IsNullOrEmpty(user.Name)){
                byte[] hashPassword = Encryptation.HashPasswordWithSeed(Encoding.UTF8.GetBytes(password), user.Seed);

                if (hashPassword.SequenceEqual(user.Password)) {
                    return true;
                }                
            }
            return false;
        }
    }
}
