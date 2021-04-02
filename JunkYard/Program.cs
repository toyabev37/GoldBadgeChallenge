using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Character> characters = new Queue<Character>();

            //create 3 characters 
            Character bob = new Character(1, "Bob the Builder");
            Character ryu = new Character(2, "Ryu");
            Character mBison = new Character(3, "M. Bison");

            //to put them in line...
            //1st in line
            characters.Enqueue(bob);
            //2nd in line
            characters.Enqueue(ryu);
            //3rd in line
            characters.Enqueue(mBison);

            foreach (var ch in characters)
            {
                Console.WriteLine($"{ch.Id}\n" +
                    $"{ch.Name}");
            }

            Console.WriteLine("----------------------------------------");
            
            //See who is next in line...
           Character singleCharacterNextInline= characters.Peek();
            Console.WriteLine($"{singleCharacterNextInline.Id}\n" +
                    $"{singleCharacterNextInline.Name}\n");

            Console.WriteLine("----------------------------------------");
            //to get characters out of line...
            Console.WriteLine("--Get Characters out of line--");
           
            //this removes a person from the line...
            characters.Dequeue();

            Console.WriteLine("----------------------------------------");

            //See who is next in line...
            Character singleCharacterNextInline2 = characters.Peek();
            Console.WriteLine($"{singleCharacterNextInline2.Id}\n" +
                    $"{singleCharacterNextInline2.Name}\n");

            Console.WriteLine("----------------------------------------");

            foreach (var ch in characters)
            {
                Console.WriteLine($"{ch.Id}\n" +
                    $"{ch.Name}");
            }
            characters.Dequeue();
            
            foreach (var ch in characters)
            {
                Console.WriteLine($"{ch.Id}\n" +
                    $"{ch.Name}");
            }
            Console.ReadKey();
        }

       
    }
}
