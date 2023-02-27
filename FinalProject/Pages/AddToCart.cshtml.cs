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
    public class AddToCartModel : PageModel
    {

        [BindProperty]
        [Required]
        [StringLength(10, MinimumLength = 6)]

        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public string errorMessage = "";
        public string successMessage = "";


        public Item item = new Item();


        public List<Item> addtocart = new List<Item>();


        public void OnGet()
        {
        }

        public void Onpost()

         
        {
            item.Quantity = Int16.Parse(Request.Form["Quantity"]);
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new BCS();

                addtocart = RequestDirector.AddToCart(ItemCode, Quantity);

            }

        }
    }
}
