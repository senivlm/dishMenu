using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DishMenu
{раорар
    class Menu
    {
        List<(string name, List<(string name, double weight)> products)> dishList;
        public List<(string dish, List<(string name, double weight)> products)> DishList
        {
            get
            {
                return dishList;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Product list not set");
                dishList = value;
            }
        }
        
        Dictionary<string, double> priceTag;
        public Dictionary<string, double> PriceTag
        {
            get
            {
                return priceTag;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Price tag not set");
                priceTag = value;
            }
        }

        public Menu(string dishData, string priceTagData)
        {
            dishList = new List<(string name, List<(string name, double weight)> products)>();
            priceTag = new Dictionary<string, double>();

            ChangeDishes(dishData);
            ChangePriceTag(priceTagData);
        }

        public void ChangeDishes(string str)
        {
            StringReader input = new StringReader(str);
            
            while (input.Peek() != -1)
            {
                string line = input.ReadLine();
                DishList.Add((line, new List<(string, double)>()));
                while (input.Peek() != -1 && (line = input.ReadLine()) != "")
                {
                    string[] product = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    DishList[DishList.Count - 1].products.Add((product[0], Convert.ToDouble(product[1])));
                }
            }

        }

        public void ChangePriceTag(string str)
        {
            StringReader input = new StringReader(str);

            while (input.Peek() != -1)
            {
                string[] product = input.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    PriceTag.Add(product[0], Convert.ToDouble(product[1]));
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("In price tag cannot be same products");
                }
            }
        }

        public SortedDictionary<string, (double weight, double price)> GetAllProductList()
        {
            SortedDictionary<string, (double weight, double price)> productList = new SortedDictionary<string, (double, double)>();

            foreach (var elem in dishList)
                foreach (var product in elem.products)
                {
                    try
                    {
                        if (!productList.TryAdd(product.name, (Convert.ToDouble(product.weight), product.weight * priceTag[product.name])))
                        {
                            double tempWeight = productList[product.name].weight + product.weight;
                            productList[product.name] = (tempWeight, tempWeight * priceTag[product.name]);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        throw new ArgumentException("Product in menu is absent in price tag");
                    }
                }

            return productList;
        }
    }
}
