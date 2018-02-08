using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CustomButton
{

    //private string[] imagePath;
    public ButtonState buttonState;
    public Button button;
    
    
    public CustomButton(Button abutton, ButtonState state)
    {
        button = abutton;
        buttonState = state;
    }
}


public class KeyboardMgt : MonoBehaviour
{

    private Idea firstSlot;
    private Idea secondSlot;

    private Idea[] m_messageSentTable;
    private CustomButton[] m_ButtonArray;

    public string[] ideaStrings { get; set; }
    private Button[] buttonArray;
    private ButtonState[] lastButtonStates;
    private int activate_count;
    public bool deactivated = false;

    // Use this for initialization
    void Start()
    {
        firstSlot = Idea.VOID;
        secondSlot = Idea.VOID;
        m_messageSentTable = new Idea[Globals.SYMBOL_NB_PER_MSG];
        m_ButtonArray = new CustomButton[Globals.SYMBOL_NB_MAX];
        lastButtonStates = new ButtonState[Globals.SYMBOL_NB_MAX];
        string fileExt = ".jpg";

        buttonArray = new Button[22];
        buttonArray = GetComponentsInChildren<Button>();

        for (int i = 0; i < Globals.SYMBOL_NB_MAX; ++i)
        {
            m_ButtonArray[i] = new CustomButton(buttonArray[i], ButtonState.NOT_CLICKED);
           // m_ButtonArray[i].buttonState = ButtonState.NOT_CLICKED;
            //m_ButtonArray[i].button = buttonArray[i];
        }


        ideaStrings = new string[Globals.SYMBOL_NB_MAX] {
            "FRIEND",
            "HUMAN",
            "ALIEN",
            "TRANSFER",
            "SIGN_SYMBOL",
            "GOD_MEANING",
            "TIME_SAND",
            "TENTACLE_LEG",
            "ENERGY_FLOW",
            "MARRIAGE_CAPTIVITY",
            "BEAUTY",
            "CRAZY_CONFUSION",
            "EARTH",
            "HOME",
            "ACTION",
            "WEAPON",
            "VISION",
            "FEAR",
            "FREDDY_MERCURY",
            "NOTHING_NOT_DEATH",
            "LIFE_POSITIVE",
            "NEED_NUTRITION",
        };

        for (int i = 0; i < Globals.SYMBOL_NB_PER_MSG; ++i)
        {
            m_messageSentTable[i] = Idea.VOID;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!deactivated)
        {
            for (int i = 0; i < Globals.SYMBOL_NB_MAX; ++i)
            {
                if (m_ButtonArray[i].button.GetComponent<Change>().getButtonState() == ButtonState.CLICKED && m_ButtonArray[i].button.GetComponent<Change>().getButtonState() != lastButtonStates[i])
                {

                    //Debug.Log("Fiest is : " + firstSlot + " second is " + secondSlot);
                    activate_count++;

                    if (firstSlot == Idea.VOID)
                        firstSlot = (Idea)i;
                    else if (secondSlot == Idea.VOID)
                        secondSlot = (Idea)i;
                    else
                        Debug.Log("ERROR");


                }
                else if (m_ButtonArray[i].button.GetComponent<Change>().getButtonState() == ButtonState.NOT_CLICKED && m_ButtonArray[i].button.GetComponent<Change>().getButtonState() != lastButtonStates[i])
                {

                    if (firstSlot == (Idea)i)
                        firstSlot = Idea.VOID;
                    else if (secondSlot == (Idea)i)
                        secondSlot = Idea.VOID;
                    else
                    {
                        //DO NOTHING
                    }
                }
                //m_ButtonArray[i] = new CustomButton(buttonArray[i], ButtonState.NOT_CLICKED);
                // m_ButtonArray[i].buttonState = ButtonState.NOT_CLICKED;

            }
            for (int i = 0; i < Globals.SYMBOL_NB_MAX; ++i)
            {
                lastButtonStates[i] = m_ButtonArray[i].button.GetComponent<Change>().getButtonState();
            }

            if (firstSlot != Idea.VOID && secondSlot != Idea.VOID)
            {
                Debug.Log("REINITITIALIZE");
                for (int i = 0; i < Globals.SYMBOL_NB_MAX; ++i)
                {
                    //Debug.Log("NOTENABLED : " + i.ToString());
                    m_ButtonArray[i].button.GetComponent<Change>().benabled = false;
                }
                m_ButtonArray[(int)firstSlot].button.GetComponent<Change>().benabled = true;
                m_ButtonArray[(int)secondSlot].button.GetComponent<Change>().benabled = true;

                GameObject.Find("AlienPanel").GetComponent<AlienMgt2>().receiveCombination((int)firstSlot, (int)secondSlot);

                StartCoroutine(reinitialize());
                deactivated = true;

                

            }
        }

    }

    IEnumerator reinitialize()
    {
        yield return new WaitForSeconds(2.0f);
        

        m_ButtonArray[(int)firstSlot].button.GetComponent<Change>().setButtonState(ButtonState.NOT_CLICKED);
        m_ButtonArray[(int)secondSlot].button.GetComponent<Change>().setButtonState(ButtonState.NOT_CLICKED);

        firstSlot = Idea.VOID;
        secondSlot = Idea.VOID;

        
        activate_count = 0;
        deactivated = false;
        for (int i = 0; i < Globals.SYMBOL_NB_MAX && i != (int)firstSlot && i != (int)secondSlot; ++i)
        {
            //Debug.Log("NOTENABLED : ");
            m_ButtonArray[i].button.GetComponent<Change>().benabled = true;
        }

    }

    Idea[] getClickedCombination()
    {
        return m_messageSentTable;
    }

 
    

}
