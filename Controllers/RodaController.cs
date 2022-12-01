using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class RodaController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public RodaController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Rodas);
    }

    public IActionResult Show(int id)
    {
        Roda roda = _context.Rodas.Find(id);

        if(roda == null)
        {
            return NotFound();
        }

        return View(roda);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Roda roda = _context.Rodas.Find(codigo);

        if(roda == null)
        {
            return NotFound();
        }

        return View(roda);
    }

    public IActionResult Delete(int codigo)
    {
        Roda roda = _context.Rodas.Find(codigo);

        if(roda == null)
        {
            return NotFound();
        }
        
        _context.Rodas.Remove(_context.Rodas.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Roda roda)
    {
        if(!ModelState.IsValid) 
        {
            return View(roda);
        }

        _context.Rodas.Add(roda);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Roda roda, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(roda);
        }
        
        Roda updateCliente = _context.Rodas.Find(roda.Codigo);
        
        updateCliente.Nome = roda.Nome;
        updateCliente.Cpf = roda.Cpf;
        updateCliente.Idade = roda.Idade;
        updateCliente.Endereco = roda.Endereco;

        _context.Rodas.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}