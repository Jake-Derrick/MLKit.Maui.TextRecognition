using CommunityToolkit.Mvvm.ComponentModel;
using MLKit.Maui.TextRecognition;
using System.ComponentModel;
using System.Windows.Input;

namespace Example.App;

public partial class TextRecognitionExampleViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly ITextRecognitionService _textRecognitionService;
    public ICommand SelectImageCommand { get; protected set; }

    public TextRecognitionExampleViewModel(ITextRecognitionService textRecognitionService)
    {
        _textRecognitionService = textRecognitionService;
        SelectImageCommand = new Command(SelectImageClicked);
    }

    #region Observable Properties
    [ObservableProperty]
    private ImageSource? _imageSource;

    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    private bool _isBlocksSelected;

    [ObservableProperty]
    private bool _isLinesSelected;

    [ObservableProperty]
    private bool _isElementsSelected;

    [ObservableProperty]
    private List<TextRecognitionBlock> _blocks = [];

    [ObservableProperty]
    private List<TextRecognitionLine> _lines = [];

    [ObservableProperty]
    private List<TextRecognitionElement> _elements = [];
    #endregion

    internal void RadioButtonChanged(string selectedValue)
    {
        IsBlocksSelected = selectedValue == "Blocks";
        IsLinesSelected = selectedValue == "Lines";
        IsElementsSelected = selectedValue == "Elements";
    }

    private async void SelectImageClicked()
    {
        ClearPrevious();

        var file = await GetImageFromStorage();
        if (file is null)
            return;

        var result = await _textRecognitionService.GetTextFromImage(file);
        if (result is null || !result.Success)
        {
            ErrorMessage = "Failed to get text result.";
            return;
        }

        Blocks = result.Blocks;
        foreach (var block in Blocks)
        {
            Lines.AddRange(block.Lines);
            foreach (var line in block.Lines)
                Elements.AddRange(line.Elements);
        }
    }

    private async Task<FileResult?> GetImageFromStorage()
    {
        var storageReadPermission = await RequestStorageReadPermission();
        if (storageReadPermission is not PermissionStatus.Granted)
            return null;

        var file = await MediaPicker.PickPhotoAsync();
        if (file is not null)
            ImageSource = ImageSource.FromFile(file?.FullPath);

        return file;
    }

    private async Task<PermissionStatus> RequestStorageReadPermission()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if (status is not PermissionStatus.Granted)
            status = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status is not PermissionStatus.Granted)
            ErrorMessage = "Storage Read permission is required for selecting an image";

        return status;
    }

    private void ClearPrevious()
    {
        ImageSource = "";
        ErrorMessage = "";
        Blocks.Clear();
        Lines.Clear();
        Elements.Clear();
    }
}
