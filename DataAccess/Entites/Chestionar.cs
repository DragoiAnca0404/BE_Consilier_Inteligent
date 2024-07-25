using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Chestionar
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_chestionar { get; set; }

        [Required]
        [MaxLength(250)]
        public string denumire_test { get; set; }

        public int? id_consilier { get; set; }

        [ForeignKey("id_consilier")]
        public virtual Consilier Consilier { get; set; }

    }
}

