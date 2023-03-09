using System; // вертикальные 
class Program
{


    static void gen_field(out char[,] field)
    {

        field = new char[,] {
            {'0','0','0','1','1','0','0','1' },
            {'0','1','0','0','0','0','0','0' },
            {'0','1','0','0','0','1','0','0' },
            {'0','1','0','1','0','1','0','0' },
            {'0','1','0','0','0','1','0','0' },
            {'0','1','0','1','0','1','0','0' },
            {'0','0','0','0','0','0','0','0' },
            {'0','0','0','1','1','0','0','1' },
            };

       
    }
    static bool ships_afloat (char[, ] field)
    {
        bool res = false;
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; i < field.GetLength(1); i++)
            {
                if (field[i, j] == '0')
                {
                    res = true;
                    return res;
                }
            }
        }
        return res;
    }
    static void output_field(char[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
				if (field[i,j] == '*')
                Console.Write(field[i, j]);
                else Console.Write('-');
            }
            Console.WriteLine();
        }
        Console.WriteLine("______________");
    }

    static void move(char[,] field, int st_y, int st_x)
    {

        
        if (field[st_x, st_y] == '1')
        {
            field[st_x, st_y] = '*';
            check_strike(f_down_bound_ship(field, st_x, st_y), f_up_bound_ship(field, st_x, st_y), f_lft_bound_ship(field, st_x, st_y), f_rght_bound_ship(field, st_x, st_y), field, st_y, st_x);
            Console.WriteLine("ПОДБИТ");

        }
        else
        {
            field[st_x, st_y] = '*';
            Console.WriteLine("ПРОМАХ");
        }
        output_field(field);

    }
    static int f_lft_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_y;
        for (int i = st_y; i > 0; i--)
        {
            if (field[st_x, i] == '0' ) return (i+1);
        }
        return res;
    }
    static int f_rght_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_y;
        for (int i = st_y; i < field.GetLength(1); i++)
        {
            if (field[st_x, i] == '0')
            {
                return i;
            }

        }
        return res;
    }
    static int f_up_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_y;
        for (int i = st_y; i < field.GetLength(1); i++)
        {
            if (field[st_x, i] == '0') res = i;
        }
        return res;
    }
    static int f_down_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = -st_y;
        for (int i = st_y; i >= 0; i--)
        {
            if (field[st_x, i] == '0') res = (i + 1);
        }
        return res;
    }
    static void check_strike(int up, int down, int lft, int rght, char[,] field, int st_x, int st_y)
    {
		if (st_y > 0)
		{
			if ( st_x> 0)
			field[st_y-1, st_x - 1] = '*';
			if (st_x < field.GetLength(1)) field[st_y-1, st_x+1] = '*';
		}
		if (st_y < field.GetLength(0))
		{
			if (st_x < field.GetLength(1))
			field[st_y+1, st_x + 1] = '*';
			if (st_x > 0) field[st_y+1, st_x-1] = '*';
		}

    }

    static void game(char[,] field)
    {
        int st_x;
        int st_y;
        while (ships_afloat(field))
        {
            Console.Write("Введите кординаты удара от 1 до 8 по оси Х:");
            st_x = int.Parse(Console.ReadLine());
            if (st_x > 8 || st_x <= 0 )
            {
                Console.WriteLine("КАПИТАН, ВЫ ВЫХОДИТЕ ЗА ПРИДЕЛЫ ПОЛЯ СРАЖЕНИЙ, ЭТО ГРОЗИТ ВАМ ПОНИЖЕНИИ В ЗВАНИИ, НЕМЕДЛЕННО ПРЕКРАТИТЕ ВЕСТИ ОГОНЬ ПО ТЕРРОТОРИАЛЬНЫМ ВОДАМ");

                continue;
            }
            Console.Write("Введите кординаты удара от 1 до 8 по оси Y:");
            st_y = int.Parse(Console.ReadLine());
            if (st_y > 8 || st_y <= 0)
            {
                Console.WriteLine("КАПИТАН, ВЫ ВЫХОДИТЕ ЗА ПРИДЕЛЫ ПОЛЯ СРАЖЕНИЙ, ЭТО ГРОЗИТ ВАМ ПОНИЖЕНИИ В ЗВАНИИ, НЕМЕДЛЕННО ПРЕКРАТИТЕ ВЕСТИ ОГОНЬ ПО ТЕРРОТОРИАЛЬНЫМ ВОДАМ");

                continue;
            }
            if (field[st_x-1, st_y-1] == '*') Console.WriteLine("КАПИТАН, ВЫ БЬЕТЕ ПО ПОЛЮ НА КОТОРОМ НЕТ КОРАБЛЯ, ПРОТРИТЕ ЛИНЗЫ ОККУЛЯРЫ ПРИЦЕЛОВ");
            move(field, st_x-1, st_y-1);
        }

    }
    public static void Main()
    {

		Console.WriteLine("Добро пожаловать в морской бой, капитан!");
		Console.WriteLine("Сегодня предстоит жаркий бой , и чтобы вам было удобнее управлять эксадрой, я введу несколько обозначений, указанных на радаре" );
		Console.WriteLine("Если вы видете знак '*' - значит удар по этим координатам уже наносился , и второй раз бить туда не следует, вы просто жгете снаряды");
		Console.WriteLine("Если вы видете знак '-' - значит разведданых по этим координатам нет, стоит проверить их, вдруг там засел вражский линкор");
		Console.WriteLine("Если вы видете знак 'X' - значит что удар по этим координатам уже был нанесен и вражеский корабль в огне!");

        char[,] field;
        gen_field(out field);

        output_field(field);
        game(field);
    }
}

