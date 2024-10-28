<<<<<<< HEAD
﻿using System.Collections.Generic;
using UnityEngine;

namespace Kursovaaa
{
    internal class CWeaponSorter : MonoBehaviour
    {
        public List<CWeapon> weapons;


        //Shell sort method
        public void SortByCalibre()
        {
            int gap = weapons.Count / 2;
            while (gap > 1)
            {
                for (int i = 0; i < weapons.Count - gap; i++)
                {
                    if (i + gap >= weapons.Count)
                    {
                        gap = gap / 2;
                        return;
                    }
                    if (weapons[i].Calibre > weapons[i+gap].Calibre)
                    {
                        SwapElements(i, i + gap);
                    }

                }
                gap = gap / 2;
            }
            for (int i = 1; i < weapons.Count; i++)
            {
                int newPos = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (weapons[newPos].Calibre <weapons[j].Calibre)
                    {
                        SwapElements(newPos, j);
                        newPos = j;
                    }
                }
            }
            
        }

        private void SwapElements(int pos1, int pos2)
        {
            CWeapon tmp = weapons[pos1];
            weapons[pos1] = weapons[pos2];
            weapons[pos2] = tmp;
        }
    }
}
=======
﻿using System.Collections.Generic;
using UnityEngine;

namespace Kursovaaa
{
    internal class CWeaponSorter : MonoBehaviour
    {
        public List<CWeapon> weapons;


        //Shell sort method
        public void SortByCalibre()
        {
            int gap = weapons.Count / 2;
            while (gap > 1)
            {
                for (int i = 0; i < weapons.Count - gap; i++)
                {
                    if (i + gap >= weapons.Count)
                    {
                        gap = gap / 2;
                        return;
                    }
                    if (weapons[i].Calibre > weapons[i+gap].Calibre)
                    {
                        SwapElements(i, i + gap);
                    }

                }
                gap = gap / 2;
            }
            for (int i = 1; i < weapons.Count; i++)
            {
                int newPos = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (weapons[newPos].Calibre <weapons[j].Calibre)
                    {
                        SwapElements(newPos, j);
                        newPos = j;
                    }
                }
            }
            
        }

        private void SwapElements(int pos1, int pos2)
        {
            CWeapon tmp = weapons[pos1];
            weapons[pos1] = weapons[pos2];
            weapons[pos2] = tmp;
        }
    }
}
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
