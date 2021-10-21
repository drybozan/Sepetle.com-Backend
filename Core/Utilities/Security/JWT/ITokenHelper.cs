using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper //kullanıcı mailini şifresini yazıp gönderecek gönderdiği değerler doğru ise token oluşturulacak ve kullancıya verecek
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
