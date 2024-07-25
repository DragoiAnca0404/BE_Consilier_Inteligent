namespace Models
{
    public class Elev
    {
        public int id_elev { get; set; }
        public int id_utilizator { get; set; }
        public virtual Utilizator Utilizator { get; set; }
    }
}
