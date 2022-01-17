using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdcelInventory.Models
{
    public class WalletModel
    {   
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        public string Email { get; set; }
        public string NGN_Wallet_ID { get; set; }
        public string NGN_Wallet_Balance { get; set; }
        public DateTime NGN_Wallet_Create_Date { get; set; }
        public string USD_Wallet_ID { get; set; }
        public string USD_Wallet_Balance { get; set; }
        public DateTime USD_Wallet_Create_Date { get; set; }
        public string CAD_Wallet_ID { get; set; }
        public string CAD_Wallet_Balance { get; set; }
        public DateTime CAD_Wallet_Create_Date { get; set; }
        public string GBP_Wallet_ID { get; set; }
        public string GBP_Wallet_Balance { get; set; }
        public DateTime GBP_Wallet_Create_Date { get; set; }
        public string EURO_Wallet_ID { get; set; }
        public string EURO_Wallet_Balance { get; set; }
        public DateTime EURO_Wallet_Create_Date { get; set; }

    }
}
