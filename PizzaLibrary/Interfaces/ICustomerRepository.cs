using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary
{
    public interface ICustomerRepository
    {
        public int Count { get; }
        List<ICustomer> GetAll();
        void AddCustomer(ICustomer customer);
        ICustomer GetCustomerByMobile(string mobile);
        void RemoveCustomer(string mobile);
        void PrintAllCustomers();

    }

}
