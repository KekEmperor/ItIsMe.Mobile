using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.RequestModels.AssignStudentTest;

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

        public static bool SendResults()
        {
            ItSpecialityTestAnswers = new ItSpecialityTestRequest { A = 3, B = 5, C = 14 };
            DrawAPersonTestResults = new DrawAPersonTestRequest { Circle = 4, Triangle = 3, Square = 3 };

            var drawPersonTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={DRAW_TEST_ID}");

            var drawPersonSubmitResult = RequestHelper.PostTest(
                    DrawAPersonTestResults, $"assignedStudentTests/{drawPersonTestId.StudentAssignedTestId}");

            var itSpecialityTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={IT_TEST_ID}");

            var itSpecialitySubmitResult = RequestHelper.PostTest(
                    ItSpecialityTestAnswers, $"assignedStudentTests/{itSpecialityTestId.StudentAssignedTestId}");

            return drawPersonSubmitResult == System.Net.HttpStatusCode.OK
                && itSpecialitySubmitResult == System.Net.HttpStatusCode.OK;
        }
    }
}
