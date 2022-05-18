using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesVeterinario
    {
        Conexao con = new Conexao();

        public void inserirVeterinario(ModelVeterinario cmEsp) //Método para inserir tipo Especialidade
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbVeterinario values (default, @nomeVet)", con.MyConectarBD());
            cmd.Parameters.Add("@nomeVet", MySqlDbType.VarChar).Value = cmEsp.nomeVet;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}