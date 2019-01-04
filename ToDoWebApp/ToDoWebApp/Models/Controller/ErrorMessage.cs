using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models.Controller
{
    public static class ErrorMessage
    {
        public const string DataNotFound = "Data not found";
        public const string IDIsRequired = "id is required";
        public const string SubjectIsRequired = "subject is required";
        public const string StatusIsRequired = "status is required";
        public const string SetStatusNotFound = "set status failed, cannot find subject id";
        public const string EditNotFound = "edit failed, cannot find subject id";
        public const string DeleteNotFound = "delete failed, cannot find subject id";
    }
}
