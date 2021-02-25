using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // params sayesinde birden çok IResult ı parametre olarak yazabiliriz,, Arka planda onları bir arraye çevirip gönderir.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //başarısız ise error result göndeririz.Ve bu iş kuralını business a haber ederiz bu satırla.
                }
            }
            return null;
        }


    }
}
