using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelbuttons;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        int dealmany = PlayerPrefs.GetInt("dealmany", 1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            //if (i + 1 > levelReached)
            //{
                levelbuttons[i].interactable = true;
            //}

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
