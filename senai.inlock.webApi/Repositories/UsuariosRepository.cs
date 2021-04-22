using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        string StringConexao = "Data source= LAPTOP-L0JSQP3E; initial catalog= Inlock_games; user Id= sa; pwd= 20nov2004";

        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Define a query a ser executada no banco de dados
                string querySelect = "SELECT * FROM Usuarios WHERE Email = @Email AND senha = @Senha;";

                // Define o comando passando a query e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto usuarioBuscado
                        UsuariosDomain usuarioBuscado = new UsuariosDomain
                        {
                            // Atribui às propriedades os valores das colunas
                           IdUsuario = Convert.ToInt32(rdr[0]),
                           IdTipoDeUsuario = Convert.ToInt32(rdr[1]),
                           Email = rdr[2].ToString(),
                           Senha = rdr[3].ToString(),
                        };

                        // Retorna o objeto usuarioBuscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um e-mail e senha correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}

