using System.ComponentModel.Design;

namespace Block2LabLibrary
{

    //abstract marks a class as "incomplete" it MUST be inherited somehwere to be used.
    //abstract classes cannot be created as an object using the "new()"
    //Also, make it public so it can be used by other files.
    public abstract class Character   //Object
    {


        //Fields
        #region Fields

        private string _name;
        private int _maxLife;
        private int _life;
        private int _hitChance;
        private int _block;

        #endregion



        //Properties
        #region Properties

        public string Name
        {
            get { return _name; } //This will read
            set { _name = value; } //This will write Name to be whatever value is assigned to it in this or any child classes.
        }
        public int MaxLife { get; set; } //Shorthand.

        //Business Rule! Make sure life cannot exceed max life.
        public int Life
        {
            get { return _life; } //This will read
            set                   //This will set the value, but also include a business rule to ensure life never is life > maxlife.
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }
        public int HitChance { get; set; }
        public int Block { get; set; }

        #endregion



        //Constructors
        #region Constructors

        public Character(string name, int maxLife, int life, int hitChance, int block)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Block = block;
        }

        #endregion



        //Methods
        #region Methods

        public override string ToString()
        {
            return $"----- {Name} -----\n" +
                   $"Life: {Life} / {MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}%";
        }

        //CalcBlock() -> Returns the int Block property.
        public virtual int CalcBlock() { return Block; }

        //CalcHitChance() -> Returns the int HitChance property.
        public virtual int CalcHitChance() { return HitChance; }

        //CalcDamage() -> Returns the int of 0.
        public abstract int CalcDamage();
        //Abstract methods have no functionality, no scopes. It makes an override MANDATORY.


        #endregion



    }
}