using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SkiaSharp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new DropForm());
    }
}

public class DropForm : Form
{
    const int MAX_WIDTH = 1200;
    const int WEBP_QUALITY = 80;

    public DropForm()
    {
        Text = "Image Optimizer";
        Width = 420;
        Height = 180;
        AllowDrop = true;

        var label = new Label
        {
            Dock = DockStyle.Fill,
            Text = "Drop images here\nOptimized WebP copies will be created",
            TextAlign = ContentAlignment.MiddleCenter
        };

        Controls.Add(label);

        DragEnter += (s, e) =>
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        };

        DragDrop += (s, e) =>
        {
            var files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;

            foreach (var file in files)
                ProcessImage(file);

            MessageBox.Show("Done!");
        };
    }

    void ProcessImage(string inputPath)
    {
        using var input = File.OpenRead(inputPath);
        using var codec = SKCodec.Create(input);
        using var bitmap = SKBitmap.Decode(codec);

        int width = bitmap.Width;
        int height = bitmap.Height;

        if (width > MAX_WIDTH)
        {
            float scale = (float)MAX_WIDTH / width;
            width = MAX_WIDTH;
            height = (int)(bitmap.Height * scale);
        }

        var info = new SKImageInfo(width, height);

        var sampling = new SKSamplingOptions(
            SKFilterMode.Linear,
            SKMipmapMode.Linear
        );

        using var resized = bitmap.Resize(info, sampling);
        using var image = SKImage.FromBitmap(resized);
        using var data = image.Encode(SKEncodedImageFormat.Webp, WEBP_QUALITY);

        var outputPath = Path.Combine(
            Path.GetDirectoryName(inputPath)!,
            Path.GetFileNameWithoutExtension(inputPath) + ".webp"
        );

        using var output = File.OpenWrite(outputPath);
        data.SaveTo(output);
    }
}
