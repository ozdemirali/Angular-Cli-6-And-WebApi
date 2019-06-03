using ShopTemplateDataLayer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopTemplateDataLayer.Model;
using System.Web.Http.Cors;

namespace ShopTemplateWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class KategorilerController : ApiController
    {
        private ShopTemplateDal _service = new ShopTemplateDal();

        [ResponseType(typeof(List<ViewKategori>))]
        public IHttpActionResult Get()
        {
            var kategoriler = _service.GetKategoriList();
            return Ok(kategoriler);
        }

    }
}
