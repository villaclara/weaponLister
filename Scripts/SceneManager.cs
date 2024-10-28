<<<<<<< HEAD
﻿using Kursovaaa;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using SFB;

public class SceneManager : MonoBehaviour
{
    public List<CWeapon> weapons;
    public Button currentClickedButton;
    public List<Button> buttons;
    public int index = 0;
    public static bool rotate = false;
    #region GameObjects
    [SerializeField] public GameObject AK47;
    [SerializeField] public GameObject BennelliM4;
    [SerializeField] public GameObject M2;
    [SerializeField] public GameObject M4_8;
    [SerializeField] public GameObject M107;
    [SerializeField] public GameObject M249;
    [SerializeField] public GameObject M1911;
    [SerializeField] public GameObject RPG7;
    [SerializeField] public GameObject Uzi;
    #endregion

    #region TextObjects
    public TextMeshProUGUI ModelText;
    public TextMeshProUGUI TypeText;
    public TextMeshProUGUI ProducerText;
    public TextMeshProUGUI BulletsText;
    public TextMeshProUGUI CallibreText;
    public TextMeshProUGUI WeightText;
    public TextMeshProUGUI CostText;
    #endregion

    #region TextInputGameObjects
    public GameObject BulletInputField;
    public GameObject CalibreInputField;
    public GameObject WeightInputField;
    public GameObject CostInputField;
    public GameObject BulletTextGObj;
    public GameObject CalibreTextGObj;
    public GameObject WeightTextGObj;
    public GameObject CostTextGObj;
    private bool editing = false;
    #endregion

    public GameObject weaponsPannel;
    public Button weaponButtonPrefab;


    CWeaponSorter weaponSorter;

    private string modelName;
    public GameObject adWeaponPanel;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;
    public GameObject noWeaponsText;

    // Start is called before the first frame update
    void Start()
    { 
        weapons = new List<CWeapon>();
        buttons = new List<Button>();
        weaponSorter = Camera.main.GetComponent<CWeaponSorter>();
        weaponSorter.weapons = weapons;
        currentClickedButton = null;
    }

    

    public void AddWeaponButtonClick()
    {
        CWeapon instance = new CWeapon(CreateWeaponObj(modelName), modelName);
        weapons.Add(instance);
        adWeaponPanel.SetActive(false);
        weapons[index].Model.SetActive(true);
        CreateButton(weapons.Count-1);
        if (buttons.Count == 1)
        {
            currentClickedButton = buttons[0];
            buttons[0].image.color = new Color(0f, 0f, 0f);
            noWeaponsText.SetActive(false);
        }
        UpdateInfo();

    }

    public void OpenAdWeaponPanel()
    {
        adWeaponPanel.SetActive(true);
        if(weapons.Count > 0)
            weapons[index].Model.SetActive(false);
    }

    public void UpdateInfo()
    {
        ModelText.text = weapons[index].ModelString;
        TypeText.text = weapons[index].Type;
        ProducerText.text = weapons[index].Producer;
        BulletsText.text = weapons[index].Bullets.ToString();
        CallibreText.text = weapons[index].Calibre.ToString();
        WeightText.text = weapons[index].Weight.ToString();
        CostText.text = weapons[index].Cost.ToString();
    }
    public void AllowRotation()
    {
        if (rotate)
            rotate = false;
        else
            rotate = true;
    }

