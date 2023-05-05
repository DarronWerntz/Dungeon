using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Zombie : Monster
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

        public bool Decayed { get; set; }


        #endregion



        //Constructors
        #region Constructors

        public Zombie(string name, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, string description,
            bool decayed)
            : base(name, maxLife, life, hitChance, block, maxDamage, minDamage, description)
        {
            Decayed = decayed;
        }

        #endregion



        //Methods
        #region Methods

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (Decayed)
            {
                calculatedBlock -= 5;
            }
            return calculatedBlock;
        }


        #endregion
    }
}
