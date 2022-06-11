using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Vendas
    {
        private string idProduto, emailUsuario, dataCompra, idCompra, volume;
        private int qtdComprado;
        private decimal preco;
        static MySqlConnection con = new MySqlConnection("server=ESN509VMYSQL;database=vgt;user id=aluno;password=Senai1234");

        public Vendas(string idProduto, decimal preco, string emailUsuario, string dataCompra, string idCompra, int qtdComprado, string volume)
        {
            this.idProduto = idProduto;
            this.preco = preco;
            this.emailUsuario = emailUsuario;
            this.dataCompra = dataCompra;
            this.idCompra = idCompra;
            this.qtdComprado = qtdComprado;
            this.volume = volume;
        }

        public string IdProduto { get => idProduto; set => idProduto = value; }
        public string EmailUsuario { get => emailUsuario; set => emailUsuario = value; }
        public string DataCompra { get => dataCompra; set => dataCompra = value; }
        public string IdCompra { get => idCompra; set => idCompra = value; }
        public int QtdComprado { get => qtdComprado; set => qtdComprado = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public string Volume { get => volume; set => volume = value; }

        public static string Comprar(List<Produtos> lista, string email, string data)
        {
            try {

                con.Open();

                int id = 0;

                MySqlCommand comando = new MySqlCommand("SELECT COUNT(DISTINCT id_compra) FROM vgt.Compra", con);

                MySqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    string aux = "";
                    aux = leitor["COUNT(DISTINCT id_compra)"].ToString();
                    id = int.Parse(aux);
                }

                leitor.Close();

                foreach (var item in lista)
                {

                    MySqlCommand com = new MySqlCommand("SELECT * FROM Produto WHERE id_produto = @id", con);
                    com.Parameters.AddWithValue("@id", item.Id);

                    MySqlDataReader l = com.ExecuteReader();

                    if(l.Read())
                    {

                        if (item.Qtd > (int)l["qtd_produto"])
                        {
                            item.Qtd = (int)l["qtd_produto"];
                        }
                    }

                    l.Close();

                    MySqlCommand comm = new MySqlCommand("UPDATE Produto SET qtd_produto = qtd_produto - @qtd WHERE id_produto = @id", con);
                    comm.Parameters.AddWithValue("@id", item.Id);
                    comm.Parameters.AddWithValue("@qtd", item.Qtd);

                    comm.ExecuteNonQuery();

                    MySqlCommand qry = new MySqlCommand("INSERT INTO Compra VALUES(@emailU, @idP, @qtd, @data, @preco, @volume, @idCompra)", con);

                    decimal total = item.Qtd * item.Preco;

                    qry.Parameters.AddWithValue("@idP", item.Id);
                    qry.Parameters.AddWithValue("@emailU", email);
                    qry.Parameters.AddWithValue("@data", data);
                    qry.Parameters.AddWithValue("@preco", total);
                    qry.Parameters.AddWithValue("@idCompra", id + 1);
                    qry.Parameters.AddWithValue("@volume", "900ml");
                    qry.Parameters.AddWithValue("@qtd", item.Qtd);

                    qry.ExecuteNonQuery();
                }

                return "Compra Realizada com Sucesso";

            } catch(Exception e)
            {
                return "Erro: " + e;

            } finally
            {
                con.Close();
            }
        }

        public static List<Vendas> Listar(string user, string email)
        {
            List<Vendas> lista = new List<Vendas>();

            try
            {
                con.Open();

                if (user == "adm")
                {
                    MySqlCommand qry = new MySqlCommand("SELECT * FROM Compra", con);
                    MySqlDataReader leitor = qry.ExecuteReader();

                    while(leitor.Read())
                    {
                        Vendas v = new Vendas(leitor["fk_produto_id_produto"].ToString(), (decimal)leitor["preco_atual_compra"], leitor["fk_user_email_user"].ToString(),
                            leitor["data_compra"].ToString(), leitor["id_compra"].ToString(), (int)leitor["qtd_compra"], leitor["volume"].ToString());

                        lista.Add(v);
                    }
                }
                else
                {
                    MySqlCommand qry = new MySqlCommand("SELECT * FROM Compra WHERE fk_user_email_user = @email", con);
                    qry.Parameters.AddWithValue("@email", email);
                    MySqlDataReader leitor = qry.ExecuteReader();

                    while (leitor.Read())
                    {
                        Vendas v = new Vendas(leitor["fk_produto_id_produto"].ToString(), (decimal)leitor["preco_atual_compra"], leitor["fk_user_email_user"].ToString(), 
                            leitor["data_compra"].ToString(), leitor["id_compra"].ToString(), (int)leitor["qtd_compra"], leitor["volume"].ToString());

                        lista.Add(v);
                    }
                }

                return lista;

            } catch(Exception e)
            {
                return null;

            } finally
            {
                con.Close();
            }
        }
    }
}
