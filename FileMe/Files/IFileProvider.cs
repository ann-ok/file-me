using FileMe.DAL.Classes;
using System.IO;

namespace FileMe.Files
{
    public interface IFileProvider
    {
        string Name { get; }

        void Save(BinaryFile file, Stream content);

        Stream Load(BinaryFile file);
    }
}
