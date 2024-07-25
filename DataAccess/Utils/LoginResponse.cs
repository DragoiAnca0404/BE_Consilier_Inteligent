namespace ConsilierBackUP.Utils
{
    public class LoginResponse
    {
        private string nume;
        private string prenume;
        private string rol;
        private string username;

        public string Rol { get => rol; set => rol = value; }
        public string Prenume { get => prenume; set => prenume = value; }
        public string Nume { get => nume; set => nume = value; }
        public string Username { get => username; set => username = value; }
    }
}