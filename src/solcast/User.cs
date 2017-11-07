using System;

namespace Solcast
{
    public static class User
    {
        public const string SolcastKeyName = @"Solcast_API_KEY";        
        public static string Key => Environment.GetEnvironmentVariable(SolcastKeyName) ?? "";
    }
}
