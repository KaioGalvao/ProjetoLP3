namespace ProjetoLp3.Models;
using System.ComponentModel.DataAnnotations;

public class Moto
{   
    [Required(ErrorMessage = "Preencha o campo Codigo")]
    public int? Codigo { get; set; }

    [Required(ErrorMessage = "Preencha o campo Marca")]
    public string? Marca { get; set; }
    
    [Required(ErrorMessage = "Preencha o campo Modelo")]
    public string? Modelo { get; set; }

    [Required(ErrorMessage = "Preencha o campo Marca")]
    public string? Cor { get; set; }

    public Moto() { }

    public Moto(int codigo, string marca, string modelo, string cor)
    {
        Codigo = codigo;
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
    }
}