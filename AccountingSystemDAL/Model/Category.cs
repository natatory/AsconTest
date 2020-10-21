using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingSystemDAL.Model
{
    public partial class Category : ModelBase
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
