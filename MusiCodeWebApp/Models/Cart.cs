using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace MusiCodeWebApp.Models
{
    public class Cart : Entity
    {
        public int Member_ID { get; set; }

        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }

        public int Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
}