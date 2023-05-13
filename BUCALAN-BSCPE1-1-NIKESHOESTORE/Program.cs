using System;
using System.Collections.Generic;

class NikeShoe
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public NikeShoe(string name, string description, decimal price, int quantity)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name} - {Description} ({Quantity} quantity) - php{Price}(each)";
    }
}

class NikeShop
{
    private static List<NikeShoe> shoes = new List<NikeShoe>()
    {
        new NikeShoe("Air Force 1", "Classic low-top design", 5499.99m, 10),
        new NikeShoe("Air Max 90", "Iconic sneaker with visible air unit", 6499.99m, 5),
        new NikeShoe("Jordan 1", "High-top basketball shoe", 7299.99m, 3)
    };

    private static List<NikeShoe> cart = new List<NikeShoe>();

    public static void Main()
    {
        Console.WriteLine("Welcome to the Nike shop!");
        Console.WriteLine();

        while (true)
        {
            DisplayShoes();

            Console.WriteLine();
            Console.Write("Enter the number of the shoe you want to buy (or '0' to checkout): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Checking out...");

                if (cart.Count > 0)
                {
                    decimal totalAmount = CalculateTotalAmount();
                    DisplayCart();
                    Console.WriteLine($"Total amount: php{totalAmount}");
                    Console.WriteLine("Thank you for your purchase!");
                }
                else
                {
                    Console.WriteLine("Your cart is empty. Thank you for visiting our shop!");
                }

                break;
            }
            else if (choice > 0 && choice <= shoes.Count)
            {
                NikeShoe selectedShoe = shoes[choice - 1];

                Console.Write("Enter the quantity you want to buy: ");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity <= selectedShoe.Quantity)
                {
                    NikeShoe cartShoe = new NikeShoe(selectedShoe.Name, selectedShoe.Description, selectedShoe.Price, quantity);
                    cart.Add(cartShoe);
                    selectedShoe.Quantity -= quantity;

                    Console.WriteLine("Item added to cart.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have sufficient stock for the selected quantity.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
            }
        }
    }

    private static void DisplayShoes()
    {
        Console.WriteLine("Available shoes:");
        for (int i = 0; i < shoes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {shoes[i]}");
        }
    }

    private static void DisplayCart()
    {
        Console.WriteLine("Your cart:");
        for (int i = 0; i < cart.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cart[i]}");
        }
    }

    private static decimal CalculateTotalAmount()
    {
        decimal totalAmount = 0;

        foreach (NikeShoe shoe in cart)
        {
            totalAmount +=
    shoe.Price * shoe.Quantity;
        }

        return totalAmount;
    }
}