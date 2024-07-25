namespace Models
{
    public class Solutii_Training
    {

        public int id_solutii { get; set; }
        public int intrebare_1 { get; set; }
        public int intrebare_2 { get; set; }
        public int intrebare_3 { get; set; }
        public int intrebare_4 { get; set; }
        public int intrebare_5 { get; set; }
        public int intrebare_6 { get; set; }
        public int intrebare_7 { get; set; }
        public int intrebare_8 { get; set; }
        public int intrebare_9 { get; set; }
        public int intrebare_10 { get; set; }
        public int intrebare_11 { get; set; }
        public int intrebare_12 { get; set; }

        public int id_chestionar { get; set; }
        public virtual Chestionar Chestionar { get; set; }

        public int id_solutie { get; set; }
        public virtual Solutie Solutie { get; set; }
    }
}
