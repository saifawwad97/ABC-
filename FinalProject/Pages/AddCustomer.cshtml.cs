using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(10, MinimumLength = 6)]
        
        public string CustomerID { get; set; }
        [BindProperty]
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Addresses { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 7)]
        public string PostalCode { get; set; }
        public string errorMessage = "";
        public string successMessage = "";
        public Cus customer = new Cus();


        public void OnGet()
        {
        }

        public void Onpost()
        {
            customer.CustomerID = Request.Form["CustomerID"];
            customer.CustomerName = Request.Form["CustomerName"];
            customer.Addresses = Request.Form["Addresses"];
            customer.City = Request.Form["City"];
            customer.Province = Request.Form["Province"];
            customer.PostalCode = Request.Form["PostalCode"];

            if (customer.CustomerID.Length == 0 || customer.CustomerName.Length == 0 || customer.Addresses.Length == 0 || customer.City.Length == 0 || customer.Province.Length == 0 || customer.PostalCode.Length == 0)
            {
                errorMessage = "All the Fields are Required";
                return;

            }

            try
            {

                BCS RequestDirector = new BCS();

                RequestDirector.CreateNewCustomer(customer.CustomerID, customer.CustomerName, customer.Addresses, customer.City, customer.Province, customer.PostalCode);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            customer.CustomerID = ""; customer.CustomerName = ""; customer.Addresses = ""; customer.City = ""; customer.Province = ""; customer.PostalCode = "";
            successMessage = "The Customer Was Added Successfully";
            return;
        }
    }
}
