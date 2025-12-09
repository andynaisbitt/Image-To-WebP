using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SkiaSharp;

namespace ImageOptimizer
{
    public class MainForm : Form
    {
        private const int MAX_WIDTH = 1200;
        private const int WEBP_QUALITY = 85;

        // UI Controls
        private Panel dropPanel;
        private Label dropLabel;
        private Button browseButton;
        private ListView resultsListView;
        private ProgressBar progressBar;
        private Label statsLabel;
        private Button clearButton;

        // Stats tracking
        private int totalProcessed = 0;
        private long totalOriginalSize = 0;
        private long totalOptimizedSize = 0;
        private bool isDragging = false;

        public MainForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Form settings
            Text = "Image to WebP – Lightweight Image Optimiser";
            Width = 900;
            Height = 600;
            MinimumSize = new Size(800, 500);
            StartPosition = FormStartPosition.CenterScreen;
            AllowDrop = true;

            // Main layout
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10)
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F)); // Drop zone
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Progress bar
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Results list
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // Stats

            // Drop zone panel
            dropPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 245),
                AllowDrop = true
            };

            var dropLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            dropLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            dropLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));

            dropLabel = new Label
            {
                Text = "📁 Drag & Drop Images Here\n\nSupported: JPG, PNG, BMP, GIF",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomCenter,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 70, 70)
            };

            browseButton = new Button
            {
                Text = "Browse Files...",
                Dock = DockStyle.Fill,
                Height = 40,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            browseButton.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            browseButton.Click += BrowseButton_Click;

            var buttonPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(200, 10, 200, 10)
            };
            buttonPanel.Controls.Add(browseButton);

            dropLayout.Controls.Add(dropLabel, 0, 0);
            dropLayout.Controls.Add(buttonPanel, 0, 1);
            dropPanel.Controls.Add(dropLayout);

            // Wire up drag & drop events
            dropPanel.DragEnter += DropPanel_DragEnter;
            dropPanel.DragLeave += DropPanel_DragLeave;
            dropPanel.DragDrop += DropPanel_DragDrop;
            dropLabel.DragEnter += DropPanel_DragEnter;
            dropLabel.DragLeave += DropPanel_DragLeave;
            dropLabel.DragDrop += DropPanel_DragDrop;

            // Progress bar
            progressBar = new ProgressBar
            {
                Dock = DockStyle.Fill,
                Style = ProgressBarStyle.Continuous,
                Visible = false
            };

            // Results list
            resultsListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Consolas", 9F)
            };
            resultsListView.Columns.Add("Status", 80);
            resultsListView.Columns.Add("Filename", 250);
            resultsListView.Columns.Add("Original Size", 100);
            resultsListView.Columns.Add("Optimized Size", 100);
            resultsListView.Columns.Add("Saved", 100);
            resultsListView.Columns.Add("Reduction", 80);

            // Stats panel
            var statsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 250, 255)
            };

            statsLabel = new Label
            {
                Text = "Ready to optimize images. Drop files or click Browse.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Padding(10, 0, 0, 0)
            };

            clearButton = new Button
            {
                Text = "Clear Results",
                Width = 120,
                Height = 35,
                Dock = DockStyle.Right,
                Enabled = false,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            clearButton.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            clearButton.Click += ClearButton_Click;

            statsPanel.Controls.Add(statsLabel);
            statsPanel.Controls.Add(clearButton);

            // Add all to main layout
            mainLayout.Controls.Add(dropPanel, 0, 0);
            mainLayout.Controls.Add(progressBar, 0, 1);
            mainLayout.Controls.Add(resultsListView, 0, 2);
            mainLayout.Controls.Add(statsPanel, 0, 3);

            Controls.Add(mainLayout);
        }

        private void DropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                isDragging = true;
                dropPanel.BackColor = Color.FromArgb(220, 230, 255);
                dropLabel.ForeColor = Color.FromArgb(0, 80, 200);
            }
        }

        private void DropPanel_DragLeave(object sender, EventArgs e)
        {
            isDragging = false;
            dropPanel.BackColor = Color.FromArgb(240, 240, 245);
            dropLabel.ForeColor = Color.FromArgb(70, 70, 70);
        }

        private void DropPanel_DragDrop(object sender, DragEventArgs e)
        {
            isDragging = false;
            dropPanel.BackColor = Color.FromArgb(240, 240, 245);
            dropLabel.ForeColor = Color.FromArgb(70, 70, 70);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var imageFiles = files.Where(f => IsImageFile(f)).ToArray();

                if (imageFiles.Length > 0)
                {
                    ProcessImages(imageFiles);
                }
                else
                {
                    MessageBox.Show("No valid image files found. Supported formats: JPG, PNG, BMP, GIF",
                        "No Images", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*",
                Multiselect = true,
                Title = "Select Images to Optimize"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ProcessImages(dialog.FileNames);
            }
        }

        private void ProcessImages(string[] filePaths)
        {
            progressBar.Value = 0;
            progressBar.Maximum = filePaths.Length;
            progressBar.Visible = true;
            browseButton.Enabled = false;
            dropPanel.AllowDrop = false;

            var results = new List<ProcessResult>();

            foreach (var filePath in filePaths)
            {
                var result = ProcessImage(filePath);
                results.Add(result);
                progressBar.Value++;
                Application.DoEvents();
            }

            progressBar.Visible = false;
            browseButton.Enabled = true;
            dropPanel.AllowDrop = true;

            // Update results list
            foreach (var result in results)
            {
                var item = new ListViewItem(result.Success ? "✓ Success" : "✗ Failed");
                item.ForeColor = result.Success ? Color.DarkGreen : Color.DarkRed;
                item.SubItems.Add(Path.GetFileName(result.InputPath));
                item.SubItems.Add(FormatFileSize(result.OriginalSize));
                item.SubItems.Add(result.Success ? FormatFileSize(result.OptimizedSize) : "—");
                item.SubItems.Add(result.Success ? FormatFileSize(result.OriginalSize - result.OptimizedSize) : "—");
                item.SubItems.Add(result.Success ? $"{result.ReductionPercent:F1}%" : result.ErrorMessage);
                resultsListView.Items.Add(item);
            }

            resultsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Update stats
            var successful = results.Where(r => r.Success).ToList();
            totalProcessed += successful.Count;
            totalOriginalSize += successful.Sum(r => r.OriginalSize);
            totalOptimizedSize += successful.Sum(r => r.OptimizedSize);

            UpdateStats();
            clearButton.Enabled = true;

            if (results.Any(r => !r.Success))
            {
                var failedCount = results.Count(r => !r.Success);
                MessageBox.Show($"Processing complete!\n\n" +
                    $"✓ {successful.Count} images optimized\n" +
                    $"✗ {failedCount} images failed\n\n" +
                    $"Check the results list for details.",
                    "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private ProcessResult ProcessImage(string inputPath)
        {
            var result = new ProcessResult { InputPath = inputPath };

            try
            {
                var fileInfo = new FileInfo(inputPath);
                result.OriginalSize = fileInfo.Length;

                using var input = File.OpenRead(inputPath);
                using var codec = SKCodec.Create(input);

                if (codec == null)
                {
                    result.ErrorMessage = "Unsupported format";
                    return result;
                }

                using var bitmap = SKBitmap.Decode(codec);

                if (bitmap == null)
                {
                    result.ErrorMessage = "Failed to decode";
                    return result;
                }

                int width = bitmap.Width;
                int height = bitmap.Height;

                if (width > MAX_WIDTH)
                {
                    float scale = (float)MAX_WIDTH / width;
                    width = MAX_WIDTH;
                    height = (int)(bitmap.Height * scale);
                }

                var info = new SKImageInfo(width, height);
                var sampling = new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.Linear);

                using var resized = bitmap.Resize(info, sampling);
                using var image = SKImage.FromBitmap(resized);
                using var data = image.Encode(SKEncodedImageFormat.Webp, WEBP_QUALITY);

                var outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath)!,
                    Path.GetFileNameWithoutExtension(inputPath) + "_optimized.webp"
                );

                using var output = File.OpenWrite(outputPath);
                data.SaveTo(output);

                result.OptimizedSize = new FileInfo(outputPath).Length;
                result.ReductionPercent = ((result.OriginalSize - result.OptimizedSize) / (double)result.OriginalSize) * 100;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Success = false;
            }

            return result;
        }

        private void UpdateStats()
        {
            if (totalProcessed == 0)
            {
                statsLabel.Text = "Ready to optimize images. Drop files or click Browse.";
                return;
            }

            var savedSize = totalOriginalSize - totalOptimizedSize;
            var reductionPercent = (savedSize / (double)totalOriginalSize) * 100;

            statsLabel.Text = $"📊 Processed: {totalProcessed} images  |  " +
                $"💾 Total Saved: {FormatFileSize(savedSize)} ({reductionPercent:F1}% reduction)  |  " +
                $"Original: {FormatFileSize(totalOriginalSize)} → Optimized: {FormatFileSize(totalOptimizedSize)}";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            resultsListView.Items.Clear();
            totalProcessed = 0;
            totalOriginalSize = 0;
            totalOptimizedSize = 0;
            UpdateStats();
            clearButton.Enabled = false;
        }

        private bool IsImageFile(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes / (1024.0 * 1024.0):F2} MB";
        }

        private class ProcessResult
        {
            public string InputPath { get; set; }
            public long OriginalSize { get; set; }
            public long OptimizedSize { get; set; }
            public double ReductionPercent { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; } = string.Empty;
        }
    }
}
