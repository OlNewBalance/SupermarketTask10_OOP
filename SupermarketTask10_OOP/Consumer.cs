namespace Task10
{
    public class Consumer
    {
        private static readonly Random random = new Random();

        public double Rubles;

        public List<Goods> Bag = new List<Goods>();

        // Отдельные булевые флаги "хочу/не хочу"
        public bool WantsMeat;
        public bool WantsAlcohol;
        public bool WantsFruits;
        public bool WantsElectronic;
        public bool WantsVegetables;
        public bool WantsClothes;

        public Consumer(int rubles)
        {
            Rubles = rubles;

            // Генерация потребностей
            WantsMeat = random.Next(2) == 0;
            WantsAlcohol = random.Next(2) == 0;
            WantsFruits = random.Next(2) == 0;
            WantsElectronic = random.Next(2) == 0;
            WantsVegetables = random.Next(2) == 0;
            WantsClothes = random.Next(2) == 0;
        }

        // Метод для получения всех "желаний" в виде списка
        public Dictionary<string, bool> GetBasket()
        {
            return new Dictionary<string, bool>
            {
                { "Meat", WantsMeat },
                { "Alcohol", WantsAlcohol },
                { "Fruits", WantsFruits },
                { "Electronic", WantsElectronic },
                { "Vegetables", WantsVegetables },
                { "Clothes", WantsClothes }
            };
        }

        public void SetDesire(string key, bool value)
        {
            switch (key)
            {
                case "Meat": WantsMeat = value; break;
                case "Alcohol": WantsAlcohol = value; break;
                case "Fruits": WantsFruits = value; break;
                case "Electronic": WantsElectronic = value; break;
                case "Vegetables": WantsVegetables = value; break;
                case "Clothes": WantsClothes = value; break;
            }
        }
    }
}
