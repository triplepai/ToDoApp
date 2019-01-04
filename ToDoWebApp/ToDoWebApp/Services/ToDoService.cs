using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;
using ToDoWebApp.Models.Controller;
using ToDoWebApp.Models.Enum;

namespace ToDoWebApp.Services
{
    public class ToDoService
    {
        private static ToDoService instance;
        List<ToDoModel> list;
        public static ToDoService GetInstance()
        {
            if (instance == null) instance = new ToDoService();
            return instance;
        }
        public ToDoService()
        {
            // mock data
            list = new List<ToDoModel>();
            list.Add(new ToDoModel
            {
                ID = Guid.NewGuid().ToString(),
                Subject = "test",
                Detail = "detail",
                Status = ToDoEnum.Status.Pending
            });
            list.Add(new ToDoModel
            {
                ID = Guid.NewGuid().ToString(),
                Subject = "test2",
                Detail = "detail2",
                Status = ToDoEnum.Status.Pending
            });
            list.Add(new ToDoModel
            {
                ID = Guid.NewGuid().ToString(),
                Subject = "test3",
                Detail = "detail3",
                Status = ToDoEnum.Status.Done
            });
        }

        public List<ToDoModel> GetAll()
        {
            return list;
        }
        public ToDoModel Get(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new Exception(ErrorMessage.IDIsRequired);
            }
            ToDoModel result = list.FirstOrDefault(c => c.ID == id);
            if (result == null)
            {
                throw new Exception(ErrorMessage.DataNotFound);
            }
            return result;
        }
        public void Add(ToDoModel model)
        {
            if (String.IsNullOrEmpty(model.Subject))
            {
                throw new Exception(ErrorMessage.SubjectIsRequired);
            }
            model.ID = Guid.NewGuid().ToString();
            if (model.Status <= 0)
            {
                model.Status = ToDoEnum.Status.Pending;
            }
            list.Add(model);
        }
        public void Edit(ToDoModel model)
        {
            if (String.IsNullOrEmpty(model.ID))
            {
                throw new Exception(ErrorMessage.IDIsRequired);
            }
            if (String.IsNullOrEmpty(model.Subject))
            {
                throw new Exception(ErrorMessage.SubjectIsRequired);
            }
            if (model.Status <= 0)
            {
                throw new Exception(ErrorMessage.StatusIsRequired);
            }
            var item = list.FirstOrDefault(c => c.ID == model.ID);
            if (item == null)
            {
                throw new Exception(ErrorMessage.EditNotFound);
            }
            else
            {
                item.Subject = model.Subject;
                item.Detail = model.Detail;
                item.Status = model.Status;
            }

        }
        public void SetStatus(ToDoModel model)
        {
            if (String.IsNullOrEmpty(model.ID))
            {
                throw new Exception(ErrorMessage.IDIsRequired);
            }
            if (model.Status <= 0)
            {
                throw new Exception(ErrorMessage.StatusIsRequired);
            }
            var item = list.FirstOrDefault(c => c.ID == model.ID);
            if (item == null)
            {
                throw new Exception(ErrorMessage.SetStatusNotFound);
            }
            else
            {
                item.Status = model.Status;
            }

        }
        public void Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new Exception(ErrorMessage.IDIsRequired);
            }
            ToDoModel result = list.FirstOrDefault(c => c.ID == id);
            if (result == null)
            {
                throw new Exception(ErrorMessage.DeleteNotFound);
            }
            else
            {
                list.Remove(result);
            }
        }
    }
}
