using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaidy
{
    public class UserType
    {
        [Key]
        public Guid UserTypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [ForeignKey("UserType")]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public ICollection<UserTaskManager> UserTaskManagers { get; set; }
        public ICollection<DataSet> DataSets { get; set; }
        public ICollection<UserTypeMapping> UserTypeMappings { get; set; }
    }

    public class UserTypeMapping
    {
        [Key]
        public Guid UserTypeId { get; set; }

        public UserType UserType { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
