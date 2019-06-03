using ShopTemplateDataLayer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopTemplateWebApi.Controllers
{
    public class ShopTemplateController : ApiController
    {
        ShopTemplateDal _service = new ShopTemplateDal();

        public IHttpActionResult GetKategoriList()
        {
            var kategoriler = _service.GetKategoriList();
            return Ok(kategoriler);
        }

        //public string Get()
        //{
        //    return "Merhaba Dünya";
        //}
    }
}
