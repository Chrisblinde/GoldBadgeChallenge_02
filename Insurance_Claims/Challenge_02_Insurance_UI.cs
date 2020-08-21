using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Claims
{
    public class Challenge_02_Insurance_UI
    {
        private bool _isRunning = true;
        private readonly Challenge_02_Insurance_Repo _claimsRepo = new Challenge_02_Insurance_Repo();

        public void Start()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Claims Mananger!\n" +
                "1. See all calims:\n" +
                "2. Take care of the next claim:\n" +
                "3. Enter a new claim:\n" +
                "4. Modify an existing claim:");
            string userInput = Console.ReadLine();
            return userInput;

        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    DisplayNextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    ModifyClaims();
                    break;
                default:
                    Console.WriteLine("Invalid Selection.");
                    return;
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();

        }

        private void DisplayAllClaims()
        {
            Queue<Challenge_02_Insurance_Claims> listOfClaims = _claimsRepo.GetClaims();
            foreach (Challenge_02_Insurance_Claims claims in listOfClaims)
            {
                DisplayClaims(claims);
            }
        }

        private void DisplayClaims(Challenge_02_Insurance_Claims claims)
       
        {
            Console.WriteLine($"Claim ID: {claims.ClaimId}\n" +
            $"Claim Type: {claims.ClaimType}\n" +
            $"Description: {claims.Description}\n" +
            $"Claim Ammount: {claims.ClaimAmmount}\n" +
            $"Date of Incident: {claims.DateOfIncident}\n" +
            $"Date of Claim: {claims.DateOfClaim}\n" +
            $"Is Valid Claim: {claims.IsValid}");

        }
        private void DisplayNextClaim()
        {

            Queue<Challenge_02_Insurance_Claims> listOfClaims = _claimsRepo.GetClaims();
            Challenge_02_Insurance_Claims nextClaim = listOfClaims.Peek();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimId}\n" +
            $"Claim Type: {nextClaim.ClaimType}\n" +
            $"Description: {nextClaim.Description}\n" +
            $"Claim Ammount: {nextClaim.ClaimAmmount}\n" +
            $"Date of Incident:{nextClaim.DateOfIncident}\n" +
            $"Date of Claim: {nextClaim.DateOfClaim}\n" +
            $"Is Valid Claim: {nextClaim.IsValid}");

        
            Console.WriteLine("Do you want to deal with this claim now? (y/n)?");
            string response = Console.ReadLine();
            if (response == "y")
            {
                listOfClaims.Dequeue();
                Console.WriteLine();
            }
            else
            {
                RunMenu();
            }
        }

        public void ModifyClaims()

        {
            Console.WriteLine("Enter a Claim Number:");
            double claimId = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter a Claim Type");
            ClaimType claimType = GetClaimType();
            Console.WriteLine("Enter a Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter a Claim Ammount:");
            decimal ammount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter an Incident Date:");
            DateTime dateIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Claim Date:");
            DateTime dateClaim = DateTime.Parse(Console.ReadLine());
            Challenge_02_Insurance_Claims updatedClaim = new Challenge_02_Insurance_Claims(claimId, claimType, description, ammount, dateIncident, dateClaim);
            

           _claimsRepo.UpdateClaims(updatedClaim, claimId);

        }

        private void CreateNewClaim()
        {
            Console.WriteLine("Enter a Claim Number:");
            double claimId = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Claim Type");
            ClaimType claimType = GetClaimType();
            Console.WriteLine("Enter a Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter a Claim Ammount:");
            decimal ammount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter an Incident Date:");
            DateTime dateIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Claim Date:");
            DateTime dateClaim = DateTime.Parse(Console.ReadLine());
            Challenge_02_Insurance_Claims newClaim = new Challenge_02_Insurance_Claims(claimId, claimType, description, ammount, dateIncident, dateClaim);

            _claimsRepo.AddClaimToList(newClaim);
        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            while (true)
            {
                string claimString = Console.ReadLine();
                bool parseResult = int.TryParse(claimString, out int parsedNumber);
                if (parseResult && parsedNumber >= 1 && parsedNumber <= 3)
                {
                    ClaimType claimType = (ClaimType)parsedNumber - 1;
                    return claimType;
                }
            }
        }
        private void SeedClaimList()
        {
            Challenge_02_Insurance_Claims claimOne = new Challenge_02_Insurance_Claims(1, ClaimType.Car, "accident on 465", 400.00m, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"));
            Challenge_02_Insurance_Claims claimTwo = new Challenge_02_Insurance_Claims(2, ClaimType.Home, "House fire in Kitchen.", 4000.00m, DateTime.Parse("2018-04-11"), DateTime.Parse("2018-04-12"));
            Challenge_02_Insurance_Claims claimThree = new Challenge_02_Insurance_Claims(3, ClaimType.Theft, "Stolen Pancakes.", 4.00m, DateTime.Parse("2018-04-27"), DateTime.Parse("2018-06-01"));
            _claimsRepo.AddClaimToList(claimOne);
            _claimsRepo.AddClaimToList(claimTwo);
            _claimsRepo.AddClaimToList(claimThree);

        }

    }
}





            

        
        





                
                
            















