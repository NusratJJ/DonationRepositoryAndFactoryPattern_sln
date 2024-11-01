using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DonationRepositoryAndFactoryPattern.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private List<Donation> donationList;

        public DonationRepository()
        {
            
            donationList = new List<Donation>()
            {
                new Donation() { Id = 1, Name = "Nusrat", Amount = 20000, CollecctedBy = "John Doe",
                    Project = Enums.Project.SolarScholars, Type = Enums.DonationType.Permanent, Description = "Powering school with solar panels" },
                new Donation() { Id = 2, Name = "Victor Gomez", Amount = 5000, CollecctedBy = "Joseph Hardy",
                    Project = Enums.Project.CreekCleanup, Type = Enums.DonationType.Temporary, Description = "Purchasing and preserving land in the watershed" }
            };
        }

        public Donation CreateDonation(Donation donation)
        {
            Donation existingDonation = donationList.OrderByDescending(d => d.Id).FirstOrDefault();
            donation.Id = (existingDonation != null) ? existingDonation.Id + 1 : 1; // Auto-generate next ID
            donationList.Add(donation);
            return donation;
        }

        public Donation DeleteDonation(int id)
        {
            Donation donation = GetDonationById(id);
            if (donation != null)
            {
                donationList.Remove(donation);
            }
            return donation;
        }

        public IEnumerable<Donation> GetAllDonations()
        {
            return donationList;
        }

        public Donation GetDonationById(int id)
        {
            return donationList.SingleOrDefault(d => d.Id == id);
        }

        public Donation UpdateDonation(Donation updatedDonation)
        {
            Donation donation = GetDonationById(updatedDonation.Id);
            if (donation != null)
            {
                donation.Name = updatedDonation.Name;
                donation.Amount = updatedDonation.Amount;
                donation.CollecctedBy = updatedDonation.CollecctedBy;
                donation.Project = updatedDonation.Project;
                donation.Type = updatedDonation.Type;
                donation.Description = updatedDonation.Description;
            }
            return donation;
        }
    }
}
