public class CompanyInfo
{
    public int Vat { get; set; }
    public string Cvr { get; set; }
    public string Name { get; set; }
    public int ClubDiscount { get; set; }
    private static CompanyInfo? _instance;
    public static CompanyInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                 _instance = new CompanyInfo();
            }
            return _instance;
        }
    }

    private CompanyInfo()
    {
    }

    public override string ToString()
    {
        return $"Name: {Name}; CVR: {Cvr}; VAT: {Vat}; Club Discount: {ClubDiscount}";
    }
}
