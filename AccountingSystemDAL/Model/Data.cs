using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSystemDAL.Model
{
    public partial class Data : ModelBase
    {

        [Key]
        public Guid DataId { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public OperationType OpType { get; set; }
        public enum OperationType { Доходы, Расходы }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal BalanceAfterTransact { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public Guid RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual Recipient Recipient { get; set; }

        public override string ToString() => Description;

    }
}
