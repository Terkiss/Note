# 2장 스레드 동기화
## 소개
    1장 에서 보 았 드시 여러 스레드가 공유 객체를 동시에 사용하는 것은 문제가 있다.

    유저 모드
    짧은 시간을 기다려야 할경우 커널모드 보다 소모되는 자원이 적음
    문맥 교환이 일어 나지 않음 

    
    커널 모드
    매우 많은 시간을 기다려야 할경우 유저 모드 보다 cpu 사용량이 적음
    문맥 교환이 일어남
## 기본 원자 연산 수행 

using System;
using System.Threading;
namespace MultiThreadStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("incorrent counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));

            // 경합 에러 
            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();


            Console.WriteLine($"total counter {c.Count}");


            Console.WriteLine(" 올바른 카운터 ");

            var c1 = new CounterNoLock();
            t1 = new Thread(() => TestCounter(c));
            t2 = new Thread(() => TestCounter(c));
            t3 = new Thread(() => TestCounter(c));


            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"total counter {c1.Count}");
        }


        abstract class CounterBase
        {
            public abstract void Increament();

            public abstract void Decreament();

        }
        class Counter : CounterBase
        {
            private int _count;

            public int Count 
            {
                get 
                {
                    return _count;
                }
                set
                {
                    _count = value;
                }
            }
            public override void Decreament()
            {
                _count--;
            }

            public override void Increament()
            {
                _count++;
            }
        }

        class CounterNoLock : CounterBase
        {
            private int _count;

            public int Count
            {
                get
                {
                    return _count;
                }
                set
                {
                    _count = value;
                }
            }
            public override void Decreament()
            {
                // Interlocked 를 사용해서 아무런 lock 처리 를 안하고 할수 있다.
                
                Interlocked.Decrement(ref _count);
              
            }

            public override void Increament()
            {
                Interlocked.Increment(ref _count);
                
            }
        }

        static void TestCounter(CounterBase counter)
        {
            for (int i = 0; i < 100000; i++)
            {
                counter.Increament();
                counter.Decreament();
            }
        }


    }
}


## Mutex 생성자 사용

using System;
using System.Threading;



namespace Chapter2.Recipe2
{
	/// <summary>
	/// 이번 예쪠는 뮤텍스 생성자를 이용해 별개인 두 프로그램을 동기화 하는 방법을 설명 한다.
	/// 뮤텍스는 공유 자원에 배타적으로 접근 하게 끔 오직 한스레드에만 자원을 부여하는 원시적인 동기화 기법이다. 
	/// 
	/// 
	/// 명명 된 뮤텍스가 운영체제 의 전영 객체 임을 주의
	/// 다양한 프로그램 에서 뮤텍스로 동기화 할수 있으므로 매우 유용
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			const string MutexName = "CSharpThreadingCookbook";

			using (var m = new Mutex(false, MutexName))
			{
				if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
				{
					Console.WriteLine("Second instance is running!");
				}
				else
				{
					Console.WriteLine("Running!");
					Console.ReadLine();
					m.ReleaseMutex();
					Console.WriteLine("Running!2");
				}
			}
		}
	}
}


## SemaphoreSlim 생성자 사용

using System;
using System.Threading;

namespace Chapter2.Recipe3
{
	/// <summary>
	/// 이번 예제는 세마 포어 의 경량 버전을 이용해 자원에 접근할수 있는 스레드 갯수를 제한 하는 방법을 알아 보자 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 1; i <= 6; i++)
			{
				string threadName = "Thread " + i;
				int secondsToWait = 2 + 2 * i;
				var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
				t.Start();
			}
		}


		/// <summary>
		///  동시 접근 갯수 
		/// </summary>
		static SemaphoreSlim _semaphore = new SemaphoreSlim(1);

		static void AccessDatabase(string name, int seconds)
		{
			Console.WriteLine("{0} waits to access a database", name);


			_semaphore.Wait(); // 대기

			Console.WriteLine("{0} was granted an access to a database", name);
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("{0} is completed", name);

			_semaphore.Release(); // 해제

		}
	}
}


## AutoResetEvent 생성자 사용
using System;
using System.Threading;


