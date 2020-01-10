/*
* PRÁCTICA.............: Práctica 1.
* NOMBRE y APELLIDOS...: Mario Olivera Castañeda
* CURSO y GRUPO........: 2o Desarrollo de Interfaces
* TÍTULO de la PRÁCTICA: P.O.O. Abstracción. Definición de Clases.
* FECHA de ENTREGA.....: 17 de Octubre de 2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Tv
    {
        #region Variables
        private string marca;
        private float pulgadas;
        private float consumo;
        private float precio;
        private bool onOff = true;
        private int canal;
        private int canalAnterior;
        private int volumen;
        #endregion
        #region Constructor
        public Tv(string marca, float pulgadas, float consumo, float precio)
        {
            this.Marca = marca;
            this.Pulgadas = pulgadas;
            this.Consumo = consumo;
            this.Precio = precio;
            canal = 0;
            canalAnterior = 0;
            volumen = 1;
        }
        public Tv()
        {

        }
        #endregion
        #region Metodos
        #region Metodo PulsarOnOff
        public void PulsarOnOff()
        {
            if (!onOff)
            {
                onOff = !onOff;
                canal = 0;
                canalAnterior = 0;
                volumen = 1;
                EstadoActual();  
            }
            else 
            {
                onOff = !onOff;
                canal = 1;
                canalAnterior = 1;
                volumen = 25;
                EstadoActual();
            }
        }
        #endregion
        #region Metodo SubirVolumen
        public void SubirVolumen()
        {
            if (!onOff)
            {
                if (volumen < 100 && volumen >= 1)
                {
                    volumen++;
                    EstadoActual();
                }
                else if (volumen == 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Volumen al máximo no se puede subir más el volumen");
                    Console.Beep();
                    EstadoActual();
                }
            }else {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep();
                }
                EstadoActual();
            }
        }
        #endregion
        #region Metodo BajarVolumen
        public void BajarVolumen()
        {
            if (!onOff)
            {
                if (volumen <=100 && volumen > 1)
                {
                    volumen--;
                    EstadoActual();
                }
                else if(volumen == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Volumen al mínimo, no se puede bajar más el volumen");
                    Console.Beep();
                    EstadoActual();
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep();
                }
                EstadoActual();
            }
        }
        #endregion
        #region Metodo PonerCanal
        public void PonerCanal(int nuevoCanal)
        {
            if (!onOff)
            {
                if (nuevoCanal > 99 || nuevoCanal < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir el canal");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Por favor introduzca un canal entre 0 y 100");
                    Console.Beep();
                    EstadoActual();
                }
                else
                {
                    canalAnterior = canal;
                    canal = nuevoCanal;
                    EstadoActual();
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep();
                }
                EstadoActual();
            }
        }
        #endregion
        #region Metodo CambiarCanalAnterior
        public void CambiarCanalAnterior()
        {
            int guardarCanal;
            if (!onOff)
            {
                guardarCanal = canal;
                canal = canalAnterior;
                canalAnterior = guardarCanal;
                EstadoActual();
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep();
                }
                EstadoActual();
            }
        }
        #endregion
        #region Metodo EstadoActual
        public void EstadoActual()
        {
            if (!onOff)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Encendida->Canal: "+canal+", Volumen: "+volumen);
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Apagada!");
            }
        }
        #endregion
        #region Metodo InformacionTecnica
        public void InformacionTecnica()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Marca: "+Marca+". Tamaño en pulgadas: "+Pulgadas+". Consumo: "+Consumo+"W. Precio: "+Precio+" Euros.\n");
        }
        #endregion
        #region Propiedades
        public string Marca { get => marca; set => marca = value; }
        public float Pulgadas { get => pulgadas; set => pulgadas = value; }
        public float Consumo { get => consumo; set => consumo = value; }
        public float Precio { get => precio; set => precio = value; }
        #endregion
        #endregion
    }
}

