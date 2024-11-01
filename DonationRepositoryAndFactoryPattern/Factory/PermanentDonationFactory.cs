using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Factory
{
    public class PermanentDonationFactory : BaseDonationFactory
    {

        public PermanentDonationFactory(Donation don) : base(don) { }

        public override IDonationManager Create()
        {
            PermanentDonationManager manager = new PermanentDonationManager();
            _don.WelcomeMessage = manager.GetWelcomeMessage();
            return manager;
        }
    }
}
