using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{


    public Transform splash;
    public int page = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            page++;
            print("space key was pressed");
           
       
            transform.GetChild(page).gameObject.SetActive(false);
            transform.GetChild(page).gameObject.SetActive(true);

          


        
        }
                if(page==4)
        {
            loadlevel("o_o_scene");
            
        }
            

        
    }

    public void loadlevel(string level)
    {
    SceneManager.LoadScene(level);
    
    }
}
