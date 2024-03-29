﻿using Model.Interface;
using Presentation.Utils;
using System.Reflection;

namespace SoftwareDesignExam {
    internal class UpdateManagar : IUpdateManagar {
        private FileSystemWatcher _watcher;
        private string? _assamblyDirectory;
        private bool _restart = false;
        public FileSystemWatcher Watcher { get => _watcher; private set => _watcher = value; }

        /// <summary>
        /// når vi lager instanse så sjekker vi om det finnes gammle filer og sletter de
        /// </summary>
        public UpdateManagar() {
            _watcher = new();
            string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(@Assembly.GetExecutingAssembly().Location));
            foreach (string s in files) {

                // finn fil navn
                string fileName = System.IO.Path.GetFileName(s);

                if (fileName.Contains("old")) {
                    System.IO.File.Delete(s);
                }
            }
            _assamblyDirectory = System.IO.Path.GetDirectoryName(@Assembly.GetExecutingAssembly().Location);
            if (_assamblyDirectory != null)
                System.IO.Directory.CreateDirectory(_assamblyDirectory);

        }

        public void Start() {

         
            if (_assamblyDirectory != null) {
                SetupFileWatcher(_assamblyDirectory);
                _watcher.Changed += OnChanged;
                _watcher.Created += OnCreated;
                DownLoadUpdates();

                CleanUpFTPFolder();

               
             

            }
        }

        private void CleanUpFTPFolder() {
            if (_assamblyDirectory != null) {
                string sourcePath = Path.Combine(_assamblyDirectory, @"FTP");
                if (sourcePath != null) {
                    System.IO.Directory.CreateDirectory(sourcePath);
                    string[] rmFiles = System.IO.Directory.GetFiles(sourcePath);
                    foreach (string file in rmFiles) {
                        Writer.PrintLine($"Removing File {file}");
                        // Use static Path methods to extract only the file name from the path.
                        File.Delete(file);

                    }
                }
                   
            }
           



           
        }

        /// <summary>
        /// laster ned nye dlls og lager kopier(shadow copy) slik at vi kan skrive over de orginale 
        /// med nye dlls
        /// </summary>
        private void DownLoadUpdates() {
            string sourcePath = Path.Combine(_assamblyDirectory, @"FTP");
            if (System.IO.Directory.Exists(sourcePath)) {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                Writer.ClearScreen();
                if (files.Length > 0) {
                    _restart = true;
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
            string destFile = System.IO.Path.Combine(_assamblyDirectory, fileName);
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
            if (_restart) {
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

