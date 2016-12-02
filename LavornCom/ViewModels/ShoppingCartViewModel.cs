using System.Collections.Generic;
using LavornCom.Models;

namespace LavornCom.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}