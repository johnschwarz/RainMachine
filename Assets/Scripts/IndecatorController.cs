using UnityEngine;
using System.Collections;

public class IndecatorController : MonoBehaviour {

    public SpriteRenderer spriteR;
    public Sprite Red;
    public Sprite Yellow;
    public Sprite Green;

    private Transform transForMeter;
    private MeterController metercontroller;

    [SerializeField]float currentAngleOfThermo;

    void Start()
    {
        metercontroller = gameObject.GetComponentInParent<MeterController>();
        transForMeter = metercontroller.meterpublcTrans;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckAndSetIndecators(transForMeter);
    }

    void CheckAndSetIndecators(Transform incontroller)
    {
        currentAngleOfThermo = incontroller.rotation.z;
        
        if (currentAngleOfThermo <= -0.6 && currentAngleOfThermo >= -0.8)
        {
            spriteR.sprite = Green;
            EnvironmentController.Instance.WELLBEING++;
        }
        else if (currentAngleOfThermo <= -0.3 && currentAngleOfThermo >= -0.6)
        {
            spriteR.sprite =  Yellow;
        }
        else if (currentAngleOfThermo <= -0.8 && currentAngleOfThermo >= -0.9)
        {
            spriteR.sprite = Yellow;
        }
        else if(currentAngleOfThermo <= -0.3)
        {
            spriteR.sprite = Red;
            EnvironmentController.Instance.WELLBEING--;
        }
        else if (currentAngleOfThermo >= -0.9)
            {
            EnvironmentController.Instance.WELLBEING--;
            spriteR.sprite = Red; }

        
    }

}
