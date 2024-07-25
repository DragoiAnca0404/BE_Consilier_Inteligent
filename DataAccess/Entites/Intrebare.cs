using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Intrebare
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_intrebare { get; set; }

        [Required]
        [MaxLength(250)]
        public string Formulare_intrebare { get; set; }

        public int? id_chestionar { get; set; }
        [ForeignKey("id_chestionar")]

        public virtual Chestionar Chestionar { get; set; }


    }
}
