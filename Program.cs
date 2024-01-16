using HCL_AssignMent.Service;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Read data from CSV (replace this with your actual file reading logic)


        var installations = CsvReader.ReadInstallations(@"D:\Learning\concepts\HCL_AssignMent\Data\sample-small.csv");

        var service = new ApplicationService();
        int minCopies = service.CalculateMinimunCopies(installations, 374);

        Console.WriteLine($"Minimum copies needed: {minCopies}");

        Console.ReadLine(); // Pause the console to see the result
    }
}
