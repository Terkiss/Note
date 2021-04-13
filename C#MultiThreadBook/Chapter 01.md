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

    스레드가 연산을 완료 할떄까지 메인스레드가 대기 합니다.
    

## 스레드 중단
    - 이버ㅏㄴ 예제 에서 다른 스레드 시랳ㅇ을 중단하는 방법을 알아보자


    - 예제 구현 

    using System;
    using System.Threading;
-
    namespace Chapter1.Recipe5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting program...");
                // 스레드 생성 
                Thread t = new Thread(PrintNumbersWithStatus);
                Thread t2 = new Thread(DoNothing);

                Console.WriteLine(t.ThreadState.ToString());

                t2.Start();
                t.Start();

                for (int i = 1; i < 30; i++)
                {
                    Console.WriteLine("0"+t.ThreadState.ToString());
                }
                Thread.Sleep(TimeSpan.FromSeconds(6));

                t.Abort(); // 중단 

                Console.WriteLine("A thread has been aborted");
                Console.WriteLine(t.ThreadState.ToString());
                Console.WriteLine(t2.ThreadState.ToString());
            }

            static void DoNothing()
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            static void PrintNumbersWithStatus()
            {
                Console.WriteLine("Starting...");
                Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine(i);
                }
            }
        }
    }


## 스레드 상태 조사
- 이버ㅏㄴ 예제 에서 다른 스레드 상태를 조사 하는 방법을 알아보자


    - 예제 구현 

    using System;
    using System.Threading;

    namespace Chapter1.Recipe5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting program...");
                // 스레드 생성 
                Thread t = new Thread(PrintNumbersWithStatus);
                Thread t2 = new Thread(DoNothing);

                Console.WriteLine(t.ThreadState.ToString());

                t2.Start();
                t.Start();

                for (int i = 1; i < 30; i++)
                {
                    Console.WriteLine("0"+t.ThreadState.ToString());
                }
                Thread.Sleep(TimeSpan.FromSeconds(6));

                t.Abort(); // 중단 

                Console.WriteLine("A thread has been aborted");
                Console.WriteLine(t.ThreadState.ToString());
                Console.WriteLine(t2.ThreadState.ToString());
            }

            static void DoNothing()
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            static void PrintNumbersWithStatus()
            {
                Console.WriteLine("Starting...");
                Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine(i);
                }
            }
        }
    }

## 스레드 우선순위

스레드 우선순위 예제


using System;
using System.Diagnostics;
using System.Threading;

namespace Chapter1.Recipe6
{
	class Program
	{
		static void Main(string[] args)
		{
			// 현재 스레드 우선 순위는 노멀 
			Console.WriteLine("Current thread priority: {0}", Thread.CurrentThread.Priority);
			Console.WriteLine("Running on all cores available");

			RunThreads();


			// 2초간 정지 
			Thread.Sleep(TimeSpan.FromSeconds(2));

			Console.WriteLine("Running on a single core");

			// 해당 프로세스에서 점율을 고정함 
			Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
			
			RunThreads();

		}

		static void RunThreads()
		{
			var sample = new ThreadSample();

			var threadOne = new Thread(sample.CountNumbers);
			threadOne.Name = "ThreadOne";
			var threadTwo = new Thread(sample.CountNumbers);
			threadTwo.Name = "ThreadTwo";

			threadOne.Priority = ThreadPriority.Highest;
			threadTwo.Priority = ThreadPriority.Lowest;
			threadOne.Start();
			threadTwo.Start();

			Thread.Sleep(TimeSpan.FromSeconds(2));
			sample.Stop();
		}

		class ThreadSample
		{
			private bool _isStopped = false;

			public void Stop()
			{
				Console.Write("종료 됨 ::: \n");
				_isStopped = true;
			}

			public void CountNumbers()
			{
				long counter = 0;

				while (!_isStopped)
				{
					counter++;
				}

				Console.WriteLine("{0} with {1,11} priority " +
							"has a count = {2,13}", Thread.CurrentThread.Name,
							Thread.CurrentThread.Priority,
							counter.ToString("N0"));
			}
		}
	}
}



## 포그라운드 스레드와 백그라운드 스레드


using System;
using System.Threading;





/// <summary>
/// 포그라운드 스레드와 백그라운드 스레드 예제
/// 포그라운드 스레드와 백그라운드 스레드의 개념을 소개 하고 프로구램 의 동작에 영향을 끼치는 옵션을 설정 하는 방법을 알아보자 
/// </summary>
namespace Chapter1.Recipe7
{
	class Program
	{
		static void Main(string[] args)
		{
			var sampleForeground = new ThreadSample(10);  // 포그라운드 에서 돌아가는 스레드 
			var sampleBackground = new ThreadSample(20); // 백그라운드에서 돌아가는 스레드

			var threadOne = new Thread(sampleForeground.CountNumbers);  // 스레드 1 생성
			threadOne.Name = "ForegroundThread";  // 스레드 이름 지정
			var threadTwo = new Thread(sampleBackground.CountNumbers);  // 스레드 2 생성 
			threadTwo.Name = "BackgroundThread";
			threadTwo.IsBackground = true;  // 백그라운드 스레드를 지정 

			threadOne.Start(); // 시작
			threadTwo.Start();

			/*
			 *
			 *예상 되는 실행 메인 스레드의 스레드가 종료 하고 메인스레드가 종료 되 어도 백그라운드 스레드는 게속 실행이 될것이다.
			 *
			 *실제 실행 결과는 포 그라운드 스레드의 실행은 메인스레드가 기달려주지만
			 *백그아운드 스레드의 경우 메인 스레드가 기다려 주지 않고 
			 * 프로그램을 종료 한다.
			 */
		}

