﻿namespace PaycoreFinalProjectAPI.Middleware
{
    internal class ErrorDetail
    {
        public ErrorDetail()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
