﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    public class StateStatus
    {

        public int Id { get; set; }
        public string State { get; set; }
        public string Status { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Id);
                    writer.Write(State);
                    writer.Write(Status);
                }
                return m.ToArray();
            }
        }

        public static StateStatus Desserialize(byte[] data)
        {
            StateStatus result = new StateStatus();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Id = reader.ReadInt32();
                    result.State = reader.ReadString();
                    result.Status = reader.ReadString();
                }
            }
            return result;
        }

    }

}
