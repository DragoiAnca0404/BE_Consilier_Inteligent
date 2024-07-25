using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class CV
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_cv { get; set; }
        public int? id_utilizator { get; set; }
        [ForeignKey("id_utilizator")]
        public virtual Utilizator Utilizator { get; set; }
    }
}
