



    데이터 베이스의 이론
    자료 기지 또는 자료틀 보통 DB 라고 약칭 동시에 복수의 적용 업무를 지원 할 수 있도록 복수 이용자의 요구에 호응 해서 데이터를 받아 들이고 저장 공급하기 위해 일정한 구조에 따라서 편성된 데이터 의 집합

    데이터 베이스의 특징

        데이터의 중복성을 최소 화 할수 있다.
            데이터가 중복이 되어 있으면 내용을 수정 해야 할경우 중복된 내용을 하나하나 수정해야 한다 이떄 중복을 줄이면 잘못된 내용 하나만 수정 하여 저장 하면됨 

        데이서의 일관성을 유지할수 있다.
            삽입, 삭제, 갱신, 생성 후에도 저장된 데이터가 변함없이 일정

        데이터의 무결성을 유지 할수 있다.
            부적절한 자료가 입력되어 동일한 내용에 대하여 서로 다른 데이터가 저장되는 것을 허용하지 않는 성질

        데이터의 독립성을 유지할수 있다.
            데이터의 일관성성이 유지하기 위해서는 데이터의 구조나 접근 방식이 바뀔 경우 이를 사용하는 모든 프로그램이 그에 맞게 수정되어야 하고 반대로 프로그램의 내용이 바뀌어도 그프로그램과 관련된 모든 데이터 파일을 수정 해야 한다.

        데이터의 공유성을 최대화 할수 있다.
            데이터 베이스는 조직의 구성원들이 공동으로 소유하고 이용하므로 데이터를 통합 하여 관리 가 가능함

        데이터의 보안성을 보장 할수 있다.
            데이터 베이스는 저장된 데이터의 중요도와 성격에 따라서 다른 등급의 보안 유지 기능을 제공함
            따라서 각 관리자는 등급에 맞는 적당한 권한(데이터 검색, 삭제, 생성, 수정)등 
            다르게 설정 가능!@

        데이터를 표준화 하여 관리할 수 있다.
            데이터 베이스를 공유하는 사용자는 서로간에 데이터의 가독성과 처리의 효율성을 위하여 데이터를 표준화 하여 사용함!



    데이터 베이스종류
        1) 계층형 데이터 베이스
        2) 네트워크형 데이터 베이스
        3) 관계형 데이터 베이스
        4) NoSQL 데이터 베이스 

    무슨일 하는지
        데이터 베이시는 여러응용 시스템들의 통합된 정보들을 저장 하여 운영할수 있는 공용 데이터
        들의 묶음,
        데이터 베이스는 정보를 수집하고 보관하기 위한 시스템 으로 , 파일 입출력 보다 향상 되게 데이터를 접근하고 관리할수 있다.

        
     dbms 특징
관계형 데이터 베이스
    장점
        * 다양한 용도로 사용이 가능, 일반적으로 높은 성능 가능(범용/ 고성능)
        * 데이터의 일관성 보증
        * 정규화에 따른 갱신 비용 최소화
    
    단점
        * 대량의 데이터 입력 처리
        * 갱신이 발생한 테이블의 인덱스 생성 및 스키마 변경
        * 컬럼의 확장의 어려움
        * 단순히 빠른 결과

    주요 제품 종류
        * Oracle / Oreacle
        * MS-SQL Server /Microsoft
        * MySQL / Orcle(SunMicroSystems)
        * DB2 /IBM
        * Infomix / IBM
        * Sysbase / Sysbase
        * Derby / APache 
        * SQLite / Opensource

    NoSQL 데이터 베이스
        * SQL 을 사용 하지 않는 다는 의미의 데이터 베이스 





     데이터 베이스를 만들고

# 테이블 3개 ERD 그리기
두 개의 테이블이 서로의 행에 대해서 여러개로 연관 되어 있는 상태를 다대다 관꼐라고 함!

<img src ="https://github.com/Terkiss/Note/blob/master/image/61.PNG?raw=true" width = "480" height = "270"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>


