using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowingSysPars
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    namespace ConsoleApplication39
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MemoryStatus
        {
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern bool GlobalMemoryStatusEx([In, Out] MemoryStatus lpBuffer);

            public uint dwLength;
            public uint MemoryLoad;
            public ulong TotalPhys;
            public ulong AvailPhys;
            public ulong TotalPageFile;
            public ulong AvailPageFile;
            public ulong TotalVirtual;
            public ulong AvailVirtual;
            public ulong AvailExtendedVirtual;

            private static volatile MemoryStatus singleton;
            private static readonly object syncroot = new object();

            public static MemoryStatus CreateInstance()
            {
                if (singleton == null)
                    lock (syncroot)
                        if (singleton == null)
                            singleton = new MemoryStatus();
                return singleton;
            }

            [SecurityCritical]
            private MemoryStatus()
            {
                dwLength = (uint)Marshal.SizeOf(typeof(MemoryStatus));
                GlobalMemoryStatusEx(this);
            }
        }

        class Program
        {

            static void Main()
            {
                MemoryStatus status = MemoryStatus.CreateInstance();
                ulong ram = status.TotalPhys;
                Console.WriteLine("RAM = {0} MB", ram / 1024 / 1024);
                //Console.ReadKey();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(ram,status.AvailExtendedVirtual,
                    status.AvailPageFile, status.AvailPhys,
                    status.AvailVirtual, status.MemoryLoad ,
                    status.TotalPageFile,status.TotalPhys,
                    status.TotalVirtual,status.dwLength

                ));

            }
        }
    }
   
}
