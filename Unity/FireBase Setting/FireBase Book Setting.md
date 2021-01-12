# 0. 파이어 베이스 콘솔접속
    [Fire base Console]
    https://console.firebase.google.com/u/0/project/unityfacebookfire/authentication/providers

# 1. 파이어 베이스 에서 프로젝트를 추가
    프로젝트명 입력
    프로젝트 생성

# 2. 생성된 프로젝트에서 앱을 추가후 시작하기 영여의 유니티 상자를 클릭


#3. 안드로이드 앱으로 등록
    
    패키지 명과 앱 닉네임을 입력 합니다.
        ex]
        com.UniFace.UnityFaceBookFire

# 4. 유니티 로 돌아와서 원하는 fire base sdk를 설치
   여기서는 auth와 database를 설치할 것입니다.

   [Fire base sdk download ]
   https://firebase.google.com/download/unity?authuser=0

    다운로드시 dotnet 3 버전과 dotnet 4 버전, 2개의 다른 버전의 sdk 가 동봉 되어 있습니다

    프로젝트는 dotnet 4 버전을 사용 할 것입니다.  

    unity -> Assets -> import Pakage -> custom Pakage -> firebase sdk -> dotnet4 -> firebaseAuth.unityPakage 클릭
    unity -> Assets -> import Pakage -> custom Pakage -> firebase sdk -> dotnet4 -> firebaseDatabase.unityPakage 클릭

# 5. Fire base 콘솔
    빌드 -> Authentication -> sign - in method -> 로긴 제공 업체 로이동 합니다.
    이메일/비밀번호      사용설정
    google              사용설정
    Play게임            사용설정



# 6. Google Api Console

    [Google Api Console]
    https://console.developers.google.com/?pli=1
    Api - > 사용자 인증정보 해당 프로젝트의 웹 애플케이션의 클라 아이디와 클라 시크릿 키를 복사 합니다.

    복사한 키를 Fire Base 콘솔의 Authentication 항목의 sign in method 안에 있느 play 게임에 복사 붙여 넣기 합니다.


# 7. Google play Console 이동

    Google play COnsole -> 모든앱 -> 앱만들기 

    앱 이름 
    앱이 게임 인지
    앱이 무료인지 유료인지 
    설정후 저장

    왼쪽 햄버거 클릭후 성장 play 게임 서비스 
        설정 및 관리
            설정 클릭 
                네 게임에서 이미 google api를 사용 중입니다 클릭
                    클라우드 프로젝트에서 해당하는 파이어 베이스 프로젝트를 선택
                        사용자 인증 정보 추가
                            유형 게임서버 선택
                                파이어 베이스의 프로젝트 명으로 지정
                                    인증 Oauth 클라이언트 지정

            리더 보드 클릭
                리더 보드 생성


# 8. Unity

## KeyStore 파일 생성
    File -> Build Settings -> Android -> Player Settings ->
    Publishing Settings -> keyStore Manager -> keystore Custom ->
    Create now -> anywere -> 적절한 위치와 암호 지정 -> KeyStore Check On ->
    암호 입력 


## KeyStore 지문 확인
  keytool -list -v -keystore 경로를 포함한 키스토어파일명
  </br>
<img src ="https://github.com/Terkiss/Note/blob/master/image/80.PNG?raw=true" width = "720" height = "480"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>




# 9. Firebase Console

    프로젝트 설정 내앱-> 디지털 지문 추가(자세한건 아래 클릭)
    
  </br><img src ="https://github.com/Terkiss/Note/blob/master/image/80.PNG?raw=true" width = "720" height = "480"> <br>&emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;  </img>

    저장이 끝난 후 sdk 설정 및 구성에서 새로운 google -service.json을 받아서 Unity내의 Asset폴더에 넣어준다.



# 10. Unity

    [Google Play Games plugin for Unity] -- 매뉴얼 
    https://github.com/playgameservices/play-games-plugin-for-unity

    Windows -> google game play -> setup -> android setup 

