using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadatos;
using capanegocio
    ;
namespace capanegocio
{
    public class NDatos
    {

        public static string insertardato(string nombre, string apellido, DateTime fechanacimiento,
            string direccion, string genero, string estadocivil, string movil, string telefono, string correo
            )
        {
            Datos objeto = new Datos();
            objeto.Nombre = nombre;
            objeto.Apellido = apellido;
            objeto.Fecha_de_nacimiento = fechanacimiento;
            objeto.Direccion = direccion;
            objeto.Genero = genero;
            objeto.Estado_civil = estadocivil;
            objeto.Movil = movil;
            objeto.Telefono = telefono;
            objeto.Correo = correo;

            return objeto.insertardato(objeto);
        }

        public static string editardato(int id, string nombre, string apellido, DateTime fechanacimiento,
           string direccion, string genero, string estadocivil, string movil, string telefono, string correo
           )
        {
            Datos objeto = new Datos();
            objeto.Id = id;
            objeto.Nombre = nombre;
            objeto.Apellido = apellido;
            objeto.Fecha_de_nacimiento = fechanacimiento;
            objeto.Direccion = direccion;
            objeto.Genero = genero;
            objeto.Estado_civil = estadocivil;
            objeto.Movil = movil;
            objeto.Telefono = telefono;
            objeto.Correo = correo;

            return objeto.editardato(objeto);
        }

        public static string eliminardato(int id)
        {
            Datos objeto = new Datos();
            objeto.Id = id;
           

            return objeto.eliminardato(objeto);
        }

        public static DataTable mostrardato()
        {
            Datos objeto = new Datos();
            return objeto.mostrardato();
        }

        public static DataTable buscardatonombre(string textobuscar)
        {
            Datos objeto = new Datos();
            objeto.Textobuscar = textobuscar;
            return objeto.buscardatonombre(objeto);
        }

        public static DataTable buscardatoapellido(string textobuscar)
        {
            Datos objeto = new Datos();
            objeto.Textobuscar = textobuscar;
            return objeto.buscardatoapellido(objeto);
        }
    }
}
