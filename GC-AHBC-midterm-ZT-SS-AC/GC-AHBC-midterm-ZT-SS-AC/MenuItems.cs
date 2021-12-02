using System;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public class MenuItems : IComparable<MenuItems>
    {
        private string name;
        private double price;
        private string category;
        private string description;

        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Category { get { return category; } set { category = value; } }
        public string Description { get { return description; } set { description = value; } }

        public MenuItems(string name, double price, string category, string description)
        {
            Name = name;
            Price = price;
            Category = category;
            Description = description;
        }

        public int CompareTo(MenuItems other)
        {
            if (this.Category == other.Category)
            {
                if (this.Name == other.Name)
                {
                    return this.Price.CompareTo(other.Price);
                }
                return this.Name.CompareTo(other.Name);
            }
            return this.Category.CompareTo(other.Category);
        }
    }
}
