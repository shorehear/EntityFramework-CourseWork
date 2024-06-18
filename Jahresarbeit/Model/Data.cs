using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace kaidy
{
    public class DataAnalysis
    {
        [Key]
        public Guid DataAnalysisID { get; set; }
        public string AnalysisType { get; set; }
        public string Data { get; set; }

        [ForeignKey("UserType")]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }

    public class DataSet
    {
        [Key]
        public Guid DataID { get; set; }

        [NotMapped]
        public string[] Data { get; set; }
        public string Summary { get; set; }

        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}