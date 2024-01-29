//using Microsoft.AspNetCore.Mvc;
//using P1TaskFlow.Models;

//namespace P1TaskFlow.DataAcess.Tasks
//{
//    public class TodoTaskMockRepository
//    {
//        private static List<TodoTask> tasks = new();
//        private static bool empty = false;

//        //public TodoTaskMockRepository() { FillData(); }

//        public TodoTaskMockRepository()
//        {
//            if (tasks.Count == 0)
//            {
//                FillData();
//            }
//        }

//        private void FillData() 
//        {
//            if(empty == false)
//            {
//                tasks.AddRange(new List<TodoTask>
//                {
//                new TodoTask
//                {
//                    Id = 1,
//                    Title = "My first task",
//                    Description = "Some description",
//                    Status = StatusesEnum.Active,
//                    CreatedDate = DateTime.Now,
//                    Deadline = DateTime.Now,
//                    Reminder = DateTime.Now,
//                    GroupId = 1,
//                    UserId = 1,
//                    IsImportant = false,
//                    Password = "1",
//                    Email = "1"
//                },
//                new TodoTask
//                {
//                    Id = 2,
//                    Title = "My first task 2",
//                    Description = "Some description 2",
//                    Status = StatusesEnum.Active,
//                    CreatedDate = DateTime.Now,
//                    Deadline = DateTime.Now,
//                    Reminder = DateTime.Now,
//                    GroupId = 2,
//                    UserId = 1,
//                    IsImportant = false,
//                    Password = "2",
//                    Email = "2"
//                }
//                });
//            }
            
           
//        }

//        public List<TodoTask> GetTasks()
//        {
//            return tasks;
//        }
//        //nekad moze da vrati null, zato upitnik
//        public TodoTask? GetTaskById(int id)
//        {
//            return tasks.FirstOrDefault(item => item.Id == id);
//        }

//        public TodoTask CreateTask(TodoTask task)
//        {
//            task.Id = new Random().Next();
//            tasks.Add(task);
//            return GetTaskById(task.Id);
//        }

//        public TodoTask UpdateTask(TodoTask task)
//        {
//            TodoTask t = tasks.FirstOrDefault(t => t.Id == task.Id);//posto je t samo referenca,kad ga izmenimo izmenice se i u tasks
//            t.Id = task.Id;
//            t.Title = task.Title;
//            t.Description = task.Description;
//            t.Status = task.Status;
//            t.CreatedDate = task.CreatedDate;
//            t.Deadline = task.Deadline;
//            t.Reminder = task.Reminder;
//            return t;
//            //task = GetTaskById(task.Id);
//            //tasks.Remove(task);
//            //tasks.Add(task);
//            //return task;
//        }
//        //public TodoTask DeleteTaskById(int id)
//        //{
//        //    TodoTask task = GetTaskById(id);
//        //    if (task != null)
//        //    {
//        //        tasks.Remove(task);
//        //    }
//        //    return task;
//        //}
//        public TodoTask DeleteTaskById(int id)
//        {
//            TodoTask task = GetTaskById(id);
//            if (task != null)
//            {
//                tasks.Remove(task);
//                if (tasks.Count == 0)
//                {
//                    tasks.Clear();
//                    empty = true;
//                }
//            }
//            return task;
//        }

//        //public TodoTask GetUser(string Password, string Email)
//        //{
//        //    foreach (var user in tasks)
//        //    {
//        //        if (user.Password == Password && user.Email == Email)
//        //        {
//        //            return user;
//        //        }
//        //    }
//        //    return null;
//        //}
//    }
//}
