using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class CustomerBUS
    {
        public static CustomerDTO findCustomerByPhoneNumber(string cusPhoneNumber)
        {
            if (cusPhoneNumber == null || cusPhoneNumber.Equals(""))
            {
                return null;
            }
            return CustomerDAO.findCustomerByPhoneNumber(cusPhoneNumber);
        }
        public static List<CustomerDTO> findAllCustomer()
        {
            return CustomerDAO.findAllCustomer();
        }
        public static bool InsertCustomer(CustomerDTO cus)
        {
            if (CustomerBUS.findCustomerByPhoneNumber(cus.cusPhoneNumber) != null)
            {
                return false;
            }
            return CustomerDAO.InsertCustomer(cus);
        }
    }
}
