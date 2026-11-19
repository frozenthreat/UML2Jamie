using PizzaLibrary;
public class Beverage:MenuItem
{
    public bool Alcohol { get; set; }
    public Beverage(string name, double price, string description, bool alcohol):base(name, price, description, MenuType.TILBEHØR)
    {
        Alcohol = alcohol;
    }

    public override string ToString()
    {
        return $"Name: {Name}; Price: {Price}; Description: {Description}; Has alcohol: {Alcohol}";
    }
}
