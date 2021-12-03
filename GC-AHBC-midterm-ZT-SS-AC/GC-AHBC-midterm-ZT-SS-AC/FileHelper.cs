using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class FileHelper
    {
        // Reads the file for the menu items
        public static Product[] BuildMenuList (string path)
        {
            Product[] productArray = new Product[12];
            using (StreamReader reader = new StreamReader(path))
            {
                string lineText;
                int counter = 0;
                while ((lineText = reader.ReadLine()) != null)
                {
                    string[] items = lineText.Split('|');
                    if (items.Length != 4)
                    {
                        continue;
                    }
                    // Creates a new Product and stores each element into its correct variable
                    Product product = new Product();
                    product.Name = items[0];
                    product.Price = double.Parse(items[1]);
                    product.Category = items[2];
                    product.Description = items[3];
                    productArray[counter] = product;
                    counter++;
                }
            }
            return productArray;
        }

        // Adds a product to the file - This will come later but we'll have to change the Array to a List
        public static void AddProductToFile(string path, Product product)
        {
            StreamWriter writer = new StreamWriter(path, true);
            StringBuilder builder = new StringBuilder();
            builder.Append(product.Name);
            builder.Append("|");
            builder.Append(product.Category);
            builder.Append("|");
            builder.Append(product.Description);
            builder.Append("|");
            builder.Append(product.Price);
            writer.WriteLine(builder.ToString());
            writer.Flush();
            writer.Close();
        }
    }
}
