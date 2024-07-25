

namespace Models
{
    public class Sectiuni_Raport
    {


        public int id_sectiune_Raport { get; set; }
        public int id_raport { get; set; }
        public virtual Raport Raport { get; set; }

        public int id_sectiune_tip_Raport { get; set; }
        public virtual Sectiuni_Tip_Raport Sectiuni_Tip_Raport { get; set; }
    }
}
