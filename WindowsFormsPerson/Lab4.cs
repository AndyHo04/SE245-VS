﻿//Andy Ho
//Date: 2024-04-18
//Lab 4
/*Program Prompt - 
Part 1 – Within the code for our project, we want to create a “Person” Structure that contains the
following String values: First Name, Middle Name, Last Name, Street1, Street 2, City, State, Zip,
Phone, Email. Give user output to confirm that data was stored within a class object. (You can use the
“Public” precursor here, but it is not necessary till Part 2.)

Part 2 – Convert the structure to a class, making all the properties/variables public (if not already). Test
to see if this code works fine. Once the program works fine with the class, go into the “Main” method
code and make it so that the First Name has the word “Poopy” concatenated with it. (This is to show
you the weakness of developing public properties/variables within classes.

Part 3 – Using the program from #2, make all the properties of the class “private”. Can you
access/change those values within the class anymore? Why? Generate the Gets/Sets
(Accessors/Mutator methods) that allow us to gather private data from the class as well as allow us to
modify class data if the order entry data is valid.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsPerson{
        //Create the validation library
        class ValidationLibrary{
            //check to see if the strings are filled
            public static bool IsFilled(string strValue){
                bool blnResult;
                if (strValue.Length > 0){
                    blnResult = true;
                }
                else{
                    blnResult = false;
                }
                return blnResult;
            }
            //will check for semi-valid email format
           public static bool IsValidEmail(string strEmail){
                bool blnResult = true;
                //check for @ symbol index
                int atLocation = strEmail.IndexOf("@");
                int atNextLocation = strEmail.IndexOf("@", atLocation + 1);
                //check for period index
                int periodLocation = strEmail.LastIndexOf(".");

                if (strEmail.Length < 8)
                {
                    blnResult = false;
                }
                else if (atLocation < 2)
                {
                    blnResult = false;
                }
                else if (periodLocation + 2 > (strEmail.Length))
                {
                    blnResult = false;
                }
                else if (atNextLocation > -1)
                {
                    blnResult = false;
                }   
                return blnResult;
            }
            //check for valid phone number
            public static bool IsValidPhone(string strPhone){
                bool blnResult;
                int index = strPhone.IndexOf("-");
                //check for min phone length
                if ((strPhone.Length <= 12) && (index == 3) && (strPhone[3] == '-') && (strPhone[7] == '-')){
                    blnResult = true;
                }
                else{
                    blnResult = false;
                }
                return blnResult;
            }
            //check for valid zip code
            public static bool IsValidZip(string strZip){
                bool blnResult;
                //check for min zip length
                if (strZip.Length < 5 && strZip.Length > 5){
                    blnResult = true;
                }
                else{
                    blnResult = false;
                }
                return blnResult;
            }
            public static bool IsValidState(string strState)
            {
                bool blnResult;
                //check for state length
                if (strState.Length == 2)
                {
                    blnResult = true;
                }
                else
                {
                    blnResult = false;
                }
                return blnResult;
            }
            public static bool IsValidInstagram(string strInstagram)
            {
                bool blnResult = true;
                // check for period and slash location
                int periodlocation = strInstagram.IndexOf('.');
                int slashlocation = strInstagram.IndexOf("/");
                //check for min instagram length

                if (strInstagram.Length < 12)
                {
                    blnResult = false;
                }
                else if (periodlocation < 2)
                {
                    blnResult = false;
                }
                else if (slashlocation < 2)
                {
                    blnResult = false;
                }
                
                
                return blnResult;   
            }
            public static bool IsAPastDate (DateTime dtDate)
            {
                bool blnResult;
                if (dtDate <= DateTime.Now)
                {
                    blnResult = true;
                }
                else
                {
                    blnResult = false;
                }
                return blnResult;
            }
            public static bool IsAMinimumAmountInt (int intAmount, int intMinimum)
            {
                bool blnResult;
                if (intAmount >= intMinimum)
                {
                    blnResult = true;
                }
                else
                {
                    blnResult = false;
                }
                return blnResult;
            }
            public static bool IsAMinimumAmountDouble (double dblAmount, double dblMinimum)
            {
                bool blnResult;
                if (dblAmount >= dblMinimum)
            {
                    blnResult = true;
                }
                else
            {
                    blnResult = false;
                }
                return blnResult;
            }   
            public static bool IsADiscountMember (bool blnDiscount)
             {
                bool blnResult;
                if (blnDiscount == true)
            {
                    blnResult = true;
                }
                else
            {
                    blnResult = false;
                }
                return blnResult;
            }

        }
        class Person{
            private string _firstName;
            private string _middleName;
            private string _lastName;
            private string _street1;
            private string _street2;
            private string _city;
            private string _state;
            private string _zip;
            private string _phone;
            private string _email;
            private string feedback;
            
           
            public string FirstName{
                get{
                    return _firstName;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _firstName = value;
                    }
                    else{
                        _firstName = "INVALID";
                    
                    }
                }
            }
            public string MiddleName{
                get{
                    return _middleName;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _middleName = value;
                    }
                    else{
                        _middleName = "No Middle Name";
                    }
                }
            }
            public string LastName{
                get{
                    return _lastName;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _lastName = value;
                    }
                    else{
                        _lastName = "INVALID";
                    }
                }
            }
            public string Street1{
                get{
                    return _street1;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _street1 = value;
                    }
                    else{
                        _street1 = "INVALID";
                    }
                }
            }
            public string Street2{
                get{
                    return _street2;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _street2 = value;
                    }
                    else{
                        _street2 = "INVALID";
                    }
                }
            }
            public string City{
                get{
                    return _city;
                }
                set{
                    if (ValidationLibrary.IsFilled(value)){
                        _city = value;
                    }
                    else{
                        _city = "INVALID";
                    }
                }
            }
            public string State{
                get{
                    return _state;
                }
                set{
                    if (ValidationLibrary.IsValidState(value)){
                        _state = value;
                    }
                    else{
                        _state = "INVALID";
                    }
                }
            }
            public string Zip{
                get{
                    return _zip;
                }
                set{
                    if (ValidationLibrary.IsValidZip(value) == false){
                        _zip = value;
                    }
                    else{
                        _zip = "INVALID";
                    }
                }
            }
            public string Phone{
                get{
                    return _phone;
                }
                set{
                    if (ValidationLibrary.IsValidPhone(value) == true){
                        _phone = value;
                    }
                    else{
                        _phone = "INVALID";
                    }
                }
            }
            public string Email{
                get{
                    return _email;
                }
                set{
                    if (ValidationLibrary.IsValidEmail(value)){
                        _email = value;
                    }
                    else{
                        _email = "INVALID";
                    }

                }
            }
             public string PerFeedback
             {

                get { return feedback; }
                set { feedback = value; }
           
             }

            public Person()
            {
                _firstName = "";
                _middleName = "";
                _lastName = "";
                _street1 = "";
                _street2 = "";
                _city = "";
                _state = "";
                _zip = "";
                _phone = "";
                _email = "";
                feedback = "";
            }
        }
        class PersonV2: Person{
        private string cellphone;
        private string instagramurl;

        public string CellPhone
        {
            get
            {
                return cellphone;
            }
            set
            {
                if (ValidationLibrary.IsValidPhone(value) == true)
                {
                    cellphone = value;
                }
                else
                {
                    cellphone = "INVALID";
                }
            }
        }
        public string InstagramUrl
        {
            get
            {
                return instagramurl;
            }
            set
            {
                if (ValidationLibrary.IsValidInstagram(value) == true)
                {
                    instagramurl = value;
                }
                else
                {
                    instagramurl = "INVALID";
                }
            }

        }
        
        public string AddARecord() 
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu,4500;Database=Dev_202430_AHo;User Id=Dev_202430_AHo;Password=008021468;";     //Set the Who/What/Where of DB

            //insert data into sql server
            SqlCommand comm = new SqlCommand();
            string strSql = "INSERT INTO PersonV2 (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zip, Phone, Email, CellPhone, InstagramUrl) VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Email, @CellPhone, @InstagramUrl)";
            comm.CommandText = strSql;
            comm.Connection = Conn;

            //fill in the parameters
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@MiddleName", MiddleName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@Zip", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@CellPhone", CellPhone);
            comm.Parameters.AddWithValue("@InstagramUrl", InstagramUrl);

            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int IntRecs = comm.ExecuteNonQuery();               // Actually run the command (Non Query)
                strResult = $"SUCCESS: Inserted {IntRecs} record."; //Report that we have made the connection
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }




            //Return resulting feedback string
            return strResult;
        }

        public PersonV2(): base()
        {
            cellphone = "";
            instagramurl = "";
        }

    }



}  
    



