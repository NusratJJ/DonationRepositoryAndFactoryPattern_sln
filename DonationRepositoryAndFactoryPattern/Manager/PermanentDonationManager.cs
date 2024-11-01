﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Manager
{
    public class PermanentDonationManager : IDonationManager
    {
        public double GetAmount()
        {
            double amount = 20000;
            return amount;
        }

        public string GetWelcomeMessage()
        {
            return "Thank you for your permanent donation!";
        }

        public string AddDonation()
        {
           
            double donationAmount = GetAmount();

         
            string message = GetWelcomeMessage();
            return $"Donation of {donationAmount} was added. {message}";
        }
    }
}