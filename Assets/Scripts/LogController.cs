using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogController : MonoBehaviour {
    [SerializeField]
    Text _LogText;

    public Text logTextPublic;
    private static LogController _Instance;
    public static LogController Instance
    {
        get { return _Instance; }

    }

    [SerializeField]
    RectTransform windowsize;

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

        logTextPublic = _LogText;

       
    }

    void Start()
    {
        StartCoroutine(IBOOT());
    }

    IEnumerator IBOOT()
    {
        yield return new WaitForSeconds(0.4f);
        SetLog("Booting up...\n");
        yield return new WaitForSeconds(1.2f);
        SetLog("...\n");
        yield return new WaitForSeconds(1f);
        SetLog("Operation Finished.\n");
    }

    public void SetLog(string inText)
    {
        logTextPublic.text += inText;
        AudioManager.instance.PlayTypeLog();
    }





}
