# 커맨드 패턴





Invoker 
     BehaviourCommand의 execute를 요청하는 호출자 클래스 

Command
    실행될 기능을 execute 메서드로 선언
    실행한 명령을 취소 하는 Undo 메서드 선언

BehaviourCommand
    command 인터페이스를 구현,
    실제로 실행을 하는 기능을 구현함

Actor
    BehaviourCommand클래스에서 execute 메서드를 구현 할떄 필요한 클래스
    BehaviourCommand의 기능을 수행하기 위해 사용자는 수신자 클래스

예시]

input -> x버튼
input -> b버튼
input -> ㅁ버튼
input -> a버튼

일떄 커맨드의 변경 및 취소를 보다 용이하게 하기 위함

기존의 버튼 의 기능을  뺴돌려서

Actor안에 메소드로 구현

BehaviourCommand는 인터페이스를 구현하고
인터페이스가 요구하는 execute 메서드를 구현하기 위해 뺴돌린 actor의 개별 메서드를
사용해서 execute 메서드를 구현

Command 
    명령을 한번 감싸기 위한 추상 인터페이스


</br><img src ="https://github.com/Terkiss/Note/blob/master/image/85.PNG?raw=true" width = "380" height = "380"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>