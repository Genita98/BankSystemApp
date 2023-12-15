using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class Client
    {
        
        [Key]
        [DisplayName("Id Card")]
        public int IdCardClient { get; set; } 

        [Required]
        [DisplayName("Client name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Client surname")]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone number")]

        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }


    }
}
