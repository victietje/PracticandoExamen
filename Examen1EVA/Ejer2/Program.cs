
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;

namespace pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Para poder acceder al sistema, introduce tu usuario y clave: ");
            Loguearse();
            Console.WriteLine("1. Introducir mensaje\n2. Transmitir mensaje\n3. Recibir mensaje\n4. Salir");
            int opcion = int.Parse(Console.ReadLine() ?? "");
            string mensaje = "";


            switch (opcion)
            {
                case 1:
                    mensaje = RecogeMensaje();
                    break;
                case 2:
                    TransmitiendoMensaje(mensaje);
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Introduce una opción válida");
                    break;
            }


            Console.ReadLine();
        }
        public static string Loguearse()
        {
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine() ?? "";
            Console.WriteLine("Clave: ");
            string clave = LeeClave();
            bool correcto = CompruebaUsuario(usuario, clave); //Por que en la solución del FTP lo omites y creas directamente una variable bool 'correcto' y no hay nada del metodo ComrpruebaUsuario() ???

            if (CompruebaUsuario(usuario, clave))
                return clave;
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos, vuelva a intentarlo");
                clave = LeeClave();
            }

            return clave;
        }
        public static string RecogeMensaje()
        {
            Console.WriteLine("Introduce mensaje a transmitir: ");
            string mensaje = Console.ReadLine() ?? "";

            return mensaje;
        }
        public static void TransmitiendoMensaje(string mensaje)
        {
            string clave = Loguearse();
            string mensajeCodificado = CodificaMensaje(mensaje, clave);
            string mensajeCodigo = AñadeCodigoControl(mensajeCodificado);

            Console.WriteLine("Transmitiendo mensaje: ");
            for (int i = 0; i < mensajeCodigo.Length - 1; i++)
            {
                Console.WriteLine(mensaje[i]);
                Thread.Sleep(500);
            }
        }
        public static bool CompruebaCodigoControl(string mensajeCodificado)
        {
            int suma = 0;

            for (int i = 0; i < mensajeCodificado.Length; i++)
            {
                suma -= mensajeCodificado[i]; // Hacer la operación contraria? Simplemente restar en vez de sumar?
            }

            mensajeCodificado += (char)(suma % 256);

            DecodificaMensaje(mensajeCodificado, ) // No entiendo el llamar ahora a decodificar mensaje Carmen
            

            //Como verifico el último caracter???
        }
        public static string LeeClave()
        {
            char[] contraseña = new char[15];
            int cont = 0;
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);
                if (tecla.KeyChar != '\0')
                {
                    Console.Write("*");
                    contraseña[cont++] = tecla.KeyChar;
                }
                if (tecla.Key == ConsoleKey.Backspace)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            } while (tecla.Key != ConsoleKey.Enter && cont < 15);

            return new string(contraseña); //Por que new string
        }
        public static bool CompruebaUsuario(string usuario, string clave)
        {
            var (usuarios, _) = UsuariosSitema();
            return usuarios.Contains(usuario);
        }
        static (string[], string[]) UsuariosSitema()
        {
            string[] usuarios = { "Juan", "Ana", "Luis" };
            string[] claves = { "Elzumo3.", "calabaza", "1234567890" };
            return (usuarios, claves);
        }
        public static string CodificaMensaje(string mensaje, string clave)
        {
            StringBuilder mensajeCodificado = new StringBuilder();
            int j = 0;

            for (int i = 0; i < mensaje.Length; i++)
            {
                mensajeCodificado.Append(mensaje[i] + clave[j++]);
                if (j == clave.Length - 1)
                    j = 0;
            }

            return mensajeCodificado.ToString();
        }
        public static string AñadeCodigoControl(string mensajeCodificado)
        {
            int suma = 0;

            for (int i = 0; i < mensajeCodificado.Length; i++)
            {
                suma += mensajeCodificado[i];
            }

            mensajeCodificado += (char)(suma % 256);
            Console.WriteLine(mensajeCodificado);

            return mensajeCodificado;
        }
        public static string DecodificaMensaje(string mensaje, string clave)
        {
            StringBuilder mensajeDecodificado = new StringBuilder();
            int j = 0;

            for (int i = 0; i < mensaje.Length; i++)
            {
                mensajeDecodificado.Append(mensaje[i] - clave[j++]);
                if (j == clave.Length - 1)
                    j = 0;
            }

            return mensajeDecodificado.ToString();
        }      
    }
}


