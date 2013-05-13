using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Talk2Me_login
{
    public class Login
    {

        public String Username { get; set; }
        public string Password { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Username);
                    writer.Write(Password);
                }
                return m.ToArray();
            }
        }

        public static Login Desserialize(byte[] data)
        {
            Login result = new Login();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {

                    result.Username = reader.ReadString();
                    result.Password = reader.ReadString();
                }
            }
            return result;
        }

    }

}
