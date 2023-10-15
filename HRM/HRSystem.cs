using HRM.Models;
using HRM.Utils;

namespace HRM
{
    public class HRSystem
    {
        private List<Employee> employees;
        private Bank bank;
        private string employeesDataFilePath;
        private string bankDataFilePath;

        public HRSystem(string employeesDataFilePath, string bankDataFilePath)
        {
            employees = new List<Employee>();
            this.employeesDataFilePath = employeesDataFilePath;
            this.bankDataFilePath = bankDataFilePath;

            // Set initial budget and load bank data
            bank = new Bank(500000, bankDataFilePath);
            LoadData();
        }

        public bool AddEmployee(Employee employee)
        {
            if (CheckEmployeeExists(employee.Name))
                return false;

            employees.Add(employee);
            SaveData();

            return true;
        }

        public bool RemoveEmployee(string name)
        {
            Employee employee = GetEmployeeByName(name);
            if (employee == null)
                return false;

            employees.Remove(employee);
            SaveData();

            return true;
        }

        public bool PromoteEmployee(string name, string newPosition, float salaryIncrease)
        {
            Employee employee = GetEmployeeByName(name);
            if (employee == null)
                return false;

            float oldSalary = employee.Salary;
            employee.Position = newPosition;
            employee.Salary += salaryIncrease;

            bank.DeductFromBudget(salaryIncrease - oldSalary);
            SaveData();

            return true;
        }

        public bool DemoteEmployee(string name, string newPosition, float salaryDecrease)
        {
            Employee employee = GetEmployeeByName(name);
            if (employee == null)
                return false;

            float oldSalary = employee.Salary;
            employee.Position = newPosition;
            employee.Salary -= salaryDecrease;

            bank.AddToBudget(oldSalary - employee.Salary);
            SaveData();

            return true;
        }

        private void SaveData()
        {
            DataStorage<Employee>.SaveData(employeesDataFilePath, employees);
        }

        private void LoadData()
        {
            employees = DataStorage<Employee>.LoadData(employeesDataFilePath);
        }

        private bool CheckEmployeeExists(string name)
        {
            return employees.Exists(e => e.Name == name);
        }

        private Employee GetEmployeeByName(string name)
        {
            return employees.Find(e => e.Name == name);
        }
    }
}
