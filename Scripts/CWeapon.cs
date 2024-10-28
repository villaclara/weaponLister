<<<<<<< HEAD

using UnityEngine;


namespace Kursovaaa
{
    public class CWeapon
    {
        private GameObject model;
        private string modelString;
        private string type;
        private string producer;
        private float calibre;
        private int bullets;
        private int size;
        private float weight;
        private float cost;
        public GameObject Model { get => model; set => model = value; }
        public string ModelString { get => modelString; set => modelString = value; }
        public string Type { get => type; set => type = value; }
        public string Producer { get => producer; set => producer = value; }
        public float Calibre { get => calibre; set => calibre = value; }
        public int Bullets { get => bullets; set => bullets = value; }
        public int Size { get => size; set { size = value;
                model.transform.localScale = new Vector3(value, value, value);} }
        public float Weight { get => weight; set => weight = value; }
        public float Cost { get => cost; set => cost = value; }

        public CWeapon()
        {
            ModelString = "empty";
            Model = null;
            Type = "empty";
            Bullets = 0;
            Producer = "empty";
            Calibre = 0;
            Size = 0;
            Weight = 0;
            Cost = 0;
        }

        //use this when getting weapons from file
        public CWeapon(GameObject model,string modelString, string type, string producer, float calibre, int bullets, int size, float weight, float cost)
        {
            Model = model;
            ModelString = modelString;
            Type = type;
            Producer = producer;
            Calibre = calibre;
            Bullets = bullets;
            Size = size;
            Weight = weight;
            Cost = cost;
        }
        public CWeapon(GameObject model, string modelString)
        {
            Model = model;
            if (modelString == "AK47")
            {
                ModelString = modelString;
                Type = "Assault Rifle";
                Bullets = 30;
                Producer = "Kalashnikov Concern";
                Calibre = 7.62f;
                Size = 4;
                Weight = 3.47f; // kg
                Cost = 700; // Approximate cost in USD
            }

            else if (modelString == "BennelliM4")
            {
                ModelString = modelString;
                Type = "Shotgun";
                Bullets = 7;
                Producer = "Benelli Armi S.p.A.";
                Calibre = 12; // Gauge
                Size = 4;
                Weight = 3.82f; // kg
                Cost = 2000; // Approximate cost in USD
            }

            else if (modelString == "M2")
            {
                Model.transform.position = new Vector3(1f, -1f, 4f);
                ModelString = modelString;
                Type = "Heavy Machine Gun";
                Bullets = 100;
                Producer = "Browning";
                Calibre = 12.7f; // mm (.50 BMG)
                Size = 3;
                Weight = 38.0f; // kg
                Cost = 8000; // Approximate cost in USD
            }

            else if (modelString == "M4_8")
            {
                ModelString = modelString;
                Type = "Carbine";
                Bullets = 30;
                Producer = "Colt's Manufacturing";
                Calibre = 5.56f; // mm
                Size = 4;
                Weight = 2.88f; // kg
                Cost = 1000; // Approximate cost in USD
            }

            else if (modelString == "M107")
            {
                ModelString = modelString;
                Type = "Sniper Rifle";
                Bullets = 10;
                Producer = "Barrett Firearms Manufacturing";
                Calibre = 12.7f; // mm (.50 BMG)
                Size = 4;
                Weight = 13.5f; // kg
                Cost = 12000; // Approximate cost in USD
            }

            else if (modelString == "M249")
            {
                ModelString = modelString;
                Type = "Light Machine Gun";
                Bullets = 200;
                Producer = "FN Herstal";
                Calibre = 5.56f; // mm
                Size = 4;
                Weight = 7.5f; // kg
                Cost = 4000; // Approximate cost in USD
            }

            else if (modelString == "M1911")
            {
                ModelString = modelString;
                Type = "Pistol";
                Bullets = 7;
                Producer = "Colt's Manufacturing";
                Calibre = 11.43f; // mm (.45 ACP)
                Size = 4;
                Weight = 1.1f; // kg
                Cost = 1000; // Approximate cost in USD
            }

            else if (modelString == "RPG7")
            {
                ModelString = modelString;
                Type = "Rocket-Propelled Grenade Launcher";
                Bullets = 1; // Single-shot reloadable
                Producer = "Bazalt";
                Calibre = 40; // mm
                Size = 3;
                Weight = 7.0f; // kg (launcher without grenade)
                Cost = 2000; // Approximate cost in USD
            }

            else if (modelString == "Uzi")
            {
                ModelString = modelString;
                Type = "Submachine Gun";
                Bullets = 32;
                Producer = "Israel Military Industries";
                Calibre = 9f; // mm
                Size = 4;
                Weight = 3.5f; // kg
                Cost = 1200; // Approximate cost in USD
            }
        }

