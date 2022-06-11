using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Cadastrar()
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if(user.Tipo == "adm")
            {
                return View();
            } else
            {
                return RedirectToAction("Listar");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(string id, string nomeProduto, decimal preco, int qtd, string desc)
        {
            List<byte[]> img = new List<byte[]>();

            foreach (IFormFile arquivo in Request.Form.Files)
            {
                string tipoArquivo = arquivo.ContentType;

                if(tipoArquivo.Contains("png") || tipoArquivo.Contains("jpg") || tipoArquivo.Contains("jpeg"))
                {
                    MemoryStream s = new MemoryStream();
                    arquivo.CopyToAsync(s);
                    byte[] bytesArquivo = s.ToArray();

                    img.Add(bytesArquivo);
                } else
                {
                    TempData["msg"] = "Favor Inserir um Tipo de Imagem Válida";
                    return View();
                }
            }

            Produtos p = new Produtos(nomeProduto, id, preco, desc, qtd, img);

            TempData["msg"] = p.Cadastrar();

            return RedirectToAction("Cadastrar");
        }

        public IActionResult Editar(string id)
        {
            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if (user.Tipo == "adm")
            {
                TempData["id"] = id;

                ViewData["p"] = Produtos.Listar("", id);

                return View();
            }
            else
            {
                return RedirectToAction("Listar");
            }
        }

        [HttpPost]
        public IActionResult Editar(string id, string nomeProduto, decimal preco, int qtd, string desc)
        {

            List<byte[]> img = new List<byte[]>();

            foreach (IFormFile arquivo in Request.Form.Files)
            {
                string tipoArquivo = arquivo.ContentType;

                if(tipoArquivo.Contains("png") || tipoArquivo.Contains("jpg") || tipoArquivo.Contains("jpeg"))
                {
                    MemoryStream s = new MemoryStream();
                    arquivo.CopyToAsync(s);
                    byte[] bytesArquivo = s.ToArray();

                    img.Add(bytesArquivo);
                } 
                else
                {
                    TempData["msg"] = "Favor Inserir um Tipo de Imagem Válida";
                    return View();
                }
            }

            Produtos p = new Produtos(nomeProduto, id, preco, desc, qtd, img);

            TempData["msg"] = p.Editar();

            return RedirectToAction("Editar");
        }

        public IActionResult Listar()
        {
            return View(Produtos.Listar("user", null));
        }

        public IActionResult ListarAdm()
        {

            Users user = JsonConvert.DeserializeObject<Users>(HttpContext.Session.GetString("user"));

            if (user.Tipo == "adm")
            {
                return View(Produtos.Listar("adm", null));
            }
            else
            {
                return RedirectToAction("Listar");
            }
        }


        public IActionResult AdicionarCarrinho(string id, int qtd)
        {

            if(qtd == 0)
            {
                qtd = 1;
            }

            Produtos p = new Produtos("", id, 0, "", 0, null);

            TempData["msg"] = p.AdicionarCarrinho(qtd);
            return RedirectToAction("Listar");
        }

        public IActionResult Carrinho()
        {
            return View(Produtos.ListarCarrinho());
        }

        [HttpPost]
        public IActionResult Carrinho(int aux)
        {

            List<int> qtds = new List<int>();

            for(int i = 0; i < aux; i++)
            {
                string input = i.ToString();

                string num = Request.Form[input].ToString();

                qtds.Add(int.Parse(num));
            }

            Produtos.SalvarCarrinho(qtds);

            return RedirectToAction("Carrinho");
        }

        public IActionResult Finalizar()
        {
            return RedirectToAction("FinalizarCompra", "Vendas");
        }

        public IActionResult RemoverCarrinho(int id)
        {

            TempData["msg"] = Produtos.RemoverCarrinho(id);

            return RedirectToAction("Carrinho");
        }

        public IActionResult Inativar(string id)
        {
            Produtos v = new Produtos("", id, 0, "", 0, null);
            TempData["msg"] = v.Inativar();
            return RedirectToAction("ListarAdm");
        }
    }
}
