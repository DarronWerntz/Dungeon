using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Goblin : Monster
    {


        //Fields
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

        public bool Nimble { get; set; }

        #endregion



        //Constructors
        #region Constructors


        public Goblin(string name, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, string description,
            bool nimble) 
            : base(name, maxLife, life, hitChance, block, maxDamage, minDamage, description)
        {
            Nimble = nimble;
        }


        #endregion


        //Methods
        #region Methods

        public override int CalcHitChance()
        {
            if (Nimble)
            {
                int hitChance = HitChance + 5;
            }
            return CalcHitChance();
        }


        #endregion
    }
}
