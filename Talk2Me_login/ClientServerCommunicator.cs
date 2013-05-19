using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

// Loosely inspired on http://msdn.microsoft.com/en-us/library/bew39x2a.aspx

namespace Talk2Me_login
{
    class ClientServerCommunicator
    {

       
        static readonly IPAddress serverIP = IPAddress.Loopback;
        const int serverPort = 2500;

        static ManualResetEvent connectDone = new ManualResetEvent(false);
        static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ChatWindow cw;

        public static Socket server_socket; 

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


        public static void InitConection()
        {
            server_socket = Connect();
        }


        public static Socket Connect()
        {
            try
            {
                IPEndPoint serverAddress = new IPEndPoint(serverIP, serverPort);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.BeginConnect(serverAddress, new AsyncCallback(ConnectCallback), client);
                
                
                StateObject new_state = new StateObject();
                new_state.connection = client;

                client.BeginReceive(new_state.buffer, 0, StateObject.bufferSize,
                    SocketFlags.None, new AsyncCallback(ReadCallback), new_state);

                
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
                MessageBox.Show(e.Message);

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
                        int type;
                        //handler.Shutdown(SocketShutdown.Both);
                        //handler.Close();
                        byte[] buffer = new byte[state.message.Length - 4];
                        Array.ConstrainedCopy(state.message, 4, buffer, 0, state.message.Length - 4);

                        type = BitConverter.ToInt32(state.message, 0);

                       // MessageBox.Show("Received message: \n" + " " + cw.currentUser.Username);


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
         //           message(Authentication.Desserialize(buffer), handler);
                    break;
                case 2:
           //         message(FriendOp.Desserialize(buffer), handler);
                    break;
                case 3:
             //       Login mess = Login.Desserialize(buffer);
              //      message(mess, handler);
                    break;
                case 4:
                    Message t = Message.Desserialize(buffer);
                    message(t, handler);
                    break;
                case 5:
                //    message(StateStatus.Desserialize(buffer), handler);
                    break;
            }
        }


        public static void message(Message mess, Socket handler)
        {
           // MessageBox.Show(cw.currentUser.Username + " " + cw.conversationPartnerUser.Username );

            //cw.addMessageToRichBox("PIZda");
            //cw.textBox1.Text ="euuu";
            //cw.Dispatcher.Invoke(new Action(() => cw.label1.Content = "Irantha signed in"));
            cw.Dispatcher.Invoke(new Action(() => cw.addMessageToRichBox(mess.Data)));
                //cw.label1.Content = "Irantha signed in"));

            //cw.label1.Content = "pisic";
            

        }

    }
}
