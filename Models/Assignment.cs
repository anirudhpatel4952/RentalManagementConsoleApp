using System;

namespace rentManagement.Models
{
    public class Assignment
    {
        public Assignment(Rental rental, Tenant tenant) 
        {
            this.AssignId = Guid.NewGuid();
            this.Rental = rental;
            this.Tenant = tenant;
            this.IsAssigned = false;
               
        }
        public Assignment()
        {
            
        }
        public Guid AssignId { get; }
        public Tenant Tenant { get; private set; }
        public Rental Rental{ get; private set; }
        
        public bool IsAssigned { get; set; }
    }
}