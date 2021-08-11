# c# 프라우드에서 c++ 비해 사용법이 다른 api

using Nettention.ProudClr;
public class CClientEventSink 
{
    public CClientEventSink(NetClient Client, C2C.Proxy Proxy)
    {
        m_Client = Client;
        m_C2CProxy = Proxy;
        //핸들 넣어주는 곳
        m_Client.JoinServerCompleteHandler = OnJoinServerComplete;
        m_Client.LeaveServerHandler = OnLeaveServer;
        m_Client.P2PMemberJoinHandler = OnP2PMemberJoin;
        m_Client.P2PMemberLeaveHandler = OnP2PMemberLeave;
    }
    public void OnJoinServerComplete(ErrorInfo info, ByteArray replyFromServer)
    {
        // 처리할 로직
    }
    public void OnLeaveServer(ErrorInfo errorInfo)
    {
        // 처리할 로직
    }
    public void OnP2PMemberJoin(HostID memberHostID, HostID groupHostID, int memberCount, ByteArray customField)
    {
        // 처리할 로직
    }
    public void OnP2PMemberLeave(HostID memberHostID, HostID groupHostID, int memberCount)
    {
        // 처리할 로직
    }
}







# 1. 서버와 클라이언트 생성

    서버쪽 코드
    using System;
using Nettention.Proud;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        
            NetServer s = new NetServer(); // [1]  

            StartServerParameter param = new StartServerParameter();

            param.tcpPorts.Add(44444);
            param.udpPorts.Add(44444);

            param.protocolVersion.Set(new System.Guid("{0x5dca93f4, 0x8133, 0x44a0, { 0xb5, 0x7b, 0x75, 0x7d, 0x9c, 0x78, 0xd5, 0x2e }}"));





            s.Start(param);
        s.ClientJoinHandler = (Info) => {
                    Console.WriteLine("접속한 클라이언트 ::" + Info.hostID);
                };

            s.ClientLeaveHandler = (client, reason, comment) => {
                Console.WriteLine("clinet > " + client.hostID);
                Console.WriteLine("Clinet > " + client?.natDeviceName);

                Console.WriteLine("reason > " + reason?.source);
                Console.WriteLine("comment > " + comment?.data);
                Console.WriteLine("comment > " + comment?.GrowPolicy);

                // 클라가 연결이 끈겻을떄 이벤트 처리 영역 
            };

            while (true)
            {

               string line =  Console.ReadLine();

                if (line.Equals("1"))
                {
                    Console.WriteLine("서버 대기중 ");
                }

            }

        }
    }
}



클라쪽 코드
using System;
using Nettention.Proud;
using netClient;

namespace netClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("프라우드넷 클라이언트 ");


            NetClient netClient = new NetClient();
            NetConnectionParam param = new NetConnectionParam();

            param.serverIP = "localhost";
            param.serverPort = 44444;

            param.protocolVersion.Set(new System.Guid("{0x5dca93f4, 0x8133, 0x44a0, { 0xb5, 0x7b, 0x75, 0x7d, 0x9c, 0x78, 0xd5, 0x2e }}"));

            netClient.Connect(param);


            netClient.JoinServerCompleteHandler = (info, serverReple) => {
                // 서버에 접속이 되면 콜백 되는 함수

                if (info.errorType == ErrorType.Ok)
                {
                    Console.WriteLine("서버 접속 성공 ");
                }
                else
                {
                    Console.WriteLine("서버 접속 실패 ");

                    string dat = "개인적으로 연결 해제 합니다";

                    byte[] StrByte = System.Text.Encoding.UTF8.GetBytes(dat);

                    serverReple.data = StrByte;
                }

                Console.WriteLine("server count " + serverReple?.Count);

                Console.WriteLine("Server GrowPoliy" + serverReple?.GrowPolicy);

                Console.WriteLine("Server data " + serverReple?.data);
            };


            netClient.LeaveServerHandler = (reason) =>
            {
                Console.WriteLine(reason.comment);
                Console.WriteLine(reason.source);

                Console.WriteLine(reason.ToString());

            };

            
           
            while (true)
            {
                netClient.FrameMove();

                string command = Console.ReadLine();

                if (command.Equals("quit"))
                {
                    netClient.Disconnect();
                    netClient.FrameMove();
                   // break;
                }
            }
        }
    }
}


