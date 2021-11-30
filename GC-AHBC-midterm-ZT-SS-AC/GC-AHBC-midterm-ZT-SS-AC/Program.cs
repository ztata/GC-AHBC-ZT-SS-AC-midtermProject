using System;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Full Stack After Hours Bootcamp Midterm Project";

            string addressPath = @"C:\Users\schan\Documents\Web Development\Education\Grand Circus\Full Stack C# .NET Bootcamp\MidTermProject\GC-AHBC-midterm-ZT-SS-AC\productList.txt";

            FileHelper.BuildMenuList(addressPath);

            // Adds the created product to the file
            FileHelper.AddProductToFile(addressPath, product);
        }
    }
}
