using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary
{
    public class VIPCustomer:Customer
    {
        public int? Discount { get; set; }

        public VIPCustomer(string name, string mobile, string address, int? discount):base(name, mobile, address)
        {
            /*if (discount < 1 || discount > 25)
            {
                throw new InvalidDiscountException($"Discount {discount} is out of expected range");
            }*/
            Discount = discount;
        }

        public override string ToString()
        {
            return $"VIP CUSTOMER: ID: {Id}; Name: {Name}; Mobile: {Mobile}; Address: {Address}; Is club member: {ClubMember}; Discount: {Discount}";
        }
    }
}