클라는 멀티 스레드 적용이 안되어 있어서 프레임 무브를 일일히 해줘야 하는 것으로 보임 서버가 팅겨도
 frammove를 호출시까지 서버가 팅긴지 모름!

책 설명 
일반 적인 게임 클라이언트는 메인 루프를 가짐
메인 루프에서는 게임 로직 처리와 렌더링을 함 서버나 다른 클라이언트에서 
온 메시지를 처리 하거나 이벤트 함수를 호출 받는것도 이 메인 루프 어딘가에서 함




1. NetServer를 생성해서 Start를 호출한다.
2. NetClient를 생성해서 Connect를 호출한다.
3. NetServer.OnClientJoin, OnClientLeave에서 클라의 들어옴/나감을 처리한다.
4. NetClient.OnJoinServerComplete, OnLeaveServer에서 서버와의 접속의 성공/실패/중도연결 해제를 처리한다.
5. NetClient.FrameMove를 계속해서 호출해 주어야 한다. 








# 프라우드 넷 사용법 메시지 주고 받기 

프라우드 넷에서 메시지르 주고 받는 방법은 다음과 같음
1. 전통적인 방법으로 바이너리 데이터 주고 받기
2. 다른 컴퓨터에 있는 함수를  원격으로 호출 하기


1번 방식의 처리
    NetClient, NetServer 에는 sendMessage 메서드가 있음 이 메서드는 몇가지의 요구 사항이 있음 


1. 누구에게-> host ID or host[] ID 

2. 어떻게 (reliable or unreliable)
    reliable -> 보장
    unreliable -> 비보장
    
    이외에도 암호화 해서 보낼지 압축해서 보낼지 를 옵션이 존재, 구조체 방식



3. 무엇을 byte array
    바이너리 데이터를 보내면 댐 ;

    서버측
    using System;
using Nettention.Proud;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        
            NetServer s = new NetServer(); // [1]  

            StartServerParameter param = new StartServerParameter();

            param.tcpPorts.Add(44444);
            param.udpPorts.Add(44444);

            param.protocolVersion.Set(new System.Guid("{0x5dca93f4, 0x8133, 0x44a0, { 0xb5, 0x7b, 0x75, 0x7d, 0x9c, 0x78, 0xd5, 0x2e }}"));





            s.Start(param);
            s.ClientJoinHandler = (Info) => {
                    Console.WriteLine("접속한 클라이언트 ::" + Info.hostID);
                };

            s.ClientLeaveHandler = (client, reason, comment) => {
                Console.WriteLine("clinet > " + client.hostID);
                Console.WriteLine("Clinet > " + client?.natDeviceName);
                Console.WriteLine("Client > " + client);


                Console.WriteLine("reason > " + reason.ToString());
                Console.WriteLine("comment > " + comment?.data);
                Console.WriteLine("comment > " + comment?.GrowPolicy);

                // 클라가 연결이 끈겻을떄 이벤트 처리 영역 
            };



            s.ReceiveUserMessageHandler = (sender, rmicontext, payload) => {


                string receivData = System.Text.Encoding.UTF8.GetString(payload.data);

                Console.WriteLine($"{sender}클라가 서버에게  {rmicontext?.ToString()} 방식으로 \n {receivData}\n 보냄");


                string data = "클라 데이터 받음 확인";

                byte[] process = System.Text.Encoding.UTF8.GetBytes(data);

                ByteArray byteArray = new ByteArray(process);

                s.SendUserMessage(sender, rmicontext, byteArray);

            };

            while (true)
            {

               string line =  Console.ReadLine();

                if (line.Equals("1"))
                {
                    Console.WriteLine("서버 대기중 ");
                }

            }

        }
    }
}



클라측
using System;
using Nettention.Proud;
using netClient;
using System.Threading;

