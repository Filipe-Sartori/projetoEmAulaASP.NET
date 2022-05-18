using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesAnimal
    {

        Conexao con = new Conexao();

        public void inserirAnimal(ModelAnimal cm)// Cadastrar o atendimento no BD
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbAnimal (codAtendimento, nomeAnimal, codTipoAnimal, codCliente) values (default, @nomeAnimal, @codTipoAnimal, @codCliente)", con.MyConectarBD());
            cmd.Parameters.Add("@nomeAnimal", MySqlDbType.VarChar).Value = cm.nomeAnimal;
            cmd.Parameters.Add("@codTipoAnimal", MySqlDbType.VarChar).Value = cm.codTipoAnimal;
            cmd.Parameters.Add("@codCliente", MySqlDbType.VarChar).Value = cm.codCliente;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaAnimal()//Método de consulta Paciente
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Paciente = new DataTable();
            da.Fill(Paciente);
            con.MyDesconectarBD();
            return Paciente;
        }
    }
}