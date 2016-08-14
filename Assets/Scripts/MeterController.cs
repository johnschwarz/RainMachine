using UnityEngine;
using System.Collections;

public class MeterController : MonoBehaviour {
    
    private HingeJoint2D _MeterHinge;
    private JointMotor2D _Holder;
    
    public Transform meterpublcTrans;

    private float meterJointSpeed;
    public float Meterpower;

    public IndecatorController indecatorControllr;
    

    void Start()
    {
        indecatorControllr = gameObject.GetComponentInChildren<IndecatorController>();
        _MeterHinge= gameObject.GetComponentInChildren<HingeJoint2D>();
        _Holder = _MeterHinge.motor;

        
    }

    void Update()
    {
        _Holder.motorSpeed = Meterpower;
        _MeterHinge.motor = _Holder;
    }
}
