using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseEnd : MonoBehaviour {
    private string input = "0	0	0 0	1	3 0	2	3 0	3	0 0	4	4 0	5	3 1	1	1 1	2	4 1	3	2 1	4	1 1	5	4 2	2	2 2	3	2 2	4	1 2	5	4 3	4	0 3	5	4 4	5	2 5	5	3";
    private int[,] endTable;
    private EndState end1;
    private EndState end2;

    // Use this for initialization

    void Start()
    {
        //GameObject.Find("GameManager");
        end1 = GameObject.Find("EndManager").GetComponent<EndMgt>().END1;
        end2 = GameObject.Find("EndManager").GetComponent<EndMgt>().END2;
        string[] substr = new string[1000];
        endTable = new int[19, 3];
        //substr = reactionStr.Split(' ');
        substr = System.Text.RegularExpressions.Regex.Split(input, @"\s{1,}");
        /*for (int c = 0; c < 100; c++)
            Debug.Log("substr[" + c + "]" + " = " + substr[c] + " \n");*/

        for (int i = 0; i < substr.Length / 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                endTable[i, j] = int.Parse(substr[i * 3 + j]);
                //Debug.Log(endTable[i, j]);
            }
            
        }
        //Debug.Log("INDEX FUCK IS : " + endTable[(int)EndMgt.eND1, (int)EndMgt.eND2].ToString());
        bool endfound = false;
        int indexfound = 0;
        for (int i = 0; i < 19; ++i)
        {
            Debug.Log("END 1 : " + (int)end1 + " end 2 : " + (int)end2);
            if ((endTable[i,0] == (int)end1 && endTable[i, 1] == (int)end2) || (endTable[i, 1] == (int)end1 && endTable[i, 0] == (int)end2))
            {
                indexfound = i;
                endfound = true;
                break;
            }
            Debug.Log("Ends/end" + endTable[indexfound, 2].ToString());
            
        }
        if (endfound)
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Ends/end" + endTable[indexfound, 2].ToString());
        else
            Debug.Log("ERROR FINDFING ENDING");



        Debug.Log("AWAKE");
        //end1 = GameObject.Find("GameManager").GetComponent<EndMgt>().END1;
        //end2 = GameObject.Find("GameManager").GetComponent<EndMgt>().END2;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

 
}

public enum possibleEnd
{
    INTEGRATION,
    EATEN,
    NOCOM,
    PEACE,
    ISOLATION
}
