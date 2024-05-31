using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Classes
{
    public class Farmer
    {
        //---------------------------------//
        // DECLARATION OF VARIABLES
        //---------------------------------//
        private int farmerID;
        private string farmerFirstName;
        private string farmerLastName;
        //---------------------------------//
        // CONSTRUCTORS
        //---------------------------------//
        public Farmer() { }

        public Farmer(int farmerID, string farmerFirstName, string farmerLastName)
        {
            this.farmerID = farmerID;
            this.farmerFirstName = farmerFirstName;
            this.farmerLastName = farmerLastName;
        }
        //---------------------------------//
        // GETTERS AND SETTERS
        //---------------------------------//
        public int FarmerID { get => farmerID; set => farmerID = value; }
        public string FarmerFirstName { get => farmerFirstName; set => farmerFirstName = value; }
        public string FarmerLastName { get => farmerLastName; set => farmerLastName = value; }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//