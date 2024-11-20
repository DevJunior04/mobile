var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Erro para ambientes de produ��o.
    app.UseHsts(); // Configura o HSTS.
}

app.UseHttpsRedirection(); // Redireciona para HTTPS.
app.UseStaticFiles(); // Permite o uso de arquivos est�ticos (CSS, JS, imagens).

app.UseRouting(); // Habilita o roteamento.

app.UseAuthorization(); // Autoriza as requisi��es.

// Configura a rota padr�o para direcionar para o controlador Home e a a��o Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Rota padr�o (Home/Index)

// Inicia a aplica��o.
app.Run();
