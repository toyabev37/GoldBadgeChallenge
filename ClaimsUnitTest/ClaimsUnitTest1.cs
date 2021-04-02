using ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace ClaimsUnitTest
{
    [TestClass]
    public class ClaimsUnitTest1
    {
       
        private Claim claim;
        private ClaimRepo _Repo;
        [TestInitialize]

        public void arrange()
        {
            _Repo = new ClaimRepo();
             
        claim = new Claim(1, "Car", "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
        }

        [TestMethod]
        public void GetAllClaims()
        {
            Queue<Claim> claim = _Repo.GetAllClaims();
            foreach (var c in claim)
            {
                Console.WriteLine($"Claim ID:{c.ClaimType}");
            }
        }
        


        [TestMethod]
        public void ViewNextClaim()
        {
            Claim claim = _Repo.ViewNextClaim();
        }

        [TestMethod]
        public void RemoveClaim()
        {
            Queue<Claim> claim = _Repo.GetAllClaims();
            _Repo.RemoveClaim();
            Console.WriteLine(claim.Count);
            Assert.IsTrue(claim.Count==0);
        }

        [TestMethod]
        public void AddToDatabase()
        {
            _Repo.AddToDatabase(claim);
        }


    }
}
