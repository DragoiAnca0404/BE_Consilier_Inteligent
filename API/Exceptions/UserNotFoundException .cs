﻿namespace BE_ConsilierInteligent.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found.")
        {
        }
    }
}
