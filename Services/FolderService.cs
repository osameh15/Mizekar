using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MizeKar.Models;

namespace MizeKar.Services
{
    public class FolderService
    {
        private readonly string _dataFolderPath;
        private FileSystemWatcher? _fileSystemWatcher;
        private FileSystemWatcher? _categoryWatcher;

        public FolderService()
        {
            _dataFolderPath = App.DataFolderPath;
            EnsureDataFolderExists();
            InitializeFileSystemWatcher();
        }

        public event EventHandler? FoldersChanged;

        private void EnsureDataFolderExists()
        {
            if (!Directory.Exists(_dataFolderPath))
            {
                Directory.CreateDirectory(_dataFolderPath);
            }
        }

        private void InitializeFileSystemWatcher()
        {
            _fileSystemWatcher = new FileSystemWatcher(_dataFolderPath)
            {
                NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.LastWrite,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true
            };

            _fileSystemWatcher.Created += OnFolderChanged;
            _fileSystemWatcher.Deleted += OnFolderChanged;
            _fileSystemWatcher.Renamed += OnFolderChanged;
        }

        private void OnFolderChanged(object sender, FileSystemEventArgs e)
        {
            FoldersChanged?.Invoke(this, EventArgs.Empty);
        }

        public List<FolderInfo> GetFolders()
        {
            try
            {
                if (!Directory.Exists(_dataFolderPath))
                    return new List<FolderInfo>();

                var directories = Directory.GetDirectories(_dataFolderPath);
                // Sort by predefined category order from App.Categories
                return directories
                    .OrderBy(dir =>
                    {
                        var name = Path.GetFileName(dir);
                        var index = Array.IndexOf(App.Categories, name);
                        return index >= 0 ? index : int.MaxValue;
                    })
                    .Select(dir => new FolderInfo(
                        Path.GetFileName(dir),
                        dir
                    )).ToList();
            }
            catch (Exception ex)
            {
                // Log error and return empty list
                System.Diagnostics.Debug.WriteLine($"Error reading folders: {ex.Message}");
                return new List<FolderInfo>();
            }
        }

        public List<FolderInfo> GetFoldersFromCategory(string categoryPath)
        {
            try
            {
                if (!Directory.Exists(categoryPath))
                    return new List<FolderInfo>();

                var directories = Directory.GetDirectories(categoryPath);
                // Sort by creation time (oldest first)
                return directories
                    .OrderBy(dir => Directory.GetCreationTime(dir))
                    .Select(dir => new FolderInfo(
                        Path.GetFileName(dir),
                        dir
                    )).ToList();
            }
            catch (Exception ex)
            {
                // Log error and return empty list
                System.Diagnostics.Debug.WriteLine($"Error reading category folders: {ex.Message}");
                return new List<FolderInfo>();
            }
        }

        public bool CreateFolder(string folderName, string? parentPath = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(folderName))
                    return false;

                // Sanitize folder name
                var invalidChars = Path.GetInvalidFileNameChars();
                var sanitizedName = new string(folderName.Where(c => !invalidChars.Contains(c)).ToArray());
                
                if (string.IsNullOrWhiteSpace(sanitizedName))
                    return false;

                var basePath = parentPath ?? _dataFolderPath;
                var folderPath = Path.Combine(basePath, sanitizedName);
                
                if (Directory.Exists(folderPath))
                    return false;

                Directory.CreateDirectory(folderPath);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating folder: {ex.Message}");
                return false;
            }
        }

        public bool DeleteFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    return false;

                Directory.Delete(folderPath, true);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting folder: {ex.Message}");
                return false;
            }
        }

        public void OpenFolderInExplorer(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", $"\"{folderPath}\"");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error opening folder: {ex.Message}");
            }
        }

        public void StartCategoryWatching(string categoryPath)
        {
            StopCategoryWatching();
            
            if (Directory.Exists(categoryPath))
            {
                _categoryWatcher = new FileSystemWatcher(categoryPath)
                {
                    NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.LastWrite,
                    IncludeSubdirectories = false,
                    EnableRaisingEvents = true
                };

                _categoryWatcher.Created += OnFolderChanged;
                _categoryWatcher.Deleted += OnFolderChanged;
                _categoryWatcher.Renamed += OnFolderChanged;
            }
        }

        public void StopCategoryWatching()
        {
            _categoryWatcher?.Dispose();
            _categoryWatcher = null;
        }

        public void Dispose()
        {
            _fileSystemWatcher?.Dispose();
            _categoryWatcher?.Dispose();
        }
    }
}