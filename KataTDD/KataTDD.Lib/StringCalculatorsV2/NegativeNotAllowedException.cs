using System;

namespace KataTDD.Lib.StringCalculatorsV2
{
    public class NegativeNotAllowedException : ArgumentException
    {
        public NegativeNotAllowedException(string message) : base(message)
        {
            
        }
    }
}