using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_EntityFramework.DTO
{
    public class ResponseCategoryWithPriceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalPrice { get; set; }
    }
}
