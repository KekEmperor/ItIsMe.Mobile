using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItIsMe.Mobile.DataModels
{
    public class Group
    {
        public int Number { get; set; }

        public int Year { get; set; }

        public EducationalProgram EducationalProgram { get; set; }
    }
}
