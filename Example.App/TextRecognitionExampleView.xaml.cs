namespace Example.App;

public partial class TextRecognitionExampleView : ContentPage
{
    private readonly TextRecognitionExampleViewModel _viewModel;
    public TextRecognitionExampleView(TextRecognitionExampleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private void RadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
            _viewModel.RadioButtonChanged(((RadioButton)sender).ContentAsString());
    }
}
