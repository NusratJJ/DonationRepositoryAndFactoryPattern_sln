using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Factory
{
    public class DonationManagementFactory
    {
        public BaseDonationFactory CreateFactory(Donation don)
        {
            BaseDonationFactory returnValue = null;

            if (don.Type == DonationType.Permanent)
            {
                returnValue = new PermanentDonationFactory(don);
            }
            else if (don.Type == DonationType.Temporary)
            {
                returnValue = new TemporaryDonationFactory(don);
            }
            else
            {
                throw new ArgumentException("Invalid DonationType");
            }

            return returnValue;
        }
    }
}
