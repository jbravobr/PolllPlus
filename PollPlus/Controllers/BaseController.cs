using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    public class BaseController : Controller
    {
        private log4net.ILog logger;

        protected override void OnException(ExceptionContext filterContext)
        {
            // Armazena informações da Exception no Banco de Dados.
            logger = log4net.LogManager.GetLogger(typeof(BaseController).FullName);
            logger.Error(filterContext.Exception.Message, filterContext.Exception);

            // If the request is AJAX return JSON else redirect user to Error view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, message = "Não foi possível processar sua solicitação devido a ocorrência de erro. Verifique o endereço solicitado e caso o problema venha ocorrer novamente procure o suporte responsável." }
                };
            }
            else
            {
                // Redirect user to error page
                filterContext.ExceptionHandled = true;
                filterContext.Result = this.RedirectToAction("Index", "Erro");
            }

            base.OnException(filterContext);
        }

        [NonAction]
        protected T ObterInstanciaService<T>() where T : class, new()
        {
            return new T();
        }
    }
}