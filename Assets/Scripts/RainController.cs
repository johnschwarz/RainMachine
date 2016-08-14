using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour {


    private static RainController Instance;
    public static RainController instance { get { return Instance; } }

    void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(this.gameObject); }
        else { Instance = this; }
    }


    [SerializeField]
    GameObject rainBack;

    [SerializeField]
    GameObject rainMid;

    [SerializeField]
    GameObject rainFront;

    [SerializeField]
    Animator _Anim;

    [SerializeField]    Transform rainBackTrans;

    [SerializeField]    Transform rainMidTrans;

    [SerializeField]    Transform rainFrotTrans;

    public bool isLiteRain;
    public bool isNoRain;
    public bool isHeavyRain;
    public bool isMedRain;



    public enum RainStates
    {
        soft,
        med,
        hard,
        none
    }
    void SetRainStat(RainStates rainState)
    {
        switch (rainState)
        {
            case RainStates.soft:
                rainBack.SetActive(true);
                rainMid.SetActive(false);
                rainFront.SetActive(false);
                rainBackTrans.Rotate(new Vector3(0,0,0));              
                rainMidTrans.Rotate(new Vector3(0, 0, 0));
                rainFrotTrans.Rotate(new Vector3(0, 0, 0));
                isLiteRain = true;
                isNoRain = false;
                isHeavyRain = false;
                isMedRain = false;

                break;
            case RainStates.med:
                rainBack.SetActive(true);
                rainMid.SetActive(true);
                rainFront.SetActive(false);
                rainBackTrans.Rotate(new Vector3(0, 0, 358));
                rainMidTrans.Rotate(new Vector3(0, 0, 356));
                rainFrotTrans.Rotate(new Vector3(0, 0, 0));

                isLiteRain = false;
                isNoRain = false;
                isHeavyRain = false;
                isMedRain = true;
                break;
            case RainStates.hard:
                isLiteRain = false;
                isNoRain = false;
                isHeavyRain = true;
                isMedRain = false;
                rainBack.SetActive(true);
                rainMid.SetActive(true);
                rainFront.SetActive(true);

                rainBackTrans.Rotate(new Vector3(0, 0, 358));
                rainMidTrans.Rotate(new Vector3(0, 0, 355));
                rainFrotTrans.Rotate(new Vector3(0, 0, 337));
                break;
            case RainStates.none:
                isLiteRain = false;
                isNoRain = true;
                isHeavyRain = false;
                isMedRain = false;
                rainBack.SetActive(false);
                rainMid.SetActive(false);
                rainFront.SetActive(false);
                rainBackTrans.Rotate(new Vector3(0, 0, 0));
                rainMidTrans.Rotate(new Vector3(0, 0, 0));
                rainFrotTrans.Rotate(new Vector3(0, 0, 0));
                break;
        }
    }

    public void ChangeRain(RainStates rain)
    {
        SetRainStat(rain);
    }


    void Start () {

      

        ChangeRain(RainStates.none);

    }
	

}
