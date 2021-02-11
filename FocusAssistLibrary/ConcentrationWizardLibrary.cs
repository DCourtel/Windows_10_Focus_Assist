using System;
using System.Runtime.InteropServices;

namespace FocusAssistLibrary
{
    public class ConcentrationWizardLibrary
    {
        [DllImport("shell32.dll")]
        private static extern int SHQueryUserNotificationState(out QuietHoursState pquns);

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

        public enum QuietHoursState
        {
            FAILED = -1,
            NOT_PRESENT = 1,
            BUSY = 2,
            RUNNING_D3D_FULL_SCREEN = 3,
            PRESENTATION_MODE = 4,
            ACCEPTS_NOTIFICATIONS = 5,
            QUIET_TIME = 6
        };

        public enum ConcentrationWizardName
        {
            Quiet_Hours,
            Focus_Assist
        };

        /// <summary>
        /// Returns the name of the feature used by the current Windows installation. (Quiet Hours or Focus Assist)
        /// </summary>
        /// <returns>Returns Quiet Hours if Windows build is < 17083, otherwise, Focus Assist.</returns>
        public static ConcentrationWizardName GetConcentrationWizardName()
        {
            return (GetWindowsCurrentBuildNumber() >= 17083 ? ConcentrationWizardName.Focus_Assist : ConcentrationWizardName.Quiet_Hours);
        }

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

        /// <summary>
        /// Returns the state of Quiet Hours if availble of this computer. On computers where Focus Assist is available, always returns <see cref="QuietHoursState.ACCEPTS_NOTIFICATIONS"/>.
        /// </summary>
        /// <returns></returns>
        public static QuietHoursState GetQuietHoursState()
        {
            try
            {
                //  Quiet Hours:    Windows 10 build < 17083
                if (SHQueryUserNotificationState(out QuietHoursState state) == 0)
                {
                    return state;
                }
            }
            catch { }

            return QuietHoursState.FAILED;
        }

        /// <summary>
        /// Returns the build number of the current Windows 10 installation.
        /// </summary>
        /// <returns></returns>
        private static int GetWindowsCurrentBuildNumber()
        {
            try
            {
                using (var hklm = Microsoft.Win32.Registry.LocalMachine)
                {
                    var currentVersionKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
                    return int.Parse(currentVersionKey.GetValue("CurrentBuildNumber", "0").ToString());
                }
            }
            catch { }

            return 0;
        }
    }
}
