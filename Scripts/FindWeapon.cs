<<<<<<< HEAD

using Kursovaaa;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FindWeapon : MonoBehaviour
{
    SceneManager sceneManager;
    public GameObject FindWeaponPanel;
    private int option;
    private string input;
    public GameObject noWeaponsText;
    public GameObject helpPanel;
    public TextMeshProUGUI helpText;
    public TextMeshProUGUI filterText;
    private string[] weaponNames = { "AK47", "BennelliM4", "M2", "M4_8", "M107", "M249", "M1911", "RPG7", "Uzi" };
    void Start()
    {
        FindWeaponPanel.SetActive(false);
        sceneManager = Camera.main.GetComponent<SceneManager>();
    }


    // Called when a dropdown option is selected. Controls which filtering method
    // will be used to find weapons
    public void FindWeaponDropdownMenuOption(int val)
    {
        filterText.text = "";
        FindWeaponPanel.SetActive(false);
        switch (val)
        {
            // Case 0: Display all weapons without filtering
            case 0:
                if (sceneManager.weapons.Count > 0)
                {
                    foreach (Button b in sceneManager.buttons)
                    {
                        Destroy(b.gameObject);
                    }
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.buttons = new List<Button>(sceneManager.weapons.Count);
                    for (int i = 0; i < sceneManager.weapons.Count; i++)
                        sceneManager.CreateButton(i);
                    sceneManager.weapons[sceneManager.index].Model.SetActive(true);
                    sceneManager.currentClickedButton = sceneManager.buttons[sceneManager.index];
                    sceneManager.buttons[sceneManager.index].image.color = new Color(0f, 0f, 0f);
                    noWeaponsText.SetActive(false);
                }
                else
                {
                    noWeaponsText.SetActive(true);
                }
                break;
            // Cases 1, 2, and 3: Show the input panel for filtering by Model, Producer, or Type
            case 1:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 1; // Option to search by ModelString
                }
                break;
            case 2:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 2; // Option to search by Producer
                }
                break;
            case 3:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 3; // Option to search by Type
                }
                break;
        }

    }

    // Stores the user's input from an input field into the `input` variable
    public void InputField(string inp)
    {
        input = inp;
    }

    //Applies the selected filter and creates buttons for the matching weapons
    public void ActivateButtonClick()
    {
        noWeaponsText.SetActive(false);
        FindWeaponPanel.SetActive(false);
        
        int buttonArraySize = 0;
        foreach(Button b in sceneManager.buttons)
        {
            Destroy(b.gameObject);
        }
        List<int> neededIndexes = new List<int>();
        switch (option)
        {
            case 1:
                bool isWordInString = false;
                string[] words = input.Split(" ");
                foreach(var word in words)
                {
                    foreach(var name in weaponNames)
                    {
                        if(word == name)
                        {
                            input = word;
                            isWordInString = true;
                            break;
                        }
                        if (isWordInString)
                            break;
                    }
                }
                if (isWordInString)
                {
                    for (int i = 0; i < sceneManager.weapons.Count; i++)
                    {
                        if (sceneManager.weapons[i].ModelString == input)
                        {
                            buttonArraySize++;
                            neededIndexes.Add(i);
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < sceneManager.weapons.Count; i++)
                {
                    if (sceneManager.weapons[i].Producer == input)
                    {
                        buttonArraySize++;
                        neededIndexes.Add(i);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < sceneManager.weapons.Count; i++)
                {
                    if (sceneManager.weapons[i].Type == input)
                    {
                        buttonArraySize++;
                        neededIndexes.Add(i);
                    }
                }
                break;

        }

        filterText.text = input;
        sceneManager.buttons = new List<Button>(buttonArraySize);
        foreach (int i in neededIndexes)
        {
            sceneManager.CreateButton(i);
        }
        if (buttonArraySize > 0)
        {
            sceneManager.weapons[neededIndexes[0]].Model.SetActive(true);
            sceneManager.buttons[0].image.color = new Color(0f, 0f, 0f);
            sceneManager.currentClickedButton = sceneManager.buttons[0];
            sceneManager.index = neededIndexes[0];
            sceneManager.UpdateInfo();
        }
        else
        {
            noWeaponsText.SetActive(true);
        }
    }

    public void CancelButtonClick()
    {
        sceneManager.weapons[sceneManager.index].Model.SetActive(true);
        FindWeaponPanel.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        switch (option) {

            case 1:
            helpText.text = "AK47, BennelliM4, M2, M4_8, M107, M249, M1911, RPG7 ,Uzi ";
                break;
            case 2:
                helpText.text = "Kalashnikov Concern, Benelli Armi S.p.A., Browning, Colt's Manufacturing, Barrett Firearms Manufacturing, FN Herstal, Bazalt, Israel Military Industries ";
                break;
            case 3:
                helpText.text = "Assault Rifle, Shotgun, Heavy Machine Gun, Carbine, Sniper Rifle, Light Machine Gun, Pistol, Rocket-Propelled Grenade Launcher, Submachine Gun";
                break;
        }
        helpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }
}
=======

using Kursovaaa;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FindWeapon : MonoBehaviour
{
    SceneManager sceneManager;
    public GameObject FindWeaponPanel;
    private int option;
    private string input;
    public GameObject noWeaponsText;
    public GameObject helpPanel;
    public TextMeshProUGUI helpText;
    public TextMeshProUGUI filterText;
    private string[] weaponNames = { "AK47", "BennelliM4", "M2", "M4_8", "M107", "M249", "M1911", "RPG7", "Uzi" };
    void Start()
    {
        FindWeaponPanel.SetActive(false);
        sceneManager = Camera.main.GetComponent<SceneManager>();
    }


    // Called when a dropdown option is selected. Controls which filtering method
    // will be used to find weapons
    public void FindWeaponDropdownMenuOption(int val)
    {
        filterText.text = "";
        FindWeaponPanel.SetActive(false);
        switch (val)
        {
            // Case 0: Display all weapons without filtering
            case 0:
                if (sceneManager.weapons.Count > 0)
                {
                    foreach (Button b in sceneManager.buttons)
                    {
                        Destroy(b.gameObject);
                    }
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.buttons = new List<Button>(sceneManager.weapons.Count);
                    for (int i = 0; i < sceneManager.weapons.Count; i++)
                        sceneManager.CreateButton(i);
                    sceneManager.weapons[sceneManager.index].Model.SetActive(true);
                    sceneManager.currentClickedButton = sceneManager.buttons[sceneManager.index];
                    sceneManager.buttons[sceneManager.index].image.color = new Color(0f, 0f, 0f);
                    noWeaponsText.SetActive(false);
                }
                else
                {
                    noWeaponsText.SetActive(true);
                }
                break;
            // Cases 1, 2, and 3: Show the input panel for filtering by Model, Producer, or Type
            case 1:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 1; // Option to search by ModelString
                }
                break;
            case 2:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 2; // Option to search by Producer
                }
                break;
            case 3:
                if (sceneManager.weapons.Count > 0)
                {
                    FindWeaponPanel.SetActive(true);
                    foreach (CWeapon weapon in sceneManager.weapons)
                    {
                        weapon.Model.SetActive(false);
                    }
                    sceneManager.weapons[sceneManager.index].Model.SetActive(false);
                    option = 3; // Option to search by Type
                }
                break;
        }

    }

    // Stores the user's input from an input field into the `input` variable
    public void InputField(string inp)
    {
        input = inp;
    }

    //Applies the selected filter and creates buttons for the matching weapons
    public void ActivateButtonClick()
    {
        noWeaponsText.SetActive(false);
        FindWeaponPanel.SetActive(false);
        
        int buttonArraySize = 0;
        foreach(Button b in sceneManager.buttons)
        {
            Destroy(b.gameObject);
        }
        List<int> neededIndexes = new List<int>();
        switch (option)
        {
            case 1:
                bool isWordInString = false;
                string[] words = input.Split(" ");
                foreach(var word in words)
                {
                    foreach(var name in weaponNames)
                    {
                        if(word == name)
                        {
                            input = word;
                            isWordInString = true;
                            break;
                        }
                        if (isWordInString)
                            break;
                    }
                }
                if (isWordInString)
                {
                    for (int i = 0; i < sceneManager.weapons.Count; i++)
                    {
                        if (sceneManager.weapons[i].ModelString == input)
                        {
                            buttonArraySize++;
                            neededIndexes.Add(i);
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < sceneManager.weapons.Count; i++)
                {
                    if (sceneManager.weapons[i].Producer == input)
                    {
                        buttonArraySize++;
                        neededIndexes.Add(i);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < sceneManager.weapons.Count; i++)
                {
                    if (sceneManager.weapons[i].Type == input)
                    {
                        buttonArraySize++;
                        neededIndexes.Add(i);
                    }
                }
                break;

        }

        filterText.text = input;
        sceneManager.buttons = new List<Button>(buttonArraySize);
        foreach (int i in neededIndexes)
        {
            sceneManager.CreateButton(i);
        }
        if (buttonArraySize > 0)
        {
            sceneManager.weapons[neededIndexes[0]].Model.SetActive(true);
            sceneManager.buttons[0].image.color = new Color(0f, 0f, 0f);
            sceneManager.currentClickedButton = sceneManager.buttons[0];
            sceneManager.index = neededIndexes[0];
            sceneManager.UpdateInfo();
        }
        else
        {
            noWeaponsText.SetActive(true);
        }
    }

    public void CancelButtonClick()
    {
        sceneManager.weapons[sceneManager.index].Model.SetActive(true);
        FindWeaponPanel.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        switch (option) {

            case 1:
            helpText.text = "AK47, BennelliM4, M2, M4_8, M107, M249, M1911, RPG7 ,Uzi ";
                break;
            case 2:
                helpText.text = "Kalashnikov Concern, Benelli Armi S.p.A., Browning, Colt's Manufacturing, Barrett Firearms Manufacturing, FN Herstal, Bazalt, Israel Military Industries ";
                break;
            case 3:
                helpText.text = "Assault Rifle, Shotgun, Heavy Machine Gun, Carbine, Sniper Rifle, Light Machine Gun, Pistol, Rocket-Propelled Grenade Launcher, Submachine Gun";
                break;
        }
        helpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }
}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
