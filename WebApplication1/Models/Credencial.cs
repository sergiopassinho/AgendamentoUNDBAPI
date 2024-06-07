namespace WebApplication1.Models
{
    public class Credencial : ICrendencial
    {
        public required string Usuario { get; set; }

        public required string Senha { get; set; }

        public Credencial(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public bool Autenticar()
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Senha))
                return false;

            if (Usuario == "teste" && Senha == "123")
                return true;

            return false;
        }
    }
}
