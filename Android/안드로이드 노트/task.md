* 엑티비티 매니저가 가진 엑티비티 스택 정보 보기 
adb shell dumpsys activity activities > activity

* 디바이스 선택
adb devices

디바이스 선택 해서 설
adb -s [210.96.43.65:1234] shell dumpsys activity activities > activity


테스크 생성
Intent.FLAG_ACTIVITY_NEW_TASK
    Intent.FLAG_ACTIVITY_MULTIPLE_TASK

액티비티 실행모드
standard
    호출 을 맘대로 해도 다 받아줌
    단 리소를 많이 쓴다.

singleTop
싱글탑 -> 상단 에 중복이 제거 
싱글탑 항시적용
 FLAG_ACTIVITY_SINGGLE_TOP
 분기를 통해 싱글탑 적용