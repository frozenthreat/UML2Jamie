using PizzaLibrary;

CustomerRepository custRepo = new CustomerRepository();
MenuItemRepository menuRepo = new MenuItemRepository();

List<ICustomer> clubMembers = custRepo.GetAllClubMembers();
foreach (var customer in clubMembers)
{
    Console.WriteLine(customer);
}

List<ICustomer> roskilde = custRepo.GetAllRoskilde();
foreach (var customer in roskilde)
{
    Console.WriteLine(customer);
}

IMenuItem? expensiveItem = menuRepo.FindMostExpensiveItem(MenuType.SANDWICHES);
Console.WriteLine($"Most expensive sandwich: {expensiveItem}");

IMenuItem? expensivePizza = menuRepo.FindMostExpensivePizza();
Console.WriteLine($"Most expensive pizza: {expensivePizza}");

menuRepo.ListMenu();

Beverage beer = new("Beer", 22.99, "Its a beer", true);
Beverage cola = new("Coca Cola", 19.99, "Classic coke", false);
Console.WriteLine(beer);
Console.WriteLine(cola);

CompanyInfo info = CompanyInfo.Instance;
info.Vat = 15;
info.Cvr = "23234323";
info.Name = "Company Inc.";
info.ClubDiscount = 20;
Console.WriteLine(info);

CompanyInfo info2 = CompanyInfo.Instance;
Console.WriteLine(info2);

info2.Name = "Companyy";
Console.WriteLine(info);
Console.WriteLine(info2);

menuRepo.MenuItemsInPriceRange(85, 97);

custRepo.UpdateCustomer(2, "ABABABAB", "BABABABA", "23272723");
Console.WriteLine(custRepo.GetCustomerByMobile("23272723"));
menuRepo.UpdateMenuItem(2, "AAAAAAAA", 99.99, "BBBBBBBBBB", MenuType.SANDWICHES);
Console.WriteLine(menuRepo.GetMenuItemByNo(2));