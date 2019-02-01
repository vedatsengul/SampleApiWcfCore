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
    public class User
    {
        public User()
        {
            UserSubscriptions = new List<UserSubscription>();
        }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public IEnumerable<UserSubscription> UserSubscriptions { get; set; }
    }
}