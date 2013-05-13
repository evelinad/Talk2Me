using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    public class FriendOp
    {

        public int Id { get; set; }
        public string Group { get; set; }
        public string Friend { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Id);
                    writer.Write(Friend);
                    writer.Write(Group);
                }
                return m.ToArray();
            }
        }

        public static FriendOp Desserialize(byte[] data)
        {
            FriendOp result = new FriendOp();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Id = reader.ReadInt32();
                    result.Friend = reader.ReadString();
                    result.Group = reader.ReadString();
                }
            }
            return result;
        }

    }

}
