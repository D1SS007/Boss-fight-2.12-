using System;

namespace ConsoleApp2._13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            bool isTotemIvoked = false;
            
            int playerHealth = random.Next(800,1000);           
            int playerMana = random.Next(500, 600);
            int swordDamage = random.Next(50, 60);
            int fireBallDamage = random.Next(80, 100);
            int fireBallManaCost = 400;
            int healRestore = random.Next(100, 150);
            int heahManaCost = 60;
            int lightningDamage = random.Next(50, 100);
            int lightningManaCost = 70;
            int totemDamageIncresing = 2;
            int totemManaCost = 200;
            int evasionHeal = random.Next(30, 40);
            int evasionManaCost = random.Next(60, 80);


            int bossHealth = random.Next(800, 1100);            
            int bossKickDmage = random.Next(60, 90);

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine("Player Heath: " + playerHealth + ", Player Mana : " + playerMana);
                Console.WriteLine("Boss Health : " + bossHealth );

                Console.WriteLine($"" +
                    $"\n1 - SWORD STRIKE   | {swordDamage} dmg                                |   0 mana cost " +
                    $"\n2 - FIREBALL       | {fireBallDamage} dmg                                | {fireBallManaCost} mana cost, " +
                    $"\n3 - NATURE HEAL    | {healRestore} restore health                    | {heahManaCost}  mana cost" +
                    $"\n4 - LIGHTNING      | {lightningDamage} dmg                                | {lightningManaCost}  mana, requires totem" +
                    $"\n5 - TOTEM INVOKING | increases dmg in {totemDamageIncresing} times              | {totemManaCost} mana," +
                    $"\n6 - EVASION        | evade next boss attack and heal a bit | {evasionManaCost}  mana ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("you deal boss " + swordDamage + " damage");
                        bossHealth -= swordDamage;
                        Console.WriteLine("boss strikes you back and deal  " + bossKickDmage + " damage");
                        playerHealth -= bossKickDmage;
                        break;

                    case 2:
                        if (playerMana >= fireBallManaCost)
                        {
                            Console.WriteLine("you deal boss " + fireBallDamage + " damage");
                            bossHealth -= fireBallDamage;
                            playerMana -= fireBallManaCost;
                            Console.WriteLine("boss strikes you back and deal  " + bossKickDmage + " damage");
                            playerHealth -= bossKickDmage;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not enought mana");
                        }
                        break;

                    case 3:
                        if (playerMana <= heahManaCost)
                        {
                            Console.WriteLine("you heal for " + healRestore);
                            playerHealth += healRestore;
                            playerMana -= heahManaCost;
                            Console.WriteLine("boss strikes you back and deal  " + bossKickDmage + " damage");
                            playerHealth -= bossKickDmage;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not enought mana");
                        }
                        break;


                    case 4:
                        if (isTotemIvoked == true)
                        {
                            if (playerMana <= lightningManaCost)
                            {
                                Console.WriteLine("you deal boss " + lightningDamage + " damage");
                                bossHealth -= lightningDamage;
                                playerMana -= lightningManaCost;
                                Console.WriteLine("boss strikes you back and deal  " + bossKickDmage + " damage");
                                playerHealth -= bossKickDmage;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Not enought mana");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Totem is not invoked");
                        }
                        
                        break;

                    case 5:
                        if (isTotemIvoked == false)
                        {
                            if (playerMana >= totemManaCost)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    isTotemIvoked = true;
                                    swordDamage *= totemDamageIncresing;
                                    healRestore *= totemDamageIncresing;
                                    fireBallDamage *= totemDamageIncresing;
                                    lightningDamage *= totemDamageIncresing;
                                }
                            }
                            Console.WriteLine($"Totem has been invoked, damage increased in {totemDamageIncresing} times!!!");
                        }
                        else
                        {
                            Console.WriteLine("Not enought mana");
                        }

                        break;

                    case 6:
                        if(playerMana >= evasionManaCost)
                        {
                            Console.WriteLine("you deal evade next boss strike");
                            playerMana -= evasionManaCost;
                            playerHealth += evasionHeal;
                            Console.WriteLine("boss strike and miss");
                        }
                        else
                        {
                            Console.WriteLine("Not enought mana");
                        }

                        break;

                    default:
                        Console.WriteLine("No ability");
                        break;
                }
                Console.WriteLine("Press any key for next round");
                Console.ReadKey();
                Console.Clear();
            }
            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("NoOne wins");
            }
            else if (playerHealth <= 0 )
            {
                Console.WriteLine("Boss Wins");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Player Wins");
            }
        }
    }
}
