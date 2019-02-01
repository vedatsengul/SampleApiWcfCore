using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebTel.API.DTOs
{
    public class SubscriptionDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceWithVAT { get; set; }
        public int CallMinutes { get; set; }
    }
}
