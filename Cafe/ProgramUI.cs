using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeRepo;

namespace Cafe
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();
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
                Console.WriteLine("Welcome to create a Menu Item\n" +
                                  "1.Create a new menu item\n" +
                                  "2. Delete a menu\n" +
                                  "3. Receive a list of all items on the cafe's menu\n" +
                                  "4. View menu item by meal number\n" +
                                  "5. Close app\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItemToDatabase();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        ReceiveListOfItems();
                        break;
                    case "4":
                        ViewMenuItemByMealNumber();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Thanks!");
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        private void AddMenuItemToDatabase()
        {
            Console.Clear();



            Console.WriteLine("Please input a meal number here");
            MenuItem item = new MenuItem();

            int managerInputMealNumber = int.Parse(Console.ReadLine());
            item.MealNumber = managerInputMealNumber;
            Console.Clear();

            Console.WriteLine("Please input a meal name here");
            string managerInputMealName = Console.ReadLine();
            item.MealName = managerInputMealName;
            Console.Clear();

            Console.WriteLine("Please input a description here");
            string managerInputDescription = Console.ReadLine();
            item.Description = managerInputDescription;
            Console.Clear();

            Console.WriteLine("Please input ingredients here");
            string managerInputIngredients = Console.ReadLine();
            item.Ingredients = managerInputIngredients;
            Console.Clear();

            Console.WriteLine("Please input price here");
            double managerInputPrice = int.Parse(Console.ReadLine());
            item.Price = managerInputPrice;
            Console.Clear();

            bool isSuccessful = _menuRepository.AddMenuItemToDatabase(item);

            if (isSuccessful)
            {
                Console.WriteLine("Menu item creation complete");
            }
            else
            {
                Console.WriteLine("Menu item creation failed");
            }

            Console.ReadKey();
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Please input a menu item for deletion");

            int userInputMenuItem = int.Parse(Console.ReadLine());

            bool isSuccessful = _menuRepository.RemoveMenuItem(userInputMenuItem);

            if (isSuccessful)
            {
                Console.WriteLine("Menu item deleted");
            }
            else
            {
                Console.WriteLine("Menu item failed to be deleted.");
            }

            Console.ReadKey();
        }
        //Get menu by ID
        private void ViewMenuItemByMealNumber()
        {
            Console.Clear();

            Console.WriteLine("Please enter menu item number");
            int managerInputMenuItemNumber = int.Parse(Console.ReadLine());
            MenuItem menu = _menuRepository.GetMenuItemByMealNumber(managerInputMenuItemNumber);

            if (menu == null)
            {
                Console.WriteLine($"Sorry menu item doesn't exist with the meal number: {managerInputMenuItemNumber}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{menu.MealNumber}\n" +
                   $"{menu.MealName}\n" +
                   $"{menu.Description}\n" +
                   $"{menu.Ingredients}\n" +
                   $"{menu.Price}\n");

            }
            Console.ReadKey();
        }            


        private void ReceiveListOfItems()
        {
            Console.Clear();
            List<MenuItem> menus = _menuRepository.ReceiveListOfItems();

            foreach (var item in menus)
            {
                //view all menu items info
                Console.WriteLine($"{item.MealNumber}\n" +
                    $"{item.MealName}\n" +
                    $"{item.Description}\n" +
                    $"{item.Ingredients}\n" +
                    $"{item.Price}\n");
            }
            
            Console.ReadKey();            
        }


        private void Seed()
        {
            //we are creating menu items
            MenuItem menu = new MenuItem("hambuger", "house special", "bacon lettuce cheese on a bun", 20.55);

            MenuItem menu1 = new MenuItem("pizza", "very cheesy", "cheese salsa", 16.99);

            MenuItem menu2 = new MenuItem("hotdog", "chili dog", "chili cheese onion", 7.95);

            //add items to database
            _menuRepository.AddMenuItemToDatabase(menu);
            _menuRepository.AddMenuItemToDatabase(menu1);
            _menuRepository.AddMenuItemToDatabase(menu2);

        }

    }

}
