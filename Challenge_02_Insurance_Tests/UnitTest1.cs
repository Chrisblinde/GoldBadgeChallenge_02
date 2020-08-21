using System;
using System.Collections;
using System.Collections.Generic;
using Insurance_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_02_Insurance_Tests
{
    [TestClass]
    public class InsuranceClaimTests
    {
        private Challenge_02_Insurance_Repo _repo;
        private Challenge_02_Insurance_Claims _claims;

        [TestInitialize]

        public void Arrange()
        {
            _repo = new Challenge_02_Insurance_Repo();
            _claims = new Challenge_02_Insurance_Claims(1, ClaimType.Car, "accident on 465", 400.00m, DateTime.Parse("2018-04-25"),
            DateTime.Parse("2018-04-27"));
            _repo.AddClaimToList(_claims);
        }


        [TestMethod]
        public void GetClaims_ShouldReturnListOfClaims()
        {
            Challenge_02_Insurance_Repo repo = new Challenge_02_Insurance_Repo();
            Challenge_02_Insurance_Claims claim = new Challenge_02_Insurance_Claims();
            repo.AddClaimToList(claim);
            Queue<Challenge_02_Insurance_Claims>directory = repo.GetClaims();

        }
        [TestMethod]
        public void UpdateClaims_ShouldReturnTrue()

        {
            bool wasUpdated = _repo.UpdateClaims();
        }

        
    }
}
