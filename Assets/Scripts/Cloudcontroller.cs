using UnityEngine;
using System.Collections;

public class Cloudcontroller : MonoBehaviour {

    [SerializeField] Sprite[] cloudArray;
    SpriteRenderer spriteR;
    Rigidbody2D ridig2D;

    [SerializeField]
    Color sunny;

    [SerializeField]
    Color drizzle;

    [SerializeField]
    Color rainy;

    [SerializeField]
    Color storm;

    public const string LAYER_NAME1 = "Skyforeground";
    public const string LAYER_NAME2 = "Background";
    public const string LAYER_NAME3 = "Midground";
    public const string LAYER_NAME4 = "Foreground";
    

    public int sortingOrder = 0;

    Transform scale;

    int[] startScale = { -1, 1 };

    void Start ()
    {
        
        scale = gameObject.transform;
        scale.localScale = new Vector3(startScale[Random.Range(0, startScale.Length)], 1, 1);

        ridig2D = gameObject.GetComponent<Rigidbody2D>();

        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = cloudArray[Random.Range(0, cloudArray.Length)];

        int ran = Random.Range(0, 4);
        if (ran == 0)
        { spriteR.sortingLayerName = LAYER_NAME1; }
        if (ran == 1)
        { spriteR.sortingLayerName = LAYER_NAME2; }
        if (ran == 2)
        { spriteR.sortingLayerName = LAYER_NAME3; }
        if (ran == 3)
        { spriteR.sortingLayerName = LAYER_NAME4; }
        
        if (EnvironmentController.Instance.currentWindLevel == 0)
        {            ridig2D.velocity = new Vector2(-0.5f, 0);
        }

        if (EnvironmentController.Instance.currentWindLevel == 1)
        {            ridig2D.velocity = new Vector2(Random.Range(-0.06f,-0.04f) , 0);        }

        if (EnvironmentController.Instance.currentWindLevel == 2)
        {            ridig2D.velocity = new Vector2(Random.Range(-0.1f, -0.07f), 0);        }

        if (EnvironmentController.Instance.currentWindLevel == 3)
        {            ridig2D.velocity = new Vector2(Random.Range(-0.14f, -0.08f), 0);        }


        if (RainController.instance.isNoRain)
        { spriteR.color = sunny; }
        if (RainController.instance.isLiteRain)
        { spriteR.color = drizzle; }
        if (RainController.instance.isMedRain)
        { spriteR.color = rainy; }
        if (RainController.instance.isHeavyRain)
        { spriteR.color = storm; }

    }
    
}
