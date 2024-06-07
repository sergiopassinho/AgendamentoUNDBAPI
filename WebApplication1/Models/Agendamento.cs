namespace WebApplication1.Models
{
    public class Agendamento
    {
        public required string Data { get; set; }
        public required string Horario { get; set; }
        public required string Sala { get; set; }

        public required int Duracao { get; set; }
    }
}
