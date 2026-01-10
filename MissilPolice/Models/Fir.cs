using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissilPolice.Models
{
    [Table("FIR")]
    public class Fir
    {
        [Key]
        public long FIRID { get; set; } // Matches FIRID column

        public string? FIRNO { get; set; }
        public string? FIRDATE { get; set; }
        public string? IDATE { get; set; } // Incident Date
        public string? PS { get; set; } // Police Station
        public string? MUDAI { get; set; } // Plaintiff
        public string? FIRMOBILE { get; set; }
        public string? FIRCNIC { get; set; }
        public string? OFFENCE { get; set; } // Sections / Type
        public string? MURASLA { get; set; }
        public string? WRITER { get; set; }
        public string? IOFFICER { get; set; }
        public string? IOMOBILE { get; set; }
        public string? STAMP { get; set; }
        public string? RANK { get; set; }
        public string? MOHARRAR { get; set; }
        public string? VDRIVER { get; set; }
        public string? VEHICLENO { get; set; }
        public string? SHO { get; set; }
        public string? DISTRICT { get; set; }
        public string? DSP { get; set; }
        public string? DIVISIONSP { get; set; }
        public string? FIRSTATUS { get; set; }
        public string? MATANFIR { get; set; }
        public string? NEW { get; set; }
        public string? NEW2 { get; set; }

        // Navigation property if needed
        [ForeignKey("FIRID")]
        public List<Accused> AccusedList { get; set; } = new();
    }
}