    public void SizeDropdownMenuOption(int val)
    {
        if (weapons[index].ModelString == "RPG7" || weapons[index].ModelString == "Heavy Machine Gun")
        {
            if (val == 0)
            {
                weapons[index].Size = 3;
                weapons[index].Model.transform.localScale = new Vector3(3, 3, 3);
            }
            else if (val == 1)
            {
                weapons[index].Size = 2;
                weapons[index].Model.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (val == 2)
            {
                weapons[index].Size = 4;
                weapons[index].Model.transform.localScale = new Vector3(4, 4, 4);
            }
        }
        else
        {
            if (val == 0)
            {
                weapons[index].Size = 4;
                weapons[index].Model.transform.localScale = new Vector3(4, 4, 4);
            }
            else if (val == 1)
            {
                weapons[index].Size = 3;
                weapons[index].Model.transform.localScale = new Vector3(3, 3, 3);
            }
            else if (val == 2)
            {
                weapons[index].Size = 5;
                weapons[index].Model.transform.localScale = new Vector3(5, 5, 5);
            }
        }
    }

    public void SortButtonClick()
    {
        if (weapons.Count <= 1)
        {
            ShowErrorPanel("Недостатньо елементів для сортування!");
        }
        else
        {
            foreach (Button b in buttons)
            {
                Destroy(b.gameObject);
            }
            buttons = new List<Button>(weapons.Count);
            for (int i = 0; i < weapons.Count; i++)
                CreateButton(i);
            weapons[index].Model.SetActive(true);

            weaponSorter.SortByCalibre();
            for (int i = 0; i < weapons.Count; i++)
            {
                TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                LeftPannelButton buttonScript = buttons[i].GetComponent<LeftPannelButton>();
                buttonScript.index = i;
                buttonScript.indexInList = i;
                text.text = weapons[i].ModelString;
            }
            foreach (CWeapon weapon in weapons)
            {
                weapon.Model.SetActive(false);
            }
            index = 0;
            weapons[index].Model.SetActive(true);
            currentClickedButton.image.color = new Color(0.298f, 0.298f, 0.298f);
            currentClickedButton = buttons[0];
            buttons[0].image.color = new Color(0f, 0f, 0f);
            UpdateInfo();
        }
    }
   
    public void CreateButton(int i)
    {
        Button button = Instantiate(weaponButtonPrefab);
        LeftPannelButton script = button.GetComponent<LeftPannelButton>();
        script.index = i;
        button.transform.SetParent(weaponsPannel.transform, false);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = weapons[i].ModelString;
        buttons.Add(button);
        script.indexInList = buttons.Count - 1;
    }

   public GameObject CreateWeaponObj(string model)
   {
        Vector3 spawnPos = new Vector3(1f, 0f, 4f);
        Vector3 M2SpawnPos = new Vector3(1f, -1f, 4f);
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
        GameObject weaponInstance;
        if (model == "AK47")
            weaponInstance = Instantiate(AK47, spawnPos, rotation);
        else if (model == "BennelliM4")
            weaponInstance = Instantiate(BennelliM4, spawnPos, rotation);
        else if (model == "M2")
            weaponInstance = Instantiate(M2, M2SpawnPos, rotation);
        else if (model == "M4_8")
            weaponInstance = Instantiate(M4_8, spawnPos, rotation);
        else if (model == "M107")
            weaponInstance = Instantiate(M107, spawnPos, rotation);
        else if (model == "M249")
            weaponInstance = Instantiate(M249, spawnPos, rotation);
        else if (model == "M1911")
            weaponInstance = Instantiate(M1911, spawnPos, rotation);
        else if (model == "RPG7")
            weaponInstance = Instantiate(RPG7, spawnPos, rotation);
        else if (model == "Uzi")
            weaponInstance = Instantiate(Uzi, spawnPos, rotation);
        else
            weaponInstance = Instantiate(AK47, spawnPos, rotation);
        weaponInstance.SetActive(false);
        weaponInstance.transform.localScale = new Vector3(4, 4, 4);
        return weaponInstance;
    }
    
    public void ChooseWeaponToAdDropdown(int val)
    {
        switch (val)
        {
            case 0:
                modelName = "AK47";
                break;
            case 1:
                modelName = "BennelliM4";
                break;
            case 2:
                modelName = "M2";
                break;
            case 3:
                modelName = "M4_8";
                break;
            case 4:
                modelName = "M107";
                break;
            case 5:
                modelName = "M249";
                break;
            case 6:
                modelName = "M1911";
                break;
            case 7:
                modelName = "RPG7";
                break;
            case 8:
                modelName = "Uzi";
                break;
            default:
                modelName = "AK47";
                break;
        }

    }
    public void CancelButtonClick()
    {
        if(weapons.Count>0)
        weapons[index].Model.SetActive(true);
        adWeaponPanel.SetActive(false);
    }

    public void OpenFileExplorer()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select a file", "", "txt", false);
        WeaponIO weaponIO = new WeaponIO(weapons, this);
        weaponIO.GetInfoFromFile(path[0]);
        if (weapons.Count > 0)
        {
            noWeaponsText.SetActive(false);
        }
    }

    public void WriteInfoInFileButton()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select a file", "", "txt", false);
        WeaponIO weaponIO = new WeaponIO(weapons, this);
        weaponIO.WriteInfoInFile(path[0]);
    }

    public void CloseErrorWindow()
    {
        errorPanel.SetActive(false);
        if(weapons.Count > 1)
            weapons[index].Model.SetActive(true);
    }

    public void ShowErrorPanel(string message)
    {
        if (weapons.Count > 0)
            weapons[index].Model.SetActive(false);
        errorPanel.SetActive(true);
        errorText.text = message;
    }
    public void EnableEditing()
    {
        BulletInputField.SetActive(!editing ? true : false);
        CalibreInputField.SetActive(!editing ? true : false);
        WeightInputField.SetActive(!editing ? true : false);
        CostInputField.SetActive(!editing ? true : false);

        BulletTextGObj.SetActive(editing ? true : false);
        CostTextGObj.SetActive(editing ? true : false);
        WeightTextGObj.SetActive(editing ? true : false);
        CostTextGObj.SetActive(editing ? true : false);

        editing = !editing;

    }
}
=======
﻿using Kursovaaa;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using SFB;

