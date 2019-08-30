﻿using FileMe.DAL.Classes;
using System;
using System.Configuration;
using System.IO;

namespace FileMe.Files
{
    [FileProvider]
    public class LocalFileProvider : IFileProvider
    {
        public string Name => "Local";

        public Stream Load(BinaryFile file)
        {
            var root = GetRootPath();
            var fileName = GetFileName(file);
            var path = Path.Combine(root, fileName);

            if (!File.Exists(path))
            {
                return null;
            }

            var stream = new FileStream(path, FileMode.Open);

            return stream;
        }

        public void Save(BinaryFile file, Stream content)
        {
            var root = GetRootPath();
            var fileName = GetFileName(file);

            using (var stream = new FileStream(Path.Combine(root, fileName), FileMode.CreateNew))
            {
                content.CopyTo(stream);
            }
        }

        private string GetRootPath()
        {
            var rootKey = ConfigurationManager.AppSettings["FileProvider.LocalPath"]; //не забываем добавить

            if (string.IsNullOrWhiteSpace(rootKey) || !Directory.Exists(rootKey))
            {
                throw new Exception("Не задана локальная папка хранения для файлов");
            }

            return rootKey;
        }

        private string GetFileName(BinaryFile file)
        {
            var ext = Path.GetExtension(file.Name);
            return $"{file.Id}{ext}";
        }
    }
}