using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }

        public TesteEFController(AppDbContext db)
        {
            Db = db;            
        }
        public IActionResult Index()
        {
            // criando um aluno
            var aluno = new Aluno()
            {
                Nome = "Ronaldo",
                Email = "ronaldo@email.com",
                DataNascimento = new DateTime(1985, 09, 30),
                Avaliacao = 5,
                Ativo = true
            };

            // adicionando o aluno no banco de dados
            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            // buscando um aluno no banco de dados e alterando o nome 
            var alunosChange = Db.Alunos.Where(a => a.Nome == "Ronaldo").FirstOrDefault();
            alunosChange.Nome = "Ronaldo Domingues";

            // aplicando as atualização no banco de dados
            Db.Alunos.Update(alunosChange);
            Db.SaveChanges();

            // removendo um aluno no banco de dados
            Db.Alunos.Remove(alunosChange);
            Db.SaveChanges();

            return View();
        }
    }
}
