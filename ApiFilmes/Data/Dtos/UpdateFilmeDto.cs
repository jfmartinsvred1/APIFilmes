using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Data.Dtos;

public class CreateFilmeDto
{
    
    [Required(ErrorMessage = "O Titúlo é obrigatório.")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero é obrigatório.")]
    [StringLength(50, ErrorMessage = "O Gênero não pode ultrapassar 50 caracteres.")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração é obrigatória.")]
    [Range(60, 480, ErrorMessage = "A Duração deve ser entre 60 e 480 minutos.")]
    public int Duracao { get; set; }
}
