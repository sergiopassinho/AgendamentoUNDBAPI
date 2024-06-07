namespace WebApplication1.Models
{
    public interface ICrendencial
    {
        string Usuario { get; }
        string Senha { get; }
        bool Autenticar();
    }
}
