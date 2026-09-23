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

        public string CurrentLogin { get; private set; }
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
                CurrentLogin = login;
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
        public async Task<bool> CreateVote(string title, string choices, string endTime)
        {
            serverEndPoint = await FindServer();
            if (serverEndPoint == null)
            {
                MessageBox.Show("Server not found");
                return false;
            }

            if (title.Contains(';') || choices.Contains(';'))
            {
                MessageBox.Show("Текст не може містити символ ';'");
                return false;
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

            if (parts[0] == "create_vote_success") { MessageBox.Show("Vote created success"); return true; }

            else { MessageBox.Show($"Vote creation failed: {parts[1]}"); return false; }
                
        }

        public async Task<List<(int Id, string Title, int TotalVotes)>> GetVotes()
        {
            serverEndPoint = await FindServer();
            if (serverEndPoint == null)
            {
                MessageBox.Show("Server not found");
                return null;
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            byte[] request = Encoding.UTF8.GetBytes("get_votes;");
            await socket.SendAsync(request);

            byte[] buffer = new byte[4096];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            socket.Close();

            var result = new List<(int, string, int)>();

            string[] parts = response.Split(';');
            if (parts[0] != "votes_list" || parts.Length < 2 || string.IsNullOrEmpty(parts[1]))
                return result;

            foreach (string entry in parts[1].Split('|'))
            {
                string[] fields = entry.Split(',');
                if (fields.Length == 3 && int.TryParse(fields[0], out int id) && int.TryParse(fields[2], out int totalVotes))
                {
                    result.Add((id, fields[1], totalVotes));
                }
            }

            return result;
        }

        public async Task<(string Title, List<(int Id, string Text)> Options)> GetVoteOptions(int voteId)
        {
            serverEndPoint = await FindServer();
            if (serverEndPoint == null) { MessageBox.Show("Server not found"); return (null, null); }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            await socket.SendAsync(Encoding.UTF8.GetBytes($"get_vote_options;{voteId}"));

            byte[] buffer = new byte[4096];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            socket.Close();

            string[] parts = response.Split(';');
            if (parts[0] != "vote_options") { MessageBox.Show("Не вдалося завантажити варіанти"); return (null, null); }

            string title = parts[1];
            var options = new List<(int, string)>();

            if (parts.Length > 2 && !string.IsNullOrEmpty(parts[2]))
            {
                foreach (var entry in parts[2].Split('|'))
                {
                    var fields = entry.Split(',', 2);
                    if (fields.Length == 2 && int.TryParse(fields[0], out int id))
                        options.Add((id, fields[1]));
                }
            }

            return (title, options);
        }

        public async Task<bool> CastVote(int voteId, int optionId)
        {
            serverEndPoint = await FindServer();
            if (serverEndPoint == null) { MessageBox.Show("Server not found"); return false; }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(serverEndPoint);

            string request = $"vote;{voteId};{optionId};{CurrentLogin}";
            await socket.SendAsync(Encoding.UTF8.GetBytes(request));

            byte[] buffer = new byte[1024];
            int len = await socket.ReceiveAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, len);
            socket.Close();

            if (response == "vote_success")
            {
                MessageBox.Show("Голос зараховано!");
                return true;
            }

            string[] parts = response.Split(';');
            string reason = parts.Length > 1 ? parts[1] : "unknown";
            string msg = reason switch
            {
                "already_voted" => "Ви вже голосували в цьому опитуванні",
                "vote_closed" => "Голосування закрито",
                "invalid_option" => "Некоректний варіант відповіді",
                "user_not_found" => "Користувача не знайдено",
                _ => "Не вдалося проголосувати"
            };
            MessageBox.Show(msg);
            return false;
        }


        private async Task<IPEndPoint> FindServer()
        {
           using(var client = new UdpClient())
            {
                client.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
                client.EnableBroadcast = true;
                byte[] requesData = Encoding.UTF8.GetBytes("discover_server");
                try { await client.SendAsync(requesData, requesData.Length, new IPEndPoint(IPAddress.Broadcast, discover_port)); } catch { }


                try { await client.SendAsync(requesData, requesData.Length, new IPEndPoint(IPAddress.Parse("26.255.255.255"), discover_port)); } catch { }

                var receive = client.ReceiveAsync();
                var timeout = Task.Delay(2000);

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