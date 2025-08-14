namespace Task10;

public class Goods
{
    public string Name;
    public double Price { get; }
    public int Quantity;

    public Goods(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
