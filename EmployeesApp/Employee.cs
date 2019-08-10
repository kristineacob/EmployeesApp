using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp
{
    class Employee
    {
        private const string TEXT_FILE_NAME = "Employee.txt";
        public string Name { get; set; }    
        public string Title { get; set; }

        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name}, {employee.Title}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);
        }

        public async static Task<ICollection<Employee>>
            GetAllEmployeesAsync()
        {
            var emploeyees = new List<Employee>();
            var content = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = content.Split('\r', '\n');
            foreach(var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var lineParts = line.Split(',');
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]
                };

                emploeyees.Add(employee);

            }
        }
    }
}
