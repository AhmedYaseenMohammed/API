using System.ComponentModel.DataAnnotations.Schema;

namespace APITest
{
    public class UploadFile
    {

        [NotMapped]
        public IFormFile image { get; set; }
    }
}
