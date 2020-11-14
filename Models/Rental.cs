using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace rentManagement.Models
{
    public class Rental
    {
        public Rental(int apartmentNum, int unitNum, double numOfRooms, double cost, bool isAssigned)
        {
            this.Apartment = apartmentNum;
            this.Unit = unitNum;
            this.NumberOfRoom = numOfRooms;
            this.Cost = cost;
            this.IsAssigned = false;
        }
        // Data member
        
        private int apartment;
        private int unit; 
        private double numberofroom;
        private double cost;
        

        //properties
        public int Apartment { get; private set; }
        public int Unit { get; set; }
        public double NumberOfRoom { get; private set; }
        public double Cost { get; private set; }
        
        public Tenant tenant { get; set; }  

        public bool IsAssigned { get; set; }   
        


    }
    
}