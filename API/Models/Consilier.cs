namespace Models
{
    public class Consilier
    {
        public int id_consilier { get; set; }
        public int id_utilizator { get; set; }
        public virtual Utilizator Utilizator { get; set; }
    }

}
