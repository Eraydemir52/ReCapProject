using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string messages):this(success)//Burda hem mesaj hem değeri döndürür
        {
            Success = success;
            Message = messages;
        }
        public Result(bool success)
        {
            Success = success;  //Burda mesaj vermez sadece değeri döndürür
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
