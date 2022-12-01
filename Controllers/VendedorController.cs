using Microsoft.AspNetCore.Mvc;
using ProjetoLp3.Models;

namespace ProjetoLp3.Controllers;

public class VendedorController : Controller
{
    private readonly ProjetoLp3Context _context; //nao é possivel mudar

    public VendedorController(ProjetoLp3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Vendedores);
    }

    public IActionResult Show(int id)
    {
        Vendedor vendedor = _context.Vendedores.Find(id);

        if(vendedor == null)
        {
            return NotFound();
        }

        return View(vendedor);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int codigo)
    {
        Vendedor vendedor = _context.Vendedores.Find(codigo);

        if(vendedor == null)
        {
            return NotFound();
        }

        return View(vendedor);
    }

    public IActionResult Delete(int codigo)
    {
        Vendedor vendedor = _context.Vendedores.Find(codigo);

        if(vendedor == null)
        {
            return NotFound();
        }
        
        _context.Vendedores.Remove(_context.Vendedores.Find(codigo));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Vendedor vendedor)
    {
        if(!ModelState.IsValid) 
        {
            return View(vendedor);
        }

        _context.Vendedores.Add(vendedor);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Vendedor vendedor, int codigo)
    {

        if(!ModelState.IsValid) 
        {
            return View(vendedor);
        }
        
        Vendedor updateCliente = _context.Vendedores.Find(vendedor.Codigo);
        
        updateCliente.Nome = vendedor.Nome;
        updateCliente.Cpf = vendedor.Cpf;
        updateCliente.Idade = vendedor.Idade;
        updateCliente.Endereco = vendedor.Endereco;

        _context.Vendedores.Update(updateCliente);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}