using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Claims
{
    public class Challenge_02_Insurance_Claims
    {
        public Challenge_02_Insurance_Claims() { }
        public Challenge_02_Insurance_Claims(double claimId, ClaimType claimType, string description, decimal claimAmmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmmount = claimAmmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }

        public double ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if (DateOfClaim < DateOfIncident.AddDays(30))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ClaimType Type { get; set; }
        
    }    
    

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
}

        
        
            













/*ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid*/