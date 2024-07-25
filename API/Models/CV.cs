namespace Models
{
    public class CV
    {

        public int id_cv { get; set; }
        public int? id_utilizator { get; set; }
        public virtual Utilizator Utilizator { get; set; }
    }
}
