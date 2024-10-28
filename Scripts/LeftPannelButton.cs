<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPannelButton : MonoBehaviour
{
    public int index;
    SceneManager sceneManager;
    Camera camera;
    public int indexInList;
    void Start()
    { 
        camera = Camera.main;
        sceneManager = camera.GetComponent<SceneManager>(); 
    }

    public void ActivateWeaponByIndex()
    {
        sceneManager.currentClickedButton.image.color = new Color(0.298f, 0.298f, 0.298f);
        sceneManager.currentClickedButton = sceneManager.buttons[indexInList];
        sceneManager.currentClickedButton.image.color = new Color(0f, 0f, 0f);
        sceneManager.weapons[sceneManager.index].Model.SetActive(false);
        sceneManager.index = index;
        sceneManager.weapons[sceneManager.index].Model.SetActive(true);
        sceneManager.UpdateInfo();
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPannelButton : MonoBehaviour
{
    public int index;
    SceneManager sceneManager;
    Camera camera;
    public int indexInList;
    void Start()
    { 
        camera = Camera.main;
        sceneManager = camera.GetComponent<SceneManager>(); 
    }

    public void ActivateWeaponByIndex()
    {
        sceneManager.currentClickedButton.image.color = new Color(0.298f, 0.298f, 0.298f);
        sceneManager.currentClickedButton = sceneManager.buttons[indexInList];
        sceneManager.currentClickedButton.image.color = new Color(0f, 0f, 0f);
        sceneManager.weapons[sceneManager.index].Model.SetActive(false);
        sceneManager.index = index;
        sceneManager.weapons[sceneManager.index].Model.SetActive(true);
        sceneManager.UpdateInfo();
    }
}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
