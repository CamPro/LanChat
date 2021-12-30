using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanChat
{
    public partial class LanChat : Form
    {
        public LanChat()
        {
            InitializeComponent();
        }

        Socket _listener = null;
        Socket _socket = null;
        StateObject _state = new StateObject();
        IPEndPoint _endpoint = new IPEndPoint(IPAddress.Any, 1308);

        private void LanChat_Load(object sender, EventArgs e)
        {
            comboListIP.Items.Clear();

            foreach (IPAddress _ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    comboListIP.Items.Add(_ip.ToString());
                }
            }
            comboListIP.SelectedIndex = 0;
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_socket != null && _socket.Connected) return;

                buttonServer.BackColor = Color.Red;

                _endpoint = new IPEndPoint(IPAddress.Parse(comboListIP.Text), 1308);
                // tcp sử dụng đồng thời hai socket: 
                // một socket để chờ nghe kết nối, một socket để gửi/nhận dữ liệu
                // socket listener này chỉ làm nhiệm vụ chờ kết nối từ Client
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // yêu cầu hệ điều hành cho phép chiếm dụng cổng tcp 1308
                // server sẽ nghe trên tất cả các mạng mà máy tính này kết nối tới
                // chỉ cần gói tin tcp đến cổng 1308, tiến trình server sẽ nhận được
                _listener.Bind(_endpoint);

                // bắt đầu lắng nghe chờ các gói tin tcp đến cổng 1308
                _listener.Listen(10);

                // tcp đòi hỏi một socket thứ hai làm nhiệm vụ gửi/nhận dữ liệu
                // socket này được tạo ra bởi lệnh Accept
                _socket = _listener.Accept();

                _socket.BeginReceive(_state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ServerArrived), _state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_listener == null) return;

                // bắt đầu lắng nghe chờ các gói tin tcp đến cổng 1308
                _listener.Listen(10);

                // tcp đòi hỏi một socket thứ hai làm nhiệm vụ gửi/nhận dữ liệu
                // socket này được tạo ra bởi lệnh Accept
                _socket = _listener.Accept();

                _socket.BeginReceive(_state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ServerArrived), _state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonServerSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_socket == null || !_socket.Connected) return;

                string text = textBoxServer.Text;
                // biến đổi chuỗi thành mảng byte
                var sendBuffer = Encoding.ASCII.GetBytes(text);
                // gửi mảng byte trên đến tiến trình server
                _socket.Send(sendBuffer);
                // không tiếp tục gửi dữ liệu nữa
                //_socket.Shutdown(SocketShutdown.Send);
                richTextServer.SelectionColor = Color.Black;
                richTextServer.AppendText(text);
                richTextServer.AppendText(Environment.NewLine);

                textBoxServer.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ServerArrived(IAsyncResult iar)
        {
            try
            {
                if (!_socket.Connected)
                {
                    // Disconnected
                    buttonServer.BeginInvoke(new MethodInvoker(delegate () { buttonServer.Text = "Disconnected"; }));
                    OnDisconect();
                    return;
                }
                else if (_socket.Poll(5000, SelectMode.SelectRead) && _socket.Available == 0)
                {
                    // Disconnected
                    buttonServer.BeginInvoke(new MethodInvoker(delegate () { buttonServer.Text = "Disconnected"; }));
                    OnDisconect();
                    return;
                }

                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                _state = (StateObject)iar.AsyncState;
                string msg = string.Empty;

                // Read data from the remote device.  
                int bytesRead = _socket.EndReceive(iar);
                if (bytesRead > 0)
                {
                    msg = Encoding.ASCII.GetString(_state.buffer, 0, bytesRead);
                    // There might be more data, so store the data received so far.  
                    _state.sb.Append(msg);
                    //  Get the rest of the data.  
                    _socket.BeginReceive(_state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ServerArrived), _state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (_state.sb.Length > 1)
                    {

                    }
                    // Signal that all bytes have been received.
                }

                richTextServer.BeginInvoke(new MethodInvoker(delegate ()
                {
                    richTextServer.SelectionColor = Color.Blue;
                    richTextServer.AppendText(msg);
                    richTextServer.AppendText(Environment.NewLine);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (_socket != null && _socket.Connected) return;

                buttonClient.BackColor = Color.Red;

                _endpoint = new IPEndPoint(IPAddress.Parse(comboListIP.Text), 1308);
                // khởi tạo object của lớp socket để sử dụng dịch vụ Tcp
                // lưu ý SocketType của Tcp là Stream 
                _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

                // tạo kết nối tới Server
                _socket.Connect(_endpoint);

                _socket.BeginReceive(_state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ClientArrived), _state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonClientSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_socket == null || !_socket.Connected) return;

                string text = textBoxClient.Text;
                // biến đổi chuỗi thành mảng byte
                var sendBuffer = Encoding.ASCII.GetBytes(text);
                // gửi mảng byte trên đến tiến trình server
                _socket.Send(sendBuffer);
                // không tiếp tục gửi dữ liệu nữa
                //_socket.Shutdown(SocketShutdown.Send);

                richTextClient.SelectionColor = Color.Black;
                richTextClient.AppendText(text);
                richTextClient.AppendText(Environment.NewLine);

                textBoxClient.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClientArrived(IAsyncResult ar)
        {
            try
            {
                if (!_socket.Connected)
                {
                    // Disconnected
                    buttonClient.Text = "Disconnected";
                    OnDisconect();
                    return;
                }
                else if (_socket.Poll(5000, SelectMode.SelectRead) && _socket.Available == 0)
                {
                    // Disconnected
                    buttonClient.Text = "Disconnected";
                    OnDisconect();
                    return;
                }

                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                _state = (StateObject)ar.AsyncState;
                string msg = string.Empty;

                // Read data from the remote device.  
                int bytesRead = _socket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    msg = Encoding.ASCII.GetString(_state.buffer, 0, bytesRead);
                    // There might be more data, so store the data received so far.  
                    _state.sb.Append(msg);
                    //  Get the rest of the data.  
                    _socket.BeginReceive(_state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ClientArrived), _state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (_state.sb.Length > 1)
                    {

                    }
                    // Signal that all bytes have been received.
                }

                richTextClient.BeginInvoke(new MethodInvoker(delegate ()
                {
                    richTextClient.SelectionColor = Color.Blue;
                    richTextClient.AppendText(msg);
                    richTextClient.AppendText(Environment.NewLine);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonDisconect_Click(object sender, EventArgs e)
        {
            OnDisconect();
        }

        private void OnDisconect()
        {
            if (_socket == null || !_socket.Connected) return;

            _socket.Shutdown(SocketShutdown.Both);
            _socket.Disconnect(true);
            _socket.Close();
        }

        private void textBoxServer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonServerSend_Click(null, null);
            }
        }

        private void textBoxClient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonClientSend_Click(null, null);
            }
        }
    }

    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
