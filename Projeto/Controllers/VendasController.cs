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
    public class VendasController : Controller
    {
        public IActionResult Compras()
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));
            return View(Vendas.Listar(user.Tipo, user.Email));
        }

        public IActionResult FinalizarCompra()
        {
            return View();
        }

        public IActionResult Compra()
        {
            List<Produtos> carrinho = Produtos.ListarCarrinho();
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            string s = DateTime.Now.ToString("yyyy.MM.dd");

            TempData["msg"] = Vendas.Comprar(carrinho, user.Email, s);

            Produtos.LimparCarrinho();

            return RedirectToAction("Compras");
        }
    }
}