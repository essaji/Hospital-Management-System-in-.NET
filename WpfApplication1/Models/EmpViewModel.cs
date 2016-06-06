using HMS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    class EmpViewModel : IDataErrorInfo
    {
        HmsDA hms = new HmsDA();
        public string Error
        {
            get { return null; }
        }

        public string this[string propName]
        {
            get
            {
                string result = null;
                if (propName == "Firstname" && string.IsNullOrEmpty(this.Firstname))
                    result = "Firstname is required.";
                else if (propName == "Lastname" && string.IsNullOrEmpty(this.Lastname))
                    result = "Lastname is required.";
                else if (propName == "Category" && string.IsNullOrEmpty(this.Category))
                    result = "Category name is required.";
                else if (propName == "Username")
                {
                    if (string.IsNullOrEmpty(this.Username))
                        result = "Username is required";
                    else if (hms.getUser(this.Username) != null)
                        result = "Username is not available. Please choose another";
                }
                    
                else if (propName == "Password" && string.IsNullOrEmpty(this.Password))
                    result = "Password is required.";
                else if (propName == "Experience" && string.IsNullOrEmpty(this.Experience))
                    result = "Experience is required.";
                else if (propName == "Phone" && string.IsNullOrEmpty(this.Phone))
                    result = "Phone number is required.";
                else if (propName == "Dob" && Dob == null)
                    result = "Date of birth is required.";
                else if (propName == "Salary")
                {
                    if (this.Salary == null)
                        result = "Salary is required.";
                    else if (this.Salary <= 999)
                        result = "Salary must be greater than 1000.";
                }
                    
                return result;
            }
        }

        public DateTime Dob { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public string Experience { get; set; }
        public string Phone { get; set; }
        public long? Salary { get; set; }

        
    }
}
