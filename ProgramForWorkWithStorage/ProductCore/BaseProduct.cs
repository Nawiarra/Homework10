using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore
{
    public class BaseProduct
    {

        public DateTime dateOfDelivery { get; set; }
        public int countDayToExpirationDate { get; set; }

        public DateTime ShowExpirationDate()
        {
            DateTime finalDate = dateOfDelivery;

            return finalDate.AddDays(countDayToExpirationDate);
        }
    }
}
