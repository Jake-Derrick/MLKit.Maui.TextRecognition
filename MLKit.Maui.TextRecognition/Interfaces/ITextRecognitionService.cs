namespace MLKit.Maui.TextRecognition;

/// <summary>
/// Interface for Google ML Kit Text Recognition Services
/// </summary>
public interface ITextRecognitionService
{
    /// <summary>
    /// Extracts text from an image file using text recognition.
    /// </summary>
    Task<TextRecognitionResult> GetTextFromImage(FileResult imageFile);

    /// <summary>
    /// Extracts text from image bytes using text recognition.
    /// </summary>
    Task<TextRecognitionResult> GetTextFromImage(byte[] imageBytes);
}