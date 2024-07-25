using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Sectiuni_Tip_Raport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_sectiune_tip_Raport { get; set; }

        public string denumire_sectiune { get; set; }

        public string scurta_descriere { get; set; }

    }
}
