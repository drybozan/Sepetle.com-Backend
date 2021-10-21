using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) //Resultun 2 constructor ını da kullan 
        {

        }

        public SuccessResult() : base(true) //sadece tek parametreli olanı kullan
        {

        }
    }
}
