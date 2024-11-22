using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")]Aluno aluno) // Estamos utilizando o Bind por questão de segurança, para informar apenas o nome dos campos que queremos receber
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Redirecionando para a controller index
        }


    }
}
