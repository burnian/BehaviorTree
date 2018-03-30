using System;
using System.Text;


namespace IBehaviorTree
{
    // 节点状态
    public enum NODE_STATE : byte
    {
        SUCCESS = 1,
        FAILURE,
        RUNNING,
        ERROR
    }

    public class BTUtils
    {
        readonly public static Random RandomAgent = new Random();

        // 构造一个全局唯一ID
        public static string CreateUUID()
        {
            string hexDigits = "0123456789abcdef";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 36; i++)
            {
                sb.Append(hexDigits[RandomAgent.Next(0, 16)]);
            }
            // bits 12-15 of the time_hi_and_version field to 0010
            sb[14] = '4';

            // bits 6-7 of the clock_seq_hi_and_reserved to 01
            //s[19] = hexDigits.substr((sb[19] & 0x3) | 0x8, 1); -- this is the code in JS
            int temp = (int)Char.GetNumericValue(sb[19]);
            temp = temp < 0 ? 0 : temp;
            sb[19] = hexDigits[(temp & 0x3) | 0x8];

            sb[8] = sb[13] = sb[18] = sb[23] = '-';
            return sb.ToString();
        }
    }
}

