namespace ItIsMe.Mobile.RequestModels.AssignStudentTest
{
    public class ItSpecialityTestRequest : ITestRequest
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public string GetString() => "\"{\\\"a\\\":" + A + ", \\\"b\\\":" + B + ", \\\"c\\\":" + C + "}\"";
    }
}
