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


            //TODO - Variable to keep score


            //TODO - Weapon object creation


            //TODO - Player object creation


            //Main Game Loop
            //TODO Output the final score.
            #region Main Game
                        
            bool lose = false;
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());


                //TODO - Generate a monster


                //Encounter/Menu Loop
                #region Main Menu Loop


                bool reload = false;
                do
                {
                    
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    
                    Console.Clear();

                    
                    switch (choice)
                    {
                        case ConsoleKey.A: //TODO Combat
                            break;
                        case ConsoleKey.R: //TODO Run Away
                            Console.WriteLine("You run from the fight");
                            reload = true;
                            break;
                        case ConsoleKey.P: //TODO Player
                            break;
                        case ConsoleKey.M: //TODO Monster
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


                    //TODO Check player life. If they're dead, game over.

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

    }
}