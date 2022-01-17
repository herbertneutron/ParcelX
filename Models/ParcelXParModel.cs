using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelX.Models
{
    public class ParcelXParModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Partner_Id { get; set; }
        public string Business_Name { get; set; }
        public string Business_Email { get; set; }
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string Business_Address { get; set; }
        public string Business_LGA { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Storage_Abilty { get; set; }
        public string Interstate { get; set; }
        public string International { get; set; }
        public string Express_Delivery { get; set; }
        public string Last_Updated_By { get; set; }
        public string Partner_Status { get; set; }
        public string Vehicle_Type { get; set; }
        public DateTime Resumption_DateTime { get; set; }
        public DateTime Closing_Datetime { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Last_Updated_On { get; set; }
        public string Sameday_Delivery { get; set; }
        public string Operating_Area { get; set; }
        public string Business_Type { get; set; }
        public string Address_Doc { get; set; }
        public string CAC_Doc { get; set; }
        public string Memorandom_Doc { get; set; }
        public string ID_Doc { get; set; }
        public string Settlement_Account { get; set; }


    }
}
