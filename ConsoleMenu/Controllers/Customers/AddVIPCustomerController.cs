using PizzaLibrary;
public class AddVIPCustomerController:AddCustomerController
{
    public AddVIPCustomerController(string name, string mobile, string address, bool clubMember, ICustomerRepository customerRepository, int discount):base(name, mobile, address, clubMember, customerRepository, null)
    {
        Customer = new VIPCustomer(name, mobile, address, discount);
    }
}
