using System; // по какой то причине oX и oY перепутаны местами, в остальном работает
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
    
    static void move(char[,] field, int st_x, int st_y) 
    {


        if (field[st_x, st_y] == '1')
        {
            field[st_x, st_y] = '*';
            check_strike(f_down_bound_ship(field, st_x, st_y), f_up_bound_ship(field, st_x, st_y), f_lft_bound_ship(field, st_x, st_y), f_rght_bound_ship(field, st_x, st_y), field, st_x, st_y);
            
        }
        else
        {
            field[st_x, st_y] = '*';
        }


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
        for (int i = st_y; i >=0; i--)
        {
            if (field[st_x, i] == '0') res = (i + 1);
        }
        return res;
    }
    static void check_strike(int up, int down, int lft, int rght, char[,] field, int st_x, int st_y)
    {
        int counter_des_y = 0;
        for (int i = down+1; i >= up; i--)
        {
            Console.WriteLine($"{st_x} {i} {field[st_x, i]}");
            if (field[st_x, i] == '*')
            {
                
                if (st_x > 0)
                {
                    field[st_x - 1, i] = '*';
                }
                if (st_x < field.GetLength(0))
                {
                    field[st_x + 1, i] = '*';
                }
                counter_des_y++;
            }
        }
        if (counter_des_y == down -up - 1)
        {
            if (st_y > 0)
            {
                field[st_x, st_y-1] = '*';
            }
            if (st_y < field.GetLength(1))
            {
                field[st_x , st_y+1] = '*';
            }
        }
        int counter_des_x = 0;
        for (int i = lft; i <= rght; i++)
        {
            if (field[i, st_y] == '*')
            {
                if (st_y > 0)
                {
                    field[i, st_y-1] = '*';
                }
                if (st_y < field.GetLength(0))
                {
                    field[i, st_y+1] = '*';
                }
                counter_des_x++;
            }
        }
        if (counter_des_x == rght - lft - 1)
        {
            if (st_x > 0)
            {
                field[st_x-1, st_y ] = '*';
            }
            if (st_x < field.GetLength(0))
            {
                field[st_x+1, st_y ] = '*';
            }
        }
        output_field(field);
    }
    
    static void game(char[,] field)
    {
        move(field, 1, 1);
        move(field, 1, 2);
        move(field, 1, 3);
        move(field, 1, 4);
        move(field, 1, 5);

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
            };

        output_field(field);
        game(field);
    }
}
