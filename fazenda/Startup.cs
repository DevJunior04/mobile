public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// Este m�todo � chamado pelo runtime. Use este m�todo para adicionar servi�os ao cont�iner.
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllersWithViews(); // Adiciona suporte a Views e Controllers
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}

		// Garante que os arquivos est�ticos da pasta wwwroot sejam servidos
		app.UseStaticFiles();

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
		});
	}
}
