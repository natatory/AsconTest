using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSystemDAL.Model
{
    //idea behind this class is to encapsulate user roles.
    //this will allow to have flexible configuration of access rights
    //for possible new user groups
    public partial class Group : ModelBase
    {
        [Key]
        public Guid GroupId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool CanManageEmployee { get; set; }

        [Required]
        public bool CanAddCategories { get; set; }

        public override string ToString() => Name;
    }
}
