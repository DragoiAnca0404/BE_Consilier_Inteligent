using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Sectiuni_Tip_CV
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_sectiune_tip_CV { get; set; }

        public string denumire_sectiune { get; set; }

        public string titlu { get; set; }

        public string scurta_descriere { get; set; }

        public string data_inceput { get; set; }

        public string data_sfarsit { get; set; }

    }
}
