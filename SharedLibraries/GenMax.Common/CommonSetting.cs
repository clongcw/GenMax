using System;
using System.IO;
using System.Text;

namespace GenMax.Common
{
    public class CommonSetting
    {
        #region 声明实例
        public static bool IsExistScanner { get; set; } = true;
        public static bool IsCheckDoorLocked { get; set; } = false;//门状态检测
        public static bool IsHeartbeatEnable { get; set; } = false;//心跳包
        public static bool IsAlarmEnable { get; set; } = false;//报警灯
        public static bool IsScanBarcode { get; set; } = true;
        public static bool IsResetOutside { get; set; } = true;
        public static bool IsExtraPrickAllFilm { get; set; } = true;//提取戳膜

        public static double SealingTemperature { get; set; } = 180d;//热封默认温度
        public static bool IsTransferAllTempOneTime { get; set; } = false;

        public static double ReagentScannerXShiftSize { get; set; } = 17;//试剂条码X轴偏移量
        public static double ReagentScannerYShiftSize { get; set; } = 12.4;//试剂条码Y轴偏移量

        public static int LeftChipCount { get; set; } = 0;

        public static int TipBox0Count { get; set; } = 96;
        public static int TipBox1Count { get; set; } = 96;

        public static int PreTime { get; set; }

        public static string PcrTemplateFilePath { get; set; }
        public static bool IsExistCapY { get; set; } = true;
        public static int ResetStepZ { get; set; }

        public static int LoadCoverZShiftSize { get; set; } = 0;//加载磁套Z轴偏移量
        public static int EjectCoverZShiftSize { get; set; } = 0;//打掉磁套Z轴偏移量
        public static int EjectCoverTShiftSize { get; set; } = 0;//打掉磁套T轴偏移量
        public static int MixZ { get; set; } = 0;//混匀Z轴偏移量

        public static string PcrExperimentPath = string.Empty;
        public static string PcrImageDir { get; set; }
        #endregion
        #region 构造函数
        //public CommonSetting()
        //{
        //    LoadParameters();
        //}
        #endregion

        #region 方法
        public static void LoadParameters()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Setting.ini";
            string section = "System";
            StringBuilder strVal = new StringBuilder(255);
            Common.GetPrivateProfileString(section, nameof(IsExistScanner), "true", strVal, 255, filePath);
            IsExistScanner = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsCheckDoorLocked), "false", strVal, 255, filePath);
            IsCheckDoorLocked = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsHeartbeatEnable), "false", strVal, 255, filePath);
            IsHeartbeatEnable = Convert.ToBoolean(strVal.ToString());

            Common.GetPrivateProfileString(section, nameof(IsAlarmEnable), "false", strVal, 255, filePath);
            IsAlarmEnable = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsScanBarcode), "true", strVal, 255, filePath);
            IsScanBarcode = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsTransferAllTempOneTime), "false", strVal, 255, filePath);
            IsTransferAllTempOneTime = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(LeftChipCount), "0", strVal, 255, filePath);
            LeftChipCount = Convert.ToInt32(strVal.ToString());
            DeviceConstant.VirtualChipCount = LeftChipCount;
            Common.GetPrivateProfileString(section, nameof(TipBox0Count), "0", strVal, 255, filePath);
            TipBox0Count = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(TipBox1Count), "0", strVal, 255, filePath);
            TipBox1Count = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(DeviceConstant.PcrIntervalX), "135", strVal, 255, filePath);
            DeviceConstant.PcrIntervalX = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(DeviceConstant.PcrIntervalY), "5900", strVal, 255, filePath);
            DeviceConstant.PcrIntervalY = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(DeviceConstant.TubeIntervalX), "1433", strVal, 255, filePath);
            DeviceConstant.TubeIntervalX = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(DeviceConstant.StripInterval), "1030", strVal, 255, filePath);
            DeviceConstant.StripInterval = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(PreTime), "300", strVal, 255, filePath);
            PreTime = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsExistCapY), "true", strVal, 255, filePath);
            IsExistCapY = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(IsResetOutside), "true", strVal, 255, filePath);
            IsResetOutside = Convert.ToBoolean(strVal.ToString());
            Common.GetPrivateProfileString(section, "ResetStepE", "100", strVal, 255, filePath);
            var resetStepE = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, "ResetStepZ", "2300", strVal, 255, filePath);
            var resetStepZ = Convert.ToInt32(strVal.ToString());

            Common.GetPrivateProfileString(section, nameof(SealingTemperature), "180", strVal, 255, filePath);
            SealingTemperature = Convert.ToDouble(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(ReagentScannerXShiftSize), "100", strVal, 255, filePath);
            ReagentScannerXShiftSize = Convert.ToDouble(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(ReagentScannerYShiftSize), "100", strVal, 255, filePath);
            ReagentScannerYShiftSize = Convert.ToDouble(strVal.ToString());

            Common.GetPrivateProfileString(section, nameof(IsExtraPrickAllFilm), "false", strVal, 255, filePath);
            IsExtraPrickAllFilm = Convert.ToBoolean(strVal.ToString());


            Common.GetPrivateProfileString(section, nameof(LoadCoverZShiftSize), "0", strVal, 255, filePath);
            LoadCoverZShiftSize = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(EjectCoverZShiftSize), "0", strVal, 255, filePath);
            EjectCoverZShiftSize = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(EjectCoverTShiftSize), "0", strVal, 255, filePath);
            EjectCoverTShiftSize = Convert.ToInt32(strVal.ToString());
            Common.GetPrivateProfileString(section, nameof(MixZ), "0", strVal, 255, filePath);
            MixZ = Convert.ToInt32(strVal.ToString());

            Common.GetPrivateProfileString(section, nameof(PcrExperimentPath), "true", strVal, 255, filePath);
            PcrExperimentPath = Convert.ToString(strVal.ToString());

            Common.GetPrivateProfileString(section, nameof(PcrImageDir), @"C:\ProgramData\Virtue\PCRImage", strVal, 255, filePath);
            PcrImageDir = strVal.ToString();

            Common.GetPrivateProfileString(section, nameof(PcrTemplateFilePath), "", strVal, 255, filePath);
            var tmpPath = strVal.ToString();
            var defPath = $"{AppDomain.CurrentDomain.BaseDirectory}PcrTemplateFiles\\";
            if (!string.IsNullOrEmpty(tmpPath))
            {
                if (Directory.Exists(tmpPath))
                {
                    PcrTemplateFilePath = tmpPath;
                }
                else
                {
                    Directory.CreateDirectory(defPath);
                    PcrTemplateFilePath = defPath;

                }
            }
            else
            {
                Directory.CreateDirectory(defPath);
                PcrTemplateFilePath = defPath;
            }
        }

        #endregion


    }
}

