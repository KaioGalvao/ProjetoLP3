namespace ProjetoLp3.Models;
using System.ComponentModel.DataAnnotations;

public class Peca
{   
    [Required(ErrorMessage = "Preencha o campo Codigo")]
    public int? Codigo { get; set; }

    [Required(ErrorMessage = "Preencha o campo Nome")]
    public string? Nome { get; set; }


    public Peca() { }

    public Peca(int codigo, string nome)
    {
        Codigo = codigo;
        Nome = nome;
    }
}