        public CWeapon(CWeapon other) : this(other.Model,other.ModelString, other.Type, other.Producer, other.Calibre, other.Bullets, other.Size, other.Weight, other.Cost)
=======

using UnityEngine;


namespace Kursovaaa
{
    public class CWeapon
    {
        private GameObject model;
        private string modelString;
        private string type;
        private string producer;
        private float calibre;
        private int bullets;
        private int size;
        private float weight;
        private float cost;
        public GameObject Model { get => model; set => model = value; }
        public string ModelString { get => modelString; set => modelString = value; }
        public string Type { get => type; set => type = value; }
        public string Producer { get => producer; set => producer = value; }
        public float Calibre { get => calibre; set => calibre = value; }
        public int Bullets { get => bullets; set => bullets = value; }
        public int Size { get => size; set { size = value;
                model.transform.localScale = new Vector3(value, value, value);} }
        public float Weight { get => weight; set => weight = value; }
        public float Cost { get => cost; set => cost = value; }

        public CWeapon()
        {
            ModelString = "empty";
            Model = null;
            Type = "empty";
            Bullets = 0;
            Producer = "empty";
            Calibre = 0;
            Size = 0;
            Weight = 0;
            Cost = 0;
        }

        //use this when getting weapons from file
        public CWeapon(GameObject model,string modelString, string type, string producer, float calibre, int bullets, int size, float weight, float cost)
        {
            Model = model;
            ModelString = modelString;
            Type = type;
            Producer = producer;
            Calibre = calibre;
            Bullets = bullets;
            Size = size;
            Weight = weight;
            Cost = cost;
        }
        public CWeapon(GameObject model, string modelString)
        {
            Model = model;
            if (modelString == "AK47")
            {
                ModelString = modelString;
                Type = "Assault Rifle";
                Bullets = 30;
                Producer = "Kalashnikov Concern";
                Calibre = 7.62f;
                Size = 4;
                Weight = 3.47f; // kg
                Cost = 700; // Approximate cost in USD
            }

            else if (modelString == "BennelliM4")
            {
                ModelString = modelString;
                Type = "Shotgun";
                Bullets = 7;
                Producer = "Benelli Armi S.p.A.";
                Calibre = 12; // Gauge
                Size = 4;
                Weight = 3.82f; // kg
                Cost = 2000; // Approximate cost in USD
            }

            else if (modelString == "M2")
            {
                Model.transform.position = new Vector3(1f, -1f, 4f);
                ModelString = modelString;
                Type = "Heavy Machine Gun";
                Bullets = 100;
                Producer = "Browning";
                Calibre = 12.7f; // mm (.50 BMG)
                Size = 3;
                Weight = 38.0f; // kg
                Cost = 8000; // Approximate cost in USD
            }

            else if (modelString == "M4_8")
            {
                ModelString = modelString;
                Type = "Carbine";
                Bullets = 30;
                Producer = "Colt's Manufacturing";
                Calibre = 5.56f; // mm
                Size = 4;
                Weight = 2.88f; // kg
                Cost = 1000; // Approximate cost in USD
            }

            else if (modelString == "M107")
            {
                ModelString = modelString;
                Type = "Sniper Rifle";
                Bullets = 10;
                Producer = "Barrett Firearms Manufacturing";
                Calibre = 12.7f; // mm (.50 BMG)
                Size = 4;
                Weight = 13.5f; // kg
                Cost = 12000; // Approximate cost in USD
            }

            else if (modelString == "M249")
            {
                ModelString = modelString;
                Type = "Light Machine Gun";
                Bullets = 200;
                Producer = "FN Herstal";
                Calibre = 5.56f; // mm
                Size = 4;
                Weight = 7.5f; // kg
                Cost = 4000; // Approximate cost in USD
            }

            else if (modelString == "M1911")
            {
                ModelString = modelString;
                Type = "Pistol";
                Bullets = 7;
                Producer = "Colt's Manufacturing";
                Calibre = 11.43f; // mm (.45 ACP)
                Size = 4;
                Weight = 1.1f; // kg
                Cost = 1000; // Approximate cost in USD
            }

            else if (modelString == "RPG7")
            {
                ModelString = modelString;
                Type = "Rocket-Propelled Grenade Launcher";
                Bullets = 1; // Single-shot reloadable
                Producer = "Bazalt";
                Calibre = 40; // mm
                Size = 3;
                Weight = 7.0f; // kg (launcher without grenade)
                Cost = 2000; // Approximate cost in USD
            }

            else if (modelString == "Uzi")
            {
                ModelString = modelString;
                Type = "Submachine Gun";
                Bullets = 32;
                Producer = "Israel Military Industries";
                Calibre = 9f; // mm
                Size = 4;
                Weight = 3.5f; // kg
                Cost = 1200; // Approximate cost in USD
            }
        }

        public CWeapon(CWeapon other) : this(other.Model,other.ModelString, other.Type, other.Producer, other.Calibre, other.Bullets, other.Size, other.Weight, other.Cost)
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
        { }

        public static bool operator ==(CWeapon other)
        {
            return (this.modelString == other.modelString);
<<<<<<< HEAD
        }

    } 
=======
        }

    } 
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
}