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
    static void output_field(char[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
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

        }
        else
        {
            field[st_x, st_y] = '*';
        }
        output_field(field);

    }
    static int f_lft_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_x;
        for (int i = st_x; i > 0; i--)
        {
            if (field[i, st_y] == '0') return (i + 1);
        }
        return res;
    }
    static int f_rght_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_x;
        for (int i = st_x; i < field.GetLength(0); i++)
        {
            if (field[st_x, i] == '0')
            {
                return (i - 1);
            }

        }
        return res;
    }
    static int f_up_bound_ship(char[,] field, int st_x, int st_y)
    {
        int res = st_y;
        for (int i = st_y; i < field.GetLength(1); i++)
        {
            if (field[st_x, i] == '0') res = (i - 1);
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
        Console.WriteLine($"{up} {down} {rght} {lft}");
        for (int i = down-1; i >= up; i--)
        {
            if (field[i, st_x] == '*')
            {
                if (i > 0)
                {

                    field[i, st_x-1] = '*';
                }
                if (i < field.GetLength(0))
                {
                    field[i, st_x+1] = '*';
                }
            }
        }
        Console.WriteLine($"{lft} {rght}");
        for (int i = lft; i <= rght; i++)
        {
            Console.WriteLine($"{field[st_y, i]} {st_y} {i}");
            if (field[st_y,  i] == '*')
            {
                if (i > 0)
                {
                    field[i, st_y - 1] = '*';
                }
                if (i < field.GetLength(0))
                {
                    field[i, st_y + 1] = '*';
                }
            }
        }
        
    }

    static void game(char[,] field)
    {
        move(field, 2, 0);
        
        move(field, 3, 0);
        move(field, 4, 0);

    }
    public static void Main()
    {

        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        char[,] field =  {
            {'0','0','1','1','1','0','0','1' },
            {'0','1','0','0','0','0','0','0' },
            {'0','1','0','0','0','1','0','0' },
            {'0','1','0','1','0','1','0','0' },
            {'0','1','0','0','0','1','0','0' },
            {'0','1','0','1','0','1','0','0' },
            {'0','0','0','0','0','0','0','0' },
            {'0','0','0','0','0','0','0','0' },
            };

        output_field(field);
        game(field);
    }
}
