﻿namespace Day1API.Models
{
    public class GeneralResponse
    {
        public string Message { get; set; }

        public GeneralResponse(string message)
        { Message = message; }
    }
}
