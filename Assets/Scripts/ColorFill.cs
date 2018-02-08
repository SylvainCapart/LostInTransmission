
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorFill : MonoBehaviour
{
    public Color lerpedColor = Color.white;
    private Gradient g;
    public Texture2D texture;
    private void Start()
    {/*
        
             g = new Gradient();
             GradientColorKey[] gck = new GradientColorKey[2];
             GradientAlphaKey[] gak = new GradientAlphaKey[2];
             gck[0].color = Color.red;
             gck[0].time = 0.0F;
             gck[1].color = Color.cyan;
             gck[1].time = 1.0F;

             gak[0].alpha = 1.0F;
             gak[0].time = 0.0F;
             gak[1].alpha = 1.0F;
             gak[1].time = 1.0F;
             g.SetKeys(gck, gak);
             //GetComponentInParent<Image>().color = g.Evaluate(0.5);

         
        Color[] colorArray = new Color[100];
        for (int i = 0; i < 100; ++i)
        {
            //Debug.Log("t : " + (float)i / 100f);
            colorArray[i] = new Color(g.Evaluate((float)i/100f).r*255, g.Evaluate((float)i / 100f).g * 255, g.Evaluate((float)i / 100f).b * 255, g.Evaluate((float)i / 100f).a * 255) ;

        }
         texture = new Texture2D(100, 100);
        
         for (int i = 0; i < 100; ++i)
         {
             for (int j = 0; j < 100; ++j)
             {
                texture.SetPixel(j, i, colorArray[i]);
                Debug.Log("getPixel : " + texture.GetPixel(i,j));
            }
         }
         

        //GetComponentInParent<Image>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0), 1);
        GetComponentInParent<Image>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0), 1);*/
    }

    void Update()
    {
       // texture = Resources.Load<Texture2D>("Sprites/FRIEND_CLICKED");
        //GetComponent<SpriteRenderer>().material.mainTexture = texture; // Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0), 1);
        /*Color leftBoundCol = Color.green;
        Color rightBoundCol = Color.cyan;
        float leftBound = 0f;
        float rightBound = 100f;
        float lerpParam = Mathf.InverseLerp(leftBound, rightBound, transform.position.z);*/
        //GetComponentInParent<Image>().color = Color.Lerp(leftBoundCol, rightBoundCol, transform.position.x);
        //GetComponentInParent<Renderer>().material.color = Color.Lerp(leftBoundCol, rightBoundCol, transform.position.x);
        //GetComponentInParent<Image>().color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 0));


    }

}
