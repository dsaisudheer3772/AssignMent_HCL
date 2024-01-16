using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL_AssignMent.Model
{
    public class ApplicationModel
    {
        public int ComputerId { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public string? ComputerType { get; set; }
        public string? Comment { get; set; }
    }
    public class UserCount
    {
        public int UserId { get; set; }
        public int Count { get; set; }
    }
}
