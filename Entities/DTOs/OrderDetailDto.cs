using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto:IDto
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
