using PizzaLibrary;
public class UserMenu
{
    private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t3a.Test Mobile No Collision\n\t4.Add Pizza\n\t5.Add VIP Customer\n\t5a. Test Invalid Discount\n\tQ.Afslut\n\n\tIndtast valg:";

    private CustomerRepository _customerRepository = new CustomerRepository();
    private MenuItemRepository _menuItemRepository = new MenuItemRepository();
    private static string ReadChoice(string choices)
    {
        Console.Clear();
        Console.Write(choices);
        string choice = Console.ReadLine();
        Console.Clear();
        return choice.ToLower();
    }
    public void ShowMenu()
    {
        string theChoice = ReadChoice(mainMenuChoices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.WriteLine("Valg 1");
                    ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                    showMenuItemController.ShowAllMenuItems();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Valg 2");
                    _customerRepository.PrintAllCustomers();
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Valg 3");
                    Console.WriteLine("Indlæs navn:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Indlæs mobil nr:");
                    string mobile = Console.ReadLine();
                    Console.WriteLine("Indlæs adresse:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Vil du være clubmember y/n");
                    string clubMemberString = Console.ReadLine().ToLower();
                    bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                    AddCustomerController addMenuItemController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository, null);
                    addMenuItemController.AddCustomer();
                    break;
                case "3a":
                    Console.WriteLine("Valg 3a");
                    try
                    {
                        CustomerRepository _test = new CustomerRepository();
                        AddCustomerController test1 = new AddCustomerController("a", "13131313", "a", true, _test, null);
                        test1.AddCustomer();
                    }
                    catch (CustomerMobileNumberExist e)
                    {
                        Console.WriteLine("Mobile number collision: " + e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Valg 4");
                    Console.WriteLine("Indlæs navn:");
                    string itemName = Console.ReadLine();
                    Console.WriteLine("Indlæs pris:");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Indlæs beskrivelse:");
                    string description = Console.ReadLine();
                    MenuType menuType = MenuType.PIZZECLASSSICHE;
                    AddMenuItemController addItemController = new AddMenuItemController(itemName, price, description, menuType, _menuItemRepository);
                    addItemController.AddMenuItem();
                    break;
                case "5":
                    Console.WriteLine("Valg 5");
                    Console.WriteLine("Indlæs navn:");
                    string vipName = Console.ReadLine();
                    Console.WriteLine("Indlæs mobil nr:");
                    string vipMobile = Console.ReadLine();
                    Console.WriteLine("Indlæs adresse:");
                    string vipAddress = Console.ReadLine();
                    Console.WriteLine("Vil du være clubmember y/n");
                    string vipClubMemberString = Console.ReadLine().ToLower();
                    bool vipIsClubMember = (vipClubMemberString[0] == 'y') ? true : false;
                    Console.WriteLine("Indlæs discount for VIP (skriv kun 1-25, uden procent)");
                    int discount = int.Parse(Console.ReadLine());
                    AddCustomerController addVIPController = new AddCustomerController(vipName, vipMobile, vipAddress, vipIsClubMember, _customerRepository, discount);
                    addVIPController.AddCustomer();
                    break;
                case "5a":
                    Console.WriteLine("Valg 5a");
                    try
                    {
                        CustomerRepository _test = new CustomerRepository();
                        AddCustomerController test1 = new AddCustomerController("a", "33333333", "a", true, _test, 30);
                        test1.AddCustomer();
                    }
                    catch (InvalidDiscountException de)
                    {
                        Console.WriteLine("Invalid discount: " + de.Message);
                    }
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Angiv et tal fra 1..5 eller q for afslut");
                    break;
            }
            theChoice = ReadChoice(mainMenuChoices);
        }
    }

}
