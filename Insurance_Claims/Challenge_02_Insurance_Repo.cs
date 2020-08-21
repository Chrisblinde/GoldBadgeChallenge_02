using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Claims
{
    public class Challenge_02_Insurance_Repo
    {
        private readonly Queue<Challenge_02_Insurance_Claims> _insuranceClaims = new Queue<Challenge_02_Insurance_Claims>();
        /*private readonly Queue<Challenge_02_Insurance_Claims> _insuranceClaimsQueue = new Queue<Challenge_02_Insurance_Claims>();*/
        public void AddClaimToList(Challenge_02_Insurance_Claims claim)
        {
            _insuranceClaims.Enqueue(claim);
        }

        public Queue<Challenge_02_Insurance_Claims> GetClaims()
        {
             return _insuranceClaims;
        }


        public bool UpdateClaims(Challenge_02_Insurance_Claims updatedClaim, double originalId )
        {
            foreach (Challenge_02_Insurance_Claims claim in _insuranceClaims)
            {
                if(claim.ClaimId == originalId)
                {
                    claim.ClaimId = claim.ClaimId;
                    claim.ClaimType = updatedClaim.ClaimType;
                    claim.Description = updatedClaim.Description;
                    claim.ClaimAmmount = updatedClaim.ClaimAmmount;
                    claim.DateOfIncident = updatedClaim.DateOfIncident;
                    claim.DateOfClaim = updatedClaim.DateOfClaim;

                   
                    return true;
                }
            }
            return false;
        }

    }
}

