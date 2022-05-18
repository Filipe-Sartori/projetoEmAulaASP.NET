using ClinicaVeterinaria.Dados;
using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Controllers
{
    public class AnimalController : Controller
    {
        AcoesAnimal acA = new AcoesAnimal();

        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadAnimal() // carrega a pagina Animal
        {
            Session["tipo"] = "";

            return View();
        }

        [HttpPost]
        public ActionResult CadAnimal(ModelAnimal cmPac) //Efetua o cadastro do Animal no banco de dados
        {
            Session["tipo"] = "";

            acA.inserirAnimal(cmPac);
            Response.Write("<script>alert('Cadastro efetuado com sucesso')</script>");

            return View();
        }

        public ActionResult ConsAnimal()
        {
            Session["tipo"] = "";

            GridView dgv = new GridView();
            dgv.DataSource = acA.ConsultaAnimal();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }
    }
}