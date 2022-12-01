using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class MotoController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public MotoController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Motos);
    }

    public IActionResult Show(int id)
    {
        Moto moto = _context.Motos.Find(id);

        if(moto == null)
        {
            return NotFound();
        }

        return View(moto);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Moto moto = _context.Motos.Find(codigo);

        if(moto == null)
        {
            return NotFound();
        }

        return View(moto);
    }

    public IActionResult Delete(int codigo)
    {
        Moto moto = _context.Motos.Find(codigo);

        if(moto == null)
        {
            return NotFound();
        }
        
        _context.Motos.Remove(_context.Motos.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Moto moto)
    {
        if(!ModelState.IsValid) 
        {
            return View(moto);
        }

        _context.Motos.Add(moto);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Moto moto, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(moto);
        }
        
        Moto updateCliente = _context.Motos.Find(moto.Codigo);
        
        updateCliente.Nome = moto.Nome;
        updateCliente.Cpf = moto.Cpf;
        updateCliente.Idade = moto.Idade;
        updateCliente.Endereco = moto.Endereco;

        _context.Motos.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}