/// <summary>
/// auto reset eventt 생성자 사용
/// 오토 이벤트 생성자 사용 방법에 대해 알아 보자
/// </summary>
namespace Chapter2.Recipe4
{
	class Program
	{

		/// <summary>
		/// 메인 프로그램을 시작하면 두 auto reset event 를 ㅈ정의 한다.
		/// 그중 한 인스턴스는 두번쨰 스레드가 메인 스레드 에게 신호를 보낸다.
		/// 두번쨰 인스턴스 는 메인 스레드가 두번쨰 스레드에게 신호루ㅡㄹ 보낸다.
		/// autoreset event 생성자에게 호출할때 초기상태를 unsingaled 로 지정하는 false 를 지정 하낟. 
		/// set 메서드를 호출 할떄까지 이런 객체 중 하나의 waitone 메서드를 호출 하는 스레드를 봉쇄 한다.
		/// 만약에 true로 지정하게 되면  이벤트 상태자 signaled가 되며 waitone을 호출하는 세번쨰 스레드가 즉시 실행이 된다.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var t = new Thread(() => Process(10));
			t.Start();

			Console.WriteLine("Waiting for another thread to complete work");
			_workerEvent.WaitOne();
			Console.WriteLine("First operation is completed!");
			Console.WriteLine("Performing an operation on a main thread");
			Thread.Sleep(TimeSpan.FromSeconds(5));
			_mainEvent.Set();
			Console.WriteLine("Now running the second operation on a second thread");
			_workerEvent.WaitOne();
			Console.WriteLine("Second operation is completed!");
		}

		private static AutoResetEvent _workerEvent = new AutoResetEvent(true);
		private static AutoResetEvent _mainEvent = new AutoResetEvent(true);

		static void Process(int seconds)
		{
			Console.WriteLine("Starting a long running work...");
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("Work is done!");
			_workerEvent.Set();
			Console.WriteLine("Waiting for a main thread to complete its work");
			_mainEvent.WaitOne();
			Console.WriteLine("Starting second operation...");
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("Work is done!");
			_workerEvent.Set();
		}
	}
}


## ManualResetEventSlim 생성자 사용

using System;
using System.Threading;

/// <summary>
/// 이번 에제는 스레드간의 신호를 더 유연하게 만드는 방법에 대해 알아보자
/// 
/// </summary>
namespace Chapter2.Recipe5
{
	class Program
	{
		static void Main(string[] args)
		{
			///
			///
			/*
			 * 메인 프로그램을 시작하면 먼저 manualresetecentslim 생성자의 인스턴스를 생헌한다. 
			* 이생성자로 작업하는 전체 과정이 사람이 출입구를 통과하는 것과 매우 비슷하다.
			* 이전 예제에서 들여다본 autoresetevent 는 회전 문 처럼 동작 하며 오직 한사람만 한번에 통과를 허용 한다.
			* menualreseteventslim은 직접 reset 메서드를 호출 전까지 게속 열어둔다.
			* 
			*
			 */
			var t1 = new Thread(() => TravelThroughGates("Thread 1", 5));
			var t2 = new Thread(() => TravelThroughGates("Thread 2", 6));
			var t3 = new Thread(() => TravelThroughGates("Thread 3", 12));
			t1.Start();
			t2.Start();
			t3.Start();
			Thread.Sleep(TimeSpan.FromSeconds(6));
			Console.WriteLine("The gates are now open!");
			_mainEvent.Set();
			Thread.Sleep(TimeSpan.FromSeconds(2));
			_mainEvent.Reset();
			Console.WriteLine("The gates have been closed!");
			Thread.Sleep(TimeSpan.FromSeconds(10));
			Console.WriteLine("The gates are now open for the second time!");
			_mainEvent.Set();
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Console.WriteLine("The gates have been closed!");
			_mainEvent.Reset();
		}

		static void TravelThroughGates(string threadName, int seconds)
		{
			Console.WriteLine("{0} falls to sleep", threadName);
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("{0} waits for the gates to open!", threadName);
			_mainEvent.Wait();
			Console.WriteLine("{0} enters the gates!", threadName);
		}

		static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);
	}
}



## CountdownEvent 생성자 사용
## Barrier 생성자 사용
## ReaderWriterLockSlim 생성자 사용
## SpinWait 생성자 사용
