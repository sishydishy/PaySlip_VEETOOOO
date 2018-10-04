using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace PaySlipVeeToo.Test
{
    public class CSVFileReader
    {
        public List<EmployeeDetails> GetEmployeeDetails()
        {
            var filePath =
                "/Users/saish.dharvotkar/Projects/src/Katas/PaySlip_VEETOOOO/PaySlipVeeToo/PaySlipVeeTwo/Resources/Sample_Input.csv";
            var streamReader = new StreamReader(filePath);
            var csv = new CsvReader(streamReader);
            csv.Configuration.RegisterClassMap<ModelMap>();
            var records = csv.GetRecords<EmployeeDetails>().ToList();

            return records;
        }
        
        
    }

    public class ModelMap : ClassMap<EmployeeDetails>
    {
        public ModelMap()
        {
            Map(x => x.AnnualSalary).Name("annual salary");
            Map(x => x.FirstName).Name("first name");
            Map(x => x.LastName).Name("last name");
            Map(x => x.SuperRate).Name("super rate (%)");
            Map(x => x.PayPeriod).Name("payment start date");
        }
    }


    public class EmployeeDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " "+ LastName;

        public decimal AnnualSalary { get; set; }
        public string SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}