public class SceneManager : MonoBehaviour
{
    public List<CWeapon> weapons;
    public Button currentClickedButton;
    public List<Button> buttons;
    public int index = 0;
    public static bool rotate = false;
    #region GameObjects
    [SerializeField] public GameObject AK47;
    [SerializeField] public GameObject BennelliM4;
    [SerializeField] public GameObject M2;
    [SerializeField] public GameObject M4_8;
    [SerializeField] public GameObject M107;
    [SerializeField] public GameObject M249;
    [SerializeField] public GameObject M1911;
    [SerializeField] public GameObject RPG7;
    [SerializeField] public GameObject Uzi;
    #endregion

    #region TextObjects
    public TextMeshProUGUI ModelText;
    public TextMeshProUGUI TypeText;
    public TextMeshProUGUI ProducerText;
    public TextMeshProUGUI BulletsText;
    public TextMeshProUGUI CallibreText;
    public TextMeshProUGUI WeightText;
    public TextMeshProUGUI CostText;
    #endregion

    #region TextInputGameObjects
    public GameObject BulletInputField;
    public GameObject CalibreInputField;
    public GameObject WeightInputField;
    public GameObject CostInputField;
    public GameObject BulletTextGObj;
    public GameObject CalibreTextGObj;
    public GameObject WeightTextGObj;
    public GameObject CostTextGObj;
    private bool editing = false;
    #endregion

    public GameObject weaponsPannel;
    public Button weaponButtonPrefab;


    CWeaponSorter weaponSorter;

    private string modelName;
    public GameObject adWeaponPanel;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;
    public GameObject noWeaponsText;

    // Start is called before the first frame update
    void Start()
    { 
        weapons = new List<CWeapon>();
        buttons = new List<Button>();
        weaponSorter = Camera.main.GetComponent<CWeaponSorter>();
        weaponSorter.weapons = weapons;
        currentClickedButton = null;
    }

    

    public void AddWeaponButtonClick()
    {
        CWeapon instance = new CWeapon(CreateWeaponObj(modelName), modelName);
        weapons.Add(instance);
        adWeaponPanel.SetActive(false);
        weapons[index].Model.SetActive(true);
        CreateButton(weapons.Count-1);
        if (buttons.Count == 1)
        {
            currentClickedButton = buttons[0];
            buttons[0].image.color = new Color(0f, 0f, 0f);
            noWeaponsText.SetActive(false);
        }
        UpdateInfo();

    }

    public void OpenAdWeaponPanel()
    {
        adWeaponPanel.SetActive(true);
        if(weapons.Count > 0)
            weapons[index].Model.SetActive(false);
    }

    public void UpdateInfo()
    {
        ModelText.text = weapons[index].ModelString;
        TypeText.text = weapons[index].Type;
        ProducerText.text = weapons[index].Producer;
        BulletsText.text = weapons[index].Bullets.ToString();
        CallibreText.text = weapons[index].Calibre.ToString();
        WeightText.text = weapons[index].Weight.ToString();
        CostText.text = weapons[index].Cost.ToString();
    }
    public void AllowRotation()
    {
        if (rotate)
            rotate = false;
        else
            rotate = true;
    }

