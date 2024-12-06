using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class AlunosController : Controller
    {
        // Declarando nosso contexto de banco de dados
        private readonly AppDbContext _context; 

        // Injetando o AppDbContext no construtor de nossa classe AlunosController
        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        // Método assíncrono para listar nossos alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        // Método para exibir o formulário
        public IActionResult Create()
        {
            return View();
        }

        // Método assíncrono para receber o formulário
        [HttpPost]
        [ValidateAntiForgeryToken] // Segurança do formulário
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")]Aluno aluno) // Estamos utilizando o Bind por questão de segurança, para informar apenas o nome dos campos que queremos receber do formulário
        {
            if (ModelState.IsValid) // Verificando se o ModelState é valido
            {
                _context.Alunos.Add(aluno); // Cadastrando o aluno no banco de dados
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Retornando um redirecionando para o método Index
            }

            return View(aluno); // Caso o ModelState não seja válido, vai retornar a model aluno com os erros de validação
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
            if (id != aluno.Id) // Verificando se o id do paramêtro é o mesmo id do formulário
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao"); // Removendo o campo que não queremos validar no ModelState

            if (ModelState.IsValid)
            {
                _context.Update(aluno); // Atualizando no banco de dados
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirecionando para a controller index
            }

            return View(aluno);
        }
    }
}
