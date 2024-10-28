<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Scripting;

namespace Kursovaaa
{
    public class WeaponIO
    {
        public List<CWeapon> weapons;
        SceneManager sceneManager;
        public WeaponIO(List<CWeapon> weapons, SceneManager sceneManager)
        {
            this.weapons = weapons;
            this.sceneManager = sceneManager;
        }

        public void GetInfoFromFile(string fPath)
        {
            string filePath = fPath;
            FileStream fileStream = File.OpenRead(filePath);
            StreamReader reader = new StreamReader(fileStream);
            string input;
            int timesread = 0;
            while ((input = reader.ReadLine()) != null)
            {
                timesread++;
                string[] words = input.Split(',');
                if (words.Length != 8)
                {
                    sceneManager.ShowErrorPanel("Дані не було зчитано!");
                    return;
                }
                CWeapon wpn = new CWeapon(sceneManager.CreateWeaponObj(words[0]), words[0], words[1], words[2], float.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]), float.Parse(words[6]), float.Parse(words[7]));
                weapons.Add(wpn);
                sceneManager.CreateButton(sceneManager.buttons.Count);
            }

            if(timesread == 0)
            {
                sceneManager.ShowErrorPanel("Файл для зчитування пустий!");
                return;
            }

            if (sceneManager.currentClickedButton == null)
            {
                sceneManager.currentClickedButton = sceneManager.buttons[0];
                sceneManager.buttons[0].image.color = new Color(0f, 0f, 0f);
                weapons[0].Model.SetActive(true);
                sceneManager.UpdateInfo();
            }
        }


        public void WriteInfoInFile(string fPath)
        {
            if (weapons == null || weapons.Count == 0)
            {
                sceneManager.ShowErrorPanel("Немає зброї для записування!");
                return;
            }
            using (FileStream fileStream = new FileStream(fPath, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                string line;
                foreach (CWeapon weapon in weapons)
                {
                    line = weapon.ModelString + "," + weapon.Type + "," + weapon.Producer + "," + weapon.Calibre + "," + weapon.Bullets + "," + weapon.Size + "," + weapon.Weight + "," + weapon.Cost;
                    writer.WriteLine(line);
                }
            }
        }
    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Scripting;

namespace Kursovaaa
{
    public class WeaponIO
    {
        public List<CWeapon> weapons;
        SceneManager sceneManager;
        public WeaponIO(List<CWeapon> weapons, SceneManager sceneManager)
        {
            this.weapons = weapons;
            this.sceneManager = sceneManager;
        }

        public void GetInfoFromFile(string fPath)
        {
            string filePath = fPath;
            FileStream fileStream = File.OpenRead(filePath);
            StreamReader reader = new StreamReader(fileStream);
            string input;
            int timesread = 0;
            while ((input = reader.ReadLine()) != null)
            {
                timesread++;
                string[] words = input.Split(',');
                if (words.Length != 8)
                {
                    sceneManager.ShowErrorPanel("Дані не було зчитано!");
                    return;
                }
                CWeapon wpn = new CWeapon(sceneManager.CreateWeaponObj(words[0]), words[0], words[1], words[2], float.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]), float.Parse(words[6]), float.Parse(words[7]));
                weapons.Add(wpn);
                sceneManager.CreateButton(sceneManager.buttons.Count);
            }

            if(timesread == 0)
            {
                sceneManager.ShowErrorPanel("Файл для зчитування пустий!");
                return;
            }

            if (sceneManager.currentClickedButton == null)
            {
                sceneManager.currentClickedButton = sceneManager.buttons[0];
                sceneManager.buttons[0].image.color = new Color(0f, 0f, 0f);
                weapons[0].Model.SetActive(true);
                sceneManager.UpdateInfo();
            }
        }


        public void WriteInfoInFile(string fPath)
        {
            if (weapons == null || weapons.Count == 0)
            {
                sceneManager.ShowErrorPanel("Немає зброї для записування!");
                return;
            }
            using (FileStream fileStream = new FileStream(fPath, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                string line;
                foreach (CWeapon weapon in weapons)
                {
                    line = weapon.ModelString + "," + weapon.Type + "," + weapon.Producer + "," + weapon.Calibre + "," + weapon.Bullets + "," + weapon.Size + "," + weapon.Weight + "," + weapon.Cost;
                    writer.WriteLine(line);
                }
            }
        }
    }

}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
