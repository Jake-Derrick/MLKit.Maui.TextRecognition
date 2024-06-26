using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MLKit.Maui.TextRecognition;

namespace Example.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterViewModelsAndViews();

        builder.Services.AddTextRecognitionService();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterViewModelsAndViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<TextRecognitionExampleViewModel>();
        builder.Services.AddSingleton<TextRecognitionExampleView>();

        return builder;
    }
}
