using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Anställd 
    {
        public int Id { get; set; } //Testar att ta bort för att seeda // new
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        //public string Roll { get; set; } //om det läggs till igen. Lägg till den i seeden samt unkommentera i alla CRUD views 

    }
}
