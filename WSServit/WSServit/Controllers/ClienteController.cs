using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WSServit.Models;
using WSServit.Models.Request;
using WSServit.Models.Response;


namespace WSServit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            MyResponse oRespuesta = new MyResponse();
            try
            {
                using (ServitDataBaseContext db = new ServitDataBaseContext())
                {
                    var lst = db.Cliente.ToList();
                    oRespuesta.Success = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            MyResponse oRespuesta = new MyResponse();

            try
            {
                using (ServitDataBaseContext db = new ServitDataBaseContext())
                {

                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();

                    oRespuesta.Success = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            MyResponse oRespuesta = new MyResponse();

            try
            {
                using (ServitDataBaseContext db = new ServitDataBaseContext())
                {

                    Cliente oCliente = db.Cliente.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oRespuesta.Success = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            MyResponse oRespuesta = new MyResponse();

            try
            {
                using (ServitDataBaseContext db = new ServitDataBaseContext())
                {

                    Cliente oCliente = db.Cliente.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();

                    oRespuesta.Success = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Message = ex.Message;
            }
            return Ok(oRespuesta);

        }
    }
}