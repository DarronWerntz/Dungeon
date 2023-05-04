using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {

        //Fields
        #region Fields

        private string _name;
        private int _maxDamage;
        private int _minDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private string _type;

        #endregion


        //Properties
        #region Properties

        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get
            {
                return _minDamage;
            }
            set
            {
                if (value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = MaxDamage;
                }
            }
        }

        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public string Type { get; set; }

        #endregion


        //Constructors
        #region Constructors

        public Weapon(string name, int maxDamage, int minDamage, int bonusHitChance, bool isTwoHanded, string type)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;

        }


        #endregion


        //Methods
        #region Methods

        public override string ToString()
        {
            return $"{Name}: {(IsTwoHanded ? "Two" : "One")}-Handed\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"Weapon Type: {Type}\n";

        }

        #endregion



    }
}
