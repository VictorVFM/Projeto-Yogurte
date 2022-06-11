using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto
{
    public class Users
    {
        private string tipo, email, senha, nomeCompleto, endereco, telefone, status;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vgt;user id=root;password=TJBghjkFGYUI842");

        public Users(string tipo, string status, string email, string senha, string nomeCompleto, string endereco, string telefone)
        {
            this.tipo = tipo;
            this.status = status;
            this.email = email;
            this.senha = senha;
            this.nomeCompleto = nomeCompleto;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Status { get => status; set => status = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string NomeCompleto { get => nomeCompleto; set => nomeCompleto = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        public string Cadastrar()
        {
            try
            {
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM User WHERE email_user = @email", con);
                c.Parameters.AddWithValue("@email", email);

                MySqlDataReader leitor = c.ExecuteReader();

                if (leitor.Read())
                {
                    if (leitor["status"].ToString() == "desativado")
                    {
                        leitor.Close();

                        MySqlCommand qry = new MySqlCommand("UPDATE User SET tipo_user = @tipo, status = @status, " +
                            "senha_user = @senha, nome_user = @nome, telefone_cliente = @telefone, endereco_cliente = " +
                            "@endereco WHERE email_user = @email", con);

                        qry.Parameters.AddWithValue("@email", email);
                        qry.Parameters.AddWithValue("@senha", senha);
                        qry.Parameters.AddWithValue("@nome", nomeCompleto);
                        qry.Parameters.AddWithValue("@endereco", endereco);
                        qry.Parameters.AddWithValue("@telefone", telefone);
                        qry.Parameters.AddWithValue("@tipo", tipo);
                        qry.Parameters.AddWithValue("@status", status);

                        qry.ExecuteNonQuery();

                        return "Bem Vindo de Volta, Pode Acessar Sua Conta Novamente";
                    }
                    else
                    {
                        return "Você Já Está Cadastrado";
                    }
                } else {

                    leitor.Close();

                    MySqlCommand qry = new MySqlCommand("INSERT INTO User VALUES(@tipo, @status, @email, @senha, @nome, " +
                        "@telefone, @endereco)", con);

                    qry.Parameters.AddWithValue("@email", email);
                    qry.Parameters.AddWithValue("@senha", senha);
                    qry.Parameters.AddWithValue("@nome", nomeCompleto);
                    qry.Parameters.AddWithValue("@telefone", telefone);
                    qry.Parameters.AddWithValue("@endereco", endereco);
                    qry.Parameters.AddWithValue("@tipo", tipo);
                    qry.Parameters.AddWithValue("@status", "ativado");
                    qry.ExecuteNonQuery();

                    return "Usuário Cadastrado com Sucesso";

                }

            } catch(Exception e)
            {
                return "Erro: " + e;

            } finally
            {
                con.Close();
            }
        }

        public string Editar()
        {
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("UPDATE User SET tipo_user = @tipo, status = @status, senha_user = @senha, nome_user = " +
                    "@nome, telefone_cliente = @telefone, endereco_cliente = @endereco WHERE email_user = @email", con);
                qry.Parameters.AddWithValue("@email", email);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.Parameters.AddWithValue("@nome", nomeCompleto);
                qry.Parameters.AddWithValue("@endereco", endereco);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@tipo", tipo);
                qry.Parameters.AddWithValue("@status", status);
                qry.ExecuteNonQuery();

                return "Usuário Editado com sucesso";

            } catch (Exception e)
            {

                return "Erro " + e;
                
            } finally
            {
                con.Close();
            }
        }

        public static List<Users> Listar(string id)
        {
            List<Users> lista = new List<Users>();
            
            try
            {
                con.Open();

                string comando = "";

                if(id == null)
                {
                    comando = "SELECT * FROM User";
                } else
                {
                    comando = "SELECT * FROM User WHERE email_user = @email";
                }

                MySqlCommand qry = new MySqlCommand(comando, con);
                qry.Parameters.AddWithValue("@email", id);

                MySqlDataReader leitor = qry.ExecuteReader();

                while(leitor.Read())
                {
                    Users u = new Users(leitor["tipo_user"].ToString(), leitor["status"].ToString(), leitor["email_user"].ToString(), leitor["senha_user"].ToString(), 
                        leitor["nome_user"].ToString(), leitor["endereco_cliente"].ToString(), leitor["telefone_cliente"].ToString());
                    lista.Add(u);
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

        public Users Verificar()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM User WHERE email_user = @email AND senha_user = @senha", con);
                qry.Parameters.AddWithValue("@email", email);
                qry.Parameters.AddWithValue("@senha", senha);
                MySqlDataReader leitor = qry.ExecuteReader();

                if(leitor.Read())
                {
                    return new Users(leitor["tipo_user"].ToString(), leitor["status"].ToString(), leitor["email_user"].ToString(), leitor["senha_user"].ToString(),
                        leitor["nome_user"].ToString(), leitor["endereco_cliente"].ToString(), leitor["telefone_cliente"].ToString());
                } else
                {
                    return null;
                }

            } catch(Exception e)
            {
                return null;

            } finally
            {
                con.Close();
            }
        } 

        public string AtivarInativar(string acao)
        {

            string statusNovo, msg;

            try
            {
                con.Open();

                if(acao == "ativar")
                {
                    statusNovo = "ativado";
                    msg = "Ativado";

                } else
                {
                    statusNovo = "desativado";
                    msg = "Desativado";
                }

                MySqlCommand qry = new MySqlCommand("UPDATE User SET status = @status WHERE email_user = @email", con);
                qry.Parameters.AddWithValue("@email", email);
                qry.Parameters.AddWithValue("@status", statusNovo);

                qry.ExecuteNonQuery();

                return msg + " com Sucesso";

            } catch(Exception e)
            {
                return "Erro: " + e.Message;

            } finally
            {
                con.Close();
            }
        }

        public string TrocarAdmUsuario(string tipo_user)
        {
            string msg, tipoNovo;

            try
            {
                con.Open();

                if(tipo_user == "adm")
                {

                    tipoNovo = "user";
                    msg = "Usuário";

                } else
                {
                    tipoNovo = "adm";
                    msg = "Adm";
                }

                MySqlCommand qry = new MySqlCommand("UPDATE User SET tipo_user = @tipo WHERE email_user = @email", con);
                qry.Parameters.AddWithValue("@tipo", tipoNovo);
                qry.Parameters.AddWithValue("@email", email);

                qry.ExecuteNonQuery();

                return "Trocado para " + msg + " com Sucesso";

            } catch(Exception e)
            {

                return "Erro: " + e;

            } finally
            {
                con.Close();
            }
        }
    }
}
