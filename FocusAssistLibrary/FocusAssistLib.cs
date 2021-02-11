using System;
using System.Runtime.InteropServices;

namespace FocusAssistLibrary
{
    public class FocusAssistLib
    {
        [DllImport("NtDll.dll", SetLastError = true)]
        private static extern uint NtQueryWnfStateData(IntPtr pStateName, IntPtr pTypeId, IntPtr pExplicitScope, out uint nChangeStamp, out IntPtr pBuffer, ref uint nBufferSize);

        [StructLayout(LayoutKind.Sequential)]
        private struct WNF_TYPE_ID
        {
            public Guid TypeId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WNF_STATE_NAME
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public uint[] Data;

            public WNF_STATE_NAME(uint Data1, uint Data2) : this()
            {
                uint[] newData = new uint[2];
                newData[0] = Data1;
                newData[1] = Data2;
                Data = newData;
            }
        }

        public enum FocusAssistState
        {
            NOT_SUPPORTED = -2,
            FAILED = -1,
            OFF = 0,
            PRIORITY_ONLY = 1,
            ALARMS_ONLY = 2
        };

        /// <summary>
        /// Returns the state of Focus Assist if available on this computer. Returns <see cref="FocusAssistState.FAILED"/> otherwise.
        /// </summary>
        /// <returns></returns>
        public static FocusAssistState GetFocusAssistState()
        {
            try
            {
                //  Focus Assist:   Windows 10 build >= 17083
                WNF_STATE_NAME WNF_SHEL_QUIETHOURS_ACTIVE_PROFILE_CHANGED = new WNF_STATE_NAME(0xA3BF1C75, 0xD83063E);
                uint nBufferSize = (uint)Marshal.SizeOf(typeof(IntPtr));
                IntPtr pStateName = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WNF_STATE_NAME)));
                Marshal.StructureToPtr(WNF_SHEL_QUIETHOURS_ACTIVE_PROFILE_CHANGED, pStateName, false);
                bool success = NtQueryWnfStateData(pStateName, IntPtr.Zero, IntPtr.Zero, out uint nChangeStamp, out IntPtr pBuffer, ref nBufferSize) == 0;
                Marshal.FreeHGlobal(pStateName);
                if (success)
                {
                    return (FocusAssistState)pBuffer;
                }
            }
            catch { }

            return FocusAssistState.FAILED;
        }
    }
}
