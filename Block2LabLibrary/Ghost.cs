using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Ghost : Monster
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

        public bool Floating { get; set; }

        #endregion



        //Constructors
        #region Constructors


        public Ghost(string name, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, string description,
            bool floating) 
            : base(name, maxLife, life, hitChance, block, maxDamage, minDamage, description)
        {
            Floating = floating;
        }


        #endregion


        //Methods
        #region Methods

        public override int CalcBlock()
        {
            if (Floating)
            {
                int block = Block + 5;
            }
            return CalcBlock();
        }


        #endregion
    }
}
