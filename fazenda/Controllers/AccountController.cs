using Microsoft.AspNetCore.Mvc;
using fazenda.Models;  // Importando o modelo User

namespace fazenda.Controllers
{
    public class AccountController : Controller
    {
        // A��o GET para exibir a p�gina de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // A��o POST para processar o login
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)  // Verifica se o modelo � v�lido (valida��o das anota��es)
            {
                if (model.Email == "admin@admin.com" && model.Password == "admin123")
                {
                    return RedirectToAction("Index", "Home");  // Redireciona para a p�gina inicial
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "E-mail ou senha inv�lidos.");
                }
            }
            return View(model);
        }

        // A��o GET para exibir a p�gina de cadastro
        [HttpGet]
        public IActionResult Register()
        {
            return View();  // Exibe a p�gina de cadastro
        }

        // A��o POST para processar o cadastro
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Aqui voc� pode adicionar a l�gica para salvar o usu�rio no banco de dados
                // Exemplo: _context.Users.Add(model); _context.SaveChanges();

                // Ap�s o cadastro, redireciona o usu�rio para a p�gina de login
                return RedirectToAction("Login");
            }

            // Se o modelo for inv�lido, retorna a view com o modelo para mostrar erros de valida��o
            return View(model);
        }
    }
}
