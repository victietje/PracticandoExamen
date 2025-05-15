using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Introduce el número de partidos de LaLiga: ");
        int numPartidos = int.Parse(Console.ReadLine() ?? "");

        string datos = RecogeDatosEquipos(numPartidos);
        string resumen = ResumenLiga(datos);
        MuestraResumenLiga(resumen);
    }

    public static (string, int) RecogeDatosEquipo()
    {
        string nombre = "";
        int puntos = default;

        Console.Write("\nNombre: ");
        nombre = Console.ReadLine() ?? "";

        Console.Write("Puntos: ");
        puntos = int.Parse(Console.ReadLine() ?? "");

        return (nombre, puntos);
    }
    public static string RecogeDatosEquipos(int numPartidos)
    {
        StringBuilder cadena = new StringBuilder();
        string local, visitante;
        int puntosLocal, puntosVisitante;
        
        for (int i = 0; i < numPartidos; i++)
        {
            Console.WriteLine($"Partido {i + 1}");

            Console.Write("Equipo local: ");
            (local, puntosLocal) = RecogeDatosEquipo();

            Console.Write("Equipo visitante: ");
            (visitante, puntosVisitante) = RecogeDatosEquipo();
            cadena.Append($"{local} ({puntosLocal}) - {visitante} ({puntosVisitante})#");
        }
            
        return cadena.ToString();;
    }
    public bool EsNumero(char caracter) => char.IsDigit(caracter);
    public static string ResumenLiga(string cadena)
    {
        StringBuilder resumen = new StringBuilder();
        int contador = 0;

        for(int i=0; i<cadena.Length; i++)
        {
            if(contador < 3)
            {
                resumen.Append(cadena[i]);
                contador++;
            }

            if(cadena[i] == ' ' && cadena[i+1]!='(')
            {
                resumen.Append(' ');
                contador = 0;
            }
        }

        return resumen.ToString();
    }
    public static void MuestraResumenLiga(string resumen)
    {
        Console.WriteLine(resumen);
    }
}