// Exemplo de View Components (diferente das partial views, ele é um componente independente das Views e tem um processamento individual)

using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // podemos realizar um processamento independente da controller
            // poderiamos estar pegando os dados do aluno no banco de dados
            // poderiamos estar pegando os dados do aluno que está logado
            var aluno = new Aluno() { Nome = "Ronaldo" };

            return View(aluno);
        }

    }
}
