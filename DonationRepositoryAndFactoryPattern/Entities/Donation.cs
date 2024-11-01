using DonationRepositoryAndFactoryPattern.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationRepositoryAndFactoryPattern.Entities
{
    public class Donation
    {
        int id;
        string name;
        double amount;
        string collecctedBy;
        Project project;
        DonationType type;
        string description;

        public Donation() { }

        public Donation(int id, string name, double amount, string collecctedBy, 
            Project project, DonationType type, string description)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.collecctedBy = collecctedBy;
            this.project = project;
            this.type = type;
            this.description = description;
        }
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Amount { get => amount; set => amount = value; }
        public string CollecctedBy { get => collecctedBy; set => collecctedBy = value; }
        public Project Project { get => project; set => project = value; }
        public DonationType Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string WelcomeMessage { get; set; }
    }
}
