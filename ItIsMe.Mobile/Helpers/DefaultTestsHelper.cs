using ItIsMe.Mobile.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItIsMe.Mobile.Helpers
{
    public static class DefaultTestsHelper
    {
        public static ItSpecialityTestAnswers ItSpecialityTestAnswers { get; set; }

        public static DrawAPersonTestResults DrawAPersonTestResults { get; set; }

        public static bool AreTestsCompleted => 
            DrawAPersonTestResults != null && ItSpecialityTestAnswers != null;
    }
}
