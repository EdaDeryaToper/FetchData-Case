﻿namespace BackendCase.ExceptionHandler
{
    public class ErrorException:Exception
    {
        public ErrorException(string message) : base(message) { }
    }
}