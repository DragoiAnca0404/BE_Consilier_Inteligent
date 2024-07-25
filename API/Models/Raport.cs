
namespace Models 
{ 
    public class Raport
    {
        public int id_raport { get; set; }
        public int id_solutie { get; set; }
        public virtual Solutie Solutie { get; set; }
    }
}
