using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Skeleton : Monster
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

        public bool Brittle { get; set; }

        #endregion



        //Constructors
        #region Constructors


        public Skeleton(string name, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, string description,
            bool brittle) 
            : base(name, maxLife, life, hitChance, block, maxDamage, minDamage, description)
        {
            Brittle = brittle;
        }


        #endregion


        //Methods
        #region Methods

        public override int CalcBlock()
        {
            if (Brittle)
            {
                int block = Block - 5;
            }
            return CalcBlock();
        }


        #endregion
    }
}
