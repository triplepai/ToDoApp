using System;
using ToDoWebApp.Models.Enum;
using ToDoWebApp.Services;
using Xunit;

namespace TodoWebApp.Test
{
    public class UnitTest
    {
        ToDoService toDoService = ToDoService.GetInstance();
        [Fact]
        public void TestGetAll()
        {

            // from initial mock data should be 3 row
            Assert.Equal("3", toDoService.GetAll().Count.ToString());
        }


        [Fact]
        public void TestGet()
        {

            // from initial mock data it have "test","test2","test3" subject
            Assert.Contains("test", toDoService.Get(toDoService.GetAll()[0].ID).Subject.ToString());
        }


        [Fact]
        public void TestAdd()
        {

            // from initial mock data should be 3 row
            toDoService.Add(new ToDoWebApp.Models.ToDoModel
            {
                Subject = "test4",
                Status = 1,
            });
            //after add "test4" then find in list and check subject name 
            Assert.Equal("test4", toDoService.GetAll().Find(c => c.Subject == "test4").Subject);
        }

        [Fact]
        public void TestEdit()
        {
            var item = toDoService.GetAll()[0];
            item.Status = 2;
            item.Subject = "change";
            toDoService.Edit(item);

            //after edit subject to "change" then find item in list and check subject name
            Assert.Equal("change", toDoService.Get(item.ID).Subject);
        }
        [Fact]
        public void TestSetStatus()
        {

            // from initial mock data should be 3 row
            var item = toDoService.GetAll()[0];
            item.Status = ToDoEnum.Status.Done;
            toDoService.SetStatus(item);
            //after edit status to "Done" then find item in list and check status
            Assert.Equal(ToDoEnum.Status.Done, toDoService.Get(item.ID).Status);
        }
        [Fact]
        public void TestDelete()
        {

            // from initial mock data should be 3 row
            toDoService.Delete(toDoService.GetAll()[0].ID);

            // after delete the list of data should remain 3 rows
            Assert.Equal("3", toDoService.GetAll().Count.ToString());
        }
    }
}
