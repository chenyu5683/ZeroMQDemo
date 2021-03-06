﻿namespace SharpClient
{
    using System;
    using System.Text;
    using ZeroMQ;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (ZmqContext context =ZmqContext.Create())
            {
                using (ZmqSocket socket = context.CreateSocket(SocketType.SUB))
                {
                    socket.Connect("tcp://127.0.0.1:8585");
                    socket.Subscribe(Encoding.Default.GetBytes("642"));

                    while (true)
                    {
                        string rep = socket.Receive(Encoding.GetEncoding("gb2312"));
                        Console.WriteLine("this is :{0}",rep);
                    }
                }
            }
        }
    }
}