# REST API 개념 과 호출 예제 


## REST 정의 
### 정의는 중요하지
REST는 REpresentational State Transfer(대표적인 상태 전달?)의 약자로, 

HTTP 프로토콜로 데이터를 전달하고 웹 서비스를 만들기 위한 아키텍처 패턴입니다.

즉, 웹에 존재하는 모든 리소스에 고유한 URI를 부여해 활용하는 것으로, 자원을 정의하고 자원에 대한 주소를 지정하는 방법론을 의미합니다.

여기서 리소스란 REST 아키텍처의 핵심 요소로서 웹 사이트, 블로그, 이미지, 음악, 이용자, 지도, 검색결과 등 웹에서 다른 이들과 공유하고자 개방된 모든 자원을 의미합니다. 해당 자원에 대한 CRUD(Create, Read, Update, Delete) 작업을 HTTP의 기본 메소드인 POST/GET/PUT/DELETE 로 처리할 수 있습니다.


## REST 가 대두된 환경

    애플리케이션의 복잡도가 증가하면서 어플리 케이션을 어떻게 분리하고 통합 하느냐가 주요 이슈 가 됨.

    이에 자바 쪽 진영에서는 과거 ejb(Enterprise java beans) , SOA(serverce oriented architecture) 에 최근에 rest 가 떠오르고 있음

    또 멀티 플랫폼에 대한 대응을 위해 (웹 + 모바일 웹, 아이폰, 안드로이드 등)



## REST 특징

### 1) Uniform Interface (유니폼 인터페이스)

Uniform Interface는 URI로 지정한 리소스에 대한 조작을 통일되고 한정적인 인터페이스로 수행하는 아키텍처 스타일을 말합니다.

​

### 2) Stateless (무상태성)

REST는 무상태성 성격을 갖습니다. 다시 말해 작업을 위한 상태정보를 따로 저장하고 관리하지 않습니다. 세션 정보나 쿠키정보를 별도로 저장하고 관리하지 않기 때문에 API 서버는 들어오는 요청만을 단순히 처리하면 됩니다. 때문에 서비스의 자유도가 높아지고 서버에서 불필요한 정보를 관리하지 않음으로써 구현이 단순해집니다.

​

### 3) Cacheable (캐시 가능)

REST의 가장 큰 특징 중 하나는 HTTP라는 기존 웹표준을 그대로 사용하기 때문에, 웹에서 사용하는 기존 인프라를 그대로 활용이 가능합니다. 따라서 HTTP가 가진 캐싱 기능이 적용 가능합니다. HTTP 프로토콜 표준에서 사용하는 Last-Modified태그나 E-Tag를 이용하면 캐싱 구현이 가능합니다.

​

### 4) Self-descriptiveness (자체 표현 구조)

REST의 또 다른 큰 특징 중 하나는 REST API 메시지만 보고도 이를 쉽게 이해 할 수 있는 자체 표현 구조로 되어 있다는 것입니다.

​

### 5) Client - Server 구조

REST 서버는 API 제공, 클라이언트는 사용자 인증이나 컨텍스트(세션, 로그인 정보)등을 직접 관리하는 구조로 각각의 역할이 확실히 구분되기 때문에 클라이언트와 서버에서 개발해야 할 내용이 명확해지고 서로간 의존성이 줄어들게 됩니다.

​

### 6) Layered system (계층형 구조)

REST 서버는 다중 계층으로 구성될 수 있으며 보안, 로드 밸런싱, 암호화 계층을 추가해 구조상의 유연성을 둘 수 있고 PROXY, 게이트웨이 같은 네트워크 기반의 중간매체를 사용할 수 있게 합니다.

​

### -> 더 많은 읽을 거리 

https://blog.ndepend.com/rest-vs-restful/

https://mygumi.tistory.com/55

https://brainbackdoor.tistory.com/53

https://meetup.toast.com/posts/92

https://www.slipp.net/wiki/pages/viewpage.action?pageId=12878219



### RESTful API

RESTful API에서 -ful은 접미사로 ~의 성격을 지닌, ~의 경향이 있는 의 뜻을 나타냅니다. 고로 RESTful API는 REST의 설계적 지침, 특징을 잘 지킨 API(Application Programming Interface)라 할 수 있겠습니다.

-> RESTful한 API란
​https://beyondj2ee.wordpress.com/2013/03/21/%EB%8B%B9%EC%8B%A0%EC%9D%98-api%EA%B0%80-restful-%ED%95%98%EC%A7%80-%EC%95%8A%EC%9D%80-5%EA%B0%80%EC%A7%80-%EC%A6%9D%EA%B1%B0/


### RESTful API 클라이언트 예제

via Unity

-> https://github.com/drowsy-n/unity-restful-api-example