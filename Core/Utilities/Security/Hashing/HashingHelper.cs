using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash 
            (string password, out byte[] passwordHash, out byte[] passwordSalt) //kullanıcı için ilk defa hash yapar
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //hash ve salt işlevi görecek
            {
                passwordSalt = hmac.Key; //key ,HMACSHA512() nin anlık oluşturduğu değerdir her kullanıcı için yeni değer üretir
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //passwordün hashini doğrular, kullanıcının sisteme girmek için girdiği passworddür
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //saltı parametre göster
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) //benim hashim ile veritabanına gönderilen hash uyuşmuyorsa false döndür
                    {
                        return false;
                    }
                }
                return true;
            }


        }
    }
}
