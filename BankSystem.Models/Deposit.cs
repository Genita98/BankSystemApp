﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class Deposit
    {
        [Key]
        public int DepositId { get; set; }
        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public CurrentAccount ?CurrentAccount { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
