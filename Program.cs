
bool jogar = false;
int modo = 0;

Console.WriteLine("----------------");
Console.WriteLine("-- Math Quiz --");
Console.WriteLine("Select an option:");
Console.WriteLine("1) Add");
Console.WriteLine("2) Subtract");
Console.WriteLine("3) Multiply");
Console.WriteLine("4) Divide");
Console.WriteLine("----------------");

while (!jogar)
{
    modo = Convert.ToInt32(Console.ReadLine());

    if (modo > 1 || modo < 5)
    {
        jogar = true;
    }
}

int vitorias = 0;
int[] pergunta;
int resposta;

for (int i = 0; i < 6; i++) { 
    switch (modo)
    {
        case 1:
            pergunta = Add();
            Console.WriteLine($"{pergunta[0]} + {pergunta[1]} = ?");
            resposta = Convert.ToInt32(Console.ReadLine());

            if (resposta == pergunta[2])
            {
                vitorias++;
                Console.WriteLine("Correct!");
            }
            else { Console.WriteLine("Wrong..."); }
            
            break;
        case 2:
            pergunta = Subtract();
            Console.WriteLine($"{pergunta[0]} - {pergunta[1]} = ?");
            resposta = Convert.ToInt32(Console.ReadLine());

            if (resposta == pergunta[2])
            {
                vitorias++;
                Console.WriteLine("Correct!");
            }
            else { Console.WriteLine("Wrong..."); }

            break;
        case 3:
            pergunta = Multiply();
            Console.WriteLine($"{pergunta[0]} * {pergunta[1]} = ?");
            resposta = Convert.ToInt32(Console.ReadLine());

            if (resposta == pergunta[2])
            {
                vitorias++;
                Console.WriteLine("Correct!");
            }
            else { Console.WriteLine("Wrong..."); }

            break;
        case 4:
            pergunta = Divide();
            Console.WriteLine($"{pergunta[0]} / {pergunta[1]} = ?");
            resposta = Convert.ToInt32(Console.ReadLine());

            if (resposta == pergunta[2])
            {
                vitorias++;
                Console.WriteLine("Correct!");
            }
            else { Console.WriteLine("Wrong..."); }

            break;
        default:
            Console.WriteLine("Not a valid input!");
            break;
    }
}

Console.WriteLine("------------------------");
Console.WriteLine($"Your score: {vitorias}");
Console.WriteLine("Thank you for playing!");
Console.WriteLine("------------------------");

int[] Add()
{
    Random random = new Random();
    int n1 = random.Next(101);
    int n2 = random.Next(101);

    return [n1, n2, n1 + n2];
}

int[] Subtract()
{
    Random random = new Random();
    int n1 = random.Next(101);
    int n2 = random.Next(101);

    return [n1, n2, n1 - n2];
}

int[] Multiply()
{
    Random random = new Random();
    int n1 = random.Next(101);
    int n2 = random.Next(101);

    return [n1,n2,n1 * n2];
}

int[] Divide()
{
    Random random = new Random();

    int n1 = 0;
    int n2 = 0;
    bool divisivel = false;

    while (!divisivel)
    {
        n1 = random.Next(101);
        n2 = random.Next(1,101);

        if (n1 % n2 == 0) 
        {
            divisivel = true;
        }
    }
    return [n1, n2, n1 / n2];
}