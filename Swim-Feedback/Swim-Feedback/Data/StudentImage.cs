using System.ComponentModel.DataAnnotations;

namespace Swim_Feedback.Data
{
    public class StudentImage
    {
        [Key]
        public long StudentImageId { get; set; }
        public byte[] Data { get; set; }

        public StudentImage(byte[] data)
        {
            Data = data;
        }
    }
}
