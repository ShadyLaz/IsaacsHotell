using Microsoft.AspNetCore.Identity;
using System;


namespace IsaacsHotell.Data
{
    public class Användare : IdentityUser
    {
        [PersonalData]
        public string Namn { get; set; }
        [PersonalData]
        public string Efternamn { get; set; }
    }
}
