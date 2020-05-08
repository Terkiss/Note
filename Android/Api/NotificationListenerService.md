# public abstract class NotificationListenerService extends Service

# java.lang.Object
##   ↳	android.content.Context
### 	   ↳	android.content.ContextWrapper
#### 	 	   ↳	android.app.Service
##### 	 	 	   ↳	android.service.notification.
######                  NotificationListenerService


이서비스는 알림이 게시되거나 순위가 바뀌거나 제거될떄 시스템으로 부터 호출을 받습니다

이클래스를 상속 받으려면 매니페스트에 권한을 선언 을 해줘야함!
그리고 intent filter의  SERVICE_INTERFACE action을 포함 해줘야함!

 <service android:name=".NotificationListener"
          android:label="@string/service_name"
          android:permission="android.permission.BIND_NOTIFICATION_LISTENER_SERVICE">
     <intent-filter>
         <action android:name="android.service.notification.NotificationListenerService" />
     </intent-filter>
 </service>

서비스가 작업을 수행하기전에 onListenerConnected() 이벤트를 기달려야함!

requestRebind(android.content.ComponentName) 메서드는 유일한 그것은 안전한 호출 방법 onListenerConnected() 되기전에 또는 onListenerDIsconnected();

알림수신기는 android Q 이하에서는 ACTIVITYMANAGER#ISLOWRAMDEVICE() 기기에서는 바인딩과 시스템 엑세를 못합니다 .


시스템을 또한 작업프로필에서 실되는 모든것을 무시합니다.

DevicePolikcyManager 클래스는 작업 프로필에서 발생하는 알림을 차단 합니다.


빌드 버전이 N인것들은 앞으로 콜백 메서드는 메인 스레드에서 호출 됩니다.
