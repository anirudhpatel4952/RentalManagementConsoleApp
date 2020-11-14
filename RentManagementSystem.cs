using System;
using System.Collections.Generic;
using System.Text;
using rentManagement.Models;
using System.Linq;
using rentManagement.Storage;


namespace rentManagement
{
    public class RentManagementSystem
    {
        
        public RentManagementSystem()
        
        {
            
            //list of tenants living in first apartment
            _tenantsList = new List<Tenant>();
            
            //list of units of first apartment
            _apartmentUnitsList = new List<Rental>();

            //creating the tenant(TENANTS OBJECTS)
            Tenant tenant1 = 
            new Tenant(400, "Jay", "Bhai", "01-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant2 = 
            new Tenant(401, "Jayshree", "Ben", "02-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant3 = 
            new Tenant(402, "Jayesh", "Kumar", "03-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant4 = 
            new Tenant(403, "Jaya", "Kumari", "04-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);
            
            
            //creating the rental apartment
            Rental unit1 = new Rental(4100, 01, 2, 900, false);
            Rental unit2 = new Rental(4100, 02, 2, 900, false);
            Rental unit3 = new Rental(4100, 03, 2, 900, false);
            Rental unit4 = new Rental(4100, 04, 2, 900, false);

            Assignment assignment = new Assignment();

            //adding the tenants in the tenant list
            _tenantsList.Add(tenant1);
            _tenantsList.Add(tenant2);
            _tenantsList.Add(tenant3);
            _tenantsList.Add(tenant4);


            //adding the apartments in the apartment lists
            _apartmentUnitsList.Add(unit1);
            _apartmentUnitsList.Add(unit2);
            _apartmentUnitsList.Add(unit3);
            _apartmentUnitsList.Add(unit4);

        }
        //end of constructor

        //list of tenants in the apartment
        public List<Tenant> _tenantsList { get; private set; }  
        private TenantStorageList tenantStorageList;
        

        //list of apartments
        public List<Rental> _apartmentUnitsList {get; private set;}
        private RentalStorageList rentalStorageList;
        
        

        //method to add a tenant 
        public Tenant AddATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
            if (_tenantsList.Count <= 16){
            var tenant = new Tenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned);
            _tenantsList.Add(tenant);
            return tenant;
            }
           else{
                throw new Exception("Maximum only 8 units present, 2 Tenants per Unit. Limit reached");
            }
            
        }

        //method to delete a tenant

        public Tenant DeleteATenant(long tenantIdInput){
             
            for (int i = 0; i < _tenantsList.Count; i++) {
                var tenant = _tenantsList[i];
                if (tenantIdInput == tenant.TenantId)
                {
                    var delTenant = _tenantsList;
                    delTenant.RemoveAt(i);
                    return tenant;
                    
                }
               
            }
            return null;   
        }

        //method to print all the tenants
        public List<Tenant> PrintAllTenants(){
            return _tenantsList;
        }

        //method to print all the units in the apartment
        public List<Rental> PrintAllUnitsInApartn(){
            return _apartmentUnitsList;
        }
        
        //method to check if the unit is assigned to tenant
        public bool UnitAssigner(long tenantIdInput, int unitNumInput)
        {
            Assignment assignment = new Assignment();
            var assignmentComplete = assignment.IsAssigned = false;
            for (int i = 0; i < _tenantsList.Count; i++)
            {
                Tenant tenant = _tenantsList[i];
                if (tenantIdInput == tenant.TenantId && tenant.IsAssigned == false) {

                    for (int i1 = 0; i1 < _apartmentUnitsList.Count; i1++)
                    {
                        Rental unit = _apartmentUnitsList[i1];
                        if (unitNumInput == unit.Unit && unit.IsAssigned == false){
                            var tenantAssigned = tenant.IsAssigned = true;
                            var unitAssigned = unit.IsAssigned = true;
                        
                            assignmentComplete = true;
                            return assignmentComplete;
                    }
                        else
                            {
                                continue;
                            }
                    
                    }
                
                }
                else
                {
                    continue;
                }
            
            }
            return assignmentComplete;
        }
        
        //search functionality to search for a tenant
        public Tenant SearchForTenants(long tenantToSearchById){
            for (int i = 0; i < _tenantsList.Count; i++) {
                var tenant = _tenantsList[i];
                if (tenantToSearchById == tenant.TenantId)
                {
                    return tenant;
                }
                
            }
            return null;
        }

        //search functionality to search for a unit
        public Rental SearchForUnits(int unitToSearchByUnitNum) {
            for (int i = 0; i < _apartmentUnitsList.Count;i++) {
                var unit = _apartmentUnitsList[i];
                if (unitToSearchByUnitNum == unit.Unit){
                    return unit;
                }
                
            }
            return null;
        }

    }
}