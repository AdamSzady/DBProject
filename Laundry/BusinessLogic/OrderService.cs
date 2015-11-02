using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class OrderService
    {
        private LaundryEntities DBContext;
        public OrderService()
        {
            DBContext = new LaundryEntities();
        }
        public OrderService(LaundryEntities dbContext)
        {
            this.DBContext = dbContext;
        }


    }
}
