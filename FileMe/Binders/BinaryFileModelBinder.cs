using FileMe.DAL.Classes;
using System.Web;
using System.Web.Mvc;

namespace FileMe.Binders
{
    //в startup: ModelBinders.Binders.Add(typeof(BinaryFileWrapper), new BinaryFileModelBinder());
    public class BinaryFileModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var key = !string.IsNullOrEmpty(bindingContext.ModelName) ? bindingContext.ModelName + ".PostedFile" : "PostedFile";

            var res = bindingContext.ValueProvider.GetValue(key);

            if (res == null)
            {
                return null;
            }

            var postedFile = (HttpPostedFileBase)res.ConvertTo(typeof(HttpPostedFileBase));

            if (postedFile == null || postedFile.InputStream == null)
            {
                return null;
            }

            return new BinaryFileWrapper
            {
                BinaryFile = new BinaryFile
                {
                    Name = postedFile.FileName,
                    ContentType = postedFile.ContentType,
                    Length = postedFile.ContentLength
                },
                PostedFile = postedFile
            };
        }
    }
}