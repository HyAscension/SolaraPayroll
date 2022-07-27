using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public struct Address
    {
        private string street;
        private string city;
        private string province;
        private string postalcode;

        public string Street
        {
            get => street;
            set => street = value != "" && !int.TryParse(value, out int notStreet) ? value : "";
        }

        public string City
        {
            get => city; 
            set => city = value != "" && !int.TryParse(value, out int notCity) ? value : "";
        }

        public string Province
        {
            get => province; 
            set => province = value != "" && !int.TryParse(value, out int notProvince) ? value : "";
        }

        public string PostalCode
        {
            get => postalcode; 
            set => postalcode = value != "" && !int.TryParse(value, out int notCode) ? value : "";
        }

        public override string ToString() => $"{Street}, {City}, {Province}, {PostalCode}.";


    }
}
