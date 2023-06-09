﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace AppTickets
{
    #region Uso de datos de un usuario
    public class Login
    {
        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id {set; get;}
        
        [MaxLength(20)]
        public string Usuario { get; set; }
        
        [MaxLength(20)]
        public string Password { get; set; }
    }
    #endregion

    #region Uso de datos para el crear ticket
    public class NewPedido 
    {
        public NewPedido() { }

        [PrimaryKey, AutoIncrement]
        public int Id { set; get;}

        [MaxLength(20)]
        public string Referencia { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(20)]
        public string Despacho { get; set; }
        [MaxLength(30)]
        public double Kilos { get; set; }
    }

    #endregion

    #region Manejo de datos y conexion a BD
    public class Auxiliar 
    {
        static object locker = new object();
        SQLiteConnection conexion;
        public Auxiliar() //Esto es un constructor
        {
            conexion = ConectarBD();
            conexion.CreateTable<Login>();
            conexion.CreateTable<NewPedido>();
        }

        public SQLite.SQLiteConnection ConectarBD() 
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "asesoria.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        //Selecionar 1 registro
        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario) 
        {
            lock(locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Usuario == NombreUsuario && x.Password == ClaveUsuario);
            }
        }
        //Selecionar un Ticket
        public NewPedido SelecionarUnTicket(int Id) 
        {
            lock (locker) 
            {
                return conexion.Table<NewPedido>().FirstOrDefault(x => x.Id == Id);
            }
        }

        //Selecionar Muchos
        public IEnumerable<Login> SeleccionarTodo() 
        {
            lock (locker) 
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }

        //Selecionar todos los registros de Ticket
        public IEnumerable<NewPedido> SelecionarTodosTicket() 
        {
            lock (locker) 
            {
                return (from i in conexion.Table<NewPedido>() select i).ToList();
            }
        }

        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        //Guardar _ Actualizar Ticket
        public int GuardarTicket(NewPedido registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }

        //Eliminar Ticket
        public int EliminarTicket(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<NewPedido>(ID);
            }
        }

    }
    #endregion
}