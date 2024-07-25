using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Consilier
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_consilier { get; set; }

        public int? id_utilizator { get; set; }
        [ForeignKey("id_utilizator")]
        public virtual Utilizator Utilizator { get; set; }
    }
}
