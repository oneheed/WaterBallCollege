﻿namespace CommandPattern.Models
{
    internal class Telecom
    {
        public void Connect()
        {
            Console.WriteLine("The telecom has been turned on.");
        }

        public void Disconnect()
        {
            Console.WriteLine("The telecom has been turned off.");
        }
    }
}
