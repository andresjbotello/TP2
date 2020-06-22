using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuario
    {
        private Business.Logic.UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio { get => _UsuarioNegocio; set => _UsuarioNegocio = value; }

        public Usuario()
        {
            UsuarioNegocio = new UsuarioLogic();
        }


        public void Menu()
        {
            int opc = 0;

            Console.WriteLine("1- Listado General");
            Console.WriteLine("2- Consulta");
            Console.WriteLine("3- Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar");
            Console.WriteLine("6- Salir");

            opc = Convert.ToInt32(Console.ReadLine());

            while(opc != 6) 
            { 
                switch (opc)
                {
                    case 1:
                        ListadoGeneral();
                        Console.Clear();
                        Console.WriteLine("1- Listado General");
                        Console.WriteLine("2- Consulta");
                        Console.WriteLine("3- Agregar");
                        Console.WriteLine("4- Modificar");
                        Console.WriteLine("5- Eliminar");
                        Console.WriteLine("6- Salir");
                        opc = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 2:
                        Consultar();
                        Console.Clear();
                        Console.WriteLine("1- Listado General");
                        Console.WriteLine("2- Consulta");
                        Console.WriteLine("3- Agregar");
                        Console.WriteLine("4- Modificar");
                        Console.WriteLine("5- Eliminar");
                        Console.WriteLine("6- Salir");
                        opc = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 3:
                        Agregar();
                        Console.Clear();
                        Console.WriteLine("1- Listado General");
                        Console.WriteLine("2- Consulta");
                        Console.WriteLine("3- Agregar");
                        Console.WriteLine("4- Modificar");
                        Console.WriteLine("5- Eliminar");
                        Console.WriteLine("6- Salir");
                        opc = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Modificar();
                        Console.Clear();
                        Console.WriteLine("1- Listado General");
                        Console.WriteLine("2- Consulta");
                        Console.WriteLine("3- Agregar");
                        Console.WriteLine("4- Modificar");
                        Console.WriteLine("5- Eliminar");
                        Console.WriteLine("6- Salir");
                        opc = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 5:
                        Eliminar();
                        Console.Clear();
                        Console.WriteLine("1- Listado General");
                        Console.WriteLine("2- Consulta");
                        Console.WriteLine("3- Agregar");
                        Console.WriteLine("4- Modificar");
                        Console.WriteLine("5- Eliminar");
                        Console.WriteLine("6- Salir");
                        opc = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 6:
                        break;


                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Business.Entities.Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine("Presione cualquier tecla para volver al Menu");
            Console.ReadKey();
        }

        public void Consultar()
        {
            try 
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }

            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un entero");
            }

            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Agregar()
        {
            Console.Clear();
            Business.Entities.Usuario usuario = new Business.Entities.Usuario();
            Console.WriteLine("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese Habilitacion de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Modificar()
        {
            try 
            { 
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar :");
                int ID = int.Parse(Console.ReadLine());
                Business.Entities.Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.WriteLine("Ingrese Habilitacion de Usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }

            catch(FormatException fe)
            {
                Console.WriteLine(); 
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario que desea eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
                Console.WriteLine("El usuario se elimino correctamente");
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void MostrarDatos(Business.Entities.Usuario usr)
        {
            Console.WriteLine("Usuario: " + usr.ID);
            Console.WriteLine("\t\tNombre: " + usr.Nombre);
            Console.WriteLine("\t\tApellido: " + usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: " + usr.NombreUsuario);
            Console.WriteLine("\t\tClave: "  + usr.Clave);
            Console.WriteLine("\t\tEmail: " + usr.Email);
            Console.WriteLine("\t\tHabilitado: " + usr.Habilitado);
            Console.WriteLine();

        }
    }
}
