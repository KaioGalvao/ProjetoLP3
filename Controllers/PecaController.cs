using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class PecaController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public PecaController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Pecas);
    }

    public IActionResult Show(int id)
    {
        Peca peca = _context.Pecas.Find(id);

        if(peca == null)
        {
            return NotFound();
        }

        return View(peca);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Peca peca = _context.Pecas.Find(codigo);

        if(peca == null)
        {
            return NotFound();
        }

        return View(peca);
    }

    public IActionResult Delete(int codigo)
    {
        Peca peca = _context.Pecas.Find(codigo);

        if(peca == null)
        {
            return NotFound();
        }
        
        _context.Pecas.Remove(_context.Pecas.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Peca peca)
    {
        if(!ModelState.IsValid) 
        {
            return View(peca);
        }

        _context.Pecas.Add(peca);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Peca peca, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(peca);
        }
        
        Peca updateCliente = _context.Pecas.Find(peca.Codigo);
        
        updateCliente.Nome = peca.Nome;
        updateCliente.Cpf = peca.Cpf;
        updateCliente.Idade = peca.Idade;
        updateCliente.Endereco = peca.Endereco;

        _context.Pecas.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}