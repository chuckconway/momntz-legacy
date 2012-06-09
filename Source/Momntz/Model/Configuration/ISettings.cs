namespace Momntz.Model.Configuration
{
    public interface ISettings
    {
        string CloudUrl { get; }

        string QueueDatabase { get; }

        int ImageSmallWidth { get; }

        int ImageSmallHeight { get; }

        int ImageMediumWidth { get; }

        int ImageMediumHeight { get; }

        int ImageLargeWidth { get; }

        int ImageLargeHeight { get; }
    }
}
