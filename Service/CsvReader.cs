using HCL_AssignMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL_AssignMent.Service
{
    public static class CsvReader
    {
        public static List<ApplicationModel> ReadInstallations(string filePath) {
            var installations = new List<ApplicationModel>();

            try { 
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream) { 
                    
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        var installation = new ApplicationModel
                        {
                            ComputerId = int.Parse(values[0]),
                            UserId = int.Parse(values[1]),
                            ApplicationId = int.Parse(values[2]),
                            ComputerType = values[3],
                            Comment = values[4]
                        };
                        installations.Add(installation);
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }
            return installations;
        }
    }
}
