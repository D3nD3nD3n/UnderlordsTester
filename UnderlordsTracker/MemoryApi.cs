using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnderlordsTracker
{
    static class MemoryApi
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hProcess);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);


        public static byte[] ReadMemoryPtr(Process process, IntPtr pointer, int numOfBytes, out int bytesRead)
        {
            var hProc = OpenProcess(ProcessAccessFlags.All, false, process.Id);

            var buffer = new byte[numOfBytes];

            ReadProcessMemory(hProc, pointer, buffer, numOfBytes, out bytesRead);
            CloseHandle(hProc);
            return buffer;
        }


        public static void WriteMemoryPtrBytes(Process p, IntPtr address, byte[] bytes)
        {
            var hProc = OpenProcess(ProcessAccessFlags.All, false, p.Id);
            
            {
                WriteProcessMemory(hProc, address, bytes, (UInt32)bytes.LongLength, out _);
            }

            CloseHandle(hProc);
        }

        public static IntPtr MemoryAlloc(Process p, IntPtr lpAddress, uint dwsize)
        {
            var hProc = OpenProcess(ProcessAccessFlags.All, false, p.Id);
            IntPtr output = VirtualAllocEx(hProc, lpAddress, dwsize, 0x00002000 | 0x00001000, 0x40);
            CloseHandle(hProc);
            return output;
        }
    }
}
