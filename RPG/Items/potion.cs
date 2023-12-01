    public class Potion : Item
    {
        public Potion()
        {
            _name = "Potion";
            _description = "Small glass bottle with a strange liquid. You don't know what it is, but it's probably safe. Right?";
            _price = 5;
        }

        public void Use(Hero target)
        {
            Heal(target, 10);
        }
    }
