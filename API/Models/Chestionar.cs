using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Chestionar
    {
        public int id_chestionar { get; set; }
        public string denumire_test { get; set; }

        public int? id_consilier { get; set; }
        public virtual Consilier Consilier { get; set; }

    }
}
