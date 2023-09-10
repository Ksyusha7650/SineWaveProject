using System.Drawing;

namespace SineWaveProject;

public class ImageMaker
{
    private const int Height = 200;

    public static Image GenerateSignalImage(double[] signal)
    {
        var width = signal.Length;
        var image = new Bitmap(width, Height);
        var graphics = Graphics.FromImage(image);
        graphics.Clear(Color.White);

        var pen = new Pen(Color.Black);
        for (var i = 1; i < width; i += 2)
            graphics.DrawLine(
                pen,
                new Point(i - 1,
                    GetYCoord(signal[i - 1])),
                new Point(i,
                    GetYCoord(signal[i])));
        return image;
    }

    private static int GetYCoord(double value)
    {
        return (int)(Height / 2 * value + Height / 2);
    }
}