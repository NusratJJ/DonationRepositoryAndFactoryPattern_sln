using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Factory
{
    public class TemporaryDonationFactory : BaseDonationFactory
    {
        public TemporaryDonationFactory(Donation don) : base(don) { }

        public override IDonationManager Create()
        {
            TemporaryDonationManager manager = new TemporaryDonationManager();
            _don.WelcomeMessage = manager.GetWelcomeMessage();
            return manager;
        }
    }
}
