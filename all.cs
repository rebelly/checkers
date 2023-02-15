using System; // все работает только с положительными числами
class Program
{


    static void gen_field(out int[,] field, int num) //инициализация поля с наибольшим количеством граблей
    {

        field = new int[,] {
            {0,0,0,0,2,0,0,0 },
            {0,0,0,1,0,1,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,1,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            };


    }
    static void output_field(int[,] field) // ничего лучше не придумал, хотя там надо поиграться с Unicode
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i,j]);  
            }
            Console.WriteLine();
        }
        Console.WriteLine("______________");
    }
    static int move(int i, int j, int[,] field, int killed) // считает по одной из диагоналей, но пока вопрос как запоминать их и сравнивать , как вариант два доп массива, где первый - результат похода шашки по каждому из путей, а вторая - направление в которое надо пойти.
    {
        Console.WriteLine(killed);
        if (i < field.GetLength(0) - 2 && j > 1 && field[i + 1, j - 1] == 1) // черная справа снизу, остальные по аналогии , если справа - то j+1, если сверху, то i -1 !!!!!!!!!
        {
            if (field[i + 2, j - 2] == 0)
            {
                field[i + 1, j - 1] = 0;
                field[i, j] = 0;
                field[i + 2, j - 2] = 2;
                output_field(field);
                return move(i + 2, j - 2, field, killed=killed+1);
            }
        }
     return killed;
            
        

    }
    static void find_white (out int i, out int j, int[,] field){ //функция поиска нашей белой шашки
        i = -1;
        j = -1;
        for (int o = 0; o < field.GetLength(0); o++)
        {
            for ( int e=0; e < field.GetLength(1); e++){
                if (field[o, e] == 2)
                {
                    i = o;
                    j = e;
                    break;
                }
            }
        }
        }
    static void game(char [,] field)
    {
     
    }
    public static void Main() 
    {
        int m = int.Parse(Console.ReadLine());
        int n =     int.Parse(Console.ReadLine());
        int [,]  field = new int[8, 8];
        
        gen_field(out field, 1);
        find_white(out int i, out int j, field);
        Console.WriteLine(move(i, j, field, 0));
    }
}
