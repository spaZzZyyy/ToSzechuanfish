using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    #region Combat Button Variables
        public Variables stats;
        [SerializeField] GameObject atkBtnGO;
        [SerializeField] GameObject DefendBtnGO;
        [SerializeField] GameObject RunBtnGO;
        Button atkBtn;
        Button DefendBtn;
        Button RunBtn;
    #endregion

    #region Health Variables
        [HideInInspector] public int playerHp;
        [HideInInspector] public int enemyHp;
    #endregion

    #region Turn base bools
        bool isDefending;
        bool playerTurn = true;
        bool combatStarting;
        public GameObject menu;
    #endregion
    void Start()
    {
        #region Combat Button wiring
            atkBtn = atkBtnGO.GetComponent<Button>();
            DefendBtn = DefendBtnGO.GetComponent<Button>();
            RunBtn = RunBtnGO.GetComponent<Button>();

            atkBtn.onClick.AddListener(OnAtk);
            DefendBtn.onClick.AddListener(OnDefend);
            RunBtn.onClick.AddListener(OnRun);
        #endregion

        #region Assigning starting health
            playerHp = stats.playerHp;
            enemyHp = stats.enemyHp;
        #endregion
    }
    void OnDefend(){
        if(playerTurn == true){
            Debug.Log("Player Defended");
            isDefending = true;
            playerTurn = false;
            combatStarting = true;
        }
    }

    void OnAtk(){
        if(playerTurn == true){
            Debug.Log("Player Attacked!");
            enemyHp -= stats.playerAtk;
            playerTurn = false;
            combatStarting = true;
        }
    }

    void OnRun(){
        if(playerTurn == true){
            Debug.Log("Player Ran!");
            combatStarting = false;
            menu.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log("Player Hp:" + playerHp + " Enemy Hp:" + enemyHp);

        if(combatStarting == true){
            OnEnemyAtk();
        }

        checkDead();
    }

    void checkDead(){
        //End Combat if either die
        if(playerHp <= 0 || enemyHp <= 0){
            if (playerHp <= 0){
                Debug.Log("Player Died");
            }

            if(enemyHp <= 0){
                Debug.Log("Enemy Died");
            }
            combatStarting = false;
            enemyHp = stats.enemyHp;
            menu.SetActive(false);
        }
    }

    void OnEnemyAtk(){
        if(playerTurn == false){
            if(isDefending == false){
                playerHp -= stats.enemyAtk;
            }
            else {

                if(stats.playerDef >= stats.enemyAtk){
                    playerHp -= 0;
                } else{
                    playerHp -= stats.enemyAtk - stats.playerDef;
                }
                isDefending = false;
            } 

            Debug.Log("Enemy Attacked!");
            playerTurn = true;
        }
    }
}
