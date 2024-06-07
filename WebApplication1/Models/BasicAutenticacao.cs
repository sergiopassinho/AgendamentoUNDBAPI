namespace WebApplication1.Models
{
    public class BasicAutenticacao : Autenticar
    {
        public override bool AutenticarUsuario(Credencial credencial)
        {
            if (credencial == null)
                return false;

            return credencial.Autenticar();
        }
    }
}
