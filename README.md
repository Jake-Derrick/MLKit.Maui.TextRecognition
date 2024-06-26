# MLKit.Maui.TextRecognition
Provides easier access to Google [ML Kit Text Recognition v2 API](https://developers.google.com/ml-kit/vision/text-recognition/v2) for .NET MAUI.

![TextRecognitionEx](https://github.com/Jake-Derrick/MLKit.Maui.TextRecognition/assets/60721064/b3fcb155-7554-43ba-b49a-b223d7ca71e7)

## How to use it?
1. Install the [NuGet package](https://www.nuget.org/packages/MLKit.Maui.TextRecognition/)
```
Install-Package MLKit.Maui.TextRecognition
```
2. Initialize the Text Recognition Service in `MauiProgram.cs`.
```csharp
var builder = MauiApp.CreateBuilder()
    .UseMauiApp<App>()

builder.Services.AddTextRecognitionService();
```
3. Use the service to get the OCR/Text results from a FileResult or image byte[]
```csharp
private readonly ITextRecognitionService _textRecognitionService;

public TextRecognitionExampleViewModel(ITextRecognitionService textRecognitionService)
{
    _textRecognitionService = textRecognitionService;
}

public async Task GetTextResults(FileResult imageFile)
{
    TextRecognitionResult result = await _textRecognitionService.GetTextFromImage(imageFile);
}

public async Task GetTextResults(byte[] imageBytes)
{
    TextRecognitionResult result = await _textRecognitionService.GetTextFromImage(imageBytes);
}
```
