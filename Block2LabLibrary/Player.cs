using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {

        //Fields Not needed for most child classes. They inherit their fields from the parent. 
        #region Fields




        #endregion



        //Properties
        #region Properties

        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        #endregion



        //Constructors
        #region Constructors

        public Player(string name, Race playerRace, Weapon equippedWeapon)
            : base(name: name, maxLife: 50, life: 50, hitChance: 80, block: 30)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            switch (PlayerRace)
            {
                case Race.Orc:
                    HitChance -= 20;
                    EquippedWeapon.MinDamage += 5;
                    EquippedWeapon.MaxDamage += 5;
                    
                    break;
                case Race.Human:
                    MaxLife -= 5;
                    Life = MaxLife;
                    HitChance += 5;
                    Block += 5;
                    break;

                case Race.Elf:
                    HitChance += 10;
                    break;

                case Race.Dwarf:
                    MaxLife += 20;
                    Life = MaxLife;
                    Block -= 5;
                    break;

                case Race.Halfling:
                    Block += 10;
                    EquippedWeapon.MaxDamage -= 2;
                    break;

                default:
                    break;
            }
        }

        #endregion




        //Methods
        #region Methods


        public override int CalcDamage()
        {            
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.Orc:
                    raceDescription = "Orcs are the largest race in the realm. They use brute force to destroy anything foolish enough to stand in their way... If their wild swings hit...";
                    break;
                case Race.Human:
                    raceDescription = "Humans are adept at combat, but are less resilient than their elder race cousins.";
                    break;
                case Race.Elf:
                    raceDescription = "Elves are the eldest of all races, along with the orcs. Their martial skill and technique is unmatched.";
                    break;
                case Race.Dwarf:
                    raceDescription = "Dwarves are shorter than most other races, but they boast the greatest resilience of any other.";
                    break;
                case Race.Halfling:
                    raceDescription = "Halflings are small, but quick and nimble on their feet. They are excellent at running when it hits the fan.";
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" +
                $"Description: {raceDescription}";
        }

        #endregion


    }
}
