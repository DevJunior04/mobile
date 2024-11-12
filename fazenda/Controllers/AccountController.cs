using Microsoft.AspNetCore.Mvc;  // Necess�rio para utilizar IActionResult, Controller, etc.
using fazenda.Models;  // Importando o modelo User que foi criado

namespace fazenda.Controllers
{
	// Definindo o controller para as a��es relacionadas � conta
	public class AccountController : Controller
	{
		// A��o GET para exibir a p�gina de login
		[HttpGet]
		public IActionResult Login()
		{
			return View();  // Retorna a view de login, normalmente sem nenhum dado inicial
		}

		// A��o POST para processar o login
		[HttpPost]
		public IActionResult Login(User model)
		{
			if (ModelState.IsValid)  // Verifica se o modelo � v�lido (valida��o das anota��es)
			{
				// L�gica de autentica��o (aqui voc� pode substituir com uma consulta ao banco de dados)
				if (model.Email == "admin@admin.com" && model.Password == "admin123")
				{
					return RedirectToAction("Index", "Home");  // Redireciona para a p�gina inicial
				}
				else
				{
					// Se as credenciais forem inv�lidas, adiciona um erro ao modelo
					ModelState.AddModelError(string.Empty, "E-mail ou senha inv�lidos.");
				}
			}

			// Se o modelo for inv�lido ou se as credenciais estiverem erradas, retorna a view com o modelo para mostrar erros de valida��o
			return View(model);
		}
	}
}
