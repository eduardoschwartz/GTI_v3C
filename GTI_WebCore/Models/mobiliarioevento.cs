using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Mobiliarioevento {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codtipoevento { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Seqevento { get; set; }
        [Required]
        public DateTime Dataevento { get; set; }
    }
}
