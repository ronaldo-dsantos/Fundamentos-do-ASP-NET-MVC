using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    // Controller criada para validação do modelo de dados criado na classe Aluno, este exemplo não é necessário se os dados estiverem vindo de um formulário, neste caso a validação é automática pelo data bind
    public class ModelsController : Controller
    {
        public IActionResult Index() 
        {
            // var aluno = new Aluno();

            var aluno = new Aluno()
            {
                Nome = "R",
                Email = "ronaldo",
                EmailConfirmacao = "ronaldo.com",
            };

            // método para validar um modelo de dados
            if (TryValidateModel(aluno)) // TryValidateModel para verificar se a model aluno está válida
            {
                return View(aluno);
            }

            // Armazenando os dados da ModelState em uma variável
            var ms = ModelState; 

            // Armazenando os erros do ModelState em uma lista
            var erros = ModelState.Select(x => x.Value.Errors)
                                    .Where(y => y.Count > 0)
                                    .ToList();
            
            // Exibindo a lista de erros no console
            erros.ForEach(r => Console.WriteLine(r.First().ErrorMessage));
            
            return View(); 
        }
    }
}
