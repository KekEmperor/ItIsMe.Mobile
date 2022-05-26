namespace ItIsMe.Mobile.DataModels
{
    public class DrawTestResult
    {
        public int CirclesCounter { get; set; }

        public int SquaresCounter { get; set; }

        public int TrianglesCounter { get; set; }

        public bool CanAddShape() => CirclesCounter + SquaresCounter + TrianglesCounter < 10;

        public int GetShapesLeft() => 10 - (CirclesCounter + SquaresCounter + TrianglesCounter);
    }
}