    public void SizeDropdownMenuOption(int val)
    {
        if (weapons[index].ModelString == "RPG7" || weapons[index].ModelString == "Heavy Machine Gun")
        {
            if (val == 0)
            {
                weapons[index].Size = 3;
                weapons[index].Model.transform.localScale = new Vector3(3, 3, 3);
            }
            else if (val == 1)
            {
                weapons[index].Size = 2;
                weapons[index].Model.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (val == 2)
            {
                weapons[index].Size = 4;
                weapons[index].Model.transform.localScale = new Vector3(4, 4, 4);
            }
        }
        else
        {
            if (val == 0)
            {
                weapons[index].Size = 4;
                weapons[index].Model.transform.localScale = new Vector3(4, 4, 4);
            }
            else if (val == 1)
            {
                weapons[index].Size = 3;
                weapons[index].Model.transform.localScale = new Vector3(3, 3, 3);
            }
            else if (val == 2)
            {
                weapons[index].Size = 5;
                weapons[index].Model.transform.localScale = new Vector3(5, 5, 5);
            }
        }
    }

    public void SortButtonClick()
    {
        if (weapons.Count <= 1)
        {
            ShowErrorPanel("Недостатньо елементів для сортування!");
        }
        else
        {
            foreach (Button b in buttons)
            {
                Destroy(b.gameObject);
            }
            buttons = new List<Button>(weapons.Count);
            for (int i = 0; i < weapons.Count; i++)
                CreateButton(i);
            weapons[index].Model.SetActive(true);

            weaponSorter.SortByCalibre();
            for (int i = 0; i < weapons.Count; i++)
            {
                TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                LeftPannelButton buttonScript = buttons[i].GetComponent<LeftPannelButton>();
                buttonScript.index = i;
                buttonScript.indexInList = i;
                text.text = weapons[i].ModelString;
            }
            foreach (CWeapon weapon in weapons)
            {
                weapon.Model.SetActive(false);
            }
            index = 0;
            weapons[index].Model.SetActive(true);
            currentClickedButton.image.color = new Color(0.298f, 0.298f, 0.298f);
            currentClickedButton = buttons[0];
            buttons[0].image.color = new Color(0f, 0f, 0f);
            UpdateInfo();
        }
    }
   
    public void CreateButton(int i)
    {
        Button button = Instantiate(weaponButtonPrefab);
        LeftPannelButton script = button.GetComponent<LeftPannelButton>();
        script.index = i;
        button.transform.SetParent(weaponsPannel.transform, false);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = weapons[i].ModelString;
        buttons.Add(button);
        script.indexInList = buttons.Count - 1;
    }

   public GameObject CreateWeaponObj(string model)
   {
        Vector3 spawnPos = new Vector3(1f, 0f, 4f);
        Vector3 M2SpawnPos = new Vector3(1f, -1f, 4f);
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
        GameObject weaponInstance;
        if (model == "AK47")
            weaponInstance = Instantiate(AK47, spawnPos, rotation);
        else if (model == "BennelliM4")
            weaponInstance = Instantiate(BennelliM4, spawnPos, rotation);
        else if (model == "M2")
            weaponInstance = Instantiate(M2, M2SpawnPos, rotation);
        else if (model == "M4_8")
            weaponInstance = Instantiate(M4_8, spawnPos, rotation);
        else if (model == "M107")
            weaponInstance = Instantiate(M107, spawnPos, rotation);
        else if (model == "M249")
            weaponInstance = Instantiate(M249, spawnPos, rotation);
        else if (model == "M1911")
            weaponInstance = Instantiate(M1911, spawnPos, rotation);
        else if (model == "RPG7")
            weaponInstance = Instantiate(RPG7, spawnPos, rotation);
        else if (model == "Uzi")
            weaponInstance = Instantiate(Uzi, spawnPos, rotation);
        else
            weaponInstance = Instantiate(AK47, spawnPos, rotation);
        weaponInstance.SetActive(false);
        weaponInstance.transform.localScale = new Vector3(4, 4, 4);
        return weaponInstance;
    }
    
    public void ChooseWeaponToAdDropdown(int val)
    {
        switch (val)
        {
            case 0:
                modelName = "AK47";
                break;
            case 1:
                modelName = "BennelliM4";
                break;
            case 2:
                modelName = "M2";
                break;
            case 3:
                modelName = "M4_8";
                break;
            case 4:
                modelName = "M107";
                break;
            case 5:
                modelName = "M249";
                break;
            case 6:
                modelName = "M1911";
                break;
            case 7:
                modelName = "RPG7";
                break;
            case 8:
                modelName = "Uzi";
                break;
            default:
                modelName = "AK47";
                break;
        }

    }
    public void CancelButtonClick()
    {
        if(weapons.Count>0)
        weapons[index].Model.SetActive(true);
        adWeaponPanel.SetActive(false);
    }

    public void OpenFileExplorer()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select a file", "", "txt", false);
        WeaponIO weaponIO = new WeaponIO(weapons, this);
        weaponIO.GetInfoFromFile(path[0]);
        if (weapons.Count > 0)
        {
            noWeaponsText.SetActive(false);
        }
    }

    public void WriteInfoInFileButton()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select a file", "", "txt", false);
        WeaponIO weaponIO = new WeaponIO(weapons, this);
        weaponIO.WriteInfoInFile(path[0]);
    }

    public void CloseErrorWindow()
    {
        errorPanel.SetActive(false);
        if(weapons.Count > 1)
            weapons[index].Model.SetActive(true);
    }

    public void ShowErrorPanel(string message)
    {
        if (weapons.Count > 0)
            weapons[index].Model.SetActive(false);
        errorPanel.SetActive(true);
        errorText.text = message;
    }
    public void EnableEditing()
    {
        BulletInputField.SetActive(!editing ? true : false);
        CalibreInputField.SetActive(!editing ? true : false);
        WeightInputField.SetActive(!editing ? true : false);
        CostInputField.SetActive(!editing ? true : false);

        BulletTextGObj.SetActive(editing ? true : false);
        CostTextGObj.SetActive(editing ? true : false);
        WeightTextGObj.SetActive(editing ? true : false);
        CostTextGObj.SetActive(editing ? true : false);

        editing = !editing;

    }
}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
