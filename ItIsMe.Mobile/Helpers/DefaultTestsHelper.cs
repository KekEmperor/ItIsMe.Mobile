using ItIsMe.Mobile.RequestModels.AssignStudentTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItIsMe.Mobile.Helpers
{
    public static class DefaultTestsHelper
    {
        public const string IT_TEST_ID = "C293B957-FC1E-481C-A8BC-B780E21A2F64";
        public const string DRAW_TEST_ID = "B1A11CE1-22AE-4057-846C-D6241279E052";

        public static ItSpecialityTestRequest ItSpecialityTestAnswers { get; set; }

        public static DrawAPersonTestRequest DrawAPersonTestResults { get; set; }

        public static bool AreTestsCompleted =>
            DrawAPersonTestResults != null && ItSpecialityTestAnswers != null;

        public static void SendResults()
        {
            ItSpecialityTestAnswers = new ItSpecialityTestRequest { A = 10, B = 12, C = 0 };
            DrawAPersonTestResults = new DrawAPersonTestRequest { Circle = 8, Square = 0, Triangle = 2 };

            if (!AreTestsCompleted)
            {
                return;
            }

            var drawPersonTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={DRAW_TEST_ID}");

            var drawPersonSubmitResult = RequestHelper.PostTest(
                    DrawAPersonTestResults, $"assignedStudentTests/{drawPersonTestId.StudentAssignedTestId}");

            var itSpecialityTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={IT_TEST_ID}");

            var itSpecialitySubmitResult = RequestHelper.PostTest(
                    ItSpecialityTestAnswers, $"assignedStudentTests/{itSpecialityTestId.StudentAssignedTestId}");
        }
    }
}
