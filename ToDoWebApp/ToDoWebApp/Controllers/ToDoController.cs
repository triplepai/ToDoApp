using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApp.Models;
using ToDoWebApp.Models.Controller;
using ToDoWebApp.Models.Enum;
using ToDoWebApp.Services;

namespace ToDoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : BaseController
    {
        ToDoService toDoService = ToDoService.GetInstance();
        public ToDoController()
        {

        }

        [HttpGet]
        [Route("getall")]
        public Response<List<ToDoModel>> GetAll()
        {
            try
            {
                List<ToDoModel> result = toDoService.GetAll();
                return Response(result).Success();
            }
            catch (Exception ex)
            {
                return Response(new List<ToDoModel>()).Failed(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("get")]
        public Response<ToDoModel> Get(string id)
        {
            try
            {
                ToDoModel result = toDoService.Get(id);
                return Response(result).Success();

            }
            catch (Exception ex)
            {
                return Response(new ToDoModel()).Failed(ex.Message.ToString());
            }

        }
        [HttpPost]
        [Route("add")]
        public Response<string> Add(ToDoModel model)
        {
            try
            {
                toDoService.Add(model);
                return Response(String.Empty).Success();

            }
            catch (Exception ex)
            {
                return Response(String.Empty).Failed(ex.Message.ToString());
            }

        }
        [HttpPost]
        [Route("edit")]
        public Response<string> Edit(ToDoModel model)
        {
            try
            {
                toDoService.Edit(model);
                return Response(String.Empty).Success();

            }
            catch (Exception ex)
            {
                return Response(String.Empty).Failed(ex.Message.ToString());
            }

        }
        [HttpPost]
        [Route("setstatus")]
        public Response<string> SetStatus(ToDoModel model)
        {
            try
            {
                toDoService.SetStatus(model);
                return Response(String.Empty).Success();

            }
            catch (Exception ex)
            {
                return Response(String.Empty).Failed(ex.Message.ToString());
            }

        }
        [HttpDelete]
        [Route("delete")]
        public Response<string> Delete(string id)
        {
            try
            {
                toDoService.Delete(id);
                return Response(String.Empty).Success();

            }
            catch (Exception ex)
            {
                return Response(String.Empty).Failed(ex.Message.ToString());
            }

        }
    }
}