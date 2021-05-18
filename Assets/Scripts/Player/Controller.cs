using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour
{
    [SerializeField] private static Controller instance = null;
    public static Controller Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("singletone error!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public struct WhichIsHand
    {
        public const string rightHand = "ControllerRight";
        public const string leftHand = "ControllerLeft";
    }

    #region 컨트롤러 키 선언
    
    [SerializeField] private SteamVR_Action_Boolean select;
    public SteamVR_Action_Boolean Select => select;
    
    [SerializeField] private SteamVR_Action_Boolean menu;
    public SteamVR_Action_Boolean Menu => menu;

    [SerializeField] private SteamVR_Action_Boolean menu2;
    public SteamVR_Action_Boolean Menu2 => menu2;

    [SerializeField] private SteamVR_Action_Boolean grab;
    public SteamVR_Action_Boolean Grab => grab;

    [SerializeField] private SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean Trigger => trigger;
    
    [SerializeField] private SteamVR_Action_Boolean turnRight;
    public SteamVR_Action_Boolean TurnRight => turnRight;
    
    [SerializeField] private SteamVR_Action_Boolean turnLeft;
    public SteamVR_Action_Boolean TurnLeft => turnLeft;

    [SerializeField] private SteamVR_Action_Boolean getMetro;
    public SteamVR_Action_Boolean GetMetro => getMetro;

    [SerializeField] private SteamVR_Action_Boolean getRecorder;
    public SteamVR_Action_Boolean GetRecorder => getRecorder;
    
    #endregion

    #region 사운드 할당과 악기 생성시 셀렉트(텔레포트) 버튼 사용을 구분짓기 위한 불값 저장소
    
    [SerializeField] private bool isPadTouch = false;
    public bool IsPadTouch
    {
        get => isPadTouch;
        set => isPadTouch = value;
    }
    
    #endregion

    #region 악기의 그랩을 위한 불 값과 게임 오브젝트 저장소
    
    [SerializeField] private bool isRightPadGrab = false;
    public bool IsRightPadGrab
    {
        get => isRightPadGrab;
        set => isRightPadGrab = value;
    }
        
    [SerializeField] private bool isLeftPadGrab = false;
    public bool IsLeftPadGrab
    {
        get => isLeftPadGrab;
        set => isLeftPadGrab = value;
    }
        
    [SerializeField] private GameObject rightGrabPad = null;
    public GameObject RightGrabPad
    {
        get => rightGrabPad;
        set => rightGrabPad = value;
    }
        
    [SerializeField] private GameObject leftGrabPad = null;
    public GameObject LeftGrabPad
    {
        get => leftGrabPad;
        set => leftGrabPad = value;
    }
    
    #endregion

    #region 메트로놈의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightMetronomGrab = false;
    public bool IsRightMetronomGrab
    {
        get => isRightMetronomGrab;
        set => isRightMetronomGrab = value;
    }
        
    [SerializeField] private bool isLeftMetronomGrab = false;
    public bool IsLeftMetronomGrab
    {
        get => isLeftMetronomGrab;
        set => isLeftMetronomGrab = value;
    }
    
    [SerializeField] private GameObject rightMetronomGrab = null;
    public GameObject RightMetronomGrab
    {
        get => rightMetronomGrab;
        set => rightMetronomGrab = value;
    }
        
    [SerializeField] private GameObject leftMetronomGrab = null;
    public GameObject LeftMetronomGrab
    {
        get => leftMetronomGrab; 
        set => leftMetronomGrab = value;
    }

    #endregion

    #region 레코더의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightRecorderGrab = false;
    public bool IsRightRecorderGrab
    {
        get => isRightRecorderGrab;
        set => isRightRecorderGrab = value;
    }
            
    [SerializeField] private bool isLeftRecorderGrab = false;
    public bool IsLeftRecorderGrab
    {
        get => isLeftRecorderGrab;
        set => isLeftRecorderGrab = value;
    }
        
    [SerializeField] private GameObject rightRecorderGrab = null;
    public GameObject RightRecorderGrab
    {
        get => rightRecorderGrab;
        set => rightRecorderGrab = value;
    }
            
    [SerializeField] private GameObject leftRecorderGrab = null;
    public GameObject LeftRecorderGrab
    {
        get => leftRecorderGrab; 
        set => leftRecorderGrab = value;
    }

    #endregion
    
    #region 메뉴의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightMenuGrab = false;
    public bool IsRightMenuGrab
    {
        get => isRightMenuGrab;
        set => isRightMenuGrab = value;
    }
            
    [SerializeField] private bool isLeftMenuGrab = false;
    public bool IsLeftMenuGrab
    {
        get => isLeftMenuGrab;
        set => isLeftMenuGrab = value;
    }
        
    [SerializeField] private GameObject rightMenuGrab = null;
    public GameObject RightMenuGrab
    {
        get => rightMenuGrab;
        set => rightMenuGrab = value;
    }
            
    [SerializeField] private GameObject leftMenuGrab = null;
    public GameObject LeftMenuGrab
    {
        get => leftMenuGrab; 
        set => leftMenuGrab = value;
    }

    #endregion
    
    #region 샘플오디오의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightSampleGrab = false;
    public bool IsRightSampleGrab
    {
        get => isRightSampleGrab;
        set => isRightSampleGrab = value;
    }
            
    [SerializeField] private bool isLeftSampleGrab = false;
    public bool IsLeftSampleGrab
    {
        get => isLeftSampleGrab;
        set => isLeftSampleGrab = value;
    }
        
    [SerializeField] private GameObject rightSampleGrab = null;
    public GameObject RightSampleGrab
    {
        get => rightSampleGrab;
        set => rightSampleGrab = value;
    }
            
    [SerializeField] private GameObject leftSampleGrab = null;
    public GameObject LeftSampleGrab
    {
        get => leftSampleGrab; 
        set => leftSampleGrab = value;
    }

    #endregion
    
    #region 램프바닥의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightRampBottomGrab = false;
    public bool IsRightRampBottomGrab
    {
        get => isRightRampBottomGrab;
        set => isRightRampBottomGrab = value;
    }
            
    [SerializeField] private bool isLeftRampBottomGrab = false;
    public bool IsLeftRampBottomGrab
    {
        get => isLeftRampBottomGrab;
        set => isLeftRampBottomGrab = value;
    }
        
    [SerializeField] private GameObject rightRampBottomGrab = null;
    public GameObject RightRampBottomGrab
    {
        get => rightRampBottomGrab;
        set => rightRampBottomGrab = value;
    }
            
    [SerializeField] private GameObject leftRampBottomGrab = null;
    public GameObject LeftRampBottomGrab
    {
        get => leftRampBottomGrab; 
        set => leftRampBottomGrab = value;
    }

    #endregion
    
    #region 램프탑의 그랩을 위한 불 값과 게임 오브젝트 저장소
              
                  [SerializeField] private bool isRightRampTopGrab = false;
                  public bool IsRightRampTopGrab
                  {
                      get => isRightRampTopGrab;
                      set => isRightRampTopGrab = value;
                  }
                          
                  [SerializeField] private bool isLeftRampTopGrab = false;
                  public bool IsLeftRampTopGrab
                  {
                      get => isLeftRampTopGrab;
                      set => isLeftRampTopGrab = value;
                  }
                      
                  [SerializeField] private GameObject rightRampTopGrab = null;
                  public GameObject RightRampTopGrab
                  {
                      get => rightRampTopGrab;
                      set => rightRampTopGrab = value;
                  }
                          
                  [SerializeField] private GameObject leftRampTopGrab = null;
                  public GameObject LeftRampTopGrab
                  {
                      get => leftRampTopGrab; 
                      set => leftRampTopGrab = value;
                  }
              
                  #endregion
                  
    #region 루프그룹의 그랩을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private bool isRightLoopGrab = false;
    public bool IsRightLoopGrab
    {
        get => isRightLoopGrab;
        set => isRightLoopGrab = value;
    }
            
    [SerializeField] private bool isLeftLoopGrab = false;

    public bool IsLeftLoopGrab
    {
        get => isLeftLoopGrab;
        set => isLeftLoopGrab = value;
    }

    [SerializeField] private GameObject rightLoopGrab = null;

    public GameObject RightLoopGrab
    {
        get => rightLoopGrab;
        set => rightLoopGrab = value;
    }

    [SerializeField] private GameObject leftLoopGrab = null;

    public GameObject LeftLoopGrab
    {
        get => leftLoopGrab;
        set => leftLoopGrab = value;
    }

    #endregion

    #region 인스트루먼트 스케일을 위한 불 값과 게임 오브젝트 저장소

    [SerializeField] private Vector3 rightScalePos;
    public Vector3 RightScalePos
    {
        get => rightScalePos;
        set => rightScalePos = value;
    }

    [SerializeField] private GameObject rightInst;
    public GameObject RightInst
    {
        get => rightInst;
        set => rightInst = value;
    }

    [SerializeField] private bool isRightScale;

    public bool IsRightScale
    {
        get => isRightScale;
        set => isRightScale = value;
    }
    
    [SerializeField] private Vector3 leftScalePos;
    public Vector3 LeftScalePos
    {
        get => leftScalePos;
        set => leftScalePos = value;
    }

    [SerializeField] private GameObject leftInst;
    public GameObject LeftInst
    {
        get => leftInst;
        set => leftInst = value;
    }

    [SerializeField] private bool isLeftScale;

    public bool IsLeftScale
    {
        get => isLeftScale;
        set => isLeftScale = value;
    }

    #endregion
}
