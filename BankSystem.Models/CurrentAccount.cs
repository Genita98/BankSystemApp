using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class CurrentAccount
    {

        [Key]
        public int AccountId { get; set; } 

        [Required]
        public string CurrentAccountNumber { get; set; }  
        public double AccountBalance { get; set; }    
        public double Reservations { get; set; }
        public string Valuta { get; set; }

        [DisplayName("Id Card")]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client ?Client { get; set; }

    }
}
