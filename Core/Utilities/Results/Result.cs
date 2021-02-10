using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success) //bu sınıfın tek parametreli contructırınıda çalıştır
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        //getter lar readonly dir ve sadece constructer içinde set edilebilir

        public bool Success { get; }

        public string Message { get; }
    }
}
