using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.DataFormats;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Folder2YTD
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Check if command line arguments are provided and are valid
            if (CommandLineArgsProvided(e.Args))
            {
                HandleCommandLine(e.Args);
            }
            else
            {
                // No relevant command line arguments or invalid, start the normal GUI
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private bool CommandLineArgsProvided(string[] args)
        {
            // Check for the presence of both "-Folder" and "-file" arguments (case-insensitive)
            var argsLower = args.Select(arg => arg.ToLower()).ToArray();
            return argsLower.Contains("-folder") && argsLower.Contains("-file");
        }

        private void HandleCommandLine(string[] args)
        {
            string folderPath = null;
            string outputPath = null;

            // Parse command line arguments (case-insensitive)
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("-folder", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    folderPath = args[++i];
                }
                else if (args[i].Equals("-file", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    outputPath = args[++i];
                }
            }

            // Validate paths and process
            if (!string.IsNullOrEmpty(folderPath) && !string.IsNullOrEmpty(outputPath))
            {
                ProcessFiles(folderPath, outputPath);
            }
            else
            {
                Console.WriteLine("Invalid or incomplete arguments.");
                this.Shutdown();
            }
        }

        private void ProcessFiles(string folderPath, string outputPath)
        {
            try
            {
                // Assuming you want to process all DDS files in the given folder
                var ddsFiles = System.IO.Directory.GetFiles(folderPath, "*.dds", System.IO.SearchOption.AllDirectories).ToList();
                if (ddsFiles.Count > 0)
                {
                    YtdHelper.CreateYtdFilesFromFolders(ddsFiles, outputPath);
                    Console.WriteLine("Conversion completed successfully.");
                }
                else
                {
                    Console.WriteLine("No DDS files found in the specified folder.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing files: {ex.Message}");
            }
            finally
            {
                // Ensure the application closes after processing
                this.Shutdown();
            }
        }
    }
}
