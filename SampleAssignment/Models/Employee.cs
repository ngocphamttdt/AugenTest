using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SampleAssignment.Models
{
    public class Employee
    {
        public int index { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string post { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public string web { get; set; }

        public static Employee FromCsv(string csvLine)
        {
          
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            String[] values = CSVParser.Split(csvLine);
            // string[] values = csvLine.Split(',');
            Employee employeeValues = new Employee();

            employeeValues.first_name = Convert.ToString(values[0]);
            employeeValues.last_name = Convert.ToString(values[1]);
            employeeValues.company_name = Convert.ToString(values[2]);
            employeeValues.address = Convert.ToString(values[3]);
            employeeValues.city = Convert.ToString(values[4]);
            employeeValues.state = Convert.ToString(values[5]);
            employeeValues.post = Convert.ToString(values[6]);
            employeeValues.phone1 = Convert.ToString(values[7]);
            employeeValues.phone2 = Convert.ToString(values[8]);
            employeeValues.email = Convert.ToString(values[9]);
            employeeValues.web = Convert.ToString(values[10]);

            return employeeValues;
        }
    }
}