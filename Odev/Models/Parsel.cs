using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Odev.Models
{
    public class Parsel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParselId { get; set; }
        public string ParselIl { get; set; }
        public string ParselIlce { get; set; }
        public string PareselMahalle { get; set; }
        public string WktString { get; set; }
    }
}
