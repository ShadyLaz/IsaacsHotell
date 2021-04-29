using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Rum
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int Antalsovplatser { get; set; }
       
        public bool Smutsigt { get; set; }
        [ForeignKey("FK_Bokning")]
        public int? BokningId { get; set; } // testa tabort för att see id i bokningen
        public List<Bokning> Bokningar { get; set; }
        public double PrisPerNatt { get; set; }
    }
}
