using Model.Interface;
using Presentation.Utils;
using System.Reflection;

namespace SoftwareDesignExam {
    internal class UpdateManagar : IUpdateManagar {
        private FileSystemWatcher watcher;
        private string? assamblyDirectory;
        private bool restart = false;
        public FileSystemWatcher Watcher { get => watcher; private set => watcher = value; }

        /// <summary>
        /// når vi lager instanse så sjekker vi om det finnes gammle filer og sletter de
        /// </summary>
        public UpdateManagar() {
            string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(@Assembly.GetExecutingAssembly().Location));
            foreach (string s in files) {

                // finn fil navn
                string fileName = System.IO.Path.GetFileName(s);

                if (fileName.Contains("old")) {
                    System.IO.File.Delete(s);
                }
            }
            assamblyDirectory = System.IO.Path.GetDirectoryName(@Assembly.GetExecutingAssembly().Location);
            if (assamblyDirectory != null)
                System.IO.Directory.CreateDirectory(assamblyDirectory);
        }

        public void Start() {

         
            if (assamblyDirectory != null) {
                SetupFileWatcher(assamblyDirectory);
                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                DownLoadUpdates();

                CleanUpFTPFolder();

               
             

            }
        }

        private void CleanUpFTPFolder() {
            string sourcePath = Path.Combine(assamblyDirectory, @"FTP");
            if (sourcePath != null)
                System.IO.Directory.CreateDirectory(sourcePath);


            string[] rmFiles = System.IO.Directory.GetFiles(sourcePath);



            foreach (string file in rmFiles) {
                Writer.PrintLine($"Removing File {file}");
                // Use static Path methods to extract only the file name from the path.
                File.Delete(file);

            }
        }

        /// <summary>
        /// laster ned nye dlls og lager kopier(shadow copy) slik at vi kan skrive over de orginale 
        /// med nye dlls
        /// </summary>
        private void DownLoadUpdates() {
            string sourcePath = Path.Combine(assamblyDirectory, @"FTP");
            if (System.IO.Directory.Exists(sourcePath)) {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                Writer.ClearScreen();
                if (files.Length > 0) {
                    restart = true;
                    Writer.PrintLine("Installing new updates");
                }
                  
                else {
                    Writer.PrintLine("No new updates found");
                    Console.WriteLine("Press a key to go back");
                    Reader.ReadString();
                }
                   
                foreach (string file in files) {
                    Writer.PrintLine($"Downloading file {file}");
                    Thread.Sleep(600);
                    string destFile = CreateFilePathForFileToDownload(file);
                    RenameOldDllFiles(destFile);
                    System.IO.File.Copy(file, destFile, true);
                }
            }
        }

        private string CreateFilePathForFileToDownload(string file) {
            string fileName = System.IO.Path.GetFileName(file);
            string destFile = System.IO.Path.Combine(assamblyDirectory, fileName);
            return destFile;
        }

        private static void RenameOldDllFiles(string destFile) {
            if (File.Exists(destFile)) {
                System.IO.File.Move(destFile, destFile + " old");
            }
        }

        private void SetupFileWatcher(string? dir) {
            Watcher = new FileSystemWatcher(@dir);
            Watcher.NotifyFilter = NotifyFilters.CreationTime
                                      | NotifyFilters.LastWrite
                                      | NotifyFilters.Size
                                      | NotifyFilters.LastAccess
                                      | NotifyFilters.FileName
                                      | NotifyFilters.Attributes;

            Watcher.Filter = "*.dll";
            Watcher.IncludeSubdirectories = true;
            Watcher.EnableRaisingEvents = true;
        }

        public void Close() {
            if (restart) {
                Console.WriteLine("Innstalation done, please restart");
                Console.WriteLine("Press a key to quit game");
                Reader.ReadString();
                Environment.Exit(0);
                Watcher.Dispose();
            }
           

        }
        private static void OnChanged(object sender, FileSystemEventArgs e) {
            if (e.ChangeType != WatcherChangeTypes.Changed) {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
          

        }

        private static void OnCreated(object sender, FileSystemEventArgs e) {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
           

        }

    }
}

