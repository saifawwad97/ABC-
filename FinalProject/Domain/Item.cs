﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Domain
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }

        public int Quantity { get; set; }
        public  string ItemTotal { get; set; }
    }
}
