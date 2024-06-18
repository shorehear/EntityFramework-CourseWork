using kaidy;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace kaidy
{
    public class Periphery
    {
        [Key]
        public Guid DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Condition { get; set; }
        public string Notes { get; set; }

        [ForeignKey("UserType")]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }

    public class FileSystem
    {
        [Key]
        public Guid FileID { get; set; }
        public string FilePath { get; set; }

        [NotMapped]
        public string[] FileData { get; set; }

        [ForeignKey("UserType")]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
