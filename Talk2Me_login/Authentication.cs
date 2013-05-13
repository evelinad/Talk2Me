using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Talk2Me_login
{
    public class Authentication
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Username);
                    writer.Write(Password);
                    writer.Write(Email);
                }
                return m.ToArray();
            }
        }

        public static Authentication Desserialize(byte[] data)
        {
            Authentication result = new Authentication();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Username = reader.ReadString();
                    result.Password = reader.ReadString();
                    result.Email = reader.ReadString();
                }
            }
            return result;
        }

    }

}
