using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissilPolice.Models
{
    [Table("Accused")]
    public class Accused
    {
        [Key]
        public long ID { get; set; }

        public long FIRID { get; set; }

        public string? ACCNAME { get; set; }
        public string? ACCCNIC { get; set; }
        public string? ACCMOBILE { get; set; }
        public string? NOMINATE { get; set; }
        public string? ACCSKETCH { get; set; }
        // BLOBs are byte[] in C#
        public byte[]? ACCPIC { get; set; }
        public string? DATEARREST { get; set; }
        public string? BODY2 { get; set; }
    }
}
