namespace ItIsMe.Mobile.RequestModels.AssignStudentTest
{
    public class DrawAPersonTestRequest : ITestRequest
    {
        public int Square { get; set; }

        public int Triangle { get; set; }

        public int Circle { get; set; }

        public string GetString() => "\"{\\\"square\\\":" + Square + ", \\\"triangle\\\":" + Triangle + ", \\\"circle\\\":" + Circle + "}\"";
    }
}
