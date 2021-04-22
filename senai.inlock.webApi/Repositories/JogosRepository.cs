using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        string StringConexao = "Data source= LAPTOP-L0JSQP3E; initial catalog= Inlock_games; user Id= sa; pwd= 20nov2004";
        public void Cadastrar(JogosDomain novojogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryCreate = "INSERT INTO Jogos (IdEstudio,NomeJogo,Descricao,DataLancamento,Valor) VALUES (@IdEstudio,@NomeJogo,@Descricao,@DataLancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(QueryCreate, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novojogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@NomeJogo", novojogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novojogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novojogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novojogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> JogosLista = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryRead = "SELECT * FROM Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryRead, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogosDomain Jg = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            IdEstudio = Convert.ToInt32(rdr[1]),
                            NomeJogo = rdr[2].ToString(),
                            Descricao = rdr[3].ToString(),
                            DataLancamento = rdr[4].ToString(),
                            Valor = Convert.ToInt32(rdr[5]),
                        };

                        JogosLista.Add(Jg);
                    };
                }
            }
            return JogosLista;
        }
    }
}

