//using P1TaskFlow.Models;
//using System.Threading.Tasks;

//namespace P1TaskFlow.DataAcess.Tasks
//{
//    public class TodoTaskGroupMockRespository
//    {
//        private static List<TodoTaskGropup> groupTasks = new();
//        private static bool empty = false;

//        public TodoTaskGroupMockRespository()
//        {
//            if (groupTasks.Count == 0)
//            {
//                FillData();
//            }
//        }

//        private void FillData()
//        {
//            if (empty == false)
//            {
//                groupTasks.AddRange(new List<TodoTaskGropup>
//                {
//                new TodoTaskGropup
//                {
//                    Id = 1,
//                    Name = "My first task",
//                    Description = "Some description",
//                    Status = StatusesEnum.Active
//                },
//                new TodoTaskGropup
//                {
//                    Id = 2,
//                    Name = "My first task 2",
//                    Description = "Some description 2",
//                    Status = StatusesEnum.Active
//                }
//                });
//            }
//        }

//        public List<TodoTaskGropup> GetTasks()
//        {
//            return groupTasks;
//        }
//        //nekad moze da vrati null, zato upitnik
//        public TodoTaskGropup? GetTaskById(int id)
//        {
//            return groupTasks.FirstOrDefault(item => item.Id == id);
//        }

//        public TodoTaskGropup CreateTask(TodoTaskGropup task)
//        {
//            task.Id = new Random().Next();
//            groupTasks.Add(task);
//            return GetTaskById(task.Id);
//        }

//        public TodoTaskGropup UpdateTask(TodoTaskGropup task)
//        {
//            TodoTaskGropup t = groupTasks.FirstOrDefault(t => t.Id == task.Id);//posto je t samo referenca,kad ga izmenimo izmenice se i u tasks
//            t.Id = task.Id;
//            t.Name = task.Name;
//            t.Description = task.Description;
//            t.Status = task.Status;
//            return t;
//            //task = GetTaskById(task.Id);
//            //tasks.Remove(task);
//            //tasks.Add(task);
//            //return task;
//        }
//        public TodoTaskGropup DeleteTaskById(int id)
//        {
//            TodoTaskGropup task = GetTaskById(id);
//            if (task != null)
//            {
//                groupTasks.Remove(task);
//                if (groupTasks.Count == 0)
//                {
//                    groupTasks.Clear();
//                    empty = true;
//                }
//            }
//            return task;
//        }

//    }
//}
