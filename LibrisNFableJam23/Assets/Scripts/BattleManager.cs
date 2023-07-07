using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Camera battleCam;
    public Camera mainCam;
    public GameObject battleTextUI;
    public GameObject battleButtons;
    public GameObject attackButt;
    public GameObject defButt;
    public GameObject statButt;
    public GameObject battleTxt;
    public GameObject player;
    public GameObject opponent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            print("Found Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBattle ()
    {
        battleCam.gameObject.SetActive(true);
        print("battlecam on");
        mainCam.gameObject.SetActive(false);
        print("maincam off");
        battleTextUI.SetActive(true);
        battleButtons.SetActive(false);
        battleTxt.GetComponent<TextMesh>().text = "A TRAINER ambushued you! They sent out" + "Pokemon type";

    }
}
