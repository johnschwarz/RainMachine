using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    private static AudioManager Instance;
    public static AudioManager instance
    {
        get { return Instance; }
    }


    private AudioSource _AudioS;

    [SerializeField]
    AudioClip[] clickArray;

    [SerializeField]
    AudioClip[] leverArray;

    [SerializeField]
    AudioClip[] typeArray;

    void Awake () {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _AudioS = gameObject.GetComponent<AudioSource>();
    }

    public void PlayClick()
    {
        _AudioS.PlayOneShot(clickArray[Random.Range(0, clickArray.Length)]);
    }

    public void PlayLever()
    {
        _AudioS.PlayOneShot(leverArray[Random.Range(0, leverArray.Length)]);
    }

    public void PlayTypeLog()
    {
        _AudioS.PlayOneShot(typeArray[Random.Range(0, typeArray.Length)]);
    }
}
