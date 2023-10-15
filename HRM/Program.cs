using HRM;
using HRM.Models;

HRSystem hrSystem = new HRSystem("employees.json", "bank.json");

// Add employees
Employee john = new Employee { Name = "Mahmood", Position = "Manager", Salary = 5000 };
Employee alice = new Employee { Name = "Jamal", Position = "Senior Developer", Salary = 3000 };
hrSystem.AddEmployee(john);
hrSystem.AddEmployee(alice);

// Promote employee
hrSystem.PromoteEmployee("Mahmood", "CEO", 2000);

// Demote employee
hrSystem.DemoteEmployee("Jamal", "Junior Developer", 1000);

// Remove employee
hrSystem.RemoveEmployee("Jamal");