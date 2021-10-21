using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.operation_claims
                             join userOperationClaim in context.user_operation_claims
                                 on operationClaim.claim_id equals userOperationClaim.operation_claim_id
                             where userOperationClaim.userss_id == user.userss_id
                             select new OperationClaim { claim_id = operationClaim.claim_id, claim_name = operationClaim.claim_name };
                return result.ToList();

            }
        }
    }
}
