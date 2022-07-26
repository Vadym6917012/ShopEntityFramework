using Shop.Repository;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductMethods productMethods = new ProductMethods();

            while (true)
            {
                Console.WriteLine("Welcome to the shop!");
                Console.WriteLine("[0] - Exit");
                Console.WriteLine("[1] - Show all products");
                Console.WriteLine("[2] - Add product");
                Console.WriteLine("[3] - Delete product");
                Console.WriteLine("[4] - Update product");
                Console.Write("Enter your choise: ");
                byte userInput = byte.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            foreach (var p in productMethods.GetAll())
                            {
                                Console.WriteLine($"Name: {p.ProductName} | Price: {p.ProductPrice}");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter product name: ");
                            string productName = Console.ReadLine();

                            Console.Write("Enter product price: ");
                            double productPrice = double.Parse(Console.ReadLine());

                            productMethods.Add(productName, productPrice);

                            Console.WriteLine($"{productName} - added");
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter name: ");
                            string productName = Console.ReadLine();

                            var product = productMethods.Get(productName);

                            if (product != null)
                            {
                                productMethods.Remove(productName);
                                Console.WriteLine($"{productName} - deleted");
                            } else
                            {
                                Console.WriteLine($"{productName} - not found");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Enter name: ");
                            string productName = Console.ReadLine();

                            var product = productMethods.Get(productName);

                            if (product!= null)
                            {
                                Console.Write("Enter new name: ");
                                string newName = Console.ReadLine();

                                productMethods.Update(productName, newName);
                                Console.WriteLine($"{product.ProductName} changed to {newName}");

                            } else
                            {
                                Console.WriteLine($"{productName} - not found");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong number!");
                            break;
                        }
                }
            }
        }
    }
}