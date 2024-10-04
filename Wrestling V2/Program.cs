
using System.Xml.Linq;
Random random = new Random();
int psp = 100;          // hp left
int usedpsp = 0;        // used sp this round, resets every round
//
int csp = 100;          // HP left
int usedcsp = 0;        // used sp this round, resets every round
//
int dead = 0;           // start count for computer´s min hp random 

int x = 0;              //retunerar poängen
int y = 0;              //retunerar poängen
int playerpoints = x;   // för att definera poängen 
int computerpoints = y; // för att definera poängen 


int ticker = 1; // rounds

Console.WriteLine("Do you dare to face off against the arm wrestling world champion COMPUTOS MAXIMUS");
Console.WriteLine("Press Y to start N to exit");
string startplaying = Console.ReadLine().ToLower();
if (startplaying == "y")
{
    Console.WriteLine("What is your Wrestling name?");
    string username = Console.ReadLine().ToUpper();
    Console.WriteLine($"Welcome to the Arm Wrestling game. Our next Challanger {username} is up and ");

    do
    {
        // round 1 - 3
        Console.WriteLine($"Round {ticker}.... Fight");
        usedpsp = 0;
        usedcsp = 0;
        

        usedpsp = PlayerSP();
        Console.WriteLine($"You have {psp} SP LEFT!");

        var (remaningCsp, usedCsp) = ComputerSP(dead);
        Console.WriteLine($"The other player have used {usedCsp} SP it have {remaningCsp} SP left!");

        RoundS(ref x, ref y, psp, csp, usedpsp, usedCsp);
        ++ticker;

    }
    while (x < 2 && y < 2);

    if (x == 2)
    {
        Console.WriteLine($"{username} WON AND IS THE NEW CHAMPION!!!! YOU WON WITH {x} - {y} WINS!! CLAME YOUR PRIZE WITH DEATH!");
    }
    else 
    {
        Console.WriteLine($"COMPUTOS MAXIMUS IS STILL THE UNDEFEATED CHAMPION!!!! AND YOU {username} HAVE LOST! " +
            $"\n THE FINALS SCORE IS {y} - {x}");
    }
}
else if (startplaying == "n")
{
    Console.WriteLine("*Sniff* *sniff* i smell a fucking chicken around here.");
}
else
{
    Console.WriteLine("Can you not read fool?");
}

int PlayerSP()
{
    Console.WriteLine($"Chooce your strenght from 0 - {psp}");
    int usedpsp = int.Parse(Console.ReadLine());

    if (usedpsp > -1 && usedpsp <= psp)
    {
        psp -= usedpsp;
        return usedpsp;
    }
    else
    {
        Console.WriteLine($"Invalid PlayerSP you only have {psp} left");
        return PlayerSP();
    }
}

(int, int) ComputerSP(int dead)
{
    Console.WriteLine("Your opponent is loading....");
    int usedcsp = random.Next(dead, csp);
    csp -= usedcsp;

    return (csp, usedcsp);
}

int RoundS(ref int x, ref int y, int csp, int psp, int usedpsp, int usedcsp)
{
    if (usedpsp > usedcsp)
    {
        ++x;
        Console.WriteLine("You won son.");
        return x;
    }
    else if (usedpsp == usedcsp)
    {
        Console.WriteLine("Its a DRAW!");
        return 0;
    }
    else
    {
        ++y;
        Console.WriteLine("COMPUTOS MAXIMUS won this round!! ");
        return y;
    }
}


