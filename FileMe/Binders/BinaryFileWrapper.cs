using FileMe.DAL.Classes;
using System.Web;

namespace FileMe.Binders
{
    public class BinaryFileWrapper
    {
        public BinaryFile BinaryFile { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
    }
}