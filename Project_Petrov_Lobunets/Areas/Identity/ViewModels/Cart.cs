using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Petrov_Lobunets.Models.ShoppingCart.Models;

namespace Project_Petrov_Lobunets.Areas.Identity.ViewModels
{
    public class Cart
    {          
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ValidateNever]

        public Product Product { get; set; }
        [ValidateNever]

        public string ApplicationUserId { get; set; }
        [ValidateNever]

        public ApplicationUser ApplicationUser { get; set; }

        public int Count { get; set; }
    }
}
