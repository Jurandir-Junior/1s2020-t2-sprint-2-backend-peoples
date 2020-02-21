using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=DEV701\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario, DataNascimento = @DataNascimento WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                    cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario, DataNascimento FROM Funcionarios WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            NomeFuncionario = rdr["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString(),

                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectByName = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario, DataNascimento FROM Funcionarios WHERE NomeFuncionario = @NomeFuncionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectByName, con))
                {
                    cmd.Parameters.AddWithValue("@NomeFuncionario", nome);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            NomeFuncionario = rdr["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString(),

                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }


        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario, DataNascimento) VALUES (@NomeFuncionario, @SobrenomeFuncionario, @DataNascimento)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            NomeFuncionario = rdr["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString(),

                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}
