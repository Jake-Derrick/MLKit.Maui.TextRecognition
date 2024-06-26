namespace MLKit.Maui.TextRecognition;

#if !ANDROID && !IOS
// See the Platforms folder for the device specific implementation of this service.
/// <summary>
/// The plain .Net implementation of <see cref="ITextRecognitionService"/>
/// </summary>
public class TextRecognitionService : ITextRecognitionService
{
    Task<TextRecognitionResult> ITextRecognitionService.GetTextFromImage(FileResult imageFile) => throw new NotImplementedException();

    Task<TextRecognitionResult> ITextRecognitionService.GetTextFromImage(byte[] imageBytes) => throw new NotImplementedException();
}
#endif