다대다(n:m) 구현

논리적 으로 다대다 관계의 표현은 가능하지만 2개의 테이블 만으로 구현하는 것은 불가능 함! 다대다 관계를 실제로 구현하기 ㅜ이해선 각 테이블의 primary key를 외래키로 참조하고 있는 연결 테이블을 사용해야함! 이를 erd 로 표현시 다음과 같음

<img src ="https://github.com/Terkiss/Note/blob/master/image/62.PNG?raw=true" width = "480" height = "270"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>

'학생 테이블' 과 ' 학생_수업테이블' 이 일대다 관계로 연관되어 있고, '학생_수업테이블'과 '수업테이블'이 다대일 관계로 연관되어 있다.



예를들어 '철수'라는 학생은 '국어', '영어', '수학' 3가지의 수업을 수강하고 있고, '수학'이라는 수업은 '철수', '영희', '미자' 라는 학생을 수용 하고 있습니다. 예제를 이용해서 데이터를 3개의 테이블에 입력하면 아래와 같습니다.

<img src ="https://github.com/Terkiss/Note/blob/master/image/63.PNG?raw=true" width = "720" height = "360"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>


sql 로 테이블 만들기 
CREATE TABLE NAME
(
    'NAME' CARCHAR(19) NOT NULL
    'NAME2' VARCHAR(50) 
    Primary Key(NAME)
    CONSTRAINT 제약조건이름
    FOREIGN KEY (외래키 필드 명)
    REFERENCES 테이블이름(기본키)
)

속성이 2개식 있음 조인 
SELECT M.NAME, G.NAME FROM member as m
INNER JOIN group as G
on g.name = m.name
where g.name = "홀리딱";



데이터 입력 수정 * 기본
데이터 입력
INSERT INTO membertbl
(name, int, address)
values 
('name', 0, '집이야 간');


데이터 수정 
UPDATE membertbl
set name = 22;
where name = "name"


데이터 삭제 검색

데이터 삭제
DELETE FROM membertbl
WHERE name = "name"

데이터 검색
SELECT NAME FROM membertbl 
WHERE name = "1";


물리 계층 : 실제 장비들을 연결 하기 위한 연결장치 // 허브,리피터
2. 데이터 링크 계층 : 오류와 흐름을 제거하여 신뢰성 있는 데이터를 전송 //브리지, 스위치
3. 네트워크 계층 :  다수의 중개 시스템 중 올바른 경로를 선택하도록 지원 //라우터
4. 전송 계층 : 송신, 수신 프로세스 간의 연결  TCP/IP UDP
5. 세션 계층 : 송신, 수신 간의 논리적 연결 //호스트
6. 표현 계층 : 코드 문자 등을 번역하여 일관되게 전송하고 압축, 해제, 보안 기능도 담당 //호스트
7. 응용 계층 : 사용자 친화 관경 제공(이메일, 웹 등) //호스트
    


TCP
    신뢰할수 있는 데이터 교환이 필요한 경우에 사용하는 통신
    ack 라고 부르는 응답을 발신 측에 되돌려 보내기 떄문에 송신한 데이터가 수신측에 전달되엇는지 확인가능

UDP
    TCP와 달리 ack 와 같은 응답을 송신측에 되돌려 보내지 않음 신뢰성을 포기하는 대신 응답하는 절차가 생략 되는 만큼
    더빠른 속도로 전송을 처리 할수 있어 실시간 데이터 전송이 필요한 음성 통신 애플리케이션 등에서 많이 사용

ARP
    이더넷 환경에서 IP 어드레스 정보를 활요하여 수신지의 이더넷 어드레스를 알아내는 프로토콜

    허브의 단점과 스위치의 장점

