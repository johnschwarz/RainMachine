using UnityEngine;
using System.Collections;

public class MeterButtonPressedController : MonoBehaviour {

    SpriteRenderer spriteR;
    public Sprite UpButton;
    public Sprite DownButton;

    [SerializeField]
    Transform SelfTrans;
    
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = UpButton;
    }

    void OnMouseDown()
    {
        StartCoroutine(IPressButton());
    }

    IEnumerator IPressButton()
    {
        AudioManager.instance.PlayClick();
        if (gameObject.CompareTag("wind"))
        {
            spriteR.sprite = DownButton;
            if (EnvironmentController.Instance.isWindLocked == false)
            {
                EnvironmentController.Instance.isWindLocked = true;
               
                EnvironmentController.Instance.SetWindLevel(SelfTrans);
                LogController.Instance.SetLog("Wind LOCKED. \n");
                // Debug.Log(EnvironmentController.Instance.currentWindLevel);

            }
            yield return new WaitForSeconds(0.3f);
            spriteR.sprite = UpButton;
            AudioManager.instance.PlayClick();
        }


        if (gameObject.CompareTag("temp"))
        {
            spriteR.sprite = DownButton;
            if (EnvironmentController.Instance.isTempLocked == false)
            {
                EnvironmentController.Instance.isTempLocked = true;
                EnvironmentController.Instance.SetCloudLevel(SelfTrans);
                LogController.Instance.SetLog("Cloud LOCKED. \n");

                // Debug.Log(EnvironmentController.Instance.currentCloudLevel);
            }
            yield return new WaitForSeconds(0.3f);
            spriteR.sprite = UpButton;
            AudioManager.instance.PlayClick();

        }
        if (gameObject.CompareTag("ozone"))
        {
            spriteR.sprite = DownButton;
            if (EnvironmentController.Instance.isOzoneLocked ==false) { 
                EnvironmentController.Instance.isOzoneLocked = true;
                EnvironmentController.Instance.SetRainLevel(SelfTrans);
                LogController.Instance.SetLog("Rain LOCKED. \n");
                // Debug.Log(EnvironmentController.Instance.currentRainLevel);
            }
            yield return new WaitForSeconds(0.3f);
            spriteR.sprite = UpButton;
            AudioManager.instance.PlayClick();

        }
    }

}
