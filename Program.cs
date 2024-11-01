﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;


namespace Clases_C
{
    internal static class Program
    {
        public class Cuenta
        {
            private string titular;
            private double cantidad;

            public Cuenta(string titular, double cantidad)
            {
                this.titular = titular;
                this.cantidad = cantidad;
            }

            public Cuenta(string titular)
            {
                this.titular = titular;
                this.cantidad = 0;
            }

            public string Titular { get; set; }
            public string Cantidad { get; set; }

            public override string ToString()
            {
                return $"{titular} tiene un total de {cantidad}$ en su cuenta.";
            }

            public void Ingresar(double cantidad)
            {
                this.cantidad += cantidad;
            }

            public void Retirar(double cantidad)
            {
                this.cantidad -= cantidad;
            }

        }

        static void eje01()
        {
            Cuenta cuenta = new Cuenta("Miguel");
            Console.WriteLine(cuenta.ToString());
            cuenta.Ingresar(1000);
            Console.WriteLine(cuenta.ToString());
            cuenta.Retirar(300.50);
            Console.WriteLine(cuenta.ToString());
            Console.ReadLine();
        }

        public class Contacto
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }

            public Contacto(string nombre, string telefono)
            {
                Nombre = nombre;
                Telefono = telefono;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                Contacto otro = (Contacto)obj;
                return Nombre.Equals(otro.Nombre, StringComparison.OrdinalIgnoreCase);
            }

