using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSystemDAL.Model
{
    public partial class Recipient : ModelBase
    {

        [Key]
        public Guid RecipientId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
