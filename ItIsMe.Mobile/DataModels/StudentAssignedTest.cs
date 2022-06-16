using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItIsMe.Mobile.DataModels
{
    public class StudentAssignedTest
    {
        public string Id { get; set; }

        public Test Test { get; set; }

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }

        public string? TestInterpretation { get; set; }

        public string? ResultJson { get; set; }

        public string? ResultInterpretationJson { get; set; }
    }
}
