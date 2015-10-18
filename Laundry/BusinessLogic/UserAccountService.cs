using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class UserAccountService
    {
        private LaundryEntities dbContext;

        public UserAccountService()
        {
            dbContext = new LaundryEntities();
        }

        public void SetPhone(string phone, string userId)
        {
            var user = dbContext.AspNetUsers.Find(userId);
            user.PhoneNumber = phone;

            dbContext.SaveChanges();
        }
    }
}
