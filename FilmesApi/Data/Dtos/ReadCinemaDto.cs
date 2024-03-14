

namespace FilmesApi.Data.Dtos
{
    public class ReadCinemaDto
    {
       
        public int id { get; set; }
       
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
    }
}
