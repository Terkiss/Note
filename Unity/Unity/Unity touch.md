
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began: // 시작중
                    Debug.Log("TouchPhase Began!");

                    break;

                case TouchPhase.Moved: // 움직이는중
                    Debug.Log("TouchPhase Moved!");

                    break;

                case TouchPhase.Stationary: // 유지중
                    Debug.Log("TouchPhase Stationary!");

                    break;

                case TouchPhase.Ended: // 끝남 
                    Debug.Log("TouchPhase Ended!");

                    break;

                case TouchPhase.Canceled:
                    Debug.Log("TouchPhase Canceled!");

                    break;
            }
        }
