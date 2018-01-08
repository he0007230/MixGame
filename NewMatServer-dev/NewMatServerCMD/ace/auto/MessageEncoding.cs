using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceNetFrameWork.ace.auto
{
   public class MessageEncoding
    {
        public static byte[] Encode(object value)
        {
            SocketModel sm = value as SocketModel;
            ByteArray ba = new ByteArray();
            ba.write(sm.type);
            ba.write(sm.area);
            ba.write(sm.command);
            if (sm.message != null && sm.type == 1)
            {
                byte[] m = SerializeUtil.encode(sm.message);
                ba.write(m);
            }
            else
            {
                byte[] m = Encoding.UTF8.GetBytes(sm.message.ToString());
                ba.write(m);
            }
            byte[] result = ba.getBuff();
            ba.Close();
            return result;
        }

        public static object Decode(byte[] value)
        {
            ByteArray ba = new ByteArray(value);
            SocketModel sm = new SocketModel();
            int type;
            int area;
            int command;
            ba.read(out type);
            ba.read(out area);
            ba.read(out command);
            sm.type = type;
            sm.area = area;
            sm.command = command;
            if (ba.Readnable) {
                byte[] message;
                ba.read(out message,ba.Length-ba.Position);
                if (sm.type == 1)
                {
                    sm.message = SerializeUtil.decoder(message);
                }
                else
                {
                    CompactFormatter.TransDTO transDTO = new CompactFormatter.TransDTO();
                    transDTO.AppName = "Raspberry";
                    transDTO.CodeStr = Encoding.UTF8.GetString(message);
                    transDTO.pFlag = area;
                    transDTO.Remark = "Raspberry";
                    sm.message = transDTO;
                }
            }
            ba.Close();
            return sm;
        }
    }
}
