using System;

class Program
{
    static void Main()
    {
        // Välkomstmeddelande och start av spelet  
        Console.WriteLine("");
        Console.WriteLine("██╗░░░██╗░█████╗░██╗░░░░░██╗░░██╗░█████╗░███╗░░░███╗███╗░░░███╗███████╗███╗░░██╗  ████████╗██╗██╗░░░░░██╗░░░░░");
        Console.WriteLine("██║░░░██║██╔══██╗██║░░░░░██║░██╔╝██╔══██╗████╗░████║████╗░████║██╔════╝████╗░██║  ╚══██╔══╝██║██║░░░░░██║░░░░░");
        Console.WriteLine("╚██╗░██╔╝███████║██║░░░░░█████═╝░██║░░██║██╔████╔██║██╔████╔██║█████╗░░██╔██╗██║  ░░░██║░░░██║██║░░░░░██║░░░░░");
        Console.WriteLine("░╚████╔╝░██╔══██║██║░░░░░██╔═██╗░██║░░██║██║╚██╔╝██║██║╚██╔╝██║██╔══╝░░██║╚████║  ░░░██║░░░██║██║░░░░░██║░░░░░");
        Console.WriteLine("░░╚██╔╝░░██║░░██║███████╗██║░╚██╗╚█████╔╝██║░╚═╝░██║██║░╚═╝░██║███████╗██║░╚███║  ░░░██║░░░██║███████╗███████╗");
        Console.WriteLine("░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝  ░░░╚═╝░░░╚═╝╚══════╝╚══════╝");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("███████╗██╗░██████╗░██╗░░██╗████████╗  ██████╗░  ░██╗░░░░░░░██╗██╗███╗░░██╗");
        Console.WriteLine("██╔════╝██║██╔════╝░██║░░██║╚══██╔══╝  ╚════██╗  ░██║░░██╗░░██║██║████╗░██║");
        Console.WriteLine("█████╗░░██║██║░░██╗░███████║░░░██║░░░  ░░███╔═╝  ░╚██╗████╗██╔╝██║██╔██╗██║");
        Console.WriteLine("██╔══╝░░██║██║░░╚██╗██╔══██║░░░██║░░░  ██╔══╝░░  ░░████╔═████║░██║██║╚████║");
        Console.WriteLine("██║░░░░░██║╚██████╔╝██║░░██║░░░██║░░░  ███████╗  ░░╚██╔╝░╚██╔╝░██║██║░╚███║");
        Console.WriteLine("╚═╝░░░░░╚═╝░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░  ╚══════╝  ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝");

        Console.ReadLine();


        // Karaktärer
        Player player1 = new Player("Player 1", 100);
        Player player2 = new Player("Player 2", 100);

        // Loop där spelarna slåss tills en av dem dör.
        while (player1.IsAlive && player2.IsAlive)
        {
            // Spelare 1 attackerar Spelare 2
            int damage = 0;
            bool hit = player1.Attack(out damage);
            if (hit)
            {
                Console.WriteLine(player1.Name + " attackerar " + player2.Name + " och gör " + damage + " skada!");
                Thread.Sleep(500); // Vänta en halv sekund för att göra det enklare att följa med
                player2.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine(player1.Name + " missade!");
                Thread.Sleep(500); // Vänta en halv sekund för att göra det enklare att följa med
            }

            // Spelare 2 attackerar Spelare 1
            if (player2.IsAlive)
            {
                damage = 0;
                hit = player2.Attack(out damage);
                if (hit)
                {
                    Console.WriteLine(player2.Name + " attackerar " + player1.Name + " och gör " + damage + " skada!");
                    Thread.Sleep(500); // Vänta en halv sekund för att göra det enklare att följa med
                    player1.TakeDamage(damage);
                }
                else
                {
                    Console.WriteLine(player2.Name + " missade!");
                    Thread.Sleep(500); // Vänta en halv sekund för att göra det enklare att följa med
                }
            }
        }

        if (player1.IsAlive)
        {
            Console.WriteLine();
            Console.WriteLine("  ________________ ");
            Console.WriteLine(" /                \\");
            Console.WriteLine("/                  \\");
            Console.WriteLine(player1.Name + " vann!");
            Console.WriteLine("\\                  /");
            Console.WriteLine(" \\________________/");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("  ________________ ");
            Console.WriteLine(" /                \\");
            Console.WriteLine("/                  \\");
            Console.WriteLine(player2.Name + " vann!");
            Console.WriteLine("\\                  /");
            Console.WriteLine(" \\________________/");
        }
        Console.WriteLine("Avsluta spelet genom att trycka på valfri tangent!");
        Console.ReadLine();
    }
}

// Klass för spelarna
class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public bool IsAlive { get { return Health > 0; } }

    private Random random = new Random();

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // Låter spelare attackera en annan spelare
    public bool Attack(out int damage)
    {
        if (random.Next(1, 11) <= 8) // 80% chans att träffa
        {
            damage = random.Next(1, 11);
            return true;
        }
        else
        {
            damage = 0;
            return false;
        }
    }

    // Spelare tar skada
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (!IsAlive)
        {
            Console.WriteLine(Name + " är död!");
        }
    }
}