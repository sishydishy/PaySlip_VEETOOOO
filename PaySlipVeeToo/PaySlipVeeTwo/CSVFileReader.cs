using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using PaySlipVeeTwo;

namespace PaySlipVeeToo
{
    public class CSVFileReader:IEmployeeDetails
    {
        public List<EmployeeDetails> DeserialiseEmployeeDetails()
        {
            var filePath =
                "/Users/saish.dharvotkar/Projects/src/Katas/PaySlip_VEETOOOO/PaySlipVeeToo/PaySlipVeeTwo/Resources/Sample_Input.csv";
            var streamReader = new StreamReader(filePath);
            var csv = new CsvReader(streamReader);
            csv.Configuration.RegisterClassMap<ModelMap>();
            var records = csv.GetRecords<EmployeeDetails>().ToList();

            return records;
        }

        public List<EmployeeDetails> GetEmployeeDetails()
        {
            return DeserialiseEmployeeDetails();
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
}