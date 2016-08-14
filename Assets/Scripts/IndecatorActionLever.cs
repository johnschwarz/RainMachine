using UnityEngine;
using System.Collections;

public class IndecatorActionLever : MonoBehaviour {

    public SpriteRenderer spriteR;
    public Sprite Red;
    public Sprite Green;

    void Start()
    {
        spriteR.sprite = Red;
    }

    void Update()
    {
        if ( EnvironmentController.Instance.isOzoneLocked && EnvironmentController.Instance.isTempLocked && EnvironmentController.Instance.isWindLocked)
        {
            spriteR.sprite = Green;
        }
        else {
            spriteR.sprite = Red;
        }
    }
}
