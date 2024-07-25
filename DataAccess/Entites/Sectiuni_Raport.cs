using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Sectiuni_Raport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_sectiune_Raport { get; set; }

        public int id_raport { get; set; }
        [ForeignKey("id_raport")]

        public virtual Raport Raport { get; set; }

        public int id_sectiune_tip_Raport { get; set; }
        [ForeignKey("id_sectiune_tip_Raport")]

        public virtual Sectiuni_Tip_Raport Sectiuni_Tip_Raport { get; set; }
    }
}
