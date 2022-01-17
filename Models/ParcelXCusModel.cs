using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelX.Models
{
    public class ParcelXCusModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string User_Email { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Wallet_ID { get; set; }
        public string Balance { get; set; }
        public string Password { get; set; }
        public string Enabled { get; set; }
        public DateTime CreatedOn_Date { get; set; }
        public DateTime UpdatedOn_Date { get; set; }


    }
}