스위치
3계층 스위치 4계층 스위치 7계층 스위치 있음
라우팅 세션로드 밸런싱 애플ㅇ리케이션 로드 밸런싱
보안 기능 적용
    장점 
        사용 가능한 네트워크 대역폭을 증가
        업무로드를 감소 시키고 해당 컴퓨터에게 보내지는 데이터만 받도록 함!
        네트워크 성능을 향상 시킴
        가장 작은 충돌 도메인 제공
    
    단점
        허브나 브리지의 비하여 많은 처리 비용듬
        스위치를 통한 네트워크 접속 문제의 역 추적 힘듬
        브로드 캐스팅 트래픽 필터링 하지 않음
    
라우팅
    
    모든 라우터는 브로드 캐스트 전송을 X
    로컬과 원격 접속을 동시 지원
    여분의 컴포넌트를 통해 높은 수준의 네트워크 오류 허용 제공
    내부 라우터는 자율 LAN 내부의 노드 사이에 데이터를 관리
    보더 라우터는 WAN 구간을 가진 자율 LAN에 연결
    
    정적 라우팅 
        두노드 사이의 최단 경로를 자동으로 계산 전달
    
    장점 
        서로 다른 네트워크 아키텍처간에 연결 제공
        토큰링 -> 이더넷
        네트워크 접근에 대한 최적 경로 설정
        최소 충돌 도메인 생성
        최소 브로드 캐스트 도메인 생성

    단점
        라우팅 프로토콜에 의해서만 동작함!
        허브 브리지 스위치 보다 비용이 훨훨 많이듬!
        라우팅 테이블 업데이트에 대역폭 소모함!
        큰 사이즈의 패킷 필터링과 분성은 Latency를 증가 시키는 요인









create database girlgroupDB;
use girlgroupDB;

create table groupTBL
(
	groupname varchar(10),
    number int,
    debut date,
	primary key(groupname)
);


create table memberTBL
(
	num int auto_increment,
    groupname varchar(10),
    singer char(5) not null,
    age int,
    primary key(num),
    constraint koko foreign key(groupname) references grouptbl(groupname)
);

alter table memberTBL add birth date unique;
alter table memberTBL add photo blob ;

INSERT INTO groupTBL(groupName, number, debut)
VALUES ('twice', 9, '2015-10-20');

insert into memberTBL
(
	groupname,
    singer,
    age,
    birth,
    photo
)
values
(
	'twice',
    '나연',
    '24',
    '1995-09-22',
     LOAD_FILE('f:/sql/a.jpg')
);

insert into memberTBL
(
	groupname,
    singer,
    age,
    birth,
    photo
)
values
(
	'twice',
    '모모',
    '23',
    '1996-11-09',
     LOAD_FILE('f:/sql/b.jpg')
);



INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '사나', '23', '1996-12-29', LOAD_FILE('f:/sql/b.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '지효', '22', '1997-02-01', LOAD_FILE('f:/sql/d.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '미나', '22', '1997-03-24', LOAD_FILE('f:/sql/e.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '다현', '21', '1998-05-28', LOAD_FILE('f:/sql/b.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '채영', '20', '1999-04-23', LOAD_FILE('f:/sql/c.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('twice', '쯔위', '20', '1999-06-14', LOAD_FILE('f:/sql/d.jpg')  );





INSERT INTO groupTBL(groupName, number, debut)
VALUES ('itzy', 6, '2019-2-12');



INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('itzy', '예지', '19', '2000-05-26', LOAD_FILE('f:/sql/a.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('itzy', '리아', '19', '2000-07-21', LOAD_FILE('f:/sql/b.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('itzy', '류진', '18', '2001-04-17', LOAD_FILE('f:/sql/c.jpg')  );

INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('itzy', '채령', '18', '2001-06-05', LOAD_FILE('f:/sql/d.jpg')  );


INSERT INTO memberTBL (groupname, singer, age, birth, photo)
VALUES ('itzy', '유나', '16', '2003-12-09', LOAD_FILE('f:/sql/e.jpg')  );


select * from membertbl;
select LOAD_FILE('F:/sql/a.jpg');
