using ShopTemplateDataLayer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopTemplateDataLayer.Entity;
using ShopTemplateDataLayer.Model;
using System.Web.Http.Cors;
using System.Web;
using System.Threading.Tasks;
using System.IO;

namespace ShopTemplateWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UrunlerController : ApiController
    {
        private ShopTemplateDal _service = new ShopTemplateDal();


        [ResponseType(typeof(List<ViewUrun>))]
        public IHttpActionResult Get()
        {
            var urunler = _service.GetUrunList();
            return Ok(urunler);
        }


        [ResponseType(typeof(List<ViewUrunDetay>))]
        public IHttpActionResult Get(int id)
        {
            var urun = _service.GetUrunById(id);
            if (urun.Id==0)
            {
                return NotFound();
            }
            return Ok(urun);
        }

        [ResponseType(typeof(ViewUrunDetay))]
        public IHttpActionResult Post(ViewUrunDetay urun)
        {
            if (ModelState.IsValid)
            {
                var createdUrun = _service.CreateUrun(urun);
                return Ok("Ok");
                //return CreatedAtRoute("DefaultApi", new { id = createdUrun.Id }, createdUrun);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ResponseType(typeof(ViewUrunDetay))]
        public IHttpActionResult Put(ViewUrunDetay urun)
        {
            if (!_service.IsThereAnyUrun(urun.Id))
            {
                return NotFound();
            }
            else if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_service.UpdateUrun(urun));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_service.IsThereAnyUrun(id))
            {
                return NotFound();
            }
            else
            {
                _service.DeleteUrun(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [Route("api/Urunler/UploadFile")]
        public async Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Image");
            var provider = new MultipartFormDataStreamProvider(root);
            
            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    //remove double quates from string
                    name =name.Trim('"');
                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);
                    File.Move(localFileName, filePath);
                }
            }
            catch (Exception e)
            {

                return $"Error :{e.Message}";
            }
            return "Ok";
        }



    }
}
