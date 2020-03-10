MediaPlayer 이용



MediaPlayer는 음원뿐 아니라 영상 재생에도 사용되는 클래스입니다. 영상을 재생할 때는 화면 출력이 되어야 하므로 SurfaceView를 준비해야 하지만, 음원 재생은 특별한 뷰 없이 MediaPlayer만으로 간단하게 재생할 수 있습니다. 만약 음원을 재생할 때 재생이나 정지 버튼과 프로그래스바 등을 출력해야 한다면 별도의 뷰를 이용해 개발자가 직접 준비해야 합니다.



mediaPlayer=MediaPlayer.create(this, R.raw.sound);

mediaPlayer.start();



위의 코드는 간단하게 리소스의 음원을 재생하는 예입니다. 그런데 음원 파일이 외장 메모리나 서버에 있을 때도 있습니다. 이때는 setDataSource ( ) 함수로 음원을 지정합니다.



mediaPlayer = new MediaPlayer();

mediaPlayer.setDataSource(this, Uri.parse(url));



파일일 때는 setDataSource ( ) 함수에 String 타입으로 파일 경로를 지정하여 사용합니다.



mediaPlayer.setDataSource(filePath);



리소스 파일은 대부분 간단한 효과음 정도를 사용하므로 파일 크기도 작아 리소스 파일을 지정한 후 바로 재생해도 별문제는 없습니다. 하지만 외장 메모리나 서버의 음원이면 로딩하여 재생할 수 있기까지 시간이 걸릴 수 있습니다. 이때 음원 로딩 명령을 따로 내리고 재생이 가능한 상태에서 재생 명령을 수행합니다.



음원을 로딩하려면 prepare ( )와 prepareAsync( ) 두 함수를 사용할 수 있습니다. 음원을 prepare ( ) 함수로 로딩하면 재생을 준비하는 동안 다른 작업을 수행하지 못하지만, prepareAsync( ) 함수는 다른 작업을 함께 수행할 수 있습니다. prepare( ) 함수를 이용하면 재생 가능한 상태로 로딩되었을 때 OnPreparedListener 이벤트를 발생해줍니다.



mediaPlayer.setOnPreparedListener(new MediaPlayer.OnPreparedListener() {

@Override

public void onPrepared(MediaPlayer mp) {

mediaPlayer.start();

}

});



MediaPlayer에 등록하는 이벤트는 다음과 같습니다.



OnCompletionListener: 미디어 재생 완료 시 이벤트
OnErrorListener: 재생 에러 발생
OnPreparedListener: 재생 가능한 상태로 로딩된 상태
OnBufferingUpdateListener: 버퍼링 이벤트
OnVideoSizeChangedListener: 비디오 크기 변경 이벤트


MediaPlayer에서 제공하는 함수들을 이용하여 다양한 제어 및 정보를 추출할 수 있습니다.



start(): 재생 시작
stop(): 정지
prepare(): 준비
pause(): 일시 정지
release(): 메모리 해제
seekTo(): 재생 위치 지정
getCurrentPosition(): 재생 위치
getDuration(): 재생 시간
getVideoHeight():영상 높이값
getVideoWidth():영상 너비값
setLooping():반복 설정
setVolumn():볼륨 설정


