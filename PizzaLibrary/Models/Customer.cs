using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace PizzaLibrary
{
    public class Customer:ICustomer
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        private static int _counter;
        public int Id { get; set; }
        public bool ClubMember { get; set; }
        public Customer(string name, string mobile, string address)
        {
            Id = ++_counter;
            Name = name;
            Mobile = mobile;
            Address = address;
        }

        public override string ToString()
        {
            return $"ID: {Id}; Name: {Name}; Mobile: {Mobile}; Address: {Address}; Is club member: {ClubMember}";
        }
    }
}
