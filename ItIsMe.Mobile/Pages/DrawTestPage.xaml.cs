using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public partial class DrawTestPage : ContentPage
{
	private DrawTestResult result;

	public DrawTestPage()
	{
		InitializeComponent();

		result = new DrawTestResult();

		ShapePicker.SelectedIndex = 0;
	}

	private void AddShapeButtonClicked(object sender, EventArgs e)
    {
		if (result.CanAddShape())
        {
			var shapeToPlace = new Image
			{
				WidthRequest = 100,
				HeightRequest = 100
			};

			switch (ShapePicker.SelectedIndex)
			{
				case 0:
					shapeToPlace.Source = "circle.svg";
					result.CirclesCounter++;
					break;
				case 1:
					shapeToPlace.Source = "square.svg";
					result.SquaresCounter++;
					break;
				case 2:
					shapeToPlace.Source = "triangle.svg";
					result.TrianglesCounter++;
					break;
			}

			var panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += PanUpdated;
			shapeToPlace.GestureRecognizers.Add(panGesture);

			var pinchGesture = new PinchGestureRecognizer();
			pinchGesture.PinchUpdated += PinchUpdated;
			shapeToPlace.GestureRecognizers.Add(pinchGesture);

			ShapesLayout.Children.Add(shapeToPlace);

			ShapesLeftLabel.Text = $"Possible shapes left: {result.GetShapesLeft()}";
		}
    }

	private void PanUpdated(object sender, PanUpdatedEventArgs e)
	{
		var image = (Image)sender;

		image.TranslationX += e.TotalX;
		image.TranslationY += e.TotalY;
	}

	private void PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
		var image = (Image)sender;

		image.Scale *= e.Scale;
    }
}