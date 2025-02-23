﻿using System.Net;

namespace TechLibrary.Exception
{
    public class InvalidLoginException : TechLibraryException
    {
        public override List<string> GetErrorMessages() => ["Email and/or password are invalid"];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}
