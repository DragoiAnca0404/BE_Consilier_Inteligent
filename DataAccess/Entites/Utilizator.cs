using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ConsilierInteligent.DataAccess.Entities
{
    public class Utilizator
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_utilizator { get; set; }

        [Required]
        [MaxLength(250)]
        public string username { get; set; }

        [Required]
        [MaxLength(250)]
        public string nume { get; set; }

        [Required]
        [MaxLength(250)]
        public string prenume { get; set; }

        [Required]
        [MaxLength(250)]
        public string parola { get; set; }

        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string email { get; set; }
    }
}
