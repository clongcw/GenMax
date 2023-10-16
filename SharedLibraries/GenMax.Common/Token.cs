namespace GenMax.Common
{
    public class Token
    {
        public static string MessageBox = nameof(MessageBox);
        public static string Error = "ErrorCode";
        public static string Question = nameof(Question);
        public static string Hint = nameof(Hint);

        public static string About = "About";
        public static string SingleInput = "SingleInput";
        public static string BatchInput = "BatchInput";
        public static string LoadChip = "LoadChip";
        public static string TestRetry = "TestRetry";
        public static string DoorState = "DoorState";

        public static string UserLogin = nameof(UserLogin);
        public static string StartRunningProtocal = nameof(StartRunningProtocal);//开始运行Protocal
        public static string DeviceError = nameof(DeviceError);//仪器是有异常

        public static string UserModifyPassword = nameof(UserModifyPassword);
    }
}
