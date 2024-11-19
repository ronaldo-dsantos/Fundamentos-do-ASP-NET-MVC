using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    // classe criada para validação do modelo de dados criado na classe Aluno
    public class ModelsController : Controller
    {
        public IActionResult Index() 
        {
            //var aluno = new Aluno();

            var aluno = new Aluno()
            {
                Nome = "R",
                Email = "ronaldo",
                EmailConfirmacao = "ronaldo.com",
            };

            // método para validar um modelo de dados
            if (TryValidateModel(aluno)) 
            {
                return View(aluno);
            }

            var ms = ModelState;

            // tratando os erros para que possamos visualisá-los no console
            var erros = ModelState.Select(x => x.Value.Errors)
                                    .Where(y => y.Count > 0)
                                    .ToList();

            erros.ForEach(r => Console.WriteLine(r.First().ErrorMessage));
            

            return View(); 
        }
    }
}
