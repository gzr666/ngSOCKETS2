using System;
using System.Collections.Generic;
using DOTNET_CORE.Modeli;

namespace DOTNET_CORE.Models.Data
{
public static class DummyData2
    {
        public static IEnumerable<Employee> GetEmployeeData()
        {
            return new Employee[]
            {
                new Employee
                {
                    Id = 1,
                    Name = "Jack",
                    Position = "CEO",
                    Salary = 100000,
                    JoinedDate = DateTime.UtcNow.AddYears(-2)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bill",
                    Position = "Software Engineer",
                    Salary = 90000,
                    JoinedDate = DateTime.UtcNow.AddYears(-1)
                },
                new Employee
                {
                    Id = 3,
                    Name = "Steve",
                    Position = "QA",
                    Salary = 80000,
                    JoinedDate = DateTime.UtcNow.AddMonths(-2)
                }
            };
        }
}
}