using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAssignment.Models
{
    public class IndexModel
    {
        public List<Partition> Partitions { get; set; }
        public List<Employee> Employees { get; set; }
    }
}