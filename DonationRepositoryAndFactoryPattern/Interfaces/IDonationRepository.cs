using DonationRepositoryAndFactoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Interfaces
{
    public interface IDonationRepository
    {
        IEnumerable<Donation> GetAllDonations();
        Donation GetDonationById(int id);
        Donation CreateDonation(Donation donation);
        Donation UpdateDonation(Donation donation);
        Donation DeleteDonation(int id);
    }
}
