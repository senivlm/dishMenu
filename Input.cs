using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DishMenu
{
    static class Input
    {
        public static string MenuFileInput()
        {
            StreamReader streamReader = new StreamReader("../../../menu.txt");

            return streamReader.ReadToEnd();
        }

        public static string PriceTagFileInput()
        {
            StreamReader streamReader = new StreamReader("../../../price tag.txt");

            return streamReader.ReadToEnd();
        }
    }
}
