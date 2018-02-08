
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour {

    public Button b1;
    public ButtonState buttonState;
    public bool benabled = true;
   

    //public delegate void keyboardClickEvent(string name);
    //public static event keyboardClickEvent delegateClick;

    // Use this for initialization
    void Start () {
        buttonState = ButtonState.NOT_CLICKED;
        
        b1 = GetComponentInParent<Button>();
        
        b1.image.sprite = Resources.Load<Sprite>("Sprites/" + b1.name + "_NOT_CLICKED");
        b1.onClick.AddListener(onclick);
        //b1.onClick.AddListener(delegate { GetComponent<KeyboardMgt>().keyboardClickEvent(GetComponentInParent<Button>().name); });
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onclick()
    {
        if (benabled)
        {

            if (buttonState == ButtonState.NOT_CLICKED)
            {
                b1.image.sprite = Resources.Load<Sprite>("Sprites/" + b1.name + "_CLICKED");
                buttonState = ButtonState.CLICKED;
            }
            else
            {
                buttonState = ButtonState.NOT_CLICKED;
                b1.image.sprite = Resources.Load<Sprite>("Sprites/" + b1.name + "_NOT_CLICKED");


            }
        }

        GetComponent<AudioSource>().Play();
        //GetComponent<KeyboardMgt>().keyboardClickEvent("fklzeklez" + GetComponent<Button>().name);

        //delegateClick(b1.name);


    }

    public ButtonState getButtonState()
    {
        return buttonState;
    }

    public void setButtonState(ButtonState newState)
    {
        if (!benabled)
            return;

            Debug.Log("SETBUTTON");
        buttonState = newState;
        b1.image.sprite = Resources.Load<Sprite>("Sprites/" + b1.name + "_NOT_CLICKED");
    }


}
