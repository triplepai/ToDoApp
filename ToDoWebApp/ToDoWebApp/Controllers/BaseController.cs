using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApp.Models.Controller;

namespace ToDoWebApp.Controllers
{

    public class BaseController : ControllerBase
    {
        protected Response<T> Response<T>(T data)
        {
            return new Response<T>(data);
        }

        protected Response Response()
        {
            return new Response();
        }
    }
}