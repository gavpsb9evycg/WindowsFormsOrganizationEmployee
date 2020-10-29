using System;
using System.Runtime.InteropServices;

namespace WindowsFormsOrganizationEmployee.Items
{
    /// <summary>
    /// According to Jeffrey Richter, the FCL (Framework Class Library) type names are used throughout this code
    /// Organization item
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public struct OrganizationItem
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Inn { get; set; }

        public String LegalAddress { get; set; }

        public String PhysicalAddress { get; set; }

        public String Comment { get; set; }
    }
}
