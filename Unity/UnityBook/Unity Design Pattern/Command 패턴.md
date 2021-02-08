# 커맨드 패턴


# Command
실행될 기능에 대한 인터페이스
실행될 기능을 execute 메서드로 선언함
# ConcreteCommand
실제로 실행되는 기능을 구현
즉, Command라는 인터페이스를 구현함
# Invoker
기능의 실행을 요청하는 호출자 클래스
# Actor
ConcreteCommand에서 execute 메서드를 구현할 때 필요한 클래스
즉, ConcreteCommand의 기능을 실행하기 위해 사용하는 수신자 클래스



예시]

Invoker 
     BehaviourCommand의 execute를 요청하는 호출자 클래스 


Command
    실행될 기능을 execute 메서드로 선언
    실행한 명령을 취소 하는 Undo 메서드 선언

BehaviourCommand
    command 인터페이스를 구현,
    실제로 실행을 하는 기능을 구현함



input -> x버튼
input -> b버튼
input -> ㅁ버튼
input -> a버튼

일떄 커맨드의 변경 및 취소를 보다 용이하게 하기 위함

기존의 버튼 의 기능을  뺴돌려서

Actor안에 메소드로 구현