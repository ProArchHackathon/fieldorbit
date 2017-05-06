namespace ProArch.FieldOrbit.Models
{
    public class DeviceExpert : ModelBase
    {
        public int DeviceExpertId { get; set; }
        public Employee Employee { get; set; }
        public Device Device { get; set; }
    }
}
