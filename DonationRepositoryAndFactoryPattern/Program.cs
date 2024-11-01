using DonationRepositoryAndFactoryPattern.Entities;
using DonationRepositoryAndFactoryPattern.Enums;
using DonationRepositoryAndFactoryPattern.Factory;
using DonationRepositoryAndFactoryPattern.Repository;
using DonationRepositoryAndFactoryPattern.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonationRepositoryAndFactoryPattern
{
    internal class Program
    {
        static DonationRepository repo = new DonationRepository();
        static TemporaryDonationManager temporaryDonationManager = new TemporaryDonationManager();
        static PermanentDonationManager permanentDonationManager = new PermanentDonationManager();

        static void Main(string[] args)
        {
            try
            {
                Dotask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void Dotask()
        {
            Console.WriteLine("----Round:61------");
            Console.WriteLine("----ID:1284630----");
            Console.WriteLine("Name:Mst.Nusrat Jahan Jisa");
            Console.WriteLine("\t\t\t\t\tDonation Management\r");
            Console.WriteLine("\t\t\t\t\t-----------------\n");
            Console.WriteLine("----Donation Information------");

            LoadFixedDonation();

            Console.WriteLine("\t\t\t\t\tHow many operations to perform?\n");
            int count = Convert.ToInt32(Console.ReadLine());

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("\t\t\tSelect Operation\n1. Show All\n2. Create\n3. Update\n4. Delete");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            ShowAllDonations();
                            break;
                        case 2:
                            CreateNewDonation();
                            break;
                        case 3:
                            UpdateDonation();
                            break;
                        case 4:
                            DeleteDonation();
                            break;
                        default:
                            ShowAllDonations();
                            break;
                    }
                }
            }
        }

        private static void LoadFixedDonation()
        {
            Donation don = new Donation(1, "Jisa", 56000, "Danial", Project.SolarScholars, DonationType.Permanent, "This is for solar scholars project.");

            BaseDonationFactory donFactory;
            if (don.Type == DonationType.Permanent)
            {
                donFactory = new PermanentDonationFactory(don);
            }
            else
            {
                donFactory = new TemporaryDonationFactory(don);
            }
            Donation appliedDonation = donFactory.ApplyDonation();

            Console.WriteLine($"Donation Processed: {appliedDonation.Amount}");
            Donation newDonation = repo.CreateDonation(appliedDonation);

            Console.WriteLine($"New Donation Created: {newDonation.Name}, Amount: {newDonation.Amount}");
        }

        private static void CreateNewDonation()
        {
            Donation donation = new Donation();

            Console.WriteLine("Enter Name: ");
            donation.Name = Console.ReadLine();

            Console.WriteLine("Enter Amount: ");
            donation.Amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Collected By: ");
            donation.CollecctedBy = Console.ReadLine();

            Console.WriteLine("Enter Project: (SolarScholars_1, CreekCleanup_2, LandTrust_3, ForestAsia_4)");
            int projectInput = Convert.ToInt32(Console.ReadLine());
            donation.Project = (Project)projectInput;

            Console.WriteLine("Enter Type: (Permanent_1, Temporary_2)");
            int typeInput = Convert.ToInt32(Console.ReadLine());
            donation.Type = (DonationType)typeInput;

            Console.WriteLine("Enter Description: ");
            donation.Description = Console.ReadLine();

            string welcomeMessage = donation.Type == DonationType.Temporary
                ? temporaryDonationManager.AddDonation()
                : permanentDonationManager.AddDonation();

            Console.WriteLine(welcomeMessage);

            repo.CreateDonation(donation);
            Console.WriteLine("Donation Created Successfully!");

            ShowAllDonations();
        }

        private static void DeleteDonation()
        {
            Console.WriteLine("Enter Donation ID to Delete: ");
            int donationId = Convert.ToInt32(Console.ReadLine());

            repo.DeleteDonation(donationId);
            Console.WriteLine("Deleted Successfully!");

            ShowAllDonations();
        }

        private static void UpdateDonation()
        {
            Console.WriteLine("Enter Donation ID to Update: ");
            int donationId = Convert.ToInt32(Console.ReadLine());
            Donation donation = repo.GetDonationById(donationId);

            if (donation != null)
            {
                Donation donationUpdate = new Donation();

                Console.WriteLine("Enter new Name: ");
                donationUpdate.Name = Console.ReadLine();

                Console.WriteLine("Enter new Amount: ");
                donationUpdate.Amount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter new Collected By: ");
                donationUpdate.CollecctedBy = Console.ReadLine();

                Console.WriteLine("Enter new Project: (SolarScholars_1, CreekCleanup_2, LandTrust_3, ForestAsia_4)");
                int projectInput = Convert.ToInt32(Console.ReadLine());
                donationUpdate.Project = (Project)projectInput;

                Console.WriteLine("Enter Type: (Permanent_1, Temporary_2)");
                int typeInput = Convert.ToInt32(Console.ReadLine());
                donationUpdate.Type = (DonationType)typeInput;

                Console.WriteLine("Enter Description: ");
                donationUpdate.Description = Console.ReadLine();

                donationUpdate.Id = donationId; 
                repo.UpdateDonation(donationUpdate);
                Console.WriteLine("Updated Successfully!");

                ShowAllDonations();
            }
            else
            {
                Console.WriteLine("Donation not found.");
            }
        }

        private static void ShowAllDonations()
        {
            Console.WriteLine(string.Format("|{0,5}|{1,15}|{2,-30}|{3,15}|{4,15}|{5,25}|", "ID", "Name", "Amount", "Collected By", "Project", "Description"));
            Console.WriteLine(new string('-', 120));

            var list = repo.GetAllDonations().ToList();
            foreach (var item in list)
            {
                Console.WriteLine(string.Format("|{0,5}|{1,15}|{2,-30}|{3,15}|{4,15}|{5,25}|", item.Id, item.Name, item.Amount, item.CollecctedBy, item.Project, item.Description));
                Console.WriteLine(new string('-', 120));
            }
        }
    }
}
