namespace Models
{
    public class Intrebare
    {
        public int id_intrebare { get; set; }

        public string Formulare_intrebare { get; set; }

        public int id_chestionar { get; set; }
        public virtual Chestionar Chestionar { get; set; }

    }
}
