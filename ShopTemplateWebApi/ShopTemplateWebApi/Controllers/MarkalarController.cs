using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ShopTemplateDataLayer.Controller;
using ShopTemplateDataLayer.Model;

namespace ShopTemplateWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MarkalarController : ApiController
    {
        private ShopTemplateDal _service = new ShopTemplateDal();

        [ResponseType(typeof(List<ViewMarka>))]
        public IHttpActionResult Get()
        {
            var markalar = _service.GetMarkaList();
            return Ok(markalar);
        }
    }
}
