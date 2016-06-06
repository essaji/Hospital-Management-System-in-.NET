using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    class PatientViewModel : IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }

        public string this[string propName]
        {
            get
            {
                string result = null;
                if (propName == "Name" && string.IsNullOrEmpty(this.Name))
                    result = "Name is required.";
                else if (propName == "Dob" && string.IsNullOrEmpty(this.Dob))
                    result = "Date of birth is required.";
                else if (propName == "Category" && string.IsNullOrEmpty(this.Category))
                    result = "Category name is required.";
                else if ((propName == "Female" || propName == "Male") && (!Female && !Male))
                    result = "Please select a gender.";
                return result;
            }
        }
        
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Category { get; set; }
        public bool Female { get; set; }
        public bool Male { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<long> did { get; set; }
    }
}
