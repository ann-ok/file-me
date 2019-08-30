using FileMe.DAL.Repositories;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class BinaryFileController: BaseController
    {
        private BinaryFileRepository binaryFileRepository;

        public BinaryFileController(BinaryFileRepository binaryFileRepository)
        {
            this.binaryFileRepository = binaryFileRepository;
        }

        public ActionResult Download(long id)
        {
            var binaryFile = binaryFileRepository.Load(id);

            var stream = GetFileProvider().Load(binaryFile);

            if (stream == null)
            {
                return new EmptyResult();
            }

            return File(stream, binaryFile.ContentType, binaryFile.Name);
        }
    }
}