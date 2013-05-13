using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Loosely inspired on http://msdn.microsoft.com/en-us/library/bew39x2a.aspx

namespace Talk2Me_login
{
    class ClientServerCommunicator
    {

       
        static readonly IPAddress serverIP = IPAddress.Loopback;
        const int serverPort = 2500;

        static ManualResetEvent connectDone = new ManualResetEvent(false);
        static ManualResetEvent sendDone = new ManualResetEvent(false);

        class StateObject
        {
            public Socket connection = null;

            // Note that I use a very small buffer size
            // for this example. Normally you'd like a much
            // larger buffer. But this small buffer size nicely
            // demonstrates getting the entire message in multiple
            // pieces.
            public const int bufferSize = 8;
            public byte[] buffer = new byte[bufferSize];
            public int expectedMessageLength = 0;
            public int receivedMessageLength = 0;
            public byte[] message = null;
            public int type = -1;
        }

   

        public static void SendMessageAsync(string message)
        {
            // Initiate connecting to the server
            Socket connection = Connect();

            // block this thread until we have connected
            // normally your program would just continue doing other work
            // but we've got nothing to do :)
            connectDone.WaitOne();

            Console.Out.WriteLine("Connected to server");

            // Start sending the data
            SendData(connection, message);
            sendDone.WaitOne();
            Console.Out.WriteLine("Message successfully sent");


            StateObject state = new StateObject();
            state.connection = connection;

            connection.BeginReceive(state.buffer, 0, StateObject.bufferSize,
                SocketFlags.None, new AsyncCallback(ReadCallback), state);





        }

        public static Socket Connect()
        {
            try
            {
                IPEndPoint serverAddress = new IPEndPoint(serverIP, serverPort);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.BeginConnect(serverAddress, new AsyncCallback(ConnectCallback), client);


                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static void SendData(Socket connection, string message)
        {
            try
            {
                Login send = new Login();
                Random x = new Random();
                send.Username = message;
                send.Password = "Test";
                int type = 3;

                byte[] data = Encoding.UTF8.GetBytes(message);
                data = send.Serialize();
                // We store how much data the server should expect
                // in the first 4 bytes of the data we're going to send
                byte[] head = BitConverter.GetBytes(data.Length * 2);


                byte[] total = new byte[data.Length + head.Length + data.Length];

                Console.Out.WriteLine(head.Length);
                head.CopyTo(total, 0);

                head = BitConverter.GetBytes(type);
                head.CopyTo(total, head.Length);

                data.CopyTo(total, head.Length * 2);


                connection.BeginSend(total, 0, total.Length, 0, new AsyncCallback(SendCallBack), connection);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }



        public static void SendData(Socket connection, byte[] data, int type)
        {
            try
            {

                // We store how much data the server should expect
                // in the first 4 bytes of the data we're going to send
                byte[] head = BitConverter.GetBytes(data.Length * 2);


                byte[] total = new byte[data.Length + head.Length + data.Length];

                Console.Out.WriteLine(head.Length);
                head.CopyTo(total, 0);

                head = BitConverter.GetBytes(type);
                head.CopyTo(total, head.Length);

                data.CopyTo(total, head.Length * 2);


                connection.BeginSend(total, 0, total.Length, 0, new AsyncCallback(SendCallBack), connection);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);

                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public  static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytes = client.EndSend(ar);

                Console.Out.WriteLine("A total of {0} bytes were sent to the server", bytes);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }


        public static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.connection;

                int read = handler.EndReceive(ar);

                if (read > 0)
                {
                    Console.Out.WriteLine("Read {0} bytes", read);

                    if (state.expectedMessageLength == 0)
                    {
                        // Extract how much data to expect from the first 4 bytes
                        // then configure buffer sizes and copy the already received
                        // part of the message.
                        state.expectedMessageLength = BitConverter.ToInt32(state.buffer, 0);

                        state.message = new byte[state.expectedMessageLength];
                        Array.ConstrainedCopy(state.buffer, 4, state.message, 0, Math.Min(StateObject.bufferSize - 4, state.expectedMessageLength - state.receivedMessageLength));
                        state.receivedMessageLength += read - 4;
                    }
                    else
                    {
                        Array.ConstrainedCopy(state.buffer, 0, state.message, state.receivedMessageLength, Math.Min(StateObject.bufferSize, state.expectedMessageLength - state.receivedMessageLength));
                        state.receivedMessageLength += read;
                    }

                    // Check if we received the entire message. If not
                    // continue listening, else close the connection
                    // and reconstruct the message.
                    if (state.receivedMessageLength < state.expectedMessageLength)
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.bufferSize,
                            SocketFlags.None, new AsyncCallback(ReadCallback), state);
                    }
                    else
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();

                        Console.Out.WriteLine("Received message: \n");
                        Mesaj t = Mesaj.Desserialize(state.message);
                        String a = "" + t.Id + " " + t.Name;
                        //Console.Out.WriteLine(Encoding.UTF8.GetString(state.message));
                        Console.Out.WriteLine(a);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