            public override int GetHashCode()
            {
                return Nombre.ToLower().GetHashCode();
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Teléfono: {Telefono}";
            }
        }

        public class Agenda
        {
            private List<Contacto> contactos;
            private int maxSize;

            public Agenda(int tamaño = 10)
            {
                maxSize = tamaño;
                contactos = new List<Contacto>();
            }

            public void AniadirContacto(Contacto c)
            {
                if (agendaLlena())
                {
                    Console.WriteLine("La agenda está llena, no se pueden añadir más contactos.");
                    return;
                }
                if (existeContacto(c))
                {
                    Console.WriteLine("Este contacto ya existe en la agenda.");
                    return;
                }
                contactos.Add(c);
                Console.WriteLine("Contacto añadido correctamente.");
            }

            public bool existeContacto(Contacto c)
            {
                return contactos.Contains(c);
            }

            public void ListarContactos()
            {
                if (contactos.Count == 0)
                {
                    Console.WriteLine("La agenda está vacía.");
                    return;
                }

                Console.WriteLine("Contactos en la agenda:");
                foreach (Contacto c in contactos)
                {
                    Console.WriteLine(c);
                }
            }

            public void BuscaContacto(string nombre)
            {
                Contacto encontrado = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (encontrado != null)
                {
                    Console.WriteLine($"Teléfono de {nombre}: {encontrado.Telefono}");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }

            public void EliminarContacto(Contacto c)
            {
                if (contactos.Remove(c))
                {
                    Console.WriteLine("Contacto eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se ha encontrado el contacto a eliminar.");
                }
            }

            public bool agendaLlena()
            {
                return contactos.Count >= maxSize;
            }

            public int HuecosLibres()
            {
                return maxSize - contactos.Count;
            }
        }

        static void eje02()
        {
            Agenda agenda = new Agenda();
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú de Agenda Telefónica ---");
                Console.WriteLine("1. Añadir contacto");
                Console.WriteLine("2. Comprobar si existe contacto");
                Console.WriteLine("3. Listar todos los contactos");
                Console.WriteLine("4. Buscar contacto por nombre");
                Console.WriteLine("5. Eliminar contacto");
                Console.WriteLine("6. Comprobar si la agenda está llena");
                Console.WriteLine("7. Ver huecos libres en la agenda");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del contacto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el teléfono del contacto: ");
                        string telefono = Console.ReadLine();
                        Contacto nuevoContacto = new Contacto(nombre, telefono);
                        agenda.AniadirContacto(nuevoContacto);
                        break;

                    case 2:
                        Console.Write("Ingrese el nombre del contacto a buscar: ");
                        nombre = Console.ReadLine();
                        Contacto contactoExistente = new Contacto(nombre, "");
                        if (agenda.existeContacto(contactoExistente))
                            Console.WriteLine("El contacto existe en la agenda.");
                        else
                            Console.WriteLine("El contacto no existe.");
                        break;

                    case 3:
                        agenda.ListarContactos();
                        break;

                    case 4:
                        Console.Write("Ingrese el nombre del contacto a buscar: ");
                        nombre = Console.ReadLine();
                        agenda.BuscaContacto(nombre);
                        break;

                    case 5:
                        Console.Write("Ingrese el nombre del contacto a eliminar: ");
                        nombre = Console.ReadLine();
                        Contacto contactoAEliminar = new Contacto(nombre, "");
                        agenda.EliminarContacto(contactoAEliminar);
                        break;

                    case 6:
                        if (agenda.agendaLlena())
                            Console.WriteLine("La agenda está llena.");
                        else
                            Console.WriteLine("Aún hay espacio en la agenda.");
                        break;

                    case 7:
                        Console.WriteLine($"Huecos libres en la agenda: {agenda.HuecosLibres()}");
                        break;

                    case 8:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 8);
        }

        public class Cancion
        {
            private string titulo;
            private string autor;
            public Cancion(string titulo, string autor)
            {
                this.titulo = titulo;
                this.autor = autor;
            }

            public Cancion()
            {
                this.titulo = "";
                this.autor = "";
            }

            public string DameTitulo()
            {
                return titulo;
            }

            public void PonTitulo(string titulo)
            {
                this.titulo = titulo;
            }

            public string DameAutor()
            {
                return autor;
            }

            public void PonAutor(string autor)
            {
                this.autor = autor;
            }

            public override string ToString()
            {
                return $"Título: {titulo}, Autor: {autor}";
            }
        }

        public class CD
        {
            private Cancion[] canciones;
            private int contador;

            public CD(int capacidad = 10)
            {
                canciones = new Cancion[capacidad];
                contador = 0;
            }

            public int NumeroCanciones()
            {
                return contador;
            }

            public Cancion DameCancion(int posicion)
            {
                if (posicion < 0 || posicion >= contador)
                {
                    Console.WriteLine("Posición fuera de rango");
                    return null;
                }
                return canciones[posicion];
            }

            public void GrabaCancion(int posicion, Cancion nuevaCancion)
            {
                if (posicion < 0 || posicion >= contador)
                {
                    Console.WriteLine("Posición fuera de rango");
                    return;
                }
                canciones[posicion] = nuevaCancion;
            }

            public void Agrega(Cancion nuevaCancion)
            {
                if (contador >= canciones.Length)
                {
                    Console.WriteLine("No se pueden agregar más canciones, el CD está lleno.");
                    return;
                }
                canciones[contador] = nuevaCancion;
                contador++;
            }

            public void Elimina(int posicion)
            {
                if (posicion < 0 || posicion >= contador)
                {
                    Console.WriteLine("Posición fuera de rango");
                    return;
                }

                for (int i = posicion; i < contador - 1; i++)
                {
                    canciones[i] = canciones[i + 1];
                }
                canciones[contador - 1] = null;
                contador--;
            }

            public void ListarCanciones()
            {
                Console.WriteLine("Canciones en el CD:");
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"{i + 1}. {canciones[i]}");
                }
            }
        }

        public class Juego
        {
            public int Vidas { get; private set; }

            public Juego(int vidasIniciales)
            {
                Vidas = vidasIniciales;
            }

            public void PerderVida()
            {
                if (Vidas > 0)
                {
                    Vidas--;
                    Console.WriteLine($"Has perdido una vida. Vidas restantes: {Vidas}");
                }
                else
                {
                    Console.WriteLine("No tienes más vidas.");
                }
            }

            public void MostrarVidas()
            {
                Console.WriteLine($"Vidas restantes: {Vidas}");
            }
        }

        static void eje05()
        {
            Cancion cancion1 = new Cancion("Bohemian Rhapsody", "Queen");
            Cancion cancion2 = new Cancion("Imagine", "John Lennon");

            Console.WriteLine(cancion1);
            Console.WriteLine(cancion2);

            CD miCD = new CD(5);
            miCD.Agrega(cancion1);
            miCD.Agrega(cancion2);

            miCD.ListarCanciones();

            miCD.Elimina(1);
            miCD.ListarCanciones();

            Cancion cancion3 = new Cancion("Smells Like Teen Spirit", "Nirvana");
            miCD.Agrega(cancion3);
            miCD.GrabaCancion(0, new Cancion("Stairway to Heaven", "Led Zeppelin"));
            miCD.ListarCanciones();

            Juego juego = new Juego(3);
            juego.MostrarVidas();
            juego.PerderVida();
            juego.PerderVida();
            juego.MostrarVidas();
        }

        static void Main(string[] args)
        {
            eje05();
        }
    }
}
