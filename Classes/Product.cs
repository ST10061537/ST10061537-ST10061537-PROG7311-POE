using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Classes
{
    public class Product
    {
        //---------------------------------//
        // DECLARATION OF VARIABLES
        //---------------------------------//
        private int productID;
        private string productName;
        private string productCategory;
        private DateTime productDate;
        //---------------------------------//
        // CONSTRUCTORS
        //---------------------------------//
        public Product() { }

        public Product(int productID, string productName, string productCategory, DateTime productDate)
        {
            this.productID = productID;
            this.productName = productName;
            this.productCategory = productCategory;
            this.productDate = productDate;
        }
        //---------------------------------//
        // GETTERS AND SETTERS
        //---------------------------------//
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductCategory { get => productCategory; set => productCategory = value; }
        public DateTime ProductDate { get => productDate; set => productDate = value; }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//