		class ThreadSample
		{
			private readonly int _iterations;

			public ThreadSample(int iterations)
			{
				_iterations = iterations;  // 스레드 샘플 클래스의 반복자를 생성자 에서 지정 
			}
			public void CountNumbers()
			{
				for (int i = 0; i < _iterations; i++)  // 반복자 만큼 포를 돌면서 0.5 초간 대기하며 쓰래드 이름과 현재  i값을 출력 
				{
					Thread.Sleep(TimeSpan.FromSeconds(0.5));  // 0.5초간 진행을 멈춤
					Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
				}
			}
		}
	}
}



## 스레드에 파라밍터 전달



using System;
using System.Threading;



// 스레드에 파라미터 전달 예제
/// <summary>
/// 필요한 데이터를 다른 스레드에서 실행하는 코드를 제공하는 방법에 대해 알아 보자 
/// 또한 이작업을 함에 있ㅇ서 일반 적인 실수도 알아 보자 
/// 
/// </summary>
namespace Chapter1.Recipe8
{
	class Program
	{
		static void Main(string[] args)
		{

			var sample = new ThreadSample(10);  // 반복자와 스레드 샘플 클래스를 생성  

			var threadOne = new Thread(sample.CountNumbers);  // 스레드 와 스레드 이름 지정
			threadOne.Name = "ThreadOne";
			threadOne.Start(); // 실행 
			threadOne.Join(); // 기다림 

			Console.WriteLine("--------------------------");

			var threadTwo = new Thread(Count); // ? COUNT 메서드 실행
			threadTwo.Name = "ThreadTwo"; 
			threadTwo.Start(8); // 파라메터 전달 
			threadTwo.Join(); // 기다림

			Console.WriteLine("--------------------------");

			var threadThree = new Thread(() => CountNumbers(12));  // 스테틱 메서드 COUNTNUMBER 실행
			threadThree.Name = "ThreadThree"; // 지정
			threadThree.Start(); // 시;작 
			threadThree.Join(); // 기다림 
			Console.WriteLine("--------------------------");

			int i = 10;
			var threadFour = new Thread(() => CountNumbers(i)); // 스텍틱 메서드 PRINTNUM 실행

			threadFour.Name = "ThreadFour";
			threadFour.Start();
			i = 20;
			var threadFive = new Thread(() => CountNumbers(i));


			threadFive.Name = "ThreadFive";

			threadFive.Start();

			Console.WriteLine("--------------------------");
			/*
			 * 예상 실행 결과 
			 * 스레드 1번이 10번의 행동을 함 
			 * 
			 * 스레드 2번이 스테틱 메서드 카운트의 인자를 받아서 카운트 넘버를 호출함  이후 인자 만큼 루프를 돔
			 * 
			 * 스레드 3번이 12개의 인자를 받아서 스테틱을 함 시작함 
			 * 
			 * 4번  출력함 
			 * 
			 * 실제 출력 
			 * 스레드 1번은 매개 변수를 간접적인 방법으로 세팅 
			 * 스레드 2는 Start 메서드에 인자로 설정 이떄 인자는 한개로 제한
			 * 
			 * 스레드 3은 람다 표현식으로 인자를 설정 
			 * 
			 * 스레드 4,5는  람다 표현식의 특징, 같은 변수를 가리키면 다름
			 * 
			 * 
			 */

		}

		static void Count(object iterations)
		{
			CountNumbers((int)iterations);
		}

		static void CountNumbers(int iterations)
		{
			for (int i = 1; i <= iterations; i++)
			{
				Thread.Sleep(TimeSpan.FromSeconds(0.5));
				Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
			}
		}

		static void PrintNumber(int number)
		{
			Console.WriteLine(number);
		}

		class ThreadSample
		{
			private readonly int _iterations;

			public ThreadSample(int iterations)
			{
				_iterations = iterations;
			}
			public void CountNumbers()
			{
				for (int i = 1; i <= _iterations; i++)
				{
					Thread.Sleep(TimeSpan.FromSeconds(0.5));
					Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
				}
			}
		}
	}

	
}





## C# 의 lock 키워드로 잠그기

using System;
using System.Threading;

