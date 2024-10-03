
using System.Xml.Linq;
Random random = new Random();
int psp = 100;
int usedpsp = 0;
//
int csp = 100;
int usedcsp = 0;
//
int dead = 0;
//
int x = 0;
int y = 0;

Console.WriteLine("Do you dare to face off against the arm wrestling world champion COMPUTOS MAXIMUS");
Console.WriteLine("Press Y to start N to exit");
string startplaying = Console.ReadLine().ToLower();
if (startplaying == "y")
{
    
    Console.WriteLine("What is your Wrestling name?");
    string username = Console.ReadLine().ToUpper();
    Console.WriteLine($"Welcome to the Arm Wrestling game. Our next Challanger {username} is up and ");

    // round 1
    Console.WriteLine("Round 1.... Fight");
    usedpsp = 0;
    usedcsp = 0;

    usedpsp = PlayerSP();
    Console.WriteLine($"You have {psp} SP LEFT!");

    var (remaningCsp, usedCsp) = ComputerSP(dead);
    Console.WriteLine($"The other player have used {usedCsp} SP it have {remaningCsp} SP left!");

    RoundS(ref x, ref y, psp, csp, usedpsp, usedCsp);

    // round 2
    Console.WriteLine("Round 2.... Fight");
    usedpsp = 0;
    usedcsp = 0;

    usedpsp = PlayerSP();
    Console.WriteLine($"You have {psp} SP LEFT!");

    (remaningCsp, usedCsp) = ComputerSP(dead);
    Console.WriteLine($"The other player have used {usedCsp} SP it have {remaningCsp} SP left!");

    RoundS(ref x, ref y, psp, csp, usedpsp, usedCsp);

    // Final Round
    Console.WriteLine("Final Round.... Fight");
    usedpsp = 0;
    usedcsp = 0;

    usedpsp = PlayerSP();
    Console.WriteLine($"You have {psp} SP LEFT!");

    (remaningCsp, usedCsp) = ComputerSP(dead);
    Console.WriteLine($"The other player have used {usedCsp} SP it have {remaningCsp} SP left!");

    RoundS(ref x, ref y, psp, csp, usedpsp, usedCsp);






    PlayerSP();
    Console.WriteLine(psp);

    (remaningCsp, usedCsp) = ComputerSP(dead);
    Console.WriteLine($"The other player have used {usedCsp} SP it have {remaningCsp} SP left!");
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
    Console.WriteLine($"Chooce your strenght from 1 - {psp}");
    int usedpsp = int.Parse(Console.ReadLine());

    if (usedpsp > 0 && usedpsp <= psp)
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

