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
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(10, MinimumLength = 6)]

        public string CustomerID { get; set; }
        public string errorMessage = "";
        public string successMessage = "";
 
        public Cus customer = new Cus();


        public void OnGet()
        {
        }

        public void Onpost()
        {
            customer.CustomerID = Request.Form["CustomerID"];
        

            try
            {

                BCS RequestDirector = new BCS();

                RequestDirector.DeleteCustomer(customer.CustomerID);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            customer.CustomerID = "";  
            successMessage = "The Customer Was Deleted Successfully";
            return;
        }
    }
}
