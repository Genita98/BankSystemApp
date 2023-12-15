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
        public int IdAccount { get; set; }
        public string CurrentAccountNumber { get; set; }  
        public double AccountBalance { get; set; }    
        public double Reservations { get; set; }
        public string Valuta { get; set; }
        [DisplayName("Id Card")]
        public int IdCardClient { get; set; }
        [ForeignKey("IdCardClient")]
        public Client ?Client { get; set; }  
    }
}
