using Microsoft.AspNetCore.Mvc;
using OrganizadordeTarefas.Context;
using OrganizadordeTarefas.Models;

namespace OrganizadordeTarefas.Controllers;

public class TarefaController : Controller
{
    private readonly OrganizadorContext _context;

    public TarefaController(OrganizadorContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tarefas = _context.Tarefas.ToList();
        return View(tarefas);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Tarefa tarefa)
    {
        if (!ModelState.IsValid)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(tarefa);
    }

    public IActionResult Atualizar(int id)
    {
        var tarefas = _context.Tarefas.Find(id);
        if (tarefas == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    [HttpPost]
    public IActionResult Atualizar(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
        tarefaBanco.Titulo = tarefa.Titulo;
        tarefaBanco.Descricao = tarefa.Descricao;
        tarefaBanco.Data = tarefa.Data;
        tarefaBanco.Status = tarefa.Status;
        _context.Tarefas.Update(tarefaBanco);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Detalhes(int id) 
    {
        var tarefas = _context.Tarefas.Find(id);
        if (tarefas == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(tarefas); 
    }

    public IActionResult Excluir(int id)
    {
        var tarefas = _context.Tarefas.Find(id);
        if (tarefas == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(tarefas);
    }

    [HttpPost]
    public IActionResult Excluir(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
        _context.Remove(tarefaBanco);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
