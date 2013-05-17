using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Loosely inspired on http://msdn.microsoft.com/en-us/library/fx6588te.aspx

namespace Server
{
    class Server
    {
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

        static ManualResetEvent acceptDone = new ManualResetEvent(false);
        const int listenPort = 2500;

        static Dictionary<string, Socket> map = new Dictionary<string, Socket>();

        public static void Main(string[] args)
        {
            Console.Out.WriteLine("This is the server");

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    acceptDone.Reset();

                    Console.Out.WriteLine("Listening on port {0}", listenPort);
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    acceptDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                acceptDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                StateObject state = new StateObject();
                state.connection = handler;

                handler.BeginReceive(state.buffer, 0, StateObject.bufferSize,
                    SocketFlags.None, new AsyncCallback(ReadCallback), state);

                // Start sending the data
                SendData(handler, "Tralala");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                        Array.ConstrainedCopy(state.buffer, 4, state.message, 0,
                            Math.Min(StateObject.bufferSize - 4, state.expectedMessageLength - state.receivedMessageLength));

                        state.receivedMessageLength += read - 4;
                    }
                    else
                    {
                        Array.ConstrainedCopy(state.buffer, 0, state.message, state.receivedMessageLength,
                            Math.Min(StateObject.bufferSize, state.expectedMessageLength - state.receivedMessageLength));
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
                        int type;
                        //handler.Shutdown(SocketShutdown.Both);
                        //handler.Close();
                        byte[] buffer = new byte[state.message.Length - 4];
                        Array.ConstrainedCopy(state.message, 4, buffer, 0, state.message.Length - 4);

                        type = BitConverter.ToInt32(state.message, 0);

                        Console.Out.WriteLine("Received message: \n");



                        IdentifyMessage(buffer, type, handler);

                        Console.WriteLine("");

                        StateObject new_state = new StateObject();
                        new_state.connection = handler;

                        handler.BeginReceive(new_state.buffer, 0, StateObject.bufferSize,
                            SocketFlags.None, new AsyncCallback(ReadCallback), new_state);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void IdentifyMessage(byte[] buffer, int type, Socket handler)
        {
            switch (type)
            {
                case 1:
                    message(Authentication.Desserialize(buffer), handler);
                    break;
                case 2:
                    message(FriendOp.Desserialize(buffer), handler);
                    break;
                case 3:
                    Login mess = Login.Desserialize(buffer);
                    message(mess, handler);
                    break;
                case 4:
                    message(Message.Desserialize(buffer), handler);
                    break;
                case 5:
                    message(StateStatus.Desserialize(buffer), handler);
                    break;
            }
        }


        public static void message(Authentication mess, Socket handler)
        {


        }

        public static void message(FriendOp mess, Socket handler)
        {


        }

        public static void message(Login mess, Socket handler)
        {
            // TODO INTEROGARE BAZA DE DATE, user valid
            if (!map.ContainsKey(mess.Username))
            {
                map.Add(mess.Username, handler);

            }
            else
                map[mess.Username] = handler;
            String a = "" + mess.Username + " " + mess.Password;
            Console.WriteLine(a);
            // TODO TRIMITERE MESAJ
        }

        public static void message(Message mess, Socket handler)
        {
            Console.Write("GOT HERE BITCHES");
            Socket destination;
            if (map.TryGetValue(mess.SourceName, out destination))
            {

            }


        }


        public static void message(StateStatus mess, Socket handler)
        {


        }

        static void SendData(Socket connection, string message)
        {
            try
            {
                Mesaj send = new Mesaj();
                send.Id = 10;
                send.Name = message;

                byte[] data = Encoding.UTF8.GetBytes(message);
                data = send.Serialize();
                // We store how much data the server should expect
                // in the first 4 bytes of the data we're going to send
                byte[] head = BitConverter.GetBytes(data.Length);

                byte[] total = new byte[data.Length + head.Length];
                head.CopyTo(total, 0);
                data.CopyTo(total, head.Length);

                connection.BeginSend(total, 0, total.Length, 0, new AsyncCallback(SendCallBack), connection);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        private static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytes = client.EndSend(ar);

                Console.Out.WriteLine("A total of {0} bytes were sent to the server", bytes);

                //sendDone.Set();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }


    }
}
