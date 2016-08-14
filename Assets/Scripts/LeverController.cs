using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeverController : MonoBehaviour {

    [SerializeField]
    Transform endTrans;

    [SerializeField]
    Transform startTrans;

    [SerializeField]
    Color sunny;

    [SerializeField]
    Color partlycloudy;


    [SerializeField]
    Color cloudy;

    [SerializeField]
    Color stormy;

    private float endY;
    private Transform tempStart;
    List<GameObject> listOfAllSpritesForDarkness;


    bool LeverIsActive = false;

    IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        //transform.position = target;
        yield return new WaitForSeconds(overTime);

        if (LeverIsActive)
        {
            LogController.Instance.SetLog("Generating weather... \n");
            StartCoroutine(MoveObject(endTrans.position, startTrans.position, overTime));
            AudioManager.instance.PlayLever();
            yield return new WaitForSeconds(overTime);
            LeverIsActive = false;

            if (EnvironmentController.Instance.isOzoneLocked && EnvironmentController.Instance.isTempLocked && EnvironmentController.Instance.isWindLocked)
            {
                EnvironmentController.Instance.isOzoneLocked = false;
                EnvironmentController.Instance.isTempLocked = false;
                EnvironmentController.Instance.isWindLocked = false;
                yield return new WaitForSeconds(1);
                LogController.Instance.SetLog("... \n");
                yield return new WaitForSeconds(1.4f);
                SetWeather(EnvironmentController.Instance.currentWindLevel, EnvironmentController.Instance.currentRainLevel, EnvironmentController.Instance.currentCloudLevel);

                EnvironmentController.Instance.WELLBEING -= 1750;

                StartCoroutine(EnvironmentController.Instance.IAdjustOzone());
                StartCoroutine(EnvironmentController.Instance.IAdjustTemp());
                StartCoroutine(EnvironmentController.Instance.IAdjustWind());
            }
            else {
                yield return new WaitForSeconds(0.3f);
                LogController.Instance.SetLog("...\n");
                yield return new WaitForSeconds(1.2f);
                LogController.Instance.SetLog("Operation Failed! Ensure gauges are LOCKED. \n");
            }
        }
    }

    void Start () {
        transform.position = startTrans.position;
	}

	
    void OnMouseDown()
    {
        if (LeverIsActive != true && EnvironmentController.Instance.WELLBEING >= -500)
        {
            AudioManager.instance.PlayLever();
            StartCoroutine(MoveObject(startTrans.position, endTrans.position, 0.2f));
            LeverIsActive = true;
            
        }
        else
        {
            //Debug.Log("Status not safe.  Lever disabled.");
            LogController.Instance.SetLog ( "Status: not SAFE.  Lever DISABLED. \n");
        }
    }

    void ChangeColorOfEverything(Color inColor)
    {
        listOfAllSpritesForDarkness = new List<GameObject>();
        listOfAllSpritesForDarkness.AddRange(GameObject.FindGameObjectsWithTag("ObjectToChange"));

        foreach (GameObject i in listOfAllSpritesForDarkness)
        {
            SpriteRenderer tempSprite =          i.GetComponent<SpriteRenderer>();
            tempSprite.color = inColor;
        }
    }


    void SetWeather(int wind, int rain, int clouds)
    {
        if (wind == 1)
        {
            //Debug.Log("A light breeze");
            LogController.Instance.SetLog("Wind: level 1 \n");
        }
        if (wind == 2)
        {
            //Debug.Log("A strong force blows");
            LogController.Instance.SetLog("Wind: level 2 \n");
        }
        if (wind == 3)
        {
            LogController.Instance.SetLog("Wind: level 3 \n");
        }

        if (rain == 1)
        {
            

            int tempRainOnOrOff = Random.Range(0, 2);
            if (tempRainOnOrOff == 0)
            {
                RainController.instance.ChangeRain(RainController.RainStates.soft);
                ChangeColorOfEverything(partlycloudy);
                LogController.Instance.SetLog("Rain: level 1 \n");
            }
            else {
                RainController.instance.ChangeRain(RainController.RainStates.none);
                ChangeColorOfEverything(sunny);
                LogController.Instance.SetLog("Rain: level 0 \n");
            }
            

        }
        if (rain == 2)
        {
            LogController.Instance.SetLog("Rain: level 2 \n");
            RainController.instance.ChangeRain(RainController.RainStates.med);
            ChangeColorOfEverything(cloudy);
        }
        if (rain == 3)
        {
            LogController.Instance.SetLog("Rain: level 3 \n");
            RainController.instance.ChangeRain(RainController.RainStates.hard);
            ChangeColorOfEverything(stormy);
        }

        if (clouds== 1)
        { LogController.Instance.SetLog("Clouds: level 1 \n");
            WeatherController.instance.SpawnMultipleClouds(4);
        }
        if (clouds == 2)
        { LogController.Instance.SetLog("Clouds: level 2 \n");
            WeatherController.instance.SpawnMultipleClouds(10);
        }
        if (clouds == 3)
        { LogController.Instance.SetLog("Clouds: level 3 \n");
            WeatherController.instance.SpawnMultipleClouds(18);
        }
    }
}
