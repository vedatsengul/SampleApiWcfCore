using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RebTel.WCF.Models
{
    [DataContract]
    public class Subscription
    {
        public Subscription()
        {
            UserSubscriptions = new List<UserSubscription>();
        }
        [DataMember]
        [Key]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal PriceWithVAT { get; set; }
        [DataMember]
        public int CallMinutes { get; set; }

        public List<UserSubscription> UserSubscriptions { get; set; }
    }
}