using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesCliente
    {
        Conexao con = new Conexao();

        public void inserirCliente(ModelCliente cmPac) //Método para inserir Cliente
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbCliente values (default, @nomeCliente, @telefoneCliente, @EmailCliente)", con.MyConectarBD());
            cmd.Parameters.Add("@nomeCliente", MySqlDbType.VarChar).Value = cmPac.nomeCliente;
            cmd.Parameters.Add("@telefoneCliente", MySqlDbType.VarChar).Value = cmPac.telefoneCliente;
            cmd.Parameters.Add("@EmailCliente", MySqlDbType.VarChar).Value = cmPac.EmailCliente;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaPac()//Método de consulta Cliente
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCliente", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Paciente = new DataTable();
            da.Fill(Paciente);
            con.MyDesconectarBD();
            return Paciente;
        }
    }
}