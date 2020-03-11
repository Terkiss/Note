# getSystemService(Context.LAYOUT_INFLATER_SERVICE)
    주어진 매개변수에 대응되는 안드로이드가 제공하는 시스템- 레벨 서비스를 요청함
    시스템 - 레벨 서비스란 단순하게 메모리내에 클래스의 인스턴스를 생성하여 프로그램 프로그램 구현 하는 방법이 아님 시스템 내에서 제공하는 
    디바이스나 안드로이드 프레임 워크 내 기능을 다른 애플리케이션과
    공유하고자 시스템으로부터 객체를 얻을떄 사용함

    WINDOW_SERVICE ("window")
    사용자 지정 창을 배치할 수 있는 최상위 창 관리자. 반환 객체는 윈도우 매니저
    
    SENSOR_SERVICE
    센서 접근할 수 있는 SensorManager

    LAYOUT_INFLATER_SERVICE ("layout_inflater")
    이 컨텍스트에서 레이아웃 리소스를 부풀리기 위한 레이아웃 인플레터를 반환 합니다.
    레이아웃 리소스를 인플레이트 하는 LayoutInflater

    TELEPHONY_SERVICE
    단말기내 전화를 관리하는 Telephony Manager


    ACTIVITY_SERVICE ("activity")
    시스템의 글로벌 활동 상태와 상호 작용하기 위한 활동 관리자를 반환 합니다
    시스템 내부의 액티비티 상태를 파악하는 Activity 매니저

    POWER_SERVICE ("power")
    전력 관리를 제어하는 PowerManager 반환 합니다.
    파워를 관리하는 PowerManager

    ALARM_SERVICE ("alarm")
    선택한 시간에 정보를 수신하기 위한 알람 매니저를 반환 합니다.
    주어진 시간에 경고 메시지(Intent 라는 객체)를 발신하는 AlarmManager

    NOTIFICATION_SERVICE ("notification")
    사용자에게 배경 이벤트를 알리기 위한 Notification Manager 를 반환 합니다.
    
    KEYGUARD_SERVICE ("keyguard")
    AKeyguardManager 를 제어하는 keyguard manager 를 반환 합니다.
   
    LOCATION_SERVICE ("location")
    위치(예: GPS) 업데이트를 제어하는 위치 관리자. 를 반환 합니다.
    gps를 통한 위치 서비스를 제공하는 location 관리자

    SEARCH_SERVICE ("search")
    A SearchManager for handling search.
    검색을 사용하는 SearchManager

    AUDIO_SERVICE
    오디오를 관리하는 AudioMnager

    VIBRATOR_SERVICE ("vibrator")
    A Vibrator for interacting with the vibrator hardware.
    진동 관리하는 Vibrator

    CONNECTIVITY_SERVICE ("connection")
    A ConnectivityManager for handling management of network connections.
    네트워크 연결을 관리하는 Connectivity Manager

    INPUT_METHOD_SERVICE
    입력 방법을 관리하는 InputMethodManager
    
    IPSEC_SERVICE ("ipsec")
    A IpSecManager for managing IPSec on sockets and networks.
    
    WIFI_SERVICE ("wifi")
    A WifiManager for management of Wi-Fi connectivity. On releases before NYC, it should only be obtained from an application context, and not from any other derived context to avoid memory leaks within the calling process.
    Wi-Fi 연결을 관리하는 WifiManager

    WIFI_AWARE_SERVICE ("wifiaware")
    A WifiAwareManager for management of Wi-Fi Aware discovery and connectivity.
    
    WIFI_P2P_SERVICE ("wifip2p")
    A WifiP2pManager for management of Wi-Fi Direct connectivity.
    
    INPUT_METHOD_SERVICE ("input_method")
    An InputMethodManager for management of input methods.
    
    UI_MODE_SERVICE ("uimode")
    An UiModeManager for controlling UI modes.
    UI 모드를 저절하는 UiModeManager

    DOWNLOAD_SERVICE ("download")
    HTTP 다운로드를 요청하는 다운로드 관리자
    HTTP 다운로드 작업을 수행하는 DownloadManager

    BATTERY_SERVICE ("batterymanager")
    A BatteryManager for managing battery state
    
    JOB_SCHEDULER_SERVICE ("taskmanager")
    A JobScheduler for managing scheduled tasks
    
    NETWORK_STATS_SERVICE ("netstats")
    A NetworkStatsManager for querying network usage statistics.
    
    HARDWARE_PROPERTIES_SERVICE ("hardware_properties")
    A HardwarePropertiesManager for accessing hardware properties.




# startActivityForResult(Intent intent, int Code );

#intent.setClassName(package, packName);

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
