using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Dados
{
    public class AcoesAtendimento
    {
        Conexao con = new Conexao();

        public void TestarAgenda(ModelAtendimento agenda) //verificar se a agenda está reservada
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAtendimento where DataAtendimento = @DataAtendimento and HoraAtendimento = @HoraAtendimento", con.MyConectarBD());

            cmd.Parameters.Add("@DataAtendimento", MySqlDbType.VarChar).Value = agenda.DataAtendimento;
            cmd.Parameters.Add("@HoraAtendimento", MySqlDbType.VarChar).Value = agenda.HoraAtendimento;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    agenda.confAgendamento = "0";
                }

            }

            else
            {
                agenda.confAgendamento = "1";
            }

            con.MyDesconectarBD();
        }


        public void inserirAtendimento(ModelAtendimento cm)// Cadastrar o atendimento no BD
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbAtendimento(codAtendimento, DataAtendimento, HoraAtendimento, codAnimal, codVet) values (default, @DataAtendimento, @HoraAtendimento, @codAnimal, @codVet)", con.MyConectarBD());
            cmd.Parameters.Add("@DataAtendimento", MySqlDbType.VarChar).Value = cm.DataAtendimento;
            cmd.Parameters.Add("@HoraAtendimento", MySqlDbType.VarChar).Value = cm.HoraAtendimento;
            cmd.Parameters.Add("@codAnimal", MySqlDbType.VarChar).Value = cm.codAnimal;
            cmd.Parameters.Add("@codVet", MySqlDbType.VarChar).Value = cm.codVet;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}