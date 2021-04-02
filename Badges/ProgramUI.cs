using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadgesRepo;

namespace Badges
{
    public class ProgramUI
    {
        private readonly BadgeRepository _badgeRespository = new BadgeRepository();
        private readonly BadgeItem badges = new BadgeItem();
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
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                                  "1.Add a badge\n" +
                                  "2. Edit a badge\n" +
                                  "3. List all Badges\n" +
                                  "4. Close app\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadgeToDatabase();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thanks!");
                        break;
                    default:
                        break;
                }
                Console.Clear();

            }
        }
        private void AddBadgeToDatabase()
        {
            Console.Clear();
            BadgeItem badge = new BadgeItem();

            Console.WriteLine("What is the number on the badge:");
            int inputBadgeId = int.Parse(Console.ReadLine());
            badge.BadgeId = inputBadgeId;

            Console.WriteLine("List a door that it needs access to:");

            bool keepAdding = true;
            while (keepAdding)
            {
                string inputDoorNames = Console.ReadLine();
                badge.DoorNames.Add(inputDoorNames);


                Console.WriteLine("Any other doors(y/n)?");
                string input = Console.ReadLine();
               

                if (input == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");

                }

                if (input == "n")
                {
                    keepAdding = false;

                }
            }

            bool IsAdded = _badgeRespository.AddBadgeToDatabase(badge);
            if (IsAdded != true)
            {
                Console.WriteLine("Could not add badge");
            }
            else
            {
                Console.WriteLine("Badge added successfully!");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int inputBadgeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");
            string inputDoorUpdate = Console.ReadLine();

            if (inputDoorUpdate == "1")
            {

                Console.WriteLine("Which door would you like to remove?");
                string inputDoorNumber = Console.ReadLine();

                bool isSuccessful = _badgeRespository.DeleteDoors(inputBadgeNumber, inputDoorNumber);
                if (isSuccessful)
                {
                    Console.WriteLine("Door removed successfully");
                }
                else
                {
                    Console.WriteLine("Door not removed");
                }
                Console.ReadKey();
            }
        }




        private void ListBadges()
        {
            Console.Clear();

            Dictionary<int, BadgeItem> badge = _badgeRespository.ListBadges();
            foreach (var item in badge)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var doorName in item.Value.DoorNames)
                {
                    Console.WriteLine(doorName);
                }
            }
            Console.ReadKey();
        }


        private void Seed()
        {
            BadgeItem badge1 = new BadgeItem(12345, new List<string> { "A7" });
            BadgeItem badge2 = new BadgeItem(22345, new List<string> { "A1", "A4", "B1", "B2" });
            BadgeItem badge3 = new BadgeItem(32345, new List<string> { "A4", "A5" });

            _badgeRespository.AddBadgeToDatabase(badge1);
            _badgeRespository.AddBadgeToDatabase(badge2);
            _badgeRespository.AddBadgeToDatabase(badge3);
        }



    }
}
