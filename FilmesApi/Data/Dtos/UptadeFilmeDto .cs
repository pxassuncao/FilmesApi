using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{
   
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Genero do filme é obrigatório")]
    [StringLength(10, ErrorMessage = "O tamanho do gênero não pode exceder 10 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(30, 600, ErrorMessage = "a duração do filme tem não pode ser menor que" +
        "30 minutos ou maior que 600 minutos")]
    public int Duracao { get; set; }
}
