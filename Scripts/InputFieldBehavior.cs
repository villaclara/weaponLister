<<<<<<< HEAD
﻿using UnityEngine;

public class InputField : MonoBehaviour
{
    SceneManager sceneManager;
    Camera camera;
    void Start()
    {
        camera = Camera.main;
        sceneManager = camera.GetComponent<SceneManager>();
    }

    // Method called when the user changes the "Bullets" input field.
    public void BulletsChanged(string input)
    {
        try
        {
            int result = int.Parse(input);
            sceneManager.weapons[sceneManager.index].Bullets = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }

    // Method called when the user changes the "Calibre" input field.
    public void CalibreChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Calibre = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }

    // Method called when the user changes the "Weight" input field.
    public void WeightChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Weight = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }
    public void CostChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Cost = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }


}
=======
﻿using UnityEngine;

public class InputField : MonoBehaviour
{
    SceneManager sceneManager;
    Camera camera;
    void Start()
    {
        camera = Camera.main;
        sceneManager = camera.GetComponent<SceneManager>();
    }

    // Method called when the user changes the "Bullets" input field.
    public void BulletsChanged(string input)
    {
        try
        {
            int result = int.Parse(input);
            sceneManager.weapons[sceneManager.index].Bullets = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }

    // Method called when the user changes the "Calibre" input field.
    public void CalibreChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Calibre = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }

    // Method called when the user changes the "Weight" input field.
    public void WeightChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Weight = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }
    public void CostChanged(string input)
    {
        try
        {
            float result = float.Parse(input);
            sceneManager.weapons[sceneManager.index].Cost = result;
            sceneManager.UpdateInfo();
        }
        catch
        {
            sceneManager.ShowErrorPanel("Не вдалось записати нове значення");
        }
    }


}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
