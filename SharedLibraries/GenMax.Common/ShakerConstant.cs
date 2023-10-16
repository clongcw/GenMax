namespace GenMax.Common
{
    public static class ShakerConstant
    {
        public const byte CMD_START = 0x80; //开始振荡
        public const byte CMD_STOP = 0x81;  //停止振荡
        public const byte CMD_SET_TEMP = 0x82; //设置孵育温度（0表示为常温，不用加热）
        public const byte CMD_QUERY_TEMP = 0x83; //查询当前温度
        public const byte CMD_QUERY_FREQUENCY = 0x84; //查询当前温度
        public const byte CMD_SET_CURRENT = 0x43;//设置电流
    }
}
