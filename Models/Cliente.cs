namespace ProjetoLp3.Models;
using System.ComponentModel.DataAnnotations;

public class Cliente
{   
    [Required(ErrorMessage = "Preencha o campo Codigo")]
    public int? Codigo { get; set; }

    [Required(ErrorMessage = "Preencha o campo Nome")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "Preencha o campo CPF")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "Preencha o campo Idade")]
    public int? Idade { get; set; }

    [Required(ErrorMessage = "Preencha o campo Endereço")]
    public string? Endereco { get; set; }

    public Cliente() { }

    public Cliente(int codigo, string nome, string cpf, int idade, string endereco)
    {
        Codigo = codigo;
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
        Endereco = endereco;
    }
}