using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    public class Message
    {

        public int Id { get; set; }
        public string SourceName { get; set; }
        public string DestinationName { get; set; }
        public string Data { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Id);
                    writer.Write(SourceName);
                    writer.Write(DestinationName);
                    writer.Write(Data);
                }
                return m.ToArray();
            }
        }

        public static Message Desserialize(byte[] data)
        {
            Message result = new Message();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Id = reader.ReadInt32();
                    result.SourceName = reader.ReadString();
                    result.DestinationName = reader.ReadString();
                    result.Data = reader.ReadString();
                }
            }
            return result;
        }

    }

}
