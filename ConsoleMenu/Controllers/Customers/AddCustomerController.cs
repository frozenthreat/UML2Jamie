using PizzaLibrary;
using System.Linq.Expressions;
public class AddCustomerController
{
    ICustomerRepository _customerRepository;
    public ICustomer Customer { get; set; }

    public AddCustomerController(string name, string mobile, string address, bool clubMember, ICustomerRepository customerRepository, int? discount)
    {
        List<ICustomer> collision = customerRepository.GetAll();
        foreach (var customer in collision)
        {
            if (mobile == customer.Mobile)
            {
                throw new CustomerMobileNumberExist($"Mobile no {mobile} already exists");
            }
        }
        if (discount < 1 || discount > 25)
        {
            throw new InvalidDiscountException($"Discount {discount} is out of expected range");
        }
        if (discount != null)
        {
            Customer = new VIPCustomer(name, mobile, address, discount);
        }
        else {
            Customer = new Customer(name, mobile, address);
        }

        Customer.ClubMember = clubMember;
        _customerRepository = customerRepository;

    }

    public void AddCustomer()
    {
        _customerRepository.AddCustomer(Customer);
    }


}
