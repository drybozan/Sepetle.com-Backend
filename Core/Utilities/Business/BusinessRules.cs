using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params IResult türünde istediğin kadar parametre gönder demek
        {
            foreach (var logic  in logics)
            {
                if (!logic.Success) //gelen metotlardan hatalı olanı bildir
                {
                    return logic;
                }

            }
            return null; //null,hepsini gönder
        }
    }
}
