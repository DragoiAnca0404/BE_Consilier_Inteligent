using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Solutie
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_solutie { get; set; }

        [Required]
        public string denumire_solutie { get; set; }
    }
}
