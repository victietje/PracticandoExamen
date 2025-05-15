using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = RellenaArray();
        array = MueveCeros(array);
        MuestraArray(array);
    }
    public static int[] RellenaArray()
    {
        Console.Write("Introduce el tamaño del array: ");
        int tamaño = int.Parse(Console.ReadLine() ?? "");

        int[] arrayEnteros = new int[tamaño];
        Random random = new Random();

        for (int i = 0; i < arrayEnteros.Length; i++)
            arrayEnteros[i] = random.Next(0, 11);

        return arrayEnteros;
    }
    public static int[] MueveCeros(int[] arrayEnteros)
    {
        int cont = 0;

        for (int i = 0; i < arrayEnteros.Length; i++)
        {
            if(arrayEnteros[i] != 0)
            {
                if(i != cont) //Por que un if dentro de un if
                {
                    (arrayEnteros[cont], arrayEnteros[i]) = (arrayEnteros[i], arrayEnteros[cont]); //Stnitaxis abreviada de intercambiar??
                }
                cont++;
            }  
        }

        return arrayEnteros;
    }
    public static void MuestraArray(int[] arrayEnteros)
    {
        foreach (var num in arrayEnteros)
            Console.Write(num);
    }
}