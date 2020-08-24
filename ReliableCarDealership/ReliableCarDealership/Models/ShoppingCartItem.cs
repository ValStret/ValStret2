﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class ShoppingCartItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PartId { get; set; }

        public Part CartItemPart { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        public Cart ShoppingCart { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }

    }
}

