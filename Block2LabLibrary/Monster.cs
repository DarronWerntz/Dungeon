using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Monster : Character
    {


        //Fields ***Private INT****
        #region Fields

        private int _minDamage;

        #endregion



        //Properties
        #region Properties
       
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = (value < MaxDamage && value > 0) ? value : 1; }
        }
        
        public string Description { get; set; }

        #endregion



        //Constructors
        #region Constructors

        public Monster(string name, int maxLife, int life, int hitChance, int block,
            int maxDamage, int minDamage, string description)
            : base(name, maxLife, life, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }

        #endregion



        //Methods
        #region Methods

        public override string ToString()
        {
            return base.ToString() + $"\nDamage: {MinDamage} - {MaxDamage}\n{Description}";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }


        #endregion



    }
}
