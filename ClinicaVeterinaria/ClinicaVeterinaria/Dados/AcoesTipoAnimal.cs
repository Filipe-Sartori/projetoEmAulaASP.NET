using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesTipoAnimal
    {
        Conexao con = new Conexao();
        public void inserirTipoAnimal(ModelTipoAnimal cmEsp) //Método para inserir tipo Tipo do Animal
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbTipoAnimal values (default, @tipoAnimal)", con.MyConectarBD());
            cmd.Parameters.Add("@tipoAnimal", MySqlDbType.VarChar).Value = cmEsp.tipoAnimal;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

		public DataTable ConsultaEsp()//Método de consulta do tipo de Especialidade
		{
			MySqlCommand cmd = new MySqlCommand("select * from tbTipoAnimal", con.MyDesconectarBD());
			MySqlDataAdapter da = new MySqlDataAdapter(cmd);
			DataTable Especialidade = new DataTable();
			da.Fill(Especialidade);
			con.MyDesconectarBD();
			return Especialidade;
		}
	}
}