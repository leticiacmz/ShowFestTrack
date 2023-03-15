using System.ComponentModel.DataAnnotations;

namespace ShowsAPI.Models;

public class Show
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do artista deve ser preenchido.")]
    public string Artista { get; set;}

    [Required(ErrorMessage = "Escolha entre 'Solo'ou 'Festival'.")]
    public string Tipo { get; set;}
    public DateTime Data {  get; set;}
    public string Local { get; set;}
    public string Endereco { get; set;}

    [Required]
    [Range(1, 5, ErrorMessage = "Digite um número de 1 a 5.")]
    public int Nota { get; set; }
    public string Descricao { get; set; }
}
