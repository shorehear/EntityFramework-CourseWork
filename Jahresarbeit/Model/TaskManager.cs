using kaidy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace kaidy
{
    public class TaskManager
    {
        [Key]
        public Guid TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<UserTaskManager> UserTaskManagers { get; set; }
    }

    public class UserTaskManager
    {
        public Guid UserID { get; set; }
        public User User { get; set; }

        public Guid TaskID { get; set; }
        public TaskManager TaskManager { get; set; }
    }
}
