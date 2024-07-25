
namespace Models
{
    public class Raspuns
    {
        public int id_raspuns { get; set; }
        public int id_intrebare { get; set; }
        public virtual Intrebare Intrebare { get; set; }
        public int ResponseText { get; set; }

    }
}
