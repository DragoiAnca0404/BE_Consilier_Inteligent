


namespace Models
{
    public class Sectiuni_CV
    {
        public int id_sectiune_CV { get; set; }

        public int id_cv { get; set; }
        public virtual CV CV { get; set; }

        public int id_sectiune_tip_CV { get; set; }
        public virtual Sectiuni_Tip_CV Sectiuni_Tip_CV { get; set; }
    }
}
