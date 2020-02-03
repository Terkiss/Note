


abstract 
    하나이상이 클래스 안에 존재 할경우 클래스 에 붙여야함
    abstract는 반드시 자식단에서 구현을 해야함
    상속을통한 abstract 구현 돌리기를 할수 있다.

    용도
        설계와 구현 분리
            서브 클래스마다 목적에 맞게 추상 메소드를 다르게 구현
                다형성 실현
            슈퍼클래스에서는 개념 정의
                서브 클래스마다 다른 구현이 필요한메소드는 추상 메소드로 구현
            
            각서브 클래스에서 구체적 행위 구현

abstract class Calculator
{
    
}

문제의 상황
    주민 번호 이름 저장 -> void addPersonalInfo(...)
    주민번호 이용 검색 -> String searchName(...)

약속
abstract class PersonalNumberStorage
{
    public abstract void addPersonalInfo(...);
    public abstract String searchName(...);
}

결과
public static void main(...)
{
    PersonalNumberStorage storage = new (a 사가 구현한 크래스 이름)
    storage.addPersonalInfo(...)
    Storage.searchName(...) // 이러한 연결 고리

}

ppt 14p

모든 메소드가 abstract로 선언된 클래스는 interface로 정의가 가능하다!

인터페이스는 자체적인 메소드를 못가짐 -> 가질수 있게 됨

인터페이스 내에 선언된 변수는 무조건 public static final로 선언됨

인터페이스 내에 선언된 메소드는 무조건 public abstract로 선언됨

인터페이스도 참조 변수 선언 가능하고 메소드 오버라이딩 원칙 그대로 적용



interface의 활용

윈도우 -> 프린터 1, 프린터 2 , 프린터 3 ,프린터 4

implements : 구현 하다.

interface가 상속 할경우
    구현 하지 않고 그대로 부모를 가져옴

    extends 가 interface에서 나올수 있는 경우는 좌측값 과 우측값이 interface 일경우에 한함

interface 특성
    상속과 구현 동시에 가능
    둘 이상의 인터페이스 구현 가능

자바의 인터페이스 
    interface const

public interface Car
{
    int MAXIMUM_SPEED = 260;  // static final 생략
    int moveHandle(int degred);  // abstract public 생략
    int changeGear(int gear); // abstract public 생략
}



인터페이스 요소
    디폴트 메소드 와 정적 메소드 
        인터페이스를 구현한 여러 클래스에서 사용할 메서드가 클래스마다 같은 기능을 제공하는 경우가 있습니다.

        인터페이스에서 정적 메소드를 쓸수 있다.
        정적 메소드를 작성시에 쓸 private 메소드도 만들수 있다.


pt 28슬라이드

무엇 인가를 표시 하른 용도로도 인터페이스는 사용됨
obj instanceof class 
    해당 형으로 형변환 가능하면 true

    마커 인터페이스
        전통적으로 ~able 가 붙은 게 보통적인 마커 인터페이스

pt 30슬라이드
abstract 클래스와 interface
 추상 클래스와 인터페이스 비교
    추상 클래ㅡㅅ와 인터페이스는 내부에 선언된 추상 메소드를 갖고 있으므로 자기 자신을 인스턴스 화해서 객체로 사용 불가

    반드시 자식 클래스나 구현 클래스를 통해서 자신의 기능을 사용가능

    추상클래스나 인터페이스 모두 객체 지향 프로그래밍의 다형성 잘보여줌
    추상클래스는 인터페이스와 달리 클래스 내부에 완전형태 선언 해 사용가능 추상 클래스는 -> 좀더 클래스에 가까움

    인터페이스는 자바 클래스의 단일 상속 특징과 달리 다중 구현을 할수 있음









클래스 안의 클래스 선언하기
    내부 클래스 선언부의 형태와 사용법에 따른 네가지 종류

    인스턴스 내부 클래스
        외부클래스 안에 클래스를 선언하는 것
        보통 인스턴스 내부 클래스를 줄여서 그냥 내부 클래스


        선행조건 
            바깥에 있는 외부 클래스가 인스턴스가 되어야 내부 클래스를 인스턴스 가 가능
            외부 클래스 생성 후 생성
            정적 변수 전역 메서드 사용 x
            외부 클래스의 참조 변수를 이용 내부 클래스 사용i
            내부 클래스가 private 라면 외부 클래스에서만 사용

    정적 내부 클래스
        정적 내부 클래스 
            내부 클래스의 선언부에 static 키워드가 붙음
            클래스 에 static 가 붙을경우 변수와 메서드도 static 이 붙을수 있음
            static 은 외부클래스 형식으로 해줌 

            인스턴스 변수는 정적 내부 클래스에 있긴 하지만  인스턴스를 해야 사용가능.
    
    지역 내부 클래스
        지역 내부 클래스 -> 지역 변수 처럼 메서드 내부에 클래스를 정의 해 사용
        메소드가 종료 되도 게속 실행 상태로 존재 가능

    익명 객체
        부모 클래스 이름으로 상속을 받는 하위 클래스.

        부모 클래스 변수 = new 부모 클래스(){...}
        인터페스 변수 = new 인터페이스(){...}




