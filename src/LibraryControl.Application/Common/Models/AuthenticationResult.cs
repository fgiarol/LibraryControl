using System.Collections.Generic;

namespace LibraryControl.Application.Common.Models
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
    }
}