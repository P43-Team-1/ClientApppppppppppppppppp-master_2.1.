using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Team_Project_Voting
{
    public class ServerSpeaking
    {
        int discover_port = 4568;
        int port = 4567;
        IPEndPoint serverEndPoint;
        public async Task<string> Login(string login, string password)
        {
            serverEndPoint = await FindServer();
            
            if(serverEndPoint == null)
            {
                MessageBox.Show("Server not found");
                return null;
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            string request = $"login;{login};{Convert.ToBase64String(Encoding.UTF8.GetBytes(password))}";
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            await socket.SendAsync(buffer);

            buffer = new byte[1024];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            string[] parts = response.Split(';');
            socket.Close();
            if (parts[0] == "login_success")
            {
                return $"{parts[1]};{parts[2]}";
            }
            else
            {
                MessageBox.Show("Login failed");
                return null;
            }
        }

        public async Task Registration(string login, string password, string nickname)
        {
            serverEndPoint = await FindServer();

            if (serverEndPoint == null)
            {
                MessageBox.Show("Server not found");
                return;
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            string request = $"register;{login};{Convert.ToBase64String(Encoding.UTF8.GetBytes(password))};{nickname}";
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            await socket.SendAsync(buffer);

            buffer = new byte[1024];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            string[] parts = response.Split(';');
            if (parts[0] == "register_success")
                MessageBox.Show("Register success");
            else
                MessageBox.Show($"Register failed: {parts[1]}");
        }
        public async Task CreateVote(string title, string choices, string endTime)
        {
            serverEndPoint = await FindServer();
            if (serverEndPoint == null)
            {
                MessageBox.Show("Server not found");
                return;
            }

            if (title.Contains(';') || choices.Contains(';'))
            {
                MessageBox.Show("Текст не може містити символ ';'");
                return;
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            string request = $"create_vote;{title};{choices};{endTime}";
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            await socket.SendAsync(buffer);

            buffer = new byte[1024];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            string[] parts = response.Split(';');
            socket.Close();

            if (parts[0] == "create_vote_success")
                MessageBox.Show("Vote created success");
            else
                MessageBox.Show($"Vote creation failed: {parts[1]}");
        }

        private async Task<IPEndPoint> FindServer()
        {
           using(var client = new UdpClient())
            {
                client.EnableBroadcast = true;
                byte[] requesData = Encoding.UTF8.GetBytes("discover_server");
                await client.SendAsync(requesData, requesData.Length, new IPEndPoint(IPAddress.Broadcast, discover_port));

                await client.SendAsync(requesData, requesData.Length, new IPEndPoint(IPAddress.Parse("26.255.255.255"), discover_port));

                var receive = client.ReceiveAsync();
                var timeout = Task.Delay(200);

                var completed = await Task.WhenAny(receive, timeout);
                if(completed == receive)
                {
                    var result = receive.Result;
                    string response = Encoding.UTF8.GetString(result.Buffer);
                    if (response == "server_here")
                    {
                        IPEndPoint serverEndPoint;
                        serverEndPoint = new IPEndPoint(result.RemoteEndPoint.Address, port);
                        return serverEndPoint;
                    }
                }
            }
           return null;
        }
    }
}