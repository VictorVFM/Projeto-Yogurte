using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string tipo, string status, string email, string senha, string nomeCompleto, string endereco, string telefone)
        {

            if(HttpContext.Session.GetString("user") == null) {
                tipo = "user";
                status = "ativado";
            }

            Users u = new Users(tipo, status, email, senha, nomeCompleto, endereco, telefone);
            TempData["msg"] = u.Cadastrar();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            Users u = new Users("", "", email, senha, "", "", "");

            Users user = u.Verificar();

            if(user != null)
            {

                if(user.Status == "ativado")
                {
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Listar", "Produtos");

                } else

                {
                    TempData["msg"] = "Usuário/Senha Incorreto(s)";
                    return RedirectToAction("Login");
                }
                
            } else
            {
                TempData["msg"] = "Usuário/Senha Incorreto(s)";
                return RedirectToAction("Login");
            }
        }

        public IActionResult AreaAdmin()
        {
            return View();
        }

        public IActionResult Editar(string id)
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if (user.Tipo == "user")
            {
                id = user.Email;

                TempData["id"] = id;

                ViewData["dados"] = Users.Listar(id);
                return View();
            } else
            {
                TempData["id"] = id;

                ViewData["dados"] = Users.Listar(id);
                return View();
            }
        }

        [HttpPost]
        public IActionResult Editar(string id, string tipo, string status, string nomeCompleto, string senha, string endereco, string telefone)
        {

            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if(user.Email == id)
            {
                if(user.Tipo == "user")
                {
                    status = "ativado";
                    tipo = "user";
                }

                Users u = new Users(tipo, status, user.Email, senha, nomeCompleto, endereco, telefone);

                TempData["msg"] = u.Editar();
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));

                return RedirectToAction("Editar");
            } else
            {
                Users u = new Users(tipo, status, id, senha, nomeCompleto, endereco, telefone);
                TempData["msg"] = u.Editar();

                return RedirectToAction("Editar");
            }
        }

        public IActionResult Sair()
        {
            Produtos.LimparCarrinho();
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }

        public IActionResult Listar()
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if(user.Tipo == "adm")
            {
                return View(Users.Listar(null));
            } else
            {
                return RedirectToAction("Listar", "Produtos");
            }
        }

        public IActionResult Inativar(string id)
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if(user.Email == id)
            {
                Users v = new Users("", "", id, "", "", "", "");

                TempData["msg"] = v.AtivarInativar("inativar");
                Produtos.LimparCarrinho();
                HttpContext.Session.Remove("user");
                return RedirectToAction("Cadastrar");
            } else
            {
                Users v = new Users("", "", id, "", "", "", "");

                TempData["msg"] = v.AtivarInativar("inativar");
                return RedirectToAction("Listar");
            }
        }

        public IActionResult Ativar(string id)
        {
            Users v = new Users("", "", id, "", "", "", "");

            TempData["msg"] = v.AtivarInativar("ativar");
            return RedirectToAction("Listar");
        }

        public IActionResult TrocarParaAdm(string id)
        {
            Users v = new Users("", "", id, "", "", "", "");

            TempData["msg"] = v.TrocarAdmUsuario("user");
            return RedirectToAction("Listar");
        }

        public IActionResult TrocarParaUser(string id)
        {
            Users v = new Users("", "", id, "", "", "", "");

            TempData["msg"] = v.TrocarAdmUsuario("adm");
            return RedirectToAction("Listar");
        }
    }
}
