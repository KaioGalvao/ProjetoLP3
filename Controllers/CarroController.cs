using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class CarroController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public CarroController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Carros);
    }

    public IActionResult Show(int codigo)
    {
        Carro carro = _context.Carros.Find(codigo);

        if(carro == null)
        {
            return NotFound();
        }

        return View(carro);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Carro carro = _context.Carros.Find(codigo);

        if(carro == null)
        {
            return NotFound();
        }

        return View(carro);
    }

    public IActionResult Delete(int codigo)
    {
        Carro carro = _context.Carros.Find(codigo);

        if(carro == null)
        {
            return NotFound();
        }
        
        _context.Carros.Remove(_context.Carros.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Carro carro)
    {
        if(!ModelState.IsValid) 
        {
            return View(carro);
        }

        _context.Carros.Add(carro);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Carro carro, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(carro);
        }
        
        Carro updateCliente = _context.Carros.Find(carro.Codigo);
        
        updateCliente.Nome = carro.Nome;
        updateCliente.Cpf = carro.Cpf;
        updateCliente.Idade = carro.Idade;
        updateCliente.Endereco = carro.Endereco;

        _context.Carros.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}