1111[222](#);


# 메소드 오버 로딩과 String 클래스



# 스트링 메소드 
<!-- 
    여기는 추후 자바 api 문서로 점프 
-->
    > 문자열 연산을 위한 기본 메소드 
    





# String 클래스의 인스턴스 생성
    * java는 큰 따옴표로 묶여서 표현되는 문자열 모두 인스턴스화
    * 문자열은 String 이라는 이름의 클래스로 표현된다.


특정 형식으로 포매팅
    > 문자열 포매팅
        문자열의 형태를 정해진 문법 변환
    > 특정 형식으로 문자열을 출력하고 싶을떄 fotmat() 사용
https://docs.oracle.com/javase/9/docs/api/java/lang/String.html





# StringBuilder
 * StringBuilder 는 문자열의 저장 및 변경을 위한 메모리 공간을 지니는 클래스
 * 문자열 데이터의 추가를 위한 append와 삽입을 위한 insert메소드 제공

스트링 빌더는 자동으로 println 메소드를 만나면 tostring 호출
클래스안에 toString 오버 라이드 함수 작성 시 println 만나면 toString 호출
ex


    



