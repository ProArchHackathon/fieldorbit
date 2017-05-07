using System;

namespace ProArch.FieldOrbit.Models
{
    public class Content : ModelBase
    {
        public int ContentId { get; set; }

        public Device Device { get; set; }

        public string ContentType { get; set; }

        public ContentPath Path { get; set; }

        public Employee UploadedBy { get; set; }

        public DateTime? UploadedOn { get; set; }
    }
}
