using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.Mobile
{
    internal static class Globals
    {
        static Globals()
        {
            CurrentWorkman = new Employee() { EmployeeId = 1002 };
        }

        public static Job CurrentJob { get; set; }

        public static Employee CurrentWorkman { get; set; }

        public static Customer CurrentCustomer { get; set; }
    }
}
