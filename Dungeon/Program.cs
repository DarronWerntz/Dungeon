using DungeonLibrary;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            
            Console.Title = "THE GOBLIN KEEP";
            Console.WriteLine("Welcome, Hero! Goblins have been pouring out to the lands from a mysterious cave called The Goblin Keep wreaking havoc everywhere they go. Indeed, much destruction has been made to the lands we call home, but not a single goblin has been sighted in nearly a week... It could be that the goblins are gathering their numbers to prepare for a battle to end all that we know and love. You, hero, must delve into its labrynthine depths and slay the goblin king to end the terrors being unleashed on our world! Stay vigilant and enter at your own peril... Victory will only be found by the brave and the bold! Oh, and bring a lantern. Goblins are known to dwell in dark places.\n\n");

            #endregion


            //Variable to keep score
            int score = 0;


            //Player Creation
            #region PlayerCreation

            //Weapon Choice
            #region Weapon Selection

            //Weapon Choice Creation
            Weapon wep1 = new("Sword", 6, 1, 5, true, WeaponType.Sword);
            Weapon wep2 = new("Dagger", 4, 1, 10, false, WeaponType.Dagger);
            Weapon wep3 = new("Mace", 10, 3, 0, true, WeaponType.Mace);
            Weapon wep4 = new("Crossbow", 8, 1, 5, true, WeaponType.Crossbow);
            Weapon wep5 = new("Staff", 6, 1, 5, true, WeaponType.Staff);

            List<Weapon> weapons = new List<Weapon>() { wep1, wep2, wep3, wep4, wep5 };

            Weapon userWeapon = new();

            bool wepEquipped = false;
            do
            {
                Console.WriteLine($"What is your weapon, oh brave one?\n" +
                                  $"1) {wep1.Type}\n" +
                                  $"2) {wep2.Type}\n" +
                                  $"3) {wep3.Type}\n" +
                                  $"4) {wep4.Type}\n" +
                                  $"5) {wep5.Type}\n");
                string userChoice = (Console.ReadKey().KeyChar).ToString();
                Console.Clear();

                if (!int.TryParse(userChoice, out int wepChoice))
                {
                    Console.WriteLine("...You use a what? Tell me, really...\n"); continue;
                }
                else
                {
                    if (wepChoice > 0 && wepChoice < 6)
                    {
                        userWeapon = weapons[wepChoice -1];
                        wepEquipped = true;
                    }
                    else
                    {
                        Console.WriteLine("Why are you being so difficult about this....");
                    }
                }
               

            } while (!wepEquipped);

            #endregion

            //Race Choice
            #region Race Selection

            Race[] races = Enum.GetValues<Race>();

            Console.WriteLine("\nYou look funny for a... uhh... What are you exactly?");

            int raceChoice = 0;

            do
            {

                foreach (Race item in races)
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }

                 raceChoice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (raceChoice > 0 && raceChoice <= races.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Why are you being so difficult about this....");
                }


            } while (true);


            Race userRace = (Race)(raceChoice);
            
            Console.Clear();


            #endregion



            #endregion


            Console.WriteLine("\nWait! Should you conquer The Goblin Keep, tell me, what name shall I relay to the bards for the hero who saved our realm?\n");

            Console.Write("What is your Name: ");
            string name = Console.ReadLine();
            
            Console.Clear();


            Console.WriteLine($"\nA {userRace} named {name}, huh? Well, I wish you luck on your adventure. Enter the keep and SLAY EVERY GOBLIN YOU SEE!\n\n\n\n\n");

            Console.WriteLine("Press a button to continue");
            Console.ReadKey();
            Console.Clear();

            Player player = new Player(name, userRace, userWeapon);


            //Main Game Loop
            #region Main Game
                        
            bool lose = false;
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());


                //Generate a monster
                Monster monster = GetMonster();
                Console.WriteLine("Opponent: " + monster.Name);


                //Encounter/Menu Loop
                #region Main Menu Loop


                bool reload = false;
                do
                {
                    
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "W) Weapon Info\n" +
                        "S) Score\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    
                    Console.Clear();

                    
                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Combat.DoAttack(player, monster);
                            Combat.DoAttack(monster, player);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name!}\n");
                                Console.ResetColor();
                                score += 1;
                                Console.WriteLine($"\nYou take the opportunity to rest and restore your strength\n");
                                player.Life += 10;
                                Console.WriteLine($"So far, you have defeated {score} monsters.");
                                Console.ReadKey();
                                Console.Clear();
                                reload = true;
                                //score++;
                                //Possible Expansion: good spot for levelling and rewards.
                                //money, equipment. blah blah, chance to heal
                            }
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("You run from the fight");
                            //Attack of Opportunity
                            Combat.DoAttack(monster, player);
                            //Console.WriteLine("You have defeated " + score + " monster.");
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.W:
                            Console.WriteLine(userWeapon);
                            break;

                        case ConsoleKey.S:
                            Console.WriteLine(score);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("Quit");
                            lose = true;
                            break;

                        default:
                            Console.WriteLine("Select an option from the menu.");
                            break;
                    }

                    if (player.Life <= 0)
                    {
                        Console.WriteLine($"You died and were forgotten, but you took {score} monsters with you!  \n");
                        lose = true;
                    }


                    //While Reload and Lose are BOTH FALSE, keep looping.
                } while (!reload && !lose);
                
                #endregion

            } while (!lose);
            #endregion


        }//end Main()

        //GetRooms
        #region Get Room

        private static string GetRoom()
        {
            #region Room Descriptions

            string[] rooms = {
                "As you carefully advance through a narrow and seemingly endless passageway, you see a dim light ahead. As you approach the source of this light, you enter an expansive, dimly lit grotto. You can see the source of the light coming from an opening at the top of the room with the sound of rushing waters echoing throughout the cavernous room and notice water pouring down from the hole above you. There is a large patch of ground next to a pool of water - large enough to set up camp and get some rest. You see no signs of danger and the the water's downpour can help to mask any noise you may make. Time for some rest. You awake, the light coming from the opening above you has grown dark, night has come. You begin to rise when you noticed something cold wrapped around your ankle. Grabbing your lantern, you see a pink, bony monstrous claw has cutched your leg. The arm leads into the pool next to your camp. A pair of red glowing eyes peer at you from within the water's fall.\n",

                "Stumbling through a dark tunnel, you are met with a large, solid wooden door. A sign is posted to the door stating Only Death Beyond. There is a weak, slow scratching on the other side of this door. Cautiously, you reach for the metal latch and lift it preparing for what may come next\n",

                "Travelling through a serpentine passageway, a faint shriek is heard, followed by silence. You stand alert, peering into the darkness before you. Another shriek, louder this time. Distant footsteps echo on the stony ground tapping louder and louder as something makes its way toward you. You begin to see the silhouette of a terrifying creature barelling towards you!\n",

                "Slime. The pungent smell of decay is all that emenates from the cave before you. It started as you made your way through a tunnel. There were dried, brown footprints of many orcs painting the ground with this stuff - all heading in the opposite direction. Clearly, they were running from something, and you're headed straight toward it. As you make your reach the end of the tunnel and meet the entrance to a new cavernous expanse, you try to observe the cavern beholden to you. It's dark, but as you peer into the darkness you notice a shifting shadow. Time to investigate.\n",

                "You enter a small room and see a creature peering up at stalactites. His body is covered in a brown slime from head to toe. It's muttering incoherent words. You sneak closer to it and start to clearly hear a single word: Death. Suddenly, without warning, the monster lunges at you.\n",

                "You enter a big room with a horde of treasure littered around stalagmites. A creature is seen suspended to a wall by a sword. It's a golden sword. You walk over to retrieve this new weapon when suddenly the creature springs to life flailing about wildly. Its vigorous movements knock itself free and it stands and pulls the sword out of its ribcage. It lunges towards you.\n"
            };

            #endregion

            #region Room RNG

            Random rand = new Random();
            int index = rand.Next(rooms.Length);
            
            return rooms[index];

            //return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()
        #endregion

        #endregion

        //GetMonster
        #region Get Monster

        private static Monster GetMonster()
        {
            Monster m1 = new("Necromancer", 50, 50, 80, 15, 8, 1, "An undead creature that raises the dead.");
            Monster m2 = new("Skeleton Lord", 45, 45, 80, 25, 8, 1, "An armored skeleton with a large shield.");
            Monster m3 = new(name: "Wraith", 35, 35, 80, 20, 8, 1, "A ghostly manifestation of hate that sends chills down your spine.");
            Monster m4 = new("Hob Goblin", 40, 40, 80, 20, 8, 1, "A stout goblin with more intelligence than your average goblin.");

            Zombie m5 = new("Zombie", 25, life: 25, hitChance: 80, block: 10, maxDamage: 4, minDamage: 1, description: "A decaying creature raised from the dead.", decayed: true);
            Skeleton m6 = new("Skeleton", 20, 20, 80, 15, 4, 1, "A armored, shaky skeleton with brittle bones.", true);
            Ghost m7 = new("Ghost",15, 15, 80, 10, 4, 1, "A lingering spirit seeking vengeance.", true);
            Goblin m8 = new("Goblin", 20, 20, 80, 10, 4, 1, "A sneaky, nimble goblin.", true);

            Monster[] monsters =
            {
                m1,
                m2,
                m3,
                m4,

                m5,m5,m5,
                m6,m6,m6,
                m7,m7,m7,
                m8,m8,m8,
            };

            return monsters[new Random().Next(monsters.Length)];
        }

        #endregion

    }
}