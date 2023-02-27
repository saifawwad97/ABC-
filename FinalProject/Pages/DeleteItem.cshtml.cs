using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.TechnicalServices;
namespace FinalProject.Pages
{
    public class DeleteItemModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";
        public Item item = new Item();

        [BindProperty]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"[a-z]{1}[0-9]{5}$")]
        public string ItemCode { get; set; }

   



        public void OnGet()
        {
        }

        public void Onpost()
        {

            item.ItemCode = Request.Form["ItemCode"];

            if (item.ItemCode.Length == 0)
            {
                errorMessage = "All the Fields are Required";
                return;

            }


            try
            {

                BCS RequestDirector = new BCS();
               
                RequestDirector.deleteItem(item.ItemCode);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            item.ItemCode = "";
            successMessage = "The Item Was Deleted Successfully";
            return;
        
        }
    }
}
