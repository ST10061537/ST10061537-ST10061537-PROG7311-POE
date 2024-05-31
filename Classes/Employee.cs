using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Classes
{
    public class Employee
    {
        //---------------------------------//
        // DECLARATION OF VARIABLES
        //---------------------------------//
        private int employeeID;
        private string empFirstName;
        private string empLastName;
        //---------------------------------//
        // CONSTRUCTORS
        //---------------------------------//
        public Employee () { }

        public Employee(int employeeID, string empFirstName, string empLastName)
        {
            this.employeeID = employeeID;
            this.empFirstName = empFirstName;
            this.empLastName = empLastName;
        }
        //---------------------------------//
        // GETTERS AND SETTERS
        //---------------------------------//
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmpFirstName { get => empFirstName; set => empFirstName = value; }
        public string EmpLastName { get => empLastName; set => empLastName = value; }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//