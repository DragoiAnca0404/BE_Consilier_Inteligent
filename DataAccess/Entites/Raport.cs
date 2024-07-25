using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Raport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_raport { get; set; }
        public int id_solutie { get; set; }
        [ForeignKey("id_solutie")]
        public virtual Solutie Solutie { get; set; }
    }
}
