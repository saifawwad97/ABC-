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
    public class UpdateItemModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";
        [BindProperty]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"[a-z]{1}[0-9]{5}$")]
        public string ItemCode { get; set; }
        [BindProperty]
        [Required]
        public string Description { get; set; }
        [Required]
        public int UnitPrice { get; set; }

        [Required]

        public int Quantity { get; set; }

        public Item item = new Item();
   


        public void OnGet()
        {
        }

        public void Onpost()
        {
            item.ItemCode = Request.Form["ItemCode"];
            item.Description = Request.Form["Description"];
            item.UnitPrice = Int16.Parse(Request.Form["UnitPrice"]);
            item.Quantity = Int16.Parse(Request.Form["Quantity"]);

            if (item.ItemCode.Length == 0 || item.Description.Length== 0)
            {
                errorMessage = "All the Fields are Required";
                return;

            }

            try
            {

                BCS RequestDirector = new BCS();

                RequestDirector.updateItem(item.ItemCode, item.Description,item.UnitPrice, item.Quantity);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            item.ItemCode = ""; item.Description = "";
            successMessage = "The Item Was Updated Successfully";
            return;

          
        }
    }
}
