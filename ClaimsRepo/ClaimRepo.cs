using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimDatabase = new Queue<Claim>();
        

        public Queue<Claim> GetAllClaims()
        {
            return _claimDatabase;
        }


        public Claim ViewNextClaim()
        {
            if (_claimDatabase.Count > 0)
            {
                Claim nextInLine = _claimDatabase.Peek();
                return nextInLine;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveClaim()
        {
            if (_claimDatabase.Count > 0)
            {
                _claimDatabase.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AddToDatabase(Claim claim)
        {
            _claimDatabase.Enqueue(claim);
            return true;
        }

      
    }
}

