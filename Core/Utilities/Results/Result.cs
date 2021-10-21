using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //constructor içinde set işlemini yaptık
        //işlemin hem sonucunu hem de kullanıcıyı biliglendirmek için mesaj vermek istersem bunu kullanırım. this ile 2 metodu çalıştırmış olurum.
        public Result(bool success, string message) :this(success)
        {
            Message = message;
          
        }

        //işlemin sadece başrılı olup olmadığını bildirmek istersem 
        public Result(bool success) 
        {
           
            Success = success;
        }

        public bool Success { get; } //get,return gerektirir

        public string Message { get; }
    }
}
