using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    // Temel Voidler için yaptık bunu
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
            

    }
}
