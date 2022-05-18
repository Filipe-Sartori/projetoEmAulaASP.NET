using ClinicaVeterinaria.Dados;
using ClinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class AtendimentoController : Controller
    {
        // GET: Atendimento

        public void carregaPacientes()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdClinica;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbVeterinario order by nomeVet;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ag.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.paciente = new SelectList(ag, "Value", "Text");
        }

        public void carregaVeterinario()
        {
            List<SelectListItem> med = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdClinica;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from bdClinicaVeterinaria order by nomeVet;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    med.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.medico = new SelectList(med, "Value", "Text");
        }

        AcoesAtendimento acAtend = new AcoesAtendimento();

        public ActionResult Index()
        {
            Session["tipo"] = "";
            return View();
        }

        public ActionResult CadAtendimento()
        {
            Session["tipo"] = "";
            carregaVeterinario();
            carregaPacientes();
            return View();
        }

        [HttpPost]
        public ActionResult CadAtendimento(ModelAtendimento cmAtende)
        {
            Session["tipo"] = "";
            carregaVeterinario();
            carregaPacientes();

            acAtend.TestarAgenda(cmAtende);

            if (cmAtende.confAgendamento == "0")
            {
                ViewBag.msg = "Horário Indisponível";
            }
            else
            {
                cmAtende.codAnimal = Request["paciente"]; // pegar cod do paciente selecionado na lista
                cmAtende.codVet = Request["medico"];
                acAtend.inserirAtendimento(cmAtende);
                ViewBag.msg = "Cadastro realizado com sucesso!";

            }
            return View();
        }
    }
}