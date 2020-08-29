using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore
{
    public class BaseProduct
    {

        public DateTime dateOfDelivery { get; private set; }
        public int countDayToExpirationDate { get; private set; }

        public BaseProduct(DateTime dateOfDelivery, int countDayToExpirationDate)
        {
            this.dateOfDelivery = dateOfDelivery;
            this.countDayToExpirationDate = countDayToExpirationDate;
        }

        public DateTime ShowExpirationDate()
        {
            DateTime finalDate = dateOfDelivery;

            return finalDate.AddDays(countDayToExpirationDate);
        }
    }
}
