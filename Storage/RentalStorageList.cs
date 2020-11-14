using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public class RentalStorageList
    {
        public List<Rental> _apartmentUnitsList {get; private set;}
        public RentalStorageList()
        {
            _apartmentUnitsList = new List<Rental>();
        }
        public List<Rental> GetRentals(){
            return _apartmentUnitsList;
        }

        public Rental DisplayAllRentalByUnitNum(int unitToSearchByUnitNum) {
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