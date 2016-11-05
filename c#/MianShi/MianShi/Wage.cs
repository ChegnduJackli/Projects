using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class Wage
    {
        public void Run()
        {
            Staff staff = new Staff(new SoftWareDept());
            staff.staffName = "Li Deng";
            staff.Payment();

            staff = new Staff(new AccounntDept());
            staff.Payment();
        }
    }
    interface SalayPay
    {
        void Payment();
    }
    public abstract class Department
    {
        public abstract double GetRate();
        public string DeptName { get; set; }
    }
    public class SoftWareDept : Department
    {
        public SoftWareDept()
        {
            base.DeptName = "Software department";
           
        }

        public override double GetRate()
        {
            return 0.95;
        }
    }

    public class AccounntDept : Department
    {
        public AccounntDept()
        {
            base.DeptName = "Account department";
        }
        public override double GetRate()
        {
            return 0.90;
        }
    }

    public class Staff:SalayPay
    {
        Department _dept;
        private double _basePerform = 0.9;
        private double _baseSalary = 5000;

        public string staffName { get;set;}

        public Staff(Department dept)
        {
            this._dept = dept;
        }

        public void Payment()
        {
            double salary = this._dept.GetRate() * this._baseSalary * this._basePerform;
            Console.WriteLine("Deparment: "+ _dept.DeptName);
            Console.WriteLine("StaffName:"+this.staffName+" Staff Payment Salary:"+ salary);
        }
    }
}
