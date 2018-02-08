using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndMgt : MonoBehaviour {

    public  EndState eND1;
    public  EndState eND2;

    public EndState END1
    {
        get
        {
            return eND1;
        }

        set
        {
            eND1 = value;
        }
    }

    public EndState END2
    {
        get
        {
            return eND2;
        }

        set
        {
            eND2 = value;
        }
    }


    // Use this for initialization
    void Start () {
        END1 = EndState.VOID;
        END2 = EndState.VOID;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    public void updateEnd(EndState endstate, int alienID)
    {

        Debug.Log("END1 is : " + END1 + " and END2 : " + END2);

        if (END1 == EndState.VOID && alienID == 1)
        {
            END1 = endstate;
            StartCoroutine(changeScene());
            //nextScene();
        }
        else if (END2 == EndState.VOID && alienID == 2)
        {
            END2 = endstate;
            StartCoroutine(changeScene());
            //nextScene();
        }
        else
            Debug.Log("ERROR IN END UPDATE");


        Debug.Log("END1 is : " + END1 + " and END2 : " + END2);
    }


    public IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void nextScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}

