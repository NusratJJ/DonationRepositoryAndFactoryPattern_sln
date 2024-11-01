using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Factory
{
    public abstract class BaseDonationFactory
    {
        
        
            protected Donation _don;

            public BaseDonationFactory(Donation don)
            {
                _don = don;
            }

            public abstract IDonationManager Create();

            public Donation ApplyDonation()
            {
                IDonationManager manager = this.Create();
                _don.Amount = manager.GetAmount();
                return _don;
            }
        
    }
}
