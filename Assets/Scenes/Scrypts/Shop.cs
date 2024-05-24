using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] public GameObject peaShooter1;
    [SerializeField] public GameObject peaShooter2;
    [SerializeField] public GameObject launcher1;
    [SerializeField] public GameObject launcher2;
    // [SerializeField] public GameObject weapon3Player1;
    // [SerializeField] public GameObject weapon3Player2;

    
    // [SerializeField] public GameObject weapon4;
    // [SerializeField] public GameObject weapon5;
    // Start is called before the first frame update
    [SerializeField] public GameObject canvasShop;
    [SerializeField] public GameObject panel1;
    [SerializeField] public GameObject panel2;
    private List<Image> panels;
    [SerializeField] public Outline outline1;
    [SerializeField] public Outline outline2;
    private List<Outline> outlines;



    private List<GameObject> player1Weapons;
    private List<GameObject> player2Weapons;

    private List<int> weaponsPrice;
    private List<int> weaponsBought;

    private int score = ScoreTracker.score;
    private int player = 0;

    void Start()
    {
        canvasShop.SetActive(false);

        player1Weapons = new List<GameObject>();
        player1Weapons.Add(peaShooter1);
        player1Weapons.Add(launcher1);

        player2Weapons = new List<GameObject>();
        player2Weapons.Add(peaShooter2);
        player2Weapons.Add(launcher2);

        peaShooter1.SetActive(true);
        peaShooter2.SetActive(true);

        for (int i=1; i<player1Weapons.Count; i+=1) {
            player1Weapons[i].SetActive(false);
        }
        for (int i=1; i<player2Weapons.Count; i+=1) {
            player2Weapons[i].SetActive(false);
        }

        weaponsPrice = new List<int> {0,10,20,30,40};
        weaponsBought = new List<int> {1,0,0,0,0};


        // Panels colors
        panels = new List<Image>();
        panels.Add(panel1.GetComponent<Image>());
        panels.Add(panel2.GetComponent<Image>());
        //outlines colors
        outlines = new List<Outline>();
        outlines.Add(outline1);
        outlines.Add(outline2);

    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreTracker.score;
        // check if have enough money to buy a weapon
        for (int i=0; i<panels.Count; i+=1) {
            if (score >= weaponsPrice[i]) {
                panels[i].color = Color.white;
            }
        }

        for (int i=0; i<outlines.Count; i+=1) {
            if (weaponsBought[i] == 1) {
                outlines[i].effectColor = Color.green;
            }
        }
        
        // check for player's turn
        if (Input.GetKeyDown(KeyCode.S))
        {
            player = 2;
            canvasShop.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player = 1;
            canvasShop.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void activateWeapons(int weaponNum) {
        // Show canvas and cursor
        Cursor.lockState = CursorLockMode.None;
        canvasShop.SetActive(false);

        // Used to figure out which player will get the weapon based on who walked BACKWARDS
        List<GameObject> playerWeapons = (player == 1) ? player1Weapons : player2Weapons;
        List<GameObject> otherWeapons = (player == 1) ? player2Weapons : player1Weapons;

        // check if the other player has it:
        // activate current player's weapon and deactive the one that the other player is holding

        if (otherWeapons[weaponNum].activeInHierarchy) {
            if (weaponNum != 0) {
                playerWeapons[weaponNum].SetActive(true);
                otherWeapons[weaponNum].SetActive(false);
            }
        }
        // if we bought the weapon, but no one uses it at the moment
        else if (weaponsBought[weaponNum] == 1)  {
            // Deactivate the player's current weapons and activate that one
            for (int i=0; i<playerWeapons.Count; i+=1) {
                playerWeapons[i].SetActive(false);
            }
            playerWeapons[weaponNum].SetActive(true);
        }
        // if not, that means we didn't buy the weapon
        else {
            // have enough money to buy
            if (score >= weaponsPrice[weaponNum]) {
                for (int i=0; i<playerWeapons.Count; i+=1) {
                    playerWeapons[i].SetActive(false);
                }
                playerWeapons[weaponNum].SetActive(true);
                score -= weaponsPrice[weaponNum];
                weaponsBought[weaponNum] = 1;
            }
        }
    }

   
}
