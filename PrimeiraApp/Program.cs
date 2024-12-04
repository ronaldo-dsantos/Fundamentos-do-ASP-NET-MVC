using Microsoft.EntityFrameworkCore;
using PrimeiraApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionando a conexão com o banco de dados, os dados da string de conexão estão no arquivo appsettings.json
builder.Services.AddDbContext<AppDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting(); // Adicionando rotas a aplicação

app.UseAuthorization();

// Exemplo de como definir uma rota personalizada para a aplicação (não recomendável, exemplo para conhecimento da funcionalidade)
// "www.loja.com/MinhaConta/MeusPedidos/2020/Cancelados
//app.MapControllerRoute( 
//    name: "MinhaConta",
//    pattern: "{controller=MinhaConta}/{action=MeusPedidos}/{ano}/{status}");

// Definindo a rota padrão para a aplicação (deixar a rota padrão sempre por último)
app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
