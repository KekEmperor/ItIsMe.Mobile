namespace ItIsMe.Mobile;

public partial class DrawTestPage : ContentPage
{
	public DrawTestPage()
	{
		InitializeComponent();
	}

	private void AddShapeButtonClicked(object sender, EventArgs e)
    {
		var shapeToPlace = new Image
		{
			Source = "triangle.svg"
		};

		ShapesLayout.Children.Add(shapeToPlace);
    }
}