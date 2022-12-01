using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class ClienteController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public ClienteController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Clientes);
    }

    public IActionResult Show(int id)
    {
        Cliente cliente = _context.Clientes.Find(id);

        if(cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Cliente cliente = _context.Clientes.Find(codigo);

        if(cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    public IActionResult Delete(int codigo)
    {
        Cliente cliente = _context.Clientes.Find(codigo);

        if(cliente == null)
        {
            return NotFound();
        }
        
        _context.Clientes.Remove(_context.Clientes.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Cliente cliente)
    {
        if(!ModelState.IsValid) 
        {
            return View(cliente);
        }

        _context.Clientes.Add(cliente);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Cliente cliente, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(cliente);
        }
        
        Cliente updateCliente = _context.Clientes.Find(cliente.Codigo);
        
        updateCliente.Nome = cliente.Nome;
        updateCliente.Cpf = cliente.Cpf;
        updateCliente.Idade = cliente.Idade;
        updateCliente.Endereco = cliente.Endereco;

        _context.Clientes.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}