# 스레드 기초
## 소개
    - 스레드가 운영체제 자원의 상당한 양을 소비함을 기억.
    운영체제가 실행중인 프로그램 대신에 스레드를 관리 하느라 바쁜 상황으로 이끌기 위해 많은 스레드가 한 물리적 프로세서를 공유하도록 시도
    

    - 챕터 1의 예제는 c# 언어로 스레드를 이용한 몇몇 매우 기본적인 작업을 수행하는데 중점을 둔다.

    스레드의 생명 주기를 다루며 생성, 일시 중지, 스레드 대기, 스레드 중단을 포함한다.
    그다음에는 기 본 동기화 기법을 살펴본다.
## C#으로 스레드 생성
    c#으로 멀티 스레드를 이용한 프로그램을 작성하기 위한 주 도구인 비주얼 
    스튜디오 2015 를 사용한다. 이번 예제는 새로운 c# 프로그램을 만드는 방법과
    프로그램에서 스레드를 사용하는 방법을 보여준다.

    - 예제 구현
    using System;
    using System.Threading;

    namespace Chapter1.Recipe1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread t = new Thread(PrintNumbers);
                t.Start();
                PrintNumbers();
            }

            static void PrintNumbers()
            {
                Console.WriteLine("Starting...");
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }


    
## 스레드 일시 정지
    -이번 예제는 운영체제 자원을 소모하지 않은 채 스레드를 얼마 동안 기다리는 방법을 보여준다.

    - 예제 구현
    using System;
    using System.Threading;

    namespace Chapter1.Recipe2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread t = new Thread(PrintNumbersWithDelay);
                t.Start();
                PrintNumbers();
            }

            static void PrintNumbers()
            {
                Console.WriteLine("Starting...");
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            }

            static void PrintNumbersWithDelay()
            {
                Console.WriteLine("Starting...");
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine(i);
                }
            }
        }
    }


## 스레드 대기
    - 이번 예제는 프로그램이 코드에서 나중에 결과를 사용해 끝내도록 다른 스레드의 어떤 연산을 기다릴수 있는 방법을 포여준다. Thread.sleep 사용하기엔 충분하지 않은데 연산에 걸리는 시간을 정확하게 알수 없기 떄문이다.


    - 예제 구현
    using System;
    using System.Threading;

    namespace Chapter1.Recipe3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting program...");
                Thread t = new Thread(PrintNumbersWithDelay);
                t.Start();
                t.Join();
                Console.WriteLine("Thread completed");
            }

            static void PrintNumbersWithDelay()
            {
                Console.WriteLine("Starting...");
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine(i);
                }
            }
        }
    }



## 스레드 중단

## 스레드 상태 조사

## 스레드 우선순위

## 포그라운드 스레드와 백그라운드 스레드

## 스레드에 파라밍터 전달

## C# 의 lock 키워드로 잠그기

## moniter 생성자로 잠그기

## 예외 처리