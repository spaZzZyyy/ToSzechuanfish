using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class spinner : MonoBehaviour
{
    int randomValue;
    Animator ani;
    public combatManager combatManager;
    public Variables stats;
    int amtSpins;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        amtSpins = 5;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && combatManager.menu.activeSelf == false){
            spin();
        }
    }


    public GameObject combatMenu;
    void spin(){
        randomValue = Random.Range(1,amtSpins);
        ani.SetTrigger("Spin");

        switch(randomValue){
            case 1:
                ani.SetInteger("spinInt", 1);
                combatMenu.SetActive(true);
            break;
            case 2:
                ani.SetInteger("spinInt", 2);
                combatManager.playerHp += stats.hpPotion;
                Debug.Log("Hp potion Consumed" + "Player Hp:" + combatManager.playerHp);
            break;
            case 3:
                ani.SetInteger("spinInt", 3);
            break;
            case 4:
                ani.SetInteger("spinInt", 4);
            break;
            case 5:
                ani.SetInteger("spinInt", 5);
            break;
        }
    }
}
