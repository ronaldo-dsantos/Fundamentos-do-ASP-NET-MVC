using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PrimeiraApp.Controllers
{
    [Route("/", Order = 0)] // Se quisermos definir essa rota como a rota padrão de nossa aplicação, podemos usar esta estratégia para que ela seja acessada pelo "/"
    [Route("minha-conta", Order = 1)] // Aplicando rotas personalizadas (neste exemplo estamos alterando o nome da rota de /testes para /minha-conta)
    [Route("gestao-da-conta", Order = 2)] // Aplicando uma segunda opção de rota para a mesma controller
    public class TestesController : Controller
    {
        // GET: Testes
        //[Route("inicio")] // Redefinindo o nome padrão das rotas (se usar a personalização o index sempre precisará ser acessado pela url completa, ex. minha-conta/inicio, se personalizarmos as demais rotas e deixar o index sem esse recurso ele se torna a rota padrão e conseguimos acessa através do minha-conta/)
        public ActionResult Index()
        {
            return View();
            //return Json({nome:ronaldo});
            //return Content("Olá");
        }

        // GET: Testes/Details/5
        [HttpGet("detalhes/{id:int}")] // Informando o verbo, rota personalizada e o parâmetro
        //[HttpGet("detalhes/{id:int}/{id2?}")] // outra maneira de receber um parâmetro opcional, mas no ActionResult ele precisa ser inicializado devido a possibilidade de null, exemplo id2 = 0
        public ActionResult Details(int id, string teste01, string teste02) // Recebendo um parâmetro que não está definido na rota ("/detalhes/1?teste01=Olá&teste02=Ronaldo")
        {
            return View();
        }

        // GET: Testes/Create
        [HttpGet("novo")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testes/Create
        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nome,Idade")]IFormCollection collection) // [FromForm] para informar que estes dados estão vindo do formulário e receber todos os dados ou [Bind] para informarmos quais dados queremos receber do formulário
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Testes/Edit/5
        [HttpGet("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Testes/Edit/5
        [HttpPost("editar/{id:int}")] 
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]IFormCollection collection) // int id vem do parâmetro e [FromForm] para informar que os demais dados estão vindo do formulário
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Testes/Delete/5
        [HttpGet("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Testes/Delete/5
        [HttpPost("excluir/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
