
using proj1.Models;
using Library.eCommerce.Services;
namespace MyApp
{
    internal class Program
    {

        static void Main(string[] args) //main is always static
        {
            Console.WriteLine("Welcome to Amazone!");

            Console.WriteLine("C. Create new inventory item");
            Console.WriteLine("R. Read all inventory items");
            //make one to put into cart?
            Console.WriteLine("U. Update an inventory item");
            Console.WriteLine("D. Delete an inventory item");
            Console.WriteLine("Q. Quit");

            //List<Product?> list = ProductServiceProxy.Current.Products; //list can be replace by the right hand thing
            List<Product?> list = ProductServiceProxy.Current.Products; //shallow copy
            char choice;
            do
            {
                string? input = Console.ReadLine().ToUpper();
                choice = input[0];
                switch (choice)
                { //or you can do case' '; for lowercase version
                    case 'C':
                        ProductServiceProxy.Current.AddOrUpdate(new Product
                        {
                            Name = Console.ReadLine()
                        });
                        break;
                    case 'R':
                        list.ForEach(Console.WriteLine);
                        //foreach (var prod in list)
                        //{
                        //    Console.WriteLine(prod);
                        //}
                        break;
                    case 'U':
                        Console.WriteLine("Which prodcut would you like to update?");
                        int selection = int.Parse(Console.ReadLine() ?? "-1");
                        var selectedProd = list.FirstOrDefault(p => p.Id == selection); //effectively a shallow copy
                        
                        if (selectedProd != null)
                        {
                            selectedProd.Name = Console.ReadLine() ?? "ERROR";
                            ProductServiceProxy.Current.AddOrUpdate(selectedProd);
                        }

                        break;
                    case 'D':
                        Console.WriteLine("Which prodcut would you like to update?");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        ProductServiceProxy.Current.Delete(selection);
                        
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("Error: Unknown Command");

                        break;
                }
            } while (choice != 'Q');
        }
    }
}
