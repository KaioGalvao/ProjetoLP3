namespace ProjetoLp3.Models;
using System.ComponentModel.DataAnnotations;

public class Roda
{   
    [Required(ErrorMessage = "Preencha o campo Codigo")]
    public int? Codigo { get; set; }

    [Required(ErrorMessage = "Preencha o campo Aro")]
    public string? Aro { get; set; }


    public Roda() { }

    public Roda(int codigo, string aro)
    {
        Codigo = codigo;
        Aro = aro;
    }
}