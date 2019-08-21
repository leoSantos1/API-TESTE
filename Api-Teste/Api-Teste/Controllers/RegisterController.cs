using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Api_Teste.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetRegister()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Logic.Register().GetAll().ToList());
            }
            catch (WebException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (TimeoutException e)
            {
                return Request.CreateResponse(HttpStatusCode.RequestTimeout, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage New(Model.Register pModel)//padrão é JSON
        {
            try
            {
                if (pModel != null)
                {
                    new Logic.Register().Add(pModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (WebException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (TimeoutException e)
            {
                return Request.CreateResponse(HttpStatusCode.RequestTimeout, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
