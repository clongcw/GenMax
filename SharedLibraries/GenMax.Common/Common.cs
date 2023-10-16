﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace GenMax.Common
{
    /// <summary>
    /// CanOpen通用预定义，PDO（传输数据对象），SDO（服务数据对象）
    /// </summary>
    public static class Common
    {
        public const UInt16 TX_PDO1 = 0x200;
        public const UInt16 RX_PDO1 = 0x180;
        public const UInt16 TX_PDO2 = 0x300;
        public const UInt16 RX_PDO2 = 0x280;
        public const UInt16 TX_SDO1 = 0x600;
        public const UInt16 RX_SDO1 = 0x580;

        public const UInt16 MIN_DEVICE_ID = 0x20; //自开发设备最小设备地址
        public const UInt16 MAX_DEVICE_ID = 0x2f; //自开发设备最大设备地址
        public const int SIMPLE_CMD_TIME_OUT = 10000; //简单命令执行超时时间
        public const int ELAPSED_TIME_OUT = 20000; //耗时命令执行超时时间
        public const int ELAPSED_RESET_TIME_OUT = 30000; //耗时命令执行超时时间

        public const int CODE_DEFAULT = 0;
        public const int CODE_X = 100000; //X轴代码
        public const int CODE_Y = 200000;//Y轴代码
        public const int CODE_Z = 300000;//Z轴代码
        public const int CODE_T = 400000;//T轴
        public const int CODE_E = 500000;//E轴电磁铁
        public const int CODE_ADP = 600000;//ADP代码
        public const int CODE_Temp = 700000;//温控代码

        public const int CODE_CHANNEL = 1000000;
        public const int CODE_DOOR = 2000000;
        public const int CODE_LED = 3000000;
        public const int CODE_UV = 4000000;
        public const int CODE_FAN = 5000000;
        public const int CODE_ALARM = 6000000;
        public const int CODE_FAN2 = 7000000;
        public const int CODE_MODULE_CH = 10000000;
        public const int CODE_LH = 20000000;
        public const int CODE_HANDLE_Z = 30000000;
        public const int CODE_HANDLE_X = 40000000;
        public const int CODE_MODULE_PCR = 50000000;
        public const int FLAG_SCANNER = 60000000;
        public const int CODE_AUX = 70000000;
        public const byte CMD_CHIP = 0x17;


        public const byte CMD_CONNECT = 0x00;
        public const byte CMD_VERSION = 0x02;//查询版本

        public const byte SIGN_OC_ON = 0x01;//光耦挡住
        public const byte SIGN_OC_OFF = 0x00; //光耦未挡住

        //public const byte DefaultDetectSpeed = 32;
        //public const byte DeepDetectSpeed = 90;

        public const byte FRAME_START = 0x91; //起始帧
        public const byte FRAME_MID = 0x92; //中间帧
        public const byte FRAME_END = 0x93; //结束帧
        public const int GROUP_HS = 800;
        public const int GROUP_HS_X = 900;
        /// <summary>
        /// 通过功能码和设备ID生成帧ID（4位功能码+7位设备ID）
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="deviceId">设备ID</param>
        /// <returns>帧ID</returns>
        public static UInt32 GeneralFrameID(UInt16 functionCode, UInt16 deviceId)
        {
            return (UInt32)(functionCode + deviceId);
        }

        /// <summary>
        /// 从帧ID中解析出设备ID（帧ID的后7位为设备ID）
        /// </summary>
        /// <param name="frameId"></param>
        /// <returns>设备ID</returns>
        public static UInt16 ParseDeviceId(UInt32 frameId)
        {
            return (UInt16)(frameId & 0x7F);
        }

        /// <summary>
        /// 根据序号计算行列数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countPerCol"></param>
        /// <param name="countPerRack"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int GetPosById(int id, int countPerCol, int countPerRack, ref int row, ref int col)
        {
            int res = -1;
            if ((id >= 0) && (id < countPerRack))
            {
                col = id / countPerCol;
                row = id % countPerCol;
                res = (int)Math.Ceiling((id + 0.5) / countPerRack) - 1;
            }
            else
            {
                row = 0;
                col = 0;
            }
            return res;
        }

        public static int GetTipPos(int id, ref int row, ref int col)
        {
            return GetPosById(id, 8, 96, ref row, ref col);
        }

        private static string _sepator = "-";
        public static string EncodeLocaName(string name, int index)
        {
            return string.Format("{0}{1}{2}", name, _sepator, index);
        }

        public static string EncodeLocaName(string name, string pos)
        {
            return string.Format("{0}{1}{2}", name, _sepator, pos);
        }

        public static bool DecodeLocaName(string name, out string deName, out int index)
        {
            deName = string.Empty;
            index = 0;
            var names = name.Split(new[] { _sepator }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 2)
            {
                deName = names[0];
                return int.TryParse(names[1], out index);
            }
            return false;
        }

        public static int GenerateAdpGroupId(Channels ch)
        {
            return GenerateGroupId((int)ch);
        }

        public static int GenerateAdpGroupId(Channels ch, Tips tip)
        {
            var t = ((int)ch).ToString();
            var t2 = ((int)tip).ToString();
            var t3 = ((int)Module.Adp).ToString();
            return Convert.ToInt16(((int)ch).ToString() + ((int)tip).ToString() + ((int)Module.Adp).ToString());
        }

        public static int GeneratePcrGroupId(Channels ch)
        {
            return 20 + (int)ch;
        }

        public static int GenerateGroupId(int ch, bool isAdp = true)
        {
            if (isAdp)
            {
                return 10 + ch;
            }
            else
            {
                return ch;
            }
        }

        public static int GenerateScannerGroupId(int ch)
        {
            return 30 + ch;
        }

        public static int GenerateReagentScannerGroupId(int ch)
        {
            return 40 + ch;
        }

        public static int GenerateChipSealingGroupId(int ch)
        {
            return 50 + ch;
        }

        public static int GetChannelIndex(int groupId)
        {
            return groupId % 10;
        }

        /// <summary>
        /// 写ini文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 读ini文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="refVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder refVal, int size, string filePath);

        public delegate void DelegateRetryCommand(RetryModule module, int errCode, bool isIgnore);
    }


    #region 协议格式 FunctionCode+CommonDevice+CMD
    public static class FunctionCode
    {
        public const UInt16 SENDING_CODE = 0x300;
        public const UInt16 RECEIVE_CODE = 0x2C0;

        //public const UInt16 RX_SEALING_Z = 0x300;
        //public const UInt16 TX_SEALING_Z = 0x2C0;
    }
    public static class CommonDevice
    {
        public const UInt16 HEARTBEAT_PACKET = 0x00;//热封设置温度
        #region 风扇
        public const UInt16 FAN = 0x25;//上排风口
        public const UInt16 FAN2 = 0x3F;//风扇0x3f
        #endregion

        public const UInt16 LED = 0x21;//LED灯
        public const UInt16 UV_LAMP = 0x22;//紫外灯灯

        public const UInt16 DOOR = 0x3F;//门控制
        public const UInt16 ALARM = 0x3F;//三色灯警报       
        #region 热封
        public const UInt16 CHIP_SEALING_SET_TEMP = 0x4C;//热封设置温度
        public const UInt16 CHIP_SEALING_Y_MOVE = 0x4D;//热封y移动
        public const UInt16 CHIP_SEALING_Z_MOVE = 0x4C;//热封z移动
        #endregion

        #region 上提取
        public const UInt16 UPPER_LIFT_Z_MOVE = 0x21;//上提取Z
        public const UInt16 UPPER_LIFT_T_MOVE = 0x21;//上提取T
        #endregion
        //#region 电机
        //public const UInt16 MOTOR_SET_TEMP = 0x4C;//热封设置温度
        //#endregion

        #region 搬运
        public const UInt16 CHIP_HANDLING_SYSX = 0x2A;//芯片X搬运
        public const UInt16 CHIP_HANDLING_SYS = 0x28;//芯片Z搬运

        public const UInt16 LIQUID_HANDLING_SYS = 0x20;//液滴搬运
        #endregion

        #region 通道
        public const UInt16 CHANNEL_Y_MOVE = 0x25;//通道Y电机
        #endregion

        #region 压力
        public const UInt16 XPRESSURE = 0x2A;//门控制
        public const UInt16 ZPRESSURE = 0x28;//三色灯警报  
        public const UInt16 NEGATIVEPRESSURE = 0x27;//门控制        
        #endregion
    }

    public static class CMD
    {
        public const byte CMD_HEARTBEAT_PACKET = 0x00;//心跳包
        #region 热封
        public const byte CMD_SET_TEMP = 0x82;//设置温度
        public const byte CMD_QUERY_TEMP = 0x83;//查询温度
        #endregion

        public const byte CALIBRATION_PARAM_A = 0x0A;//温度校准A参数
        public const byte CALIBRATION_PARAM_B = 0x0B;//温度校准B参数
        public const byte CALIBRATION_PARAM_C = 0x0C;//温度校准C参数


        #region 上提取
        public const byte CMD_UPPER_LIFT_Z_MOTOR_SPEED = 0x14; //上提取Z电机运动速度
        public const byte CMD_MAGNETIC_COVER_STATUS = 0xA2; //上提取磁套状态
        public const byte START_MIX = 0xA3; //开始混匀
        public const byte END_MIX = 0xA4; //结束混匀
        #endregion

        public const byte CMD_PRESSURE = 0x54;//查询压力
    }
    #region MpConst
    public class MpConst
    {
        public const byte CmdConnect = 0x00;
        public const byte CmdVersion = 0x01;
        public const byte CmdInitPump = 0x10;
        public const byte CmdSetV = 0x11;
        public const byte CmdAspirate = 0x12;
        public const byte CmdDispense = 0x13;
        public const byte CmdTipFlag = 0x14;
        public const byte CmdEject = 0x15;

        public const byte CmdOptElectromagnet = 0x81;
        public const byte CmdSetTemp = 0x82;//设置温度
        public const byte CmdQueryTemp = 0x83;//查询温度

        public const byte CmdInit = 0x52;
        public const byte CmdMove = 0xb6;

        public const byte SignOn = 0x01;
        public const byte SignOff = 0x00;

        public const byte CmdSetCalibrationParams = 0xA0;//设置温度校准参数
        public const byte CmdQueryCalibrationParams = 0xA1;//查询温度校准参数

        public const int ReagentCount = 6;//试剂数目
    }
    #endregion
    public static class MotroId
    {
        public const byte UPPER_LIFT_Z_MOTOR = 0x00; //上提取Z电机id
        public const byte UPPER_LIFT_T_MOTOR = 0x01; //上提取T电机id
    }
    #endregion




    #region CommonEnums

    /// <summary>
    /// 液体类型
    /// </summary>
    public enum LiquidType
    {
        [Description("水或试剂")]
        Water = 0x01,
        [Description("血清")]
        Serum,
        [Description("其它")]
        Other,
    }

    public enum GroupId
    {
        Pipette900_ChannelA = 0,//排枪 900tip头
        Pipette900_ChannelB = 1,
        Pipette900_ChannelC = 2,
        Pipette900_ChannelD = 3,

        Pipette175_ChannelA = 4,//排枪 175tip头
        Pipette175_ChannelB = 5,
        Pipette175_ChannelC = 6,
        Pipette175_ChannelD = 7,

        Adp175_ChannelA = 10,//Adp 175tip头
        Adp175_ChannelB = 11,
        Adp175_ChannelC = 12,
        Adp175_ChannelD = 13,
        TipBox175 = 14,
        Adp900_ChannelA = 15,//Adp 900tip头
        Adp900_ChannelB = 16,
        Adp900_ChannelC = 17,
        Adp900_ChannelD = 18,




        Scanner_ChannelA = 30,//扫码枪A通道
        Scanner_ChannelB = 31,
        Scanner_ChannelC = 32,
        Scanner_ChannelD = 33,

        ReagentScanner_ChannelA = 40,//试剂扫码枪A通道
        ReagentScanner_ChannelB = 41,
        ReagentScanner_ChannelC = 42,
        ReagentScanner_ChannelD = 43,

        SealingYCollection = 50,//热封Y收集位置
        SealingYSealing = 51,//热封Y热封位置
        SealingYHome = 52,
        SealingZSealing = 53,
        SealingZHome = 54,
        //Adp900_ChannelA = 14,//Adp 900tip头
        //Adp900_ChannelB = 15,
        //Adp900_ChannelC = 16,
        //Adp900_ChannelD = 17,
    }
    //GroupId格式
    //channel+Tip+单个模块

    /// <summary>
    /// 通道
    /// </summary>
    public enum Channels
    {
        A,
        B,
        C,
        D,
        Tip,
        Pcr1,
        Pcr2,
        Pcr3,
        Pcr4
    }

    /// <summary>
    /// 通道
    /// </summary>
    public enum HeatingBlocks
    {
        A,
        B,
    }
    /// <summary>
    /// Tip头类型
    /// </summary>
    public enum Tips
    {
        Tip900,
        Tip175 = 2,
    }

    /// <summary>
    /// 模块
    /// </summary>
    public enum Module
    {
        Adp = 10,//adp
        Pipette,//排枪
        Scanner,//扫码枪
        ReagentScanner,//试剂扫码枪
    }


    /// <summary>
    /// 项目类型
    /// </summary>
    public enum ProjectType
    {
        [Description("定性")]
        QualitativePCR,
        [Description("定量")]
        RealtimePCR,
        [Description("溶解曲线")]
        Other,
    }
    /// <summary>
    /// 样本类型
    /// </summary>
    public enum SampleType
    {
        [Description("标准品")]
        Standard,
        [Description("阴性对照")]
        Negative,
        [Description("阳性对照")]
        Positive,
        [Description("空白对照")]
        NoTemplateControl,
        [Description("未知样本")]
        Unknown,
    }
    public enum RetryModule
    {
        LiqHa,
        HandleX,
        HandleZ,
        Scanner

    }
    public enum RetryFlag
    {
        /// <summary>
        /// 终止
        /// </summary>
        Abort,
        /// <summary>
        /// 重试
        /// </summary>
        Retry,
        /// <summary>
        /// 忽略
        /// </summary>
        Ignore,
    }

    public enum ReporterType
    {
        FAM = 1,
        HEX,
        ROX,
        Cy5,
        VIC,
        Quasar705
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum ThresholdMethod
    {
        [Description("自动阈值")]
        AutoMean,
        [Description("手动阈值")]
        Manual
    }

    /// <summary>
    /// 检测结果
    /// </summary>
    public enum ResultType
    {
        [Description("阴性")]
        Negative,
        [Description("阳性")]
        Positive,
        [Description("NoCt")]
        Invalid
    }
    #endregion
}
