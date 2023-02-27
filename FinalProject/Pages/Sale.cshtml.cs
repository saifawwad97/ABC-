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
    public class SaleModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(10, MinimumLength = 6)]

        public string ItemCode { get; set; }
        public string errorMessage = "";
        public string successMessage = "";
        public string GetItem { get; set; }
        public string aa { get; set; }
        public string name { get; set; }
    



        public List<Item> getitem = new List<Item>();


        public void OnGet()
        {
        }

        public void Onpost()
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new BCS();

                getitem = RequestDirector.GetItem(ItemCode);

            }

        }
    }
}
