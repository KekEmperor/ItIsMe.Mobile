using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.RequestModels.AssignStudentTest;
using System.Net;

namespace ItIsMe.Mobile.Helpers
{
    public static class DefaultTestsHelper
    {
        public const string IT_TEST_ID = "C293B957-FC1E-481C-A8BC-B780E21A2F64";
        public const string DRAW_TEST_ID = "B1A11CE1-22AE-4057-846C-D6241279E052";
        public const string MOOD_TEST_ID = "3FA85F64-5717-4562-B3FC-2C963F66AFA6";

        public static bool IsMoodGotten { get; set; }
        public static bool IsMoodAllowed { get; set; }

        public static ItSpecialityTestRequest ItSpecialityTestAnswers { get; set; }

        public static DrawAPersonTestRequest DrawAPersonTestResults { get; set; }

        public static bool AreTestsCompleted =>
            DrawAPersonTestResults != null && ItSpecialityTestAnswers != null;

        public static bool SendResults()
        {
            var drawPersonTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={DRAW_TEST_ID}");

            var drawPersonSubmitResult = RequestHelper.PostTest(
                    DrawAPersonTestResults, $"assignedStudentTests/{drawPersonTestId.StudentAssignedTestId}");

            var itSpecialityTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={IT_TEST_ID}");

            var itSpecialitySubmitResult = RequestHelper.PostTest(
                    ItSpecialityTestAnswers, $"assignedStudentTests/{itSpecialityTestId.StudentAssignedTestId}");

            if (drawPersonSubmitResult == HttpStatusCode.OK
                && itSpecialitySubmitResult == HttpStatusCode.OK)
            {
                IsMoodAllowed = false;
                IsMoodGotten = false;
                ItSpecialityTestAnswers = null;
                DrawAPersonTestResults = null;
            }

            return drawPersonSubmitResult == HttpStatusCode.OK
                && itSpecialitySubmitResult == HttpStatusCode.OK;
        }

        public static async Task<HttpStatusCode> SendImage(FileResult fileResult)
        {
            var moodTestId = RequestHelper.Post<AssignStudentTestResponse>(
                $"assignedStudentTests?studentId={Preferences.Get("StudentId", "")}&testId={MOOD_TEST_ID}");

            var response =
                await RequestHelper.PostImage(fileResult, moodTestId.StudentAssignedTestId.ToString());

            return response;
        }
    }
}
