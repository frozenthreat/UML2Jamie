using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace PizzaLibrary
{
    public class CustomerRepository:ICustomerRepository
    {
        public int Count { get { return _customers.Count; } }
        private Dictionary<string, ICustomer> _customers;

        public CustomerRepository()
        {
            //_customers = new Dictionary<string, ICustomer>();
            _customers = MockData.CustomerData;
        }

        public List<ICustomer> GetAll()
        {
            List<ICustomer> tempList = new List<ICustomer>();
            foreach (var customer in _customers.Values)
            {
                tempList.Add(((ICustomer)customer));
            }
            return tempList;
        }
        public void AddCustomer(ICustomer customer)
        {
            if (_customers.ContainsKey(customer.Mobile))
            {
                throw new CustomerMobileNumberExist($"Mobile no {customer.Mobile} already exists");
            }
            _customers.Add(customer.Mobile, customer);
        }

        public ICustomer? GetCustomerByMobile(string mobile)
        {
            return _customers[mobile];
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public void PrintAllCustomers()
        {
            foreach (var customer in _customers.Values)
            {
                Console.WriteLine(customer);
            }
        }

        public List<ICustomer> GetAllClubMembers()
        {
            /*IEnumerable<ICustomer> clubMemberQuery = _customers.Values.Where(customer => customer.ClubMember == true);
            List<ICustomer> clubMemberList = clubMemberQuery.ToList();
            return clubMemberList;*/
            List<ICustomer> clubMemberList = new List<ICustomer>();
            foreach (var customer in _customers.Values)
            {
                if (customer.ClubMember == true)
                {
                    clubMemberList.Add(customer);
                }
            }
            return clubMemberList;
        }

        public List<ICustomer> GetAllRoskilde()
        {
            /*IEnumerable<ICustomer> roskildeQuery = _customers.Values.Where(customer => customer.Address.Contains("Roskilde"));
            List<ICustomer> roskildeList = roskildeQuery.ToList();
            return roskildeList;*/
            List<ICustomer> roskildeList = new List<ICustomer>();
            foreach (var customer in _customers.Values)
            {
                if (customer.Address.Contains("Roskilde"))
                {
                    roskildeList.Add(customer);
                }
            }
            return roskildeList;
        }

        public void UpdateCustomer(int id, string name, string address, string mobile)
        {
            foreach (var customer in _customers.Values)
            {
                if (customer.Id == id)
                {
                    RemoveCustomer(customer.Mobile);
                    Customer updatedCustomer = new(name, mobile, address);
                    Customer.DecrementCounter();
                    updatedCustomer.Id = id;
                    AddCustomer(updatedCustomer);
                    return;
                }
            }
        }
    }
}
