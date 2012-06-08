namespace Momntz.Model.Configuration
{
    public interface ISettings
    {
        string QueueDatabase { get; }

        int ImageSmallWidth { get; }

        int ImageSmallHeight { get; }

        int ImageMediumWidth { get; }

        int ImageMediumHeight { get; }

        int ImageLargeWidth { get; }

        int ImageLargeHeight { get; }
    }
}
