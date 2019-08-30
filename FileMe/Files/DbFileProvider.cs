using System.IO;
using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Helpers;

namespace FileMe.Files
{
    [FileProvider]
    public class DbFileProvider : IFileProvider
    {
        private BinaryFileContentRepository binaryFileContentRepository;

        public DbFileProvider(BinaryFileContentRepository binaryFileContentRepository)
        {
            this.binaryFileContentRepository = binaryFileContentRepository;
        }

        public string Name => "Database";

        public Stream Load(BinaryFile file)
        {
            var content = binaryFileContentRepository.GetByBinaryFile(file);

            if (content == null || content.Content == null)
            {
                return null;
            }

            var path = Path.GetTempFileName();
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(file.Name);
            var fullPath = Path.Combine(Path.GetDirectoryName(path), $"{fileName}{extension}");

            using (var stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                stream.Write(content.Content, 0, content.Content.Length);
            }

            return new FileStream(fullPath, FileMode.Open);
        }

        public void Save(BinaryFile file, Stream content)
        {
            var contentF = new BinaryFileContent
            {
                BinaryFile = file,
                Content = content.ToByteArray()
            };

            binaryFileContentRepository.Save(contentF);
        }
    }
}