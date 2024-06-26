using System.Net;
using System.Net.Sockets;

namespace ServerCore
{
    public class Listener
    {
        // 문지기
        private Socket _listenSocket;
        private Action<Socket> _onAcceptHandler;
        public void Init(IPEndPoint endPoint, Action<Socket> onAcceptHandler)
        {
            _listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _onAcceptHandler += onAcceptHandler;
            
            // 문지기 교육
            _listenSocket.Bind(endPoint);
            
            // 영업 시작
            // backlog : 최대 대기수
            _listenSocket.Listen(10);
            
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            RegisterAccept(args);
        }
        
        void RegisterAccept(SocketAsyncEventArgs args)
        {
            args.AcceptSocket = null;
            
            bool pending = _listenSocket.AcceptAsync(args); // Non-Block
            if (pending == false)
                OnAcceptCompleted(null, args);
        }
        
        void OnAcceptCompleted(object sender, SocketAsyncEventArgs args)
        {
            if (args.SocketError == SocketError.Success)
            {
                // TODO
                _onAcceptHandler.Invoke(args.AcceptSocket);
            }
            else
                Console.WriteLine(args.SocketError.ToString());
            
            RegisterAccept(args);
        }
    }
}