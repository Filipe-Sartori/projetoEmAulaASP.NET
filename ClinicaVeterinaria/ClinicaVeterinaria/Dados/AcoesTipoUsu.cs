using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesTipoUsu
    {
        Conexao con = new Conexao();
        public void inserirTipoUsu(ModelTipoUsu cmTipo) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbTipoUsuario values (default, @usuario)", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cmTipo.usuario;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaTipo()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbTipoUsuario", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}