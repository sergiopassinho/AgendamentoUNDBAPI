using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Autenticar
    {
        public bool AutenticarUsuario(Credencial credencial)
        {
            if (credencial == null)
                return false;

            if (credencial.Usuario == "teste" && credencial.Senha == "123")
                return true;

            return false;
        }
    }
}
