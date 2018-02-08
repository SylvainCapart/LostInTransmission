using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonState
{
    CLICKED,
    NOT_CLICKED
};

public class ButtonMgt : MonoBehaviour {

    private ButtonState buttonState;
    private GameObject buttonImage;
    public Button button;
    private string fileExt;
	// Use this for initialization
	void Start () {
        buttonState = ButtonState.NOT_CLICKED;
        buttonImage = GameObject.Find(Application.dataPath + "/Resources/IdeaButtons/NOT_CLICKED_" + this.gameObject.name + fileExt);
        fileExt = ".jpg";
        button = GetComponent<Button>();
        //gameObject.GetComponent<Image>().image = GameObject.Find("C:/Users/Sylvain/Documents/Unity Projects/Steampunk2/Assets/Resources/IdeaButtons/NOT_CLICKED_FRIEND.jpg");
        //GameObject newI = GameObject.Find("C:/Users/Sylvain/Documents/Unity Projects/Steampunk2/Assets/Resources/IdeaButtons/NOT_CLICKED_FRIEND.jpg");
        //button.GetComponent<Image>().sprite = newI.sprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeButtonState()
    {
        
        Debug.Log("change state");
        if (buttonState == ButtonState.NOT_CLICKED)
        {
            buttonState = ButtonState.CLICKED;
          /*  Sprite newSprite = GameObject.Find(Application.dataPath + "/Resources/IdeaButtons/CLICKED_" + this.gameObject.name + fileExt).sprite;
            Image theImage = GameObject.Find("NOT_CLICKED" + this.gameObject.name).GetComponent<Image>();
            theImage.sprite = newSprite;​
            //gameObject.GetComponent<Image>().image = GameObject.Find(Application.dataPath + "/Resources/IdeaButtons/CLICKED_" + this.gameObject.name + fileExt);*/
        }
        else
        {
            buttonState = ButtonState.NOT_CLICKED;
           // gameObject.GetComponent<Image>() = GameObject.Find(Application.dataPath + "/Resources/IdeaButtons/NOT_CLICKED_" + this.gameObject.name + fileExt);
        }

 

    }
}
