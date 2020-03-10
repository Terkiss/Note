# public void startActivity(Start)
    새로운 액티비티 실행 합니다.

# public void startActivityForResult (Intent intent, int requestCode)
    작업이 완료되면 결과를 원하는 활동을 시작하십시오. 이 활동이 종료되면 주어진 requestCode로 onActivityResult() 메소드가 호출된다. 음성 requestCode를 사용하는 것은 startActivity(Intent)를 호출하는 것과 같다(활동은 하위 활동으로 시작되지 않는다).
    