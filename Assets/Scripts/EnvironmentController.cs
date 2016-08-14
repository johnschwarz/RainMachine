using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {


   

    //theMetersAsGameObjects
    [SerializeField]
    GameObject WindMeter;
    [SerializeField]
    GameObject TempMeter;
    [SerializeField]
    GameObject OzoneMeter;
    [SerializeField]
    GameObject CoreMeter;

    [SerializeField]
    Sprite[] PlantConditionSprites;

    [SerializeField]
    SpriteRenderer CurrentPlantCondition;

    public float WELLBEING;

    public float motorPower;

    public float currentTem ;
    public float currentWind;
    public float currentOzon;
   

    public bool isWindLocked;
    public bool isTempLocked;
    public bool isOzoneLocked;

    public int currentCloudLevel;
    public int currentWindLevel;
    public int currentRainLevel;
   

    private float currentAngleOfMeter;

    public float minResetTime;
    public float maxResetTime;

    private static EnvironmentController _Instance;
    public static EnvironmentController Instance {
        get { return _Instance; }

    }

    void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        StartCoroutine(IAdjustTemp());
        StartCoroutine(IAdjustWind());
        StartCoroutine(IAdjustOzone());

        currentCloudLevel = 1;
        currentWindLevel=3;
        currentRainLevel=1;

        

    }

    public void SetWindLevel(Transform inMeterRotation)
    {
        float tempRot = inMeterRotation.rotation.z; 
        
        if (tempRot <= -0.6 && tempRot >= -0.8)
        {
            currentWindLevel = 1;
            
        }
        else if (tempRot <= -0.3 && tempRot >= -0.6)
        {
            currentWindLevel = 2;
        }
        else if (tempRot <= -0.8 && tempRot >= -0.9)
        {
            currentWindLevel = 2;
        }
        else if (tempRot <= -0.3)
        {
            currentWindLevel = 3;
        }
        else if (tempRot >= -0.9)
        {
            currentWindLevel = 3;
        }
    }
    public void SetCloudLevel(Transform inMeterRotation)
    {
        float tempRot = inMeterRotation.rotation.z;

        if (tempRot <= -0.6 && tempRot >= -0.8)
        {
            currentCloudLevel = 1;

        }
        else if (tempRot <= -0.3 && tempRot >= -0.6)
        {
            currentCloudLevel = 2;
        }
        else if (tempRot <= -0.8 && tempRot >= -0.9)
        {
            currentCloudLevel = 2;
        }
        else if (tempRot <= -0.3)
        {
            currentCloudLevel = 3;
        }
        else if (tempRot >= -0.9)
        {
            currentCloudLevel = 3;
        }
    }
    public void SetRainLevel(Transform inMeterRotation)
    {
        float tempRot = inMeterRotation.rotation.z;

        if (tempRot <= -0.6 && tempRot >= -0.8)
        {
            currentRainLevel = 1;

        }
        else if (tempRot <= -0.3 && tempRot >= -0.6)
        {
            currentRainLevel = 2;
        }
        else if (tempRot <= -0.8 && tempRot >= -0.9)
        {
            currentRainLevel = 2;
        }
        else if (tempRot <= -0.3)
        {
            currentRainLevel = 3;
        }
        else if (tempRot >= -0.9)
        {
            currentRainLevel = 3;
        }
    }

    void AdjustMeter(GameObject inMeter, float currentMeterLevel, bool inLockedCheck)
    {
        MeterController tempMeter = inMeter.GetComponent<MeterController>();
        currentAngleOfMeter = tempMeter.meterpublcTrans.rotation.z;

        if (!inLockedCheck)
        {
            if (currentAngleOfMeter > -currentMeterLevel / 100)
            {
                tempMeter.Meterpower = motorPower;
            }
            if (currentAngleOfMeter < -currentMeterLevel / 100)
            {
                tempMeter.Meterpower = -motorPower;
            }
        }
        else {
            tempMeter.Meterpower = 0;
        }
    }

    public IEnumerator IAdjustTemp()
    {
        if (isTempLocked)
        {
            yield return new WaitForSeconds(Random.Range(minResetTime, maxResetTime));
            isTempLocked = false;
            StartCoroutine(IAdjustTemp());
        }
        else
        {
            currentTem = Random.Range(4, 96);
            
            yield return new WaitForSeconds(Random.Range(1.1f, 3.5f));
            StartCoroutine(IAdjustTemp());

        }
    }
    public IEnumerator IAdjustWind()
    {
        if (isWindLocked)
        {
            yield return new WaitForSeconds(Random.Range(minResetTime, maxResetTime));
            isWindLocked = false;
            StartCoroutine(IAdjustWind());
        }
        else
        {
            currentWind = Random.Range(4, 96);
            
            
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            StartCoroutine(IAdjustWind());

        }
    }
    public IEnumerator IAdjustOzone()
    {
        if (isOzoneLocked)
        {
            yield return new WaitForSeconds(Random.Range(minResetTime, maxResetTime));
            isOzoneLocked = false;
            StartCoroutine(IAdjustOzone());
        }
        else
        {
            currentOzon = Random.Range(4, 96);
           
            
            yield return new WaitForSeconds(Random.Range(3.1f, 5.7f));
            StartCoroutine(IAdjustOzone());

        }
    }
    

    void Update()
    {   
        AdjustMeter(TempMeter, currentTem, isTempLocked);
        AdjustMeter(WindMeter, currentWind, isWindLocked);
        AdjustMeter(OzoneMeter, currentOzon, isOzoneLocked);
    
        DisplayWelllbeing();
        
    }

    void DisplayWelllbeing()
    {
        if (WELLBEING >= 0)
        {
            WELLBEING = 0;
            CurrentPlantCondition.sprite = PlantConditionSprites[0];
        }

        if (WELLBEING >= -500)
        {
            CurrentPlantCondition.sprite = PlantConditionSprites[0];
        }
        else if (WELLBEING >= -1000 && WELLBEING <= -500)
        {
            CurrentPlantCondition.sprite = PlantConditionSprites[1];
        }
        else if (WELLBEING >= -2500 && WELLBEING <= -1000)
        {
            CurrentPlantCondition.sprite = PlantConditionSprites[2];
        }
        else
        {
            CurrentPlantCondition.sprite = PlantConditionSprites[3];
        }

        if (WELLBEING <= -3000)
        {
            WELLBEING = -3000;
            CurrentPlantCondition.sprite = PlantConditionSprites[3];

        }
    }


}
