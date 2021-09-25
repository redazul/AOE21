using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger : MonoBehaviour
{
    public string spell ="";
    public string active_spell ="";
    public bool inZone = false;
    public Animator anim;
    public bool turnOnSpell = true;
    public float coolDown = 1.0f;
    public int latch =0;

        void Start()
    {
        anim = GetComponent<Animator>();

    }


   public void OnTriggerStay(Collider other) {
       inZone = true;
       active_spell = other.name;

   }

      public void OnTriggerExit(Collider other) {
       inZone = false;
       anim.SetInteger("Spell",0);
       
       }




        void Update()
    {

        // if(inZone==false && anim.GetInteger("Spell") == 1)
        // {
        //     anim.SetInteger("Spell",0);
        // }

        if(Input.GetKeyDown("space") && inZone ==true)
       {
         anim.SetInteger("Spell",1);
         Debug.Log("Grabbed "+ active_spell + " spell");
         spell = active_spell;
         
         
       }


        if (Input.GetKeyDown("space") && inZone==false )
        {

            if(latch ==0)
            {
                latch =1;
                switch (spell)
            {
                case "":Debug.Log("no spell to cast"); break;
                case "green": Debug.Log("green spell cast"); anim.SetInteger("Spell",2); 
                break;
                 case "red": Debug.Log("red spell cast"); anim.SetInteger("Spell",3); 
                 break;
                
            }
            }else{
                latch =0;
                anim.SetInteger("Spell",0);
            }

            

        }



        // if(!Input.GetKeyDown("space") && inZone ==false)
        // {
        //     Debug.Log("not pressing");
        //     anim.SetInteger("Spell",0);
            
        // }
    }

//      void CooledDown()
//  {
     
//       turnOnSpell = true;
     
//  }

   
}
