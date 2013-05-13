using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    public class Mesaj
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Id);
                    writer.Write(Name);
                }
                return m.ToArray();
            }
        }

        public static Mesaj Desserialize(byte[] data)
        {
            Mesaj result = new Mesaj();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Id = reader.ReadInt32();
                    result.Name = reader.ReadString();
                }
            }
            return result;
        }

    }
}
