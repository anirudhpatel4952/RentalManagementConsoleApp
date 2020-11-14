using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public class TenantStorageList
    {
        public List<Tenant> _tenantsList { get; private set; }
        public TenantStorageList()
        {
            _tenantsList = new List<Tenant>();
        }
        public Tenant Create(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
            if (_tenantsList.Count <= 16){
            var tenant = new Tenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned);
            _tenantsList.Add(tenant);
            return tenant;
            }
           else{
                throw new Exception("Maximum only 8 units present, 2 Tenants per Unit. Limit reached");
            }
            
        }

        public Tenant RemoveById(long tenantIdInput){
             
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

        public List<Tenant> DisplayAllTenantById(){
            return _tenantsList;
        }

        public Tenant GetById(long tenantToSearchById){
            for (int i = 0; i < _tenantsList.Count; i++) {
                var tenant = _tenantsList[i];
                if (tenantToSearchById == tenant.TenantId)
                {
                    return tenant;
                }
                
            }
            return null;
        }
    }
}