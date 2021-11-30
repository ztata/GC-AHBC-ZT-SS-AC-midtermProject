using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class FileHelper
    {
        public static List<MenuItem> BuildMenuList (string path)
        {
            List<MenuItem> productList = new List<MenuItem>();
            using (StreamReader reader = new StreamReader(path))
            {
                string lineText;
                while ((lineText = reader.ReadLine()) != null)
                {
                    string[] items = lineText.Split('|');
                    if (items.Length != 3)
                    {
                        continue;
                    }
                    MenuItem product = new MenuItem();
                    product.Name = items[0];
                    product.Category = items[1];
                    product.Description = items[2];
                    product.Price = items[3];
                    productList.Add(product);
                }
            }
            return productList;
        }

        public static void AddProductToFile(string path, MenuItem product)
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
