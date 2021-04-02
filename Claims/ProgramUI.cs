using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using ClaimsRepo;

namespace Claims
{
    public class ProgramUI
    {
        private readonly ClaimRepo _cRepo = new ClaimRepo();


        public void Run()
        {
            Seed();
            RunApplication();
        }


        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Weleome....\n" +
                    "1.See all claims \n" +
                    "2.Take care of next claim\n" +
                    "3.Enter a new claim\n" +
                    "4. Close App\n");

                string agentInput = Console.ReadLine();

                switch (agentInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thanks");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claim> claim = _cRepo.GetAllClaims();

            foreach (var c in claim)
            {
                Console.WriteLine($"Claim ID:{c.ClaimID}\n" +
                                  $"Type:{c.ClaimType}\n" +
                                  $"Description:{c.Description}\n" +
                                  $"Amount:{c.ClaimAmount}\n" +
                                  $"Date of Incident:{c.DateOfIncident}\n" +
                                  $"Date of Claim:{c.DateOfClaim}\n" +
                                  $"IsValid: {c.IsValid}\n");
            }
            Console.ReadKey();
        }

        private void NextClaim()
        {
            Console.Clear();

            Claim claim = _cRepo.ViewNextClaim();
            Console.WriteLine($"Claim ID:{claim.ClaimID}\n" +
                                  $"Type: {claim.ClaimType}\n" +
                                  $"Description: {claim.Description}\n" +
                                  $"Amount: {claim.ClaimAmount}\n" +
                                  $"Date of Incident: {claim.DateOfIncident}\n" +
                                  $"Date of Claim: {claim.DateOfClaim}\n");

            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine();
            if (input =="y")
            {
                bool isSuccessful = _cRepo.RemoveClaim();
                if (isSuccessful)
                {
                    Console.WriteLine("Claim removed successfully");
                }
                else
                {
                    Console.WriteLine("Claim not removed");
                }
            }          
               else
            {
                RunApplication();
            }

            Console.ReadKey();
        }

        private void NewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

            Console.WriteLine("Enter the claim id:");
            int userInput = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter the claim type:");
            string agentInputClaimType = Console.ReadLine();
            claim.ClaimType = agentInputClaimType;

            Console.WriteLine("Enter a claim description:");
            string agentInputDescription = Console.ReadLine();
            claim.Description = agentInputDescription;

            Console.WriteLine("Amount of Damage:");
            double agentInputAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Month of accident (number):");
            int agentInputMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Day of accident (two digit number):");
            int agentInputDay = int.Parse(Console.ReadLine());

            Console.WriteLine("Year of accident (four digit number):");
            int agentInputYear = int.Parse(Console.ReadLine());

            claim.DateOfIncident = new DateTime(agentInputYear, agentInputMonth, agentInputDay);

            Console.WriteLine("Month of claim:");
            int agentInputGetMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Day of claim:");
            int agentInputGetDay = int.Parse(Console.ReadLine());

            Console.WriteLine("Year of claim:");
            int agentInputGetYear = int.Parse(Console.ReadLine());

            claim.DateOfClaim = new DateTime(agentInputGetYear, agentInputGetMonth, agentInputGetDay);


            bool isSuccessfull = _cRepo.AddToDatabase(claim);

            if (isSuccessfull)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadKey();
        }

        
        private void Seed()
        {

            //we are creating claims menu
            Claim claim1 = new Claim(1, "Car", "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claim2 = new Claim(2, "Home", "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim claim3 = new Claim(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);

            //add items to database
            _cRepo.AddToDatabase(claim1);
            _cRepo.AddToDatabase(claim2);
            _cRepo.AddToDatabase(claim3);
        }
    }

}





            

    

