﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_EntityFramework.DTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string HiddenCode { get; set; }
        public int CategoryId { get; set; }
    }
}
