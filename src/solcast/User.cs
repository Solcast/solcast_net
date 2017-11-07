using System;

namespace Solcast
{
    public static class User
    {
        public const string SolcastKeyName = @"SOLCAST_API_KEY";        
        public static string Key => Environment.GetEnvironmentVariable(SolcastKeyName.ToUpperInvariant()) ?? "";
    }
}
