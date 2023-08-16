using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }
}
