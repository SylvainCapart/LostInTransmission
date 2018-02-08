
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlienMgt2 : MonoBehaviour
{

    private Idea[] m_messageSentTable;
    private Idea[] m_lastMessage;
    private AlienState m_alienState;
    public AudioClip[] clipArray;

    public static int m_happiness;
    public static int m_hungry;
    public static int m_confusion;
    private static int m_countUsedComb;

    private string reactionStr = "0    1    1    0    0    6 0    2    1    0    0    6 0    3    1    0    0    6 0    9    0    0    1    0 0    11    -2    0    0    0 0    12    1    0    0    0 0    3    0    1    0    0 1    13    1    0    0    0 0    16    1    0    0    0 0    14    0    1    0    0 0    15    -2    0    0    0 0    17    0    1    0    0 1    18    2    0    0    3 0    19    -1    0    0    0 0    20    1    0    0    3 0    21    0    0    2    0 1    2    0    0    0    6 1    3    0    0    1    2 1    4    1    0    0    0 1    5    -2    0    0    1 1    6    0    -1    0    2 1    7    0    0    1    4 1    8    0    0    1    4 1    9    0    0    1    5 1    10    0    -1    0    3 1    11    0    1    0    0 1    12    0    2    0    0 1    13    0    -1    0    0 1    14    0    0    0    1 1    15    -2    0    0    1 1    16    1    0    0    3 1    17    -1    0    0    5 1    18    0    -2    0    3 1    19    -1    0    0    6 1    20    1    0    0    0 1    21    0    0    2    4 2    4    0    -1    0    0 2    5    2    0    0    18 2    6    0    1    0    2 2    7    0    -1    0    6 2    8    0    0    1    4 2    9    -2    0    0    5 2    10    2    0    0    0 2    11    -1    0    0    0 2    13    0    -1    0    2 2    14    0    1    0    1 2    15    -1    0    0    1 2    16    0    1    0    0 2    17    -1    0    0    1 2    18    1    0    0    3 2    19    -2    0    0    1 2    20    1    0    0    4 2    21    -1    0    0    4 3    4    0    -1    0    0 3    4    0    -1    0    0 3    6    0    -1    0    2 3    7    0    -1    0    6 3    8    0    0    -1    4 3    9    0    2    0    5 3    10    -1    0    0    3 3    11    0    2    0    0 3    12    0    -1    0    0 3    13    0    -1    0    2 3    14    0    1    0    1 3    15    -1    0    0    1 3    16    0    -1    0    6 3    18    -2    0    0    3 3    19    -2    0    0    1 3    20    2    0    0    0 3    21    0    0    2    4 4    5    0    1    0    6 4    6    0    -1    0    2 4    7    0    -1    0    6 4    8    0    -1    0    3 4    9    0    -1    0    5 4    10    0    -1    0    3 4    11    0    2    0    0 4    12    0    -1    0    3 4    13    0    -1    0    6 4    14    0    -1    0    1 4    15    0    -1    0    1 4    16    0    -1    0    6 4    17    0    -1    0    1 4    18    0    -2    0    3 4    19    0    -2    0    0 4    20    0    2    0    0 4    21    0    0    2    4 5    6    0    -1    0    2 5    7    0    -1    0    6 5    9    -1    0    0    5 5    11    0    1    0    0 5    12    -1    0    0    5 5    15    -1    0    0    1 5    18    2    0    0    3 5    19    0    -1    0    2 5    20    0    1    0    2 5    21    0    0    2    4 6    7    0    1    0    2 6    9    -1    0    0    5 6    12    0    0    1    5 6    16    0    -1    0    0 6    19    0    -1    0    2 6    20    1    0    0    6 7    8    0    -1    0    1 7    9    -1    0    0    5 7    10    2    0    0    6 7    13    0    -1    0    6 7    14    10    0    0    6 7    15    0    -1    0    1 7    16    0    -1    0    6 7    19    -1    0    0    6 7    21    0    0    1    4 8    9    0    0    1    5 8    12    0    0    -1    2 8    14    0    1    0    1 8    17    -1    0    0    0 8    18    2    0    0    3 8    19    0    2    0    0 8    20    0    -1    0    2 8    21    0    0    2    4 9    10    -1    0    0    5 9    12    0    0    1    5 9    13    -2    0    0    1 9    14    -2    0    0    1 9    15    -1    0    0    1 9    17    -1    0    0    5 9    18    -2    0    0    3 9    19    0    1    0    2 9    20    -1    0    0    5 9    21    0    0    2    4 10    11    1    0    0    0 10    12    1    0    0    5 10    13    1    0    0    6 10    15    -1    0    0    1 10    16    2    0    0    0 10    18    2    0    0    3 10    19    -1    0    0    2 10    20    2    0    0    0 10    21    0    0    2    4 11    12    0    -1    0    0 11    14    0    1    0    1 11    16    0    1    0    6 11    17    -1    0    0    0 11    19    0    1    0    2 11    20    0    1    0    2 12    13    0    -2    0    0 12    14    0    1    0    1 12    15    -1    0    0    1 12    16    0    -1    0    6 12    17    -1    0    0    6 12    18    0    -2    0    3 12    19    0    -1    0    2 12    20    1    0    0    0 12    21    0    0    2    4 13    15    -1    0    0    1 13    16    0    -1    0    6 13    17    0    1    0    6 13    18    0    -2    0    3 13    19    -1    0    0    2 13    20    1    0    0    0 13    21    0    0    1    5 14    15    -2    0    0    1 14    18    0    1    0    3 14    19    -2    0    0    1 14    20    0    0    1    4 14    21    0    0    2    4 15    16    0    -1    0    1 15    17    1    0    0    1 15    18    -2    0    0    5 15    19    1    0    0    6 15    20    -1    0    0    1 15    21    0    0    1    5 16    18    5    0    0    3 16    19    0    1    0    2 16    20    0    -1    0    2 16    21    -1    0    0    5 17    18    0    3    0    3 17    19    0    -1    0    2 17    20    0    -1    0    2 18    19    -2    0    0    6 18    20    2    0    0    3 18    21    -1    0    0    3 19    20    0    1    0    0 19    21    0    0    2    4 20    21    0    0    1    4";

    private int[,] reactionTable;

    private Idea firstSlot;
    private Idea secondSlot;
    public string alienStr;
    public int alienID;
    public bool slotsHaveChanged;
    public int endInt;
    private int lastIndexFound = 500;
   

    // Use this for initialization
    void Start()
    {
        clipArray = new AudioClip[6];
        m_messageSentTable = new Idea[Globals.SYMBOL_NB_PER_MSG];
        m_lastMessage = new Idea[Globals.SYMBOL_NB_PER_MSG];

        for (int i = 0; i < Globals.SYMBOL_NB_PER_MSG; ++i)
        {
            m_messageSentTable[i] = Idea.VOID;
            m_lastMessage[i] = Idea.VOID;
        }

        m_alienState = AlienState.IDLE;

        m_happiness = 0;
        m_confusion = 0;
        m_hungry = 0;
        m_countUsedComb = 0;

        //Debug.Log("END1 is : " + Globals.END1 + " and END2 : " + Globals.END2);


        reactionTable = new int[185, 6];

        int[] numbers = new int[reactionStr.Length];
        string[] substr = new string[1000];

        //substr = reactionStr.Split(' ');
        substr = System.Text.RegularExpressions.Regex.Split(reactionStr, @"\s{1,}");
        /*for (int c = 0; c < 100; c++)
            Debug.Log("substr[" + c + "]" + " = " + substr[c] + " \n");*/
        Debug.Log(substr.Length);
        for (int i = 0; i < substr.Length / 6; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                reactionTable[i, j] = int.Parse(substr[i * 6 + j]);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

        switch (m_alienState)
        {
            case AlienState.IDLE:
                if ((m_messageSentTable[0] == m_lastMessage[0] && m_messageSentTable[1] == m_lastMessage[1]) || (m_messageSentTable[0] == m_lastMessage[1] && m_messageSentTable[1] == m_lastMessage[0]))
                    break;


                for (int i = 0; i < Globals.SYMBOL_NB_PER_MSG; ++i)
                {
                    m_lastMessage[i] = m_messageSentTable[i];
                }

                break;

            case AlienState.ANIMATION_TRIGGERED:
                break;
            default:
                Debug.Log("default");
                break;

        }




    }


    public void changeAlienState(AlienState newState)
    {
        m_alienState = newState;
    }

    public AlienState getAlienState()
    {
        return m_alienState;
    }

    public void updateAlienMood(int happy, int confused, int hungry)
    {
        Debug.Log("Mood Update : " + happy + " " + confused + " " + hungry);
        m_happiness += happy;
        m_confusion += confused;
        m_hungry += hungry;

    }

    public void receiveCombination(int firstValue, int secondValue)
    {

        
        //Debug.Log(Application.dataPath + alienStr + "/angry.png");
        bool combination_found = false;
        int lastHappy, lastConfused, lastHungry;

        m_countUsedComb++;

        for (int i = 0; i < 185 ; ++i)
        {
            if ((reactionTable[i, 0] == firstValue && reactionTable[i, 1] == secondValue) || (reactionTable[i, 0] == secondValue && reactionTable[i, 1] == firstValue))
            {
                if (i != lastIndexFound)
                {
                    Debug.Log("HAPPY : " + m_happiness + " will add : " + reactionTable[i, 2]);
                    lastHappy = m_happiness;
                    lastConfused = m_confusion;
                    lastHungry = m_hungry;

                    m_happiness += reactionTable[i, 2];
                    m_confusion += reactionTable[i, 3];
                    m_hungry += reactionTable[i, 4];

                    m_happiness = (m_happiness > Globals.MAX_LIMIT) ? Globals.MAX_LIMIT : m_happiness;
                    m_confusion = (m_confusion > Globals.MAX_LIMIT) ? Globals.MAX_LIMIT : m_confusion;
                    m_hungry = (m_hungry > Globals.MAX_LIMIT) ? Globals.MAX_LIMIT : m_hungry;


                    m_happiness = (m_happiness < Globals.MIN_LIMIT) ? Globals.MIN_LIMIT : m_happiness;
                    m_confusion = (m_confusion < Globals.MIN_LIMIT) ? Globals.MIN_LIMIT : m_confusion;
                    m_hungry = (m_hungry < Globals.MIN_LIMIT) ? Globals.MIN_LIMIT : m_hungry;
                    Debug.Log("HAPPY : " + m_happiness + " PASSED : " + firstValue + " " + secondValue + ")");

                    combination_found = true;
                    lastIndexFound = i;
                    Debug.Log("ARRAY FOUND : " + lastIndexFound);

                    if (m_happiness > lastHappy)
                    {
                        GameObject.Find("happy").GetComponent<AudioSource>().Play();
                        updateImage("happy");
                        if (lastIndexFound == 172)
                            GameObject.Find("freddy").GetComponent<AudioSource>().Play();
                        else
                            GameObject.Find("happy").GetComponent<AudioSource>().Play();
                    }
                    else if (m_happiness < lastHappy)
                    {

                        if (File.Exists(Application.dataPath + "/" + alienStr + "angry.png"))
                            updateImage("angry2");
                        else
                            updateImage("angry");
                        GameObject.Find("nothappy").GetComponent<AudioSource>().Play();
                    }
                    else if (m_confusion > lastConfused)
                    {
                        updateImage("confused");
                        GameObject.Find("conf").GetComponent<AudioSource>().Play();
                    }
                    else if (m_confusion < lastConfused)
                    {
                        updateImage("understanding");
                        GameObject.Find("notconf").GetComponent<AudioSource>().Play();
                    }
                    else if (m_hungry > lastHungry)
                    {
                        updateImage("hungry");
                        GameObject.Find("hung").GetComponent<AudioSource>().Play();
                    }
                    else if (m_hungry < lastHungry)
                    {
                        updateImage("nothungry");
                        GameObject.Find("nothung").GetComponent<AudioSource>().Play();
                    }
                    else
                        updateImage("neutral");



                    checkSymbol(reactionTable[i, 5]);

                    break;
                }
            }
        }
        if (!combination_found)
        {
            updateImage("neutral");
            checkSymbol(0);
        }
        
        checkMoodValues();




    }

    void updateImage(string imageName)
    {
        //GetComponent<AudioSource>().GetComponent<AudioClip>().preloadAudioData = 
        GameObject.Find("Image").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(alienStr + imageName);
    }

    void checkSymbol(int symbolID)
    {
        switch (symbolID)
        {
            case 0:
                Color newColor = new Color();
                newColor = GameObject.Find("Symbol").GetComponentInChildren<Image>().color;
                newColor.a = 0;
                GameObject.Find("Symbol").GetComponentInChildren<Image>().color = newColor;
                break;
            case 1:
                updateSymbol("tentaclewithstoneaxe");
                break;
            case 2:
                updateSymbol("tentaclewithhourglas");
                break;
            case 3:
                updateSymbol("tentaclewithmercury");
                break;
            case 4:
                updateSymbol("tentaclewithfruit");
                break;
            case 5:
                updateSymbol("tentaclewithcaptivity");
                break;
            case 6:
                updateSymbol("tentacle");
                break;
            default:
                Debug.Log("ERROR IN SYMBOL CHANGE");
                break;


        }
        if (symbolID != 0)
        {
            Color newColor = new Color();
            newColor = GameObject.Find("Symbol").GetComponentInChildren<Image>().color;
            newColor.a = 155;
            GameObject.Find("Symbol").GetComponentInChildren<Image>().color = newColor;
        }
    }

    void updateSymbol(string imageName)
    {
        GameObject.Find("Symbol").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(alienStr + imageName);

        Color newColor = new Color();
        newColor = GameObject.Find("Symbol").GetComponentInChildren<Image>().color;
        newColor.a = 155;
        GameObject.Find("Symbol").GetComponentInChildren<Image>().color = newColor;
    }

    void checkMoodValues()
    {

        Debug.Log(m_happiness + " " + m_confusion + " " + m_hungry);
        bool wootDatPlafondhascracked = false;
        if (m_happiness >= Globals.MAX_LIMIT)
        {
            Debug.Log("HAPPINEES SENT");
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.HAPPY, alienID);
            wootDatPlafondhascracked = true;

        }
        else if (m_happiness <= Globals.MIN_LIMIT)
        {
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_HAPPY, alienID);
            wootDatPlafondhascracked = true;

        }
        else if (m_confusion >= Globals.MAX_LIMIT)
        {
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.CONFUSED, alienID);
            wootDatPlafondhascracked = true;
        }
        else if (m_confusion <= Globals.MIN_LIMIT)
        {
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_CONFUSED, alienID);
            wootDatPlafondhascracked = true;
        }
        else if (m_hungry >= Globals.MAX_LIMIT)
        {
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.HUNGRY, alienID);
            wootDatPlafondhascracked = true;
        }
        else if (m_hungry <= Globals.MIN_LIMIT)
        {
            GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_HUNGRY, alienID);
            wootDatPlafondhascracked = true;
        }
        else if (m_countUsedComb >= Globals.MAX_NB_TRY)
        {
            CaracType endCarac;
            int maxVal = 0;
            wootDatPlafondhascracked = true;
            maxVal = Mathf.Max(Mathf.Abs(m_confusion), Mathf.Abs(m_happiness), Mathf.Abs(m_hungry));
            endCarac = (Mathf.Abs(m_happiness) > Mathf.Abs(m_confusion)) ? CaracType.HAPPINESS : ((Mathf.Abs(m_confusion) > Mathf.Abs(m_hungry)) ? CaracType.CONFUSION : CaracType.HUNGRINESS);

            switch (endCarac)
            {
                case CaracType.HAPPINESS:
                    if (m_happiness >= 0)
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.HAPPY, alienID);
                    else
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_HAPPY, alienID);
                    break;
                case CaracType.CONFUSION:
                    if (m_confusion >= 0)
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.CONFUSED, alienID);
                    else
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_CONFUSED, alienID);
                    break;
                case CaracType.HUNGRINESS:
                    if (m_hungry >= 0)
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.HUNGRY, alienID);
                    else
                        GameObject.Find("EndManager").GetComponent<EndMgt>().updateEnd(EndState.NOT_HUNGRY, alienID);
                    break;
                default:
                    Debug.Log("Error in carac type determination");
                    break;
            }

        }
        else
        {
            //DO_NOTHING
        }

        if (wootDatPlafondhascracked)
            this.enabled = false;

    }


}
