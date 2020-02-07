# getSystemService(Context.LAYOUT_INFLATER_SERVICE)

# startActivityForResult(Intent intent, int Code );

# protected  void  onActivityResult(int requstCode, int resultCode, Intent data)
    액티비티가 종료되면 호출되는 콜백 메소드

# putExtra(...)
    인텐트에 데이타를 저장

# get...Extra(...)
    인텐트에 저장된 데이타를 형식에 맞게 가져옴

# setResult(..., ...);
    응답 하는 것
    op 1 : 응답 코드
    op 2 : 인텐트

# finish()
    액티비티를 종료 합니다
