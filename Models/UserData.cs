using System;
using Microsoft.AspNetCore.Http;

namespace ParcelX.Models
{
    public class UserData
    {

        //Customer Data
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile_Number { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Mobile_Verification { get; set; }
        public string Country_Name { get; set; }
        public string Country_Code { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string WalletCurrency { get; set; }
        public DateTime Create_Date { get; set; }
        public string Response { get; set; }
        public string Token { get; set; }


        //Partner Data
        public string BusinessName { get; set; }
        public string PartnerMobile { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerPassword { get; set; }

        public string Partner_Id { get; set; }
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
        //public string Public_Holidays { get; set; }
        public DateTime Resumption_DateTime { get; set; }
        public DateTime Closing_Datetime { get; set; }
        public string Sameday_Delivery { get; set; }
        public string Operating_Area { get; set; }
        public string Business_Type { get; set; }
        public string Address_Doc { get; set; }
        public string CAC_Doc { get; set; }
        public string Memorandom_Doc { get; set; }
        public string ID_Doc { get; set; }
        public string Settlement_Account { get; set; }
        public string HasBike { get; set; }
        public string HasSmallvan { get; set; }
        public string HasBigvan { get; set; }
        public string Bank { get; set; }
        public string Account_Type { get; set; }
        public string AccountNumber { get; set; }
       

    }
}
