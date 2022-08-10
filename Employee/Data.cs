using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class Data
    {
        private static List<Employee> employee;     //declare a generic list

        static Data()
        {
            employee = new List<Employee>();        //initialize the list
        }

        //a generic list method that add data into the Employee list
        public static List<Employee> GetDataRecords()
        {
            Hourly hourly = new Hourly("977993106", "Keelan", "North", 18, 40);
            hourly.HireDate = DateTime.Parse("2022-08-05");
            hourly.BirthDate = DateTime.Parse("1980-12-13");
            hourly.Phone = "6159985792";
            hourly.Address = new Address{
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly.Email = "randomperson@gmail.com";
            hourly.Active = true;
            employee.Add(hourly);                               //add object with data into list
                                                                //repeat with the rest

            Hourly hourly2 = new Hourly("665370318", "Eman", "England", 24, 40);
            hourly2.HireDate = DateTime.Parse("2021-08-16");
            hourly2.BirthDate = DateTime.Parse("1992-02-10");
            hourly2.Phone = "6971368629";
            hourly2.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly2.Email = "randomperson@gmail.com";
            hourly2.Active = true;
            employee.Add(hourly2);

            Hourly hourly3 = new Hourly("344115475", "Mikaela", "Lucero", 17, 40);
            hourly3.HireDate = DateTime.Parse("2021-09-08");
            hourly3.BirthDate = DateTime.Parse("1991-10-23");
            hourly3.Phone = "8596726839";
            hourly3.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly3.Email = "randomperson@gmail.com";
            hourly3.Active = true;
            employee.Add(hourly3);

            Hourly hourly4 = new Hourly("171914661", "Mcauley", "Marshall", 28, 40);
            hourly4.HireDate = DateTime.Parse("2021-09-15");
            hourly4.BirthDate = DateTime.Parse("1986-07-26");
            hourly4.Phone = "5849022271";
            hourly4.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly4.Email = "randomperson@gmail.com";
            hourly4.Active = true;
            employee.Add(hourly4);

            Hourly hourly5 = new Hourly("876962245", "Izabelle", "Lacey", 24, 40);
            hourly5.HireDate = DateTime.Parse("2021-10-13");
            hourly5.BirthDate = DateTime.Parse("1994-07-27");
            hourly5.Phone = "5001385952";
            hourly5.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly5.Email = "randomperson@gmail.com";
            hourly5.Active = true;
            employee.Add(hourly5);

            Hourly hourly6 = new Hourly("840921708", "Zakk", "Findlay", 20, 40);
            hourly6.HireDate = DateTime.Parse("2021-09-28");
            hourly6.BirthDate = DateTime.Parse("1983-01-04");
            hourly6.Phone = "5125405905";
            hourly6.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            hourly6.Email = "randomperson@gmail.com";
            hourly6.Active = true;
            employee.Add(hourly6);

            Salary salary = new Salary("434310459", "Aviana", "Cantu", 83000);
            salary.HireDate = DateTime.Parse("2021-10-08");
            salary.BirthDate = DateTime.Parse("1986-06-24");
            salary.Phone = "3143762442";
            salary.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary.Email = "randomperson@gmail.com";
            salary.Active = true;
            employee.Add(salary);

            Salary salary2 = new Salary("587537913", "Coen", "Romero", 96000);
            salary2.HireDate = DateTime.Parse("2021-11-02");
            salary2.BirthDate = DateTime.Parse("1994-03-09");
            salary2.Phone = "3143762442";
            salary2.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary2.Email = "randomperson@gmail.com";
            salary2.Active = true;
            employee.Add(salary2);

            Salary salary3 = new Salary("866081710", "Piers", "Mays", 60000);
            salary3.HireDate = DateTime.Parse("2021-11-03");
            salary3.BirthDate = DateTime.Parse("1997-01-14");
            salary3.Phone = "5234503935";
            salary3.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary3.Email = "randomperson@gmail.com";
            salary3.Active = true;
            employee.Add(salary3);

            Salary salary4 = new Salary("893582684", "Karl", "Devine", 61000);
            salary4.HireDate = DateTime.Parse("2021-11-17");
            salary4.BirthDate = DateTime.Parse("1984-11-17");
            salary4.Phone = "8603575378";
            salary4.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary4.Email = "randomperson@gmail.com";
            salary4.Active = true;
            employee.Add(salary4);

            Salary salary5 = new Salary("839007338", "Miyah", "Seymour", 93000);
            salary5.HireDate = DateTime.Parse("2021-08-19");
            salary5.BirthDate = DateTime.Parse("1995-05-28");
            salary5.Phone = "5130342122";
            salary5.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary5.Email = "randomperson@gmail.com";
            salary5.Active = true;
            employee.Add(salary5);

            Salary salary6 = new Salary("184137137", "Mina", "Arroyo", 85000);
            salary6.HireDate = DateTime.Parse("2021-08-25");
            salary6.BirthDate = DateTime.Parse("1985-09-13");
            salary6.Phone = "1430113790";
            salary6.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            salary6.Email = "randomperson@gmail.com";
            salary6.Active = true;
            employee.Add(salary6);

            SoftwareDev softwareDev = new SoftwareDev("623771224", 6000);
            softwareDev.FirstName = "Elizabeth";
            softwareDev.LastName = "Hicks";
            softwareDev.HireDate = DateTime.Parse("2021-10-27");
            softwareDev.BirthDate = DateTime.Parse("1978-05-09");
            softwareDev.Phone = "8157972284";
            softwareDev.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev.Email = "randomperson@gmail.com";
            softwareDev.Active = true;
            employee.Add(softwareDev);

            SoftwareDev softwareDev2 = new SoftwareDev("674581538", 7750);
            softwareDev2.FirstName = "Kara";
            softwareDev2.LastName = "Fellows";
            softwareDev2.HireDate = DateTime.Parse("2021-11-22");
            softwareDev2.BirthDate = DateTime.Parse("1982-01-14");
            softwareDev2.Phone = "9012636916";
            softwareDev2.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev2.Email = "randomperson@gmail.com";
            softwareDev2.Active = true;
            employee.Add(softwareDev2);

            SoftwareDev softwareDev3 = new SoftwareDev("630457538", 7500);
            softwareDev3.FirstName = "Keri";
            softwareDev3.LastName = "Hays";
            softwareDev3.HireDate = DateTime.Parse("2021-12-10");
            softwareDev3.BirthDate = DateTime.Parse("1989-12-13");
            softwareDev3.Phone = "6617713206";
            softwareDev3.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev3.Email = "randomperson@gmail.com";
            softwareDev3.Active = true;
            employee.Add(softwareDev3);

            SoftwareDev softwareDev4 = new SoftwareDev("214661918", 7083);
            softwareDev4.FirstName = "Evelina";
            softwareDev4.LastName = "Estes";
            softwareDev4.HireDate = DateTime.Parse("2021-08-25");
            softwareDev4.BirthDate = DateTime.Parse("1981-11-12");
            softwareDev4.Phone = "3184614912";
            softwareDev4.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev4.Email = "randomperson@gmail.com";
            softwareDev4.Active = true;
            employee.Add(softwareDev4);

            SoftwareDev softwareDev5 = new SoftwareDev("511168618", 5416);
            softwareDev5.FirstName = "Stephan";
            softwareDev5.LastName = "Blackwell";
            softwareDev5.HireDate = DateTime.Parse("2021-09-09");
            softwareDev5.BirthDate = DateTime.Parse("1978-01-23");
            softwareDev5.Phone = "8748555514";
            softwareDev5.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev5.Email = "randomperson@gmail.com";
            softwareDev5.Active = true;
            employee.Add(softwareDev5);

            SoftwareDev softwareDev6 = new SoftwareDev("786174145", 5916);
            softwareDev6.FirstName = "Lewys";
            softwareDev6.LastName = "Griffith";
            softwareDev6.HireDate = DateTime.Parse("2021-09-28");
            softwareDev6.BirthDate = DateTime.Parse("1983-01-31");
            softwareDev6.Phone = "4451844420";
            softwareDev6.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            softwareDev6.Email = "randomperson@gmail.com";
            softwareDev6.Active = true;
            employee.Add(softwareDev6);

            SupplyManager gsm = new SupplyManager("384874482", 129000);
            gsm.FirstName = "Maximilian";
            gsm.LastName = "Sadler";
            gsm.HireDate = DateTime.Parse("2021-10-18");
            gsm.BirthDate = DateTime.Parse("1971-11-25");
            gsm.Phone = "2913658154";
            gsm.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm.Email = "randomperson@gmail.com";
            gsm.Active = false;
            employee.Add(gsm);

            SupplyManager gsm2 = new SupplyManager("258004520", 67000);
            gsm2.FirstName = "Huw";
            gsm2.LastName = "Coombes";
            gsm2.HireDate = DateTime.Parse("2021 -10-25");
            gsm2.BirthDate = DateTime.Parse("1995-08-25");
            gsm2.Phone = "7740739086";
            gsm2.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm2.Email = "randomperson@gmail.com";
            gsm2.Active = false;
            employee.Add(gsm2);

            SupplyManager gsm3 = new SupplyManager("417418582", 99000);
            gsm3.FirstName = "Essa";
            gsm3.LastName = "Blackburn";
            gsm3.HireDate = DateTime.Parse("2021-08-02");
            gsm3.BirthDate = DateTime.Parse("1981-06-18");
            gsm3.Phone = "1814375916";
            gsm3.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm3.Email = "randomperson@gmail.com";
            gsm3.Active = false;
            employee.Add(gsm3);

            SupplyManager gsm4 = new SupplyManager("658645062", 89000);
            gsm4.FirstName = "Marnie";
            gsm4.LastName = "Farmer";
            gsm4.HireDate = DateTime.Parse("2021-08-12");
            gsm4.BirthDate = DateTime.Parse("1972-03-12");
            gsm4.Phone = "1876335241";
            gsm4.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm4.Email = "randomperson@gmail.com";
            gsm4.Active = false;
            employee.Add(gsm4);

            SupplyManager gsm5 = new SupplyManager("906483746", 64000);
            gsm5.FirstName = "Rudi";
            gsm5.LastName = "Barr";
            gsm5.HireDate = DateTime.Parse("2021-09-22");
            gsm5.BirthDate = DateTime.Parse("1973-03-23");
            gsm5.Phone = "4958586997";
            gsm5.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm5.Email = "randomperson@gmail.com";
            gsm5.Active = false;
            employee.Add(gsm5);

            SupplyManager gsm6 = new SupplyManager("151287189", 75000);
            gsm6.FirstName = "Emerson";
            gsm6.LastName = "Travers";
            gsm6.HireDate = DateTime.Parse("2021-10-12");
            gsm6.BirthDate = DateTime.Parse("1975-04-14");
            gsm6.Phone = "1131645323";
            gsm6.Address = new Address
            {
                Street = "391 Foster City Blvd",
                City = "Foster City",
                Province = "CA",
                PostalCode = "94404"
            };
            gsm6.Email = "randomperson@gmail.com";
            gsm6.Active = false;
            employee.Add(gsm6);

            return employee;        //return the list of employees
        }
    }
}
