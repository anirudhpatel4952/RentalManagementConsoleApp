using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using rentManagement.Models;



namespace rentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Your Rent Management System");
            var rentManagementSystem = new RentManagementSystem();
            Tenant tenant = new Tenant();
            Assignment assignment = new Assignment();

            bool loopBreak = true;
            while (loopBreak)
            {
                Console.WriteLine($"\nENTER \nA: TO LIST ALL THE RENTAL APARTMENT UNITS AND TENANTS, \nB: TO ADD A TENANT, \nC: TO REMOVE A TENANT, \nD: TO SEARCH FOR A TENANT OR A UNIT, \nE: TO ASSIGN A UNIT, \nQ: TO QUIT");
                var welcomeInput = Console.ReadLine().ToUpper();

               switch (welcomeInput)
                {
                    case "A":
                        Console.WriteLine("Getting the list......");
                        
                        rentManagementSystem.PrintAllTenants();
                        foreach (var Cx in rentManagementSystem._tenantsList)
                        {
                            System.Console.WriteLine($"Full name of the tenant is :{Cx.FullName} \nId is :{Cx.TenantId} \nAddress is :{Cx.Address}, {Cx.PostalCode}, {Cx.City} \nDeposit payed is: {Cx.Deposit}\n");
                        }
                        rentManagementSystem.PrintAllUnitsInApartn();
                        foreach (var unit in rentManagementSystem._apartmentUnitsList)
                        {
                            
                            System.Console.WriteLine($"\nApartment: {unit.Apartment} \nUnit No. :{unit.Unit} \nNumber of Rooms available are :{unit.NumberOfRoom} \nCost of this Unit is :{unit.Cost}");
                        }

                        break;

                    case "B":
                        System.Console.WriteLine("Adding a tenant.....");
                        System.Console.WriteLine("Please enter the following details of the Tenant:");
                        System.Console.WriteLine("Enter tenantId:");
                        var tenantIdInput = Convert.ToInt64(Console.ReadLine());
                        System.Console.WriteLine("Enter First Name:");
                        var firstNameInput = Console.ReadLine();
                        System.Console.WriteLine("Enter Last Name:");
                        var lastNameInput = Console.ReadLine();
                        System.Console.WriteLine("Enter Address:");
                        var addressInput = Console.ReadLine();
                        System.Console.WriteLine("Enter Postal Code:");
                        var postalCodeInput = Console.ReadLine();
                        System.Console.WriteLine("Enter City:");
                        var cityInput = Console.ReadLine();
                        System.Console.WriteLine("Enter the Id proof provided:");
                        var idProofInput = Console.ReadLine();
                        System.Console.WriteLine("Enter Deposit Amount:");
                        var depositInput = Convert.ToDouble(Console.ReadLine());
                        System.Console.WriteLine("Enter if the tenant is assigned:");
                        var isAssignedInput = Convert.ToBoolean(Console.ReadLine());
                        var tenantAdded = rentManagementSystem.AddATenant(tenantIdInput,firstNameInput, lastNameInput, addressInput, postalCodeInput, cityInput, idProofInput, depositInput, isAssignedInput);
                       
                        System.Console.WriteLine($"Tenant with Id: {tenantAdded.TenantId} & First Name: {tenantAdded.FirstName} added");
                        break;

                    case "C":
                        System.Console.WriteLine("Deleting a tenant.....");
                        System.Console.WriteLine("Enter the tenantId to delete the Tenant:");
                        var tenantDelIdInput = Convert.ToInt64(Console.ReadLine());
                        //store the below func in a variable so it becomes easier to display
                        var tenantDeleted = rentManagementSystem.DeleteATenant(tenantDelIdInput);
                       
                        System.Console.WriteLine($"Tenant with Id:{tenantDeleted.TenantId} removed");
                        break;
                    
                    case "D":
                        System.Console.WriteLine("Search for a Tenant or Unit?");
                        var searchResponse = Console.ReadLine().ToLower();
                        if (searchResponse == "tenant"){
                            System.Console.WriteLine("Please enter the Tenant Id to search for the tenant");
                            var searchTenantIdInput = Convert.ToInt32(Console.ReadLine());
                            var searchResult = rentManagementSystem.SearchForTenants(searchTenantIdInput);
                            System.Console.WriteLine($"\nFull name of the tenant is :{searchResult.FullName} \nId is :{searchResult.TenantId} \nAddress is :{searchResult.Address}, {searchResult.PostalCode}, {searchResult.City} \nDeposit payed is: {searchResult.Deposit}\n");
                            //WORKING ON IT
                        }
                        else if (searchResponse == "unit"){
                            System.Console.WriteLine("Please enter the Unit number to search for the unit");
                            var searchUnitNumInput = Convert.ToInt32(Console.ReadLine());
                            var searchResult = rentManagementSystem.SearchForUnits(searchUnitNumInput);
                            System.Console.WriteLine($"\nApartment: {searchResult.Apartment} \nUnit No. :{searchResult.Unit} \nNumber of Rooms available are :{searchResult.NumberOfRoom} \nCost of this Unit is :{searchResult.Cost}");
                        }
                        break;

                    case "E":
                        System.Console.WriteLine("Assigning a Unit.....");
                        System.Console.WriteLine("Please enter a unit you want to assign:");
                        var unitNumInput = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Please enter a Tenant Id for the tenant to get a unit assigned:");
                        var tenantIdToassignInput = Convert.ToInt64(Console.ReadLine());
                        var assignmentComplete = rentManagementSystem.UnitAssigner(tenantIdToassignInput, unitNumInput);
                        
                        if (assignmentComplete == true){
                            Guid assignmentId = assignment.AssignId;
                            var assignmentguid = System.Guid.NewGuid();
                            System.Console.WriteLine($"Assignment Completed. The Tenant with Id: {tenantIdToassignInput} is assigned the unit: {unitNumInput}. The Assignment Id for this contract is {assignmentguid}. ");
                            
                        }
                        else{
                            System.Console.WriteLine($"Either Tenant Id or Unit number not available, try again");
                        }
                        break;

                    case "Q":
                        System.Console.WriteLine("Thanks for using Rent Management, See You Again !");
                        loopBreak = false;
                        break;

                    default:
                        System.Console.WriteLine("Please enter a valid input");
                        break;
                }
            }
        }
        
    
    }
}
