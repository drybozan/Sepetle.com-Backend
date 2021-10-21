using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //json web tokenın kendisi,token vereceğiz kullanıcıya sisteme erişim sağlayabilmesi için
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } //bitiş zamanı,tokenın
    }
}
