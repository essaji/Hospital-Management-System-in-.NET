using HMS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    class ValidationModel : IDataErrorInfo
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
                if (propName == "MedName" && string.IsNullOrEmpty(this.MedName))
                    result = "Medicine Name is required.";
                else if (propName == "MedPrice")
                {
                    if (this.MedPrice == null)
                        result = "Medicne price is required.";
                    else if (this.MedPrice <= 0)
                        result = "Medicine price must be positive number.";
                }
                else if (propName == "NoOfBeds")
                {
                    if (this.NoOfBeds == null)
                        result = "No of beds is required.";
                    else if (this.NoOfBeds <= 0)
                        result = "No of beds should be greater than zero.";
                }
                else if (propName == "GovernedBy" && string.IsNullOrEmpty(this.GovernedBy))
                    result = "Please select a nurse name.";
                return result;
            }
        }

        public long? NoOfBeds { get; set; }

        public string GovernedBy { get; set; }

        public string MedName { get; set; }
        public long? MedPrice { get; set; }
    }
}
