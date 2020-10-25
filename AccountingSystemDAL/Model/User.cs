using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSystemDAL.Model
{
    public partial class User : ModelBase
    {

        [Key]
        public Guid UserId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public string WinUserName { get; set; }
        public virtual ICollection<Data> Transactions { get; set; } = new HashSet<Data>();

        public override string ToString() => FirstName + " " + LastName;

    }
}