// c#  스레드 에서 한 스레드가 어떤 ;자원을사용할떄 다른 스드가 ㅏ동시에 사용하지 않을음ㅇ/ㅇ/
// 보장화는 방법에대해 알아 보자
// 이러한 내용을 통해  그것이 필요한 이유를 이해하고 스레드 안정성 개념에 대한 모든 것을 살펴 볼수 있다.  

/// <summary>
/// 이번 에제도 역시 비주얼 스튜디오 만 필요하다.
/// </summary>
namespace Chapter1.Recipe9
{
	class Program
	{
		static void Main(string[] args)
		{
			// 잘못된 카운터
			Console.WriteLine("Incorrect counter");

			var c = new Counter();


			// 스레드에 카운터를 할당 
			var t1 = new Thread(() => TestCounter(c));  // 스레드에 하나의 카운터 주소를 할당 했음 공유 될거 같다 
			var t2 = new Thread(() => TestCounter(c));
			var t3 = new Thread(() => TestCounter(c));
			t1.Start(); // 실행  
			t2.Start();
			t3.Start();
			t1.Join(); // 대기
			t2.Join();
			t3.Join();

			Console.WriteLine("Total count: {0}",c.Count); 
			Console.WriteLine("--------------------------");

			Console.WriteLine("Correct counter");

			var c1 = new CounterWithLock();

			t1 = new Thread(() => TestCounter(c1));
			t2 = new Thread(() => TestCounter(c1));
			t3 = new Thread(() => TestCounter(c1));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();
			Console.WriteLine("Total count: {0}", c1.Count);


			// 실행 예측
			/*
			 * 잘못된 카운터  방식에서는 값이 공유가 되므로 스레드 마다 다 다를것 이다.\
			 * 반면 제대로 된 방법에서는 0 이 출력 될것이다.
			 * 
			 * 실제 실행
			 * 예상한대로 동작 했으나 설명이 부족했다.
			 * 잘못된 계수기 방식에서는 하나의 값을 1,2,3 번 스레드가 동시 접근하므로 어떤 값이 나올지는 예측이 불가능하다.
			 * 반면에 제대로된 계수기는 증감 메서드를 한번 호출시마다 실행 하고 그것을 lock 키워드로 객체를 잠궈 버리므로 0이란 값의 출력을 보장 할 수 있다.
			 * 
			 */
		} 

		static void TestCounter(CounterBase c)
		{
			for (int i = 0; i < 100000; i++)
			{
				c.Increment();
				c.Decrement();
			}
		}


		// 카운터 클래스 
		class Counter : CounterBase
		{
			public int Count { get; private set; }

			public override void Increment()
			{
				Count++;
			}

			public override void Decrement()
			{
				Count--;
			}
		}

		class CounterWithLock : CounterBase
		{
			private readonly object _syncRoot = new Object();

			public int Count { get; private set; }

			public override void Increment()
			{
				lock (_syncRoot)  // 오브젝트 잠구기 동시에 하나만 이용가능 
				{
					Count++;
				}
			}

			public override void Decrement()
			{
				lock (_syncRoot) // 동시 하나만 이용가능 
				{
					Count--;
				}
			}
		}

		abstract class CounterBase
		{
			public abstract void Increment();

			public abstract void Decrement();
		}
	}
}


## moniter 생성자로 잠그기

using System;
using System.Threading;

/// <summary>
/// 스레드의 교착상태 오류 예제
/// lock 키워드의 적절한사용으로 교착상태를 얻을수 있다.
/// 
/// </summary>
namespace Chapter1.Recipe10
{
	class Program
	{
		static void Main(string[] args)
		{
			object lock1 = new object();
			object lock2 = new object();

			// 스레드 생성 과 시작 동시 진행 멈출수 없음 기타 조작 불능 
			new Thread(() => LockTooMuch(lock1, lock2)).Start(); // lock1 잠구고 lock 취득 대기

			lock (lock2)  // lock2 잠구고
			{
				Thread.Sleep(1000);
				Console.WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");
				if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5))) //lock1 취득 대기, 5초동안 취득이 안되면 time out 실행 
				{
					Console.WriteLine("Acquired a protected resource succesfully");
					
				}
				else
				{
					Console.WriteLine("Timeout acquiring a resource!");
				}
			}

			new Thread(() => LockTooMuch(lock1, lock2)).Start();

			Console.WriteLine("----------------------------------");
			lock (lock2)
			{
				Console.WriteLine("This will be a deadlock!");
				lock (lock2) // 자기가 점유 하고 있으면 실행 가능 아마도 이 클래스가 종료 하기 전까지 실행 할거 같다 .
				{
                    Console.WriteLine("호에에");

				}
				Thread.Sleep(1000);
				lock (lock1)
				{
					Console.WriteLine("Acquired a protected resource succesfully");
				}
			}
			
		}

		static void LockTooMuch(object lock1, object lock2)
		{
			lock (lock1)
			{
				Thread.Sleep(1000);
				lock (lock2);
			}
		}
	}
}




## 예외 처리    