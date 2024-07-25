using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Raspuns
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_raspuns { get; set; }
        public int? id_intrebare { get; set; }
        public virtual Intrebare Intrebare { get; set; }
        public int ResponseText { get; set; }



    }
}
