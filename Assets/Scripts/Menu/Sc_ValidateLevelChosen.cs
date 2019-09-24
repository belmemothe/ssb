using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ValidateLevelChosen : MonoBehaviour
{
    private GameObject textTest;
    //ici on va mettre tout les cartes des niveaux
    //Pour chaque carte, on ajoute un gameobject
    [Header("Level's card")]
    //public GameObject levelSample
    public GameObject level01;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * c'est le systeme de messagerie
     * 
     * Ce script va recevoir tout les messages concernant "PopupAppear"
     * On va ensuite utiliser la fonction du même nom
     */
    private void OnEnable()
    {
        Sc_EventManager.StartListening("PopupAppear", PopupAppear);
    }


    private void OnDisable()
    {
        Sc_EventManager.StopListening("PopupAppear", PopupAppear);
    }
    
    //Prend en compte le niveau et fait apparaitre la carte correspondante
    private void PopupAppear(float level)
    {
        Debug.Log("now entering in the popupappear function");
        //Sc_EventManager.TriggerEvent("PopupAppear", 0);

        // Equivalent au if else...
        switch ((int)level)
        {
            case 1:
                Debug.Log("Panel lvl01 appear !");
                // on instantit le level et on le place dans le canvas
                GameObject level01Object = Instantiate(level01, GameObject.FindGameObjectWithTag("Canvas").transform);
                break;

        }

    }

}
