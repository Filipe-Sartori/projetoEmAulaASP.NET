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
    public class TipoAnimalController : Controller
    {
        AcoesTipoAnimal acT = new AcoesTipoAnimal();

        // GET: AcoesTipoAnimal
        public ActionResult Index()
        {
            Session["tipo"] = "";

            return View();
        }

        public ActionResult CadAnimal() // carrega a pagina tipo animal
        {
            Session["tipo"] = "";

            return View();
        }

        [HttpPost]
        public ActionResult CadAnimal(ModelTipoAnimal cmAnimal) //Efetua o cadastro do tipo animal no banco de dados
        {
            Session["tipo"] = "";

            acT.inserirTipoAnimal(cmAnimal);
            Response.Write("<script>alert('Cadastro efetuado com sucesso')</script>");

            return View();
        }

        public ActionResult ConsAnimal()
        {
            Session["tipo"] = "";

            GridView dgv = new GridView();
            dgv.DataSource = acT.ConsultaEsp();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }
    }
}