namespace netClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("프라우드넷 클라이언트 ");


            NetClient netClient = new NetClient();
            NetConnectionParam param = new NetConnectionParam();

            param.serverIP = "localhost";
            param.serverPort = 44444;

            param.protocolVersion.Set(new System.Guid("{0x5dca93f4, 0x8133, 0x44a0, { 0xb5, 0x7b, 0x75, 0x7d, 0x9c, 0x78, 0xd5, 0x2e }}"));

            netClient.Connect(param);


            netClient.JoinServerCompleteHandler = (info, serverReple) => {
                // 서버에 접속이 되면 콜백 되는 함수

                if (info.errorType == ErrorType.Ok)
                {
                    Console.WriteLine("서버 접속 성공 ");
                }
                else
                {
                    Console.WriteLine("서버 접속 실패 ");

                    string dat = "개인적으로 연결 해제 합니다";

                    byte[] StrByte = System.Text.Encoding.UTF8.GetBytes(dat);

                    serverReple.data = StrByte;
                }

                Console.WriteLine("server count " + serverReple?.Count);

                Console.WriteLine("Server GrowPoliy" + serverReple?.GrowPolicy);

                

                Console.WriteLine("Server data " + serverReple?.data);
                Console.WriteLine("Server.toString() > " + serverReple?.ToString());
            };



            netClient.LeaveServerHandler = (reason) =>
            {
                Console.WriteLine(reason.comment);
                Console.WriteLine(reason.source);

                Console.WriteLine(reason.ToString());

            };

            netClient.ReceivedUserMessageHandler = (sender, rmicontext, payload) =>
            {

                string receivData = System.Text.Encoding.UTF8.GetString(payload.data);

                Console.WriteLine($"{sender}가  {rmicontext?.ToString()} 방식으로 \n {receivData}\n 보냄");

            };


            Thread a = new Thread(()=> {
               
                while (true)
                {
                    //Console.WriteLine("스레드 a");
                     netClient.FrameMove();

                    Thread.Sleep(1000);
                }
            });
            a.Start();

            while (true)
            {
              //  netClient.FrameMove();

                

                string command = Console.ReadLine();

                if (command.Equals("quit"))
                {
                    netClient.Disconnect();
                    netClient.FrameMove();
                   // break;
                }

                if (command.Equals("send"))
                {
                    Console.WriteLine("보내기");
       
                    string dat = "클라가 서버로 데이터를 보냅니다.";

                    byte[] StrByte = System.Text.Encoding.UTF8.GetBytes(dat);

                    // 넷텐션 프라우드넷에서 지원하는 바이트 형식으로 재설정 
                    ByteArray byteArray = new ByteArray(StrByte);

                    netClient.SendUserMessage(HostID.HostID_Server, RmiContext.UnreliableSend, byteArray);
                    //netClient.FrameMove();


                }
            }
        }

        
    }
}



전송시 

netClient.SendUserMessage(HostID.HostID_Server, RmiContext.UnreliableSend, byteArray);


수신시 구현


        // 메세지 수신 콜백 
        netServer.ReceiveUserMessageHandler = (sender, rmicontext, payload) => {

            string receivData = System.Text.Encoding.UTF8.GetString(payload.data);
            Console.WriteLine($"{sender}클라가 서버에게  {rmicontext?.ToString()} 방식으로 \n {receivData}\n 보냄");

            string data = "클라 데이터 받음 확인";
             byte[] process = System.Text.Encoding.UTF8.GetBytes(data);
            ByteArray byteArray = new ByteArray(process);
            netServer.SendUserMessage(sender, rmicontext, byteArray);
        };




# 프라우드 넷 클라이언트 끼리 p2p

프라우드 의 p2p 연결은 생성하는 데 그렇게 많은 시간은 들지 않는 다는것


1. 서버에서 클라 1 과 클라 2 가 p2p 연결 하라고 지시

클라이언트1 클라이언트 2 는 자기가 p2p 연결이 됨을 즉시 알수 있음

2. 직 후에 바로 클라이언트 1 과 클라이언트 서로 메세지를 주고 받음

 p2p 그룹에는 클라이언트를 0개 이상 널을수 있음
 클라이언트 하나가 여러 p2p 들어가도 됨
 서버도 p2p 그룹에 들어가는 것이 허락 됩니다.


 




