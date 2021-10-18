using System;
using System.IO;

namespace DishMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                Menu menu = new Menu(Input.MenuFileInput(), Input.PriceTagFileInput());

                var productList = menu.GetAllProductList();
                foreach (var elem in productList)
                    Console.WriteLine($"{elem.Key} {elem.Value.weight:f3} {elem.Value.price:f2}");
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
