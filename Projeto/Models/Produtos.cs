using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Produtos
    {
        private string nomeProduto, id, desc;
        private int qtd;
        private decimal preco;

        List<byte[]> img = new List<byte[]>();
        static List<Produtos> carrinho = new List<Produtos>();

        static MySqlConnection con = new MySqlConnection("server=localhost;database=vgt;user id=root;password=TJBghjkFGYUI842");

        public Produtos(string nomeProduto, string id, decimal preco, string desc, int qtd, List<byte[]> img)
        {
            this.nomeProduto = nomeProduto;
            this.id = id;
            this.preco = preco;
            this.desc = desc;
            this.qtd = qtd;
            this.img = img;
        }

        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string Id { get => id; set => id = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public string Desc { get => desc; set => desc = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        public List<byte[]> Img { get => img; set => img = value; }

        public string Cadastrar()
        {

            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Produto VALUES(@id, @nome, @desc, @preco, @qtd)", con);

                qry.Parameters.AddWithValue("@nome", nomeProduto);
                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@preco", preco);
                qry.Parameters.AddWithValue("@desc", desc);
                qry.Parameters.AddWithValue("@qtd", qtd);
                qry.ExecuteNonQuery();

                for (int i = 0; i < img.Count; i++)
                {
                    MySqlCommand imagem = new MySqlCommand("INSERT INTO Galeria(img_produto, fk_produto_id_produto) VALUES(@img, @id)", con);
                    imagem.Parameters.AddWithValue("@img", img[i]);
                    imagem.Parameters.AddWithValue("@id", id);
                    imagem.ExecuteNonQuery();
                }

                img.Clear();

                return "Produto Cadastrado com Sucesso";

            }
            catch (Exception e)
            {
                return "Erro: " + e;

            }
            finally
            {
                con.Close();
            }
        }

        public static List<Produtos> Listar(string usuario, string id)
        {
            List<Produtos> lista = new List<Produtos>();
            List<Produtos> aux = new List<Produtos>();
            int i = 0;

            try
            {
                con.Open();

                string comando = "";

                if (id != null)
                {
                    comando = "SELECT * FROM Produto WHERE id_produto = @id";
                } else if(usuario == "user")
                {
                    comando = "SELECT * FROM Produto WHERE qtd_produto > @qtd";
                } else
                {
                    comando = "SELECT * FROM Produto";
                }

                MySqlCommand qry = new MySqlCommand(comando, con);
                qry.Parameters.AddWithValue("@qtd", 0);
                qry.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = qry.ExecuteReader();

                while(leitor.Read())
                {
                    Produtos p = new Produtos(leitor["nome_produto"].ToString(), leitor["id_produto"].ToString(), (decimal) leitor["preco_produto"],
                        leitor["desc_produto"].ToString(), (int) leitor["qtd_produto"], null);

                    aux.Add(p);
                }

                leitor.Close();

                while (aux.Count > i)
                {

                    MySqlCommand imagem = new MySqlCommand("SELECT * FROM Galeria WHERE fk_produto_id_produto = @id", con);
                    imagem.Parameters.AddWithValue("@id", aux[i].Id);

                    MySqlDataReader leitorImg = imagem.ExecuteReader();

                    List<byte[]> imgLista = new List<byte[]>();

                    while (leitorImg.Read())
                    {
                        imgLista.Add((byte[])leitorImg["img_produto"]);
                    }

                    leitorImg.Close();

                    Produtos p = new Produtos(aux[i].NomeProduto, aux[i].Id, aux[i].Preco, aux[i].Desc, aux[i].Qtd, imgLista);

                    lista.Add(p);

                    i++;
                }

                return lista;

            }
            catch (Exception e)
            {

                return null;

            }
            finally
            {
                con.Close();
            }
        }

        public string Editar()
        {
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("UPDATE Produto SET nome_produto = @nome, desc_produto = " +
                    "@desc, preco_produto = @preco, qtd_produto = @qtd WHERE id_produto = @id", con);

                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@nome", nomeProduto);
                qry.Parameters.AddWithValue("@desc", desc);
                qry.Parameters.AddWithValue("@preco", preco);
                qry.Parameters.AddWithValue("@qtd", qtd);

                qry.ExecuteNonQuery();

                /*PARTE DE ATUALIZAR AS IMAGENS*/

                MySqlCommand lerImagens = new MySqlCommand("SELECT * FROM Galeria WHERE fk_produto_id_produto = @id", con);
                lerImagens.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitorImg = lerImagens.ExecuteReader();

                List<int> numeros = new List<int>();

                while (leitorImg.Read())
                {
                    numeros.Add((int)leitorImg["numero_img"]);
                }

                leitorImg.Close();

                for (int i = 0; i < img.Count; i++)
                {
                    MySqlCommand imagem = new MySqlCommand("UPDATE Galeria SET img_produto = @img WHERE numero_img = @numero", con);

                    imagem.Parameters.AddWithValue("@img", img[i]);
                    imagem.Parameters.AddWithValue("@numero", numeros[i]);

                    imagem.ExecuteNonQuery();
                }

                return "Produto Editado com sucesso";

            }
            catch (Exception e)
            {

                return "Erro " + e;

            }
            finally
            {
                con.Close();
            }
        }

        public string AdicionarCarrinho(int qtd)
        {

            List<Produtos> aux = new List<Produtos>();
            int i = 0;

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand(
                    "SELECT * FROM Produto WHERE id_produto = @id", con);
                qry.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Produtos p = new Produtos(leitor["nome_produto"].ToString(), leitor["id_produto"].ToString(), (decimal)leitor["preco_produto"],
                        leitor["desc_produto"].ToString(), (int)leitor["qtd_produto"], null);

                    aux.Add(p);
                }

                leitor.Close();

                while (aux.Count > i)
                {

                    MySqlCommand imagem = new MySqlCommand("SELECT * FROM Galeria WHERE fk_produto_id_produto = @id", con);
                    imagem.Parameters.AddWithValue("@id", aux[i].Id);

                    MySqlDataReader leitorImg = imagem.ExecuteReader();

                    List<byte[]> imgLista = new List<byte[]>();

                    while (leitorImg.Read())
                    {
                        imgLista.Add((byte[])leitorImg["img_produto"]);
                    }

                    leitorImg.Close();

                    Produtos p = new Produtos(aux[i].NomeProduto, aux[i].Id, aux[i].Preco, aux[i].Desc, qtd, imgLista);

                    if(carrinho.Count == 0)
                    {
                        carrinho.Add(p);
                    } else
                    {
                        int j = 0;
                        int ajuda = 0;
                        Boolean tem = false;

                        foreach(var item in carrinho)
                        {
                            if (item.Id == p.id)
                            {
                                tem = true;
                                j = ajuda;
                            }

                            ajuda++;
                        }

                        if(tem == true)
                        {
                            carrinho[j].Qtd += p.Qtd;
                        } else
                        {
                            carrinho.Add(p);
                        }
                    }

                    i++;
                }

                return "Produto Adicionado ao Carrinho";

            }
            catch (Exception e)

            {
                return "Erro " + e;

            }
            finally
            {
                con.Close();
            }
        }

        public static List<Produtos> ListarCarrinho()
        {
            try
            {

                return carrinho;

            }
            catch (Exception e)

            {
                return null;

            }
        }

        public static string SalvarCarrinho(List<int> lista)
        {
            try
            {
                int aux = 0;

                foreach (var item in carrinho)
                {

                    item.Qtd = lista[aux];

                    aux++;
                }

                return "Carrinho Atualizado Com Sucesso";

            } catch(Exception e)
            {
                return "Erro " + e;
            }
        }

        public static string RemoverCarrinho(int id)
        {

            try
            {
                carrinho.RemoveAt(id);

                return "Removido com Sucesso";

            } catch (Exception e)
            {

                return "Erro " + e;
                
            } 
        }

        public static void LimparCarrinho()
        {
            carrinho.Clear();
        }

        public string Inativar()
        {
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("UPDATE Produto SET qtd_produto = 0 WHERE id_produto = @id", con);

                qry.Parameters.AddWithValue("@id", id);
                qry.ExecuteNonQuery();

                return "Inativado com Sucesso";

            }
            catch (Exception e)
            {
                return "Erro: " + e.Message;

            }
            finally
            {
                con.Close();
            }
        }
    }
}