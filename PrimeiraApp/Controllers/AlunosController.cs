using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")]Aluno aluno) // Estamos utilizando o Bind por questão de segurança, para informar apenas o nome dos campos que queremos receber
        {
            if (ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirecionando para a controller index
            }

            return View(aluno);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.Id == id);

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Email,Avaliacao,Ativo")] Aluno aluno) 
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao"); // Removendo a chave que não queremos validar no ModelState

            if (ModelState.IsValid)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirecionando para a controller index
            }

            return View(aluno);
        }
    }
}
