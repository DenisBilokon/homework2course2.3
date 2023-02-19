using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = ReadProductsFromFile("products.txt");

        var groupedProducts = products.GroupBy(p => p.Category);

        Console.WriteLine("Список продуктів, згрупований за категоріями:");
        foreach (var group in groupedProducts)
        {
            Console.WriteLine("Категорія: " + group.Key);
            foreach (var product in group)
            {
                Console.WriteLine(product.Name + " - " + product.Price);
            }
            Console.WriteLine();
        }
    }

    static List<Product> ReadProductsFromFile(string filename)
    {
        List<Product> products = new List<Product>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                double price = Double.Parse(parts[1]);
                string category = parts[2];
                products.Add(new Product(name, price, category));
            }
        }

        return products;
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    public Product(string name, double price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

