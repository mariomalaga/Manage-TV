/*
* PRÁCTICA.............: Práctica 1.
* NOMBRE y APELLIDOS...: Mario Olivera Castañeda
* CURSO y GRUPO........: 2o Desarrollo de Interfaces
* TÍTULO de la PRÁCTICA: P.O.O. Abstracción. Definición de Clases.
* FECHA de ENTREGA.....: 17 de Octubre de 2018
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Aplicacion
    {
        #region Variables
        private static Tv tv;
        #endregion
        #region Main
        static void Main(string[] args)
        {
            string casos = "";
            tv = new Tv();
            Elegir();
            Console.WriteLine("Compramos una " + tv.Marca + "...");
            tv = new Tv(tv.Marca, tv.Pulgadas, tv.Consumo, tv.Precio);
            while (casos != "8")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Caso 1: Información técnica de la televisión.");
                Console.WriteLine("Caso 2: Encender o apagar la televisión.");
                Console.WriteLine("Caso 3: Subir el volúmen de la televisión.");
                Console.WriteLine("Caso 4: Bajar el volúmen de la televisión.");
                Console.WriteLine("Caso 5: Poner canal elegido.");
                Console.WriteLine("Caso 6: Cambiar canal anterior.");
                Console.WriteLine("Caso 7: Estado de la televisión.");
                Console.WriteLine("Caso 8: Salir");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                casos = Console.ReadLine();
                #region Switch
                switch (casos)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Información técnica de la televisión: \n");
                        tv.InformacionTecnica();
                        break;
                    case "2":
                        Console.Clear();
                        tv.PulsarOnOff();
                        break;
                    case "3":
                        Console.Clear();
                        tv.SubirVolumen();
                        break;
                    case "4":
                        Console.Clear();
                        tv.BajarVolumen();
                        break;
                    case "5":
                        Console.Clear();
                        int ponerCanal = ControlarEntradaInt("Introducir canal: "); 
                        tv.PonerCanal(ponerCanal);
                        break;
                    case "6":
                        Console.Clear();
                        tv.CambiarCanalAnterior();
                        break;
                    case "7":
                        Console.Clear();
                        tv.EstadoActual();
                        break;
                    case "8":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Fin de la ejecución.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Has introducido un valor distinto a los indicados.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Por favor introduzca un valor de los indicados.\n");
                        break;
                }
                #endregion
            }
        }
        #endregion
        #region Metodos
        #region Metodo Elegir
        static void Elegir()
        {
        string eleccion;
            bool eleccionCorrecto = false;
            while (!eleccionCorrecto)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Escriba 1 para poner valores de televisión.");
                Console.WriteLine("Escriba 2 para usar valores por defecto de televisión.\n");
                eleccion = Console.ReadLine(); 
                switch (eleccion)
                {
                    case "1":
                        bool introducirPulgadas = false;
                        bool introducirConsumo = false;
                        bool introducirPrecio = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Introduzca marca del televisor");
                        tv.Marca = Console.ReadLine();
                        tv.Pulgadas = ControlarEntradaFloat("Introduzca pulgadas del televisor (entre 11 y 55 pulgadas)");
                        while (!introducirPulgadas)
                        {
                            Console.Clear();
                            if (tv.Pulgadas < 11 || tv.Pulgadas > 55)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Error al introducir las pulgadas\n");
                                tv.Pulgadas = ControlarEntradaFloat("Introduzca pulgadas del televisor (entre 11 y 55 pulgadas)");
                            }
                            else
                            {
                                introducirPulgadas = !introducirPulgadas;
                            }
                        }
                        tv.Consumo = ControlarEntradaFloat("Introduzca consumo del televisor (entre 25 y 300)");
                        while (!introducirConsumo)
                        {
                            Console.Clear();
                            if (tv.Consumo < 25 || tv.Consumo >= 300)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Error al introducir el consumo\n");
                                tv.Consumo = ControlarEntradaFloat("Introduzca consumo del televisor (entre 25 y 300)");
                            }
                            else
                            {
                                introducirConsumo = !introducirConsumo;
                            }
                        }
                        tv.Precio = ControlarEntradaFloat("Introduzca precio del televisor (entre 100 y 10000)\n");
                        while (!introducirPrecio)
                        {
                            Console.Clear();
                            if (tv.Precio < 100 || tv.Precio > 10000)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Error al introducir el precio\n");
                                tv.Precio = ControlarEntradaFloat("Introduzca precio del televisor (entre 100 y 10000) ");
                            }
                            else
                            {
                                introducirPrecio = !introducirPrecio;
                            }
                        }
                        eleccionCorrecto = !eleccionCorrecto;
                        break;
                    case "2":
                        tv.Marca = "Sanyo";
                        tv.Pulgadas = 28;
                        tv.Consumo = 300;
                        tv.Precio = 499.95f;
                        eleccionCorrecto = !eleccionCorrecto;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Has introducido un valor distinto a los indicados.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Por favor introduzca un valor de los indicados.\n");
                        break;
                }
            }
        }
        #endregion
        #region Metodo ControlarEntradaFloat
        static float ControlarEntradaFloat(string texto)
        {
            float valor;
            bool esNumero;
            string variable;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto + "\n");
                variable = Console.ReadLine();
                esNumero = float.TryParse(variable, out valor);
                if (!esNumero)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir. Por favor vuelva a introducir\n");
                }
            }
            while (!esNumero);
            return float.Parse(variable);
        }
        #endregion
        #region Metodo ControlarEntradaInt
        static int ControlarEntradaInt(string texto)
        {
            int valor;
            bool esNumero;
            string variable;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto + "\n");
                variable = Console.ReadLine();
                esNumero = int.TryParse(variable, out valor);
                if (!esNumero)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir. Por favor vuelva a introducir\n");
                }
            }
            while (!esNumero);
            return int.Parse(variable);
        }
        #endregion
        #endregion
    }
}
