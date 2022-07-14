﻿using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace LaunchFoundationGameCamera
{
    internal static class DllInjector
    {
        #region kernel32.dll functions

        // Process access

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        // Getting LoadLibrary

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        // Process operations

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern IntPtr CreateRemoteThread(
            IntPtr hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            uint dwCreationFlags,
            out IntPtr lpThreadId
        );

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        #endregion

        // PROCESS_VM_READ
        // PROCESS_VM_WRITE
        // PROCESS_VM_OPERATION
        // PROCESS_CREATE_THREAD
        // PROCESS_QUERY_INFORMATION 
        const int ProcessRights = 0x0002 | 0x0400 | 0x0008 | 0x0020 | 0x0010;

        public static int GetProcessId(string processMainModuleName)
        {
            Logger.LogLine($"Searching processes, looking for {processMainModuleName}");

            foreach (var p in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processMainModuleName)))
            {
                if (p.MainModule == null || p.MainModule.ModuleName == null)
                    continue;

                if (p.MainModule.ModuleName.Equals(processMainModuleName, StringComparison.OrdinalIgnoreCase))
                {
                    Logger.LogLine($"Process {processMainModuleName} found with id {p.Id}");
                    return p.Id;
                }
            }

            return 0;
        }

        public static bool Inject(int processId, string dllPath)
        {
            IntPtr hProcess = OpenProcess(ProcessRights, false, processId);

            if (hProcess == null)
            {
                Logger.LogLine($"Invalid process handle [Error code = {Marshal.GetLastWin32Error()}]");
                return false;
            }

            Logger.LogLine("Successfully opened handle to the target process");

            try
            {
                IntPtr kernelModuleHandle = GetModuleHandle("kernel32.dll");
                IntPtr loadLibraryPointer = GetProcAddress(kernelModuleHandle, "LoadLibraryW");

                Logger.LogLine($"Kernel module found at {kernelModuleHandle}");
                Logger.LogLine($"LoadLibrary function found at {loadLibraryPointer}");

                var pathAsUnicode = Encoding.Unicode.GetBytes(dllPath);
                var pathLength = pathAsUnicode.Length + Marshal.SizeOf(typeof(ushort));

                IntPtr allocatedMemoryForPath = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)pathLength, 0x2000 | 0x1000, 0x4);

                if (allocatedMemoryForPath == null)
                {
                    Logger.LogLine($"Failed to allocate memory [Error code = {Marshal.GetLastWin32Error()}");
                    return false;
                }

                Logger.LogLine("Successfully allocated memory");

                var z = IntPtr.Zero;
                var uz = UIntPtr.Zero;

                if (!WriteProcessMemory(hProcess, allocatedMemoryForPath, pathAsUnicode, (uint)pathAsUnicode.Length, out uz))
                {
                    Logger.LogLine($"Failed to write memory [Error code = {Marshal.GetLastWin32Error()}");
                    return false;
                }

                Logger.LogLine("Successfully written memory");

                IntPtr hThread;
                if ((hThread = CreateRemoteThread(hProcess,
                                                  IntPtr.Zero,
                                                  0,
                                                  loadLibraryPointer,
                                                  allocatedMemoryForPath,
                                                  0,
                                                  out z)) == null)
                {
                    Logger.LogLine($"Failed to start a remote thread [Error code = {Marshal.GetLastWin32Error()}");
                    return false;
                }

                Logger.LogLine("Successfully started a remote thread");

                _ = WaitForSingleObject(hThread, 0xFFFFFFFF);

                Logger.LogLine("FGC loaded successfully");
            }
            finally
            {
                // Reaching this section means that the handle was opened and needs to be closed.
                CloseHandle(hProcess);
            }

            return true;
        }
    }
}
