using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeEntity employee1 = new EmployeeEntity { ID = 1, EmployeeName = "Steve", Salary = 5000, DeptCode = 123, Designation = "Engineer", ReportingTo = "Adam" };
            EmployeeEntity employee2 = new EmployeeEntity { ID = 2, EmployeeName = "Ben", Salary = 4000, DeptCode = 123, Designation = "Engineer", ReportingTo = "Adam" };
            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee2.ToString());
            Console.WriteLine($"Is Department Code same for both employees?: {employee1.DeptCode == employee2.DeptCode}");
            Console.WriteLine($"Whether both employees are same?: {employee1 == employee2}");
            Console.WriteLine(employee1 >= employee2);
            Console.WriteLine(employee1 <= employee2);
            employee1++;
            Console.WriteLine($"{employee1.EmployeeName} received a salary hike of 100 dollars to ${employee1.Salary}");
            employee2--;
            Console.WriteLine($"{employee2.EmployeeName}'s salary is reduced by 100 dollars to ${employee2.Salary}");
            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee2.ToString());
            Console.ReadLine();
        }
    }

    class EmployeeEntity
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public int DeptCode { get; set; }
        public string Designation { get; set; }
        public string ReportingTo { get; set; }

        #region BINARY OPERATOR OVERLOADING
        public static bool operator ==(EmployeeEntity e1, EmployeeEntity e2)
        {
            return e1.Equals(e2);
        }
        public static bool operator !=(EmployeeEntity e1, EmployeeEntity e2)
        {
            return !(e1 == e2);
        }
        /// <summary>
        /// Greter than or equal to operator overloading. Here I have returned a string to show that 
        /// in binary operator overloading the return type can be different than the parameter type being overloaded
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static string operator >=(EmployeeEntity e1, EmployeeEntity e2)
        {
            if (e1.Salary == e2.Salary)
                return "They both earn Same Salary";
            else if (e1.Salary > e2.Salary)
                return $"{e1.EmployeeName} earns ${e1.Salary - e2.Salary} more than {e2.EmployeeName}";
            else
                return $"{e2.EmployeeName} earns ${e2.Salary - e1.Salary} more than {e1.EmployeeName}";
        }
        public static string operator <=(EmployeeEntity e1, EmployeeEntity e2)
        {
            if (e1.Salary == e2.Salary)
                return "They both earn Same Salary";
            else if (e1.Salary < e2.Salary)
                return $"{e1.EmployeeName} earns ${e2.Salary - e1.Salary} less than {e2.EmployeeName}";
            else
                return $"{e2.EmployeeName} earns ${e1.Salary - e2.Salary} less than {e1.EmployeeName}";
        } 
        #endregion

        #region UNARY OPERATOR OVERLOADING
        public static EmployeeEntity operator ++(EmployeeEntity e1)
        {
            e1.Salary += 100;
            return e1;
        }
        public static EmployeeEntity operator --(EmployeeEntity e1)
        {
            if (e1.Salary > 99)
                e1.Salary -= 100;
            return e1;
        } 
        #endregion

        public override string ToString()
        {
            return $"Employee ID: {this.ID}, Employee Name: {this.EmployeeName}, Salary: {this.Salary}, " +
                   $"Department Code: {this.DeptCode}, Designation: {this.Designation}, Reporting to: {this.ReportingTo}";
        }
        public override bool Equals(object obj)
        {
            return obj is EmployeeEntity emp && EqualTo(emp);
        }
        private bool EqualTo(EmployeeEntity emp)
        {
            return (emp != null) && (ID == emp.ID &&
                    EmployeeName == emp.EmployeeName &&
                    Salary == emp.Salary &&
                    DeptCode == emp.DeptCode &&
                    Designation == emp.Designation &&
                    ReportingTo == emp.ReportingTo);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
