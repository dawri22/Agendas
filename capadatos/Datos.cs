using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace capadatos
{
    public class Datos
    {

        private int _id;
        private string _nombre;
        private string _apellido;
        private DateTime _fecha_de_nacimiento;
        private string _direccion;
        private string _genero;
        private string _estado_civil;
        private string _movil;
        private string _telefono;
        private string _correo;
        private string _textobuscar;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public DateTime Fecha_de_nacimiento { get => _fecha_de_nacimiento; set => _fecha_de_nacimiento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Estado_civil { get => _estado_civil; set => _estado_civil = value; }
        public string Movil { get => _movil; set => _movil = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }

        public Datos()
        {
        }

        public Datos(int id, string nombre, string apellido, DateTime fecha_de_nacimiento, string direccion, string genero, string estado_civil, string movil, string telefono, string correo, string textobuscar)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Fecha_de_nacimiento = fecha_de_nacimiento;
            Direccion = direccion;
            Genero = genero;
            Estado_civil = estado_civil;
            Movil = movil;
            Telefono = telefono;
            Correo = correo;
            Textobuscar = textobuscar;
        }

        public string insertardato(Datos dato)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_dato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = dato.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = dato.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_de_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = dato.Fecha_de_nacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 50;
                ParDireccion.Value = dato.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 10;
                ParGenero.Value = dato.Direccion;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter ParEstadoCivil = new SqlParameter();
                ParEstadoCivil.ParameterName = "@estado_civil";
                ParEstadoCivil.SqlDbType = SqlDbType.VarChar;
                ParEstadoCivil.Size = 20;
                ParEstadoCivil.Value = dato.Estado_civil;
                SqlCmd.Parameters.Add(ParEstadoCivil);

                SqlParameter ParMovil = new SqlParameter();
                ParMovil.ParameterName = "@movil";
                ParMovil.SqlDbType = SqlDbType.VarChar;
                ParMovil.Size = 10;
                ParMovil.Value = dato.Movil;
                SqlCmd.Parameters.Add(ParMovil);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = dato.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 20;
                ParCorreo.Value = dato.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso el registro";

                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string editardato(Datos dato)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_dato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = dato.Id;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = dato.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = dato.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_de_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = dato.Fecha_de_nacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 50;
                ParDireccion.Value = dato.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 10;
                ParGenero.Value = dato.Direccion;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter ParEstadoCivil = new SqlParameter();
                ParEstadoCivil.ParameterName = "@estado_civil";
                ParEstadoCivil.SqlDbType = SqlDbType.VarChar;
                ParEstadoCivil.Size = 20;
                ParEstadoCivil.Value = dato.Estado_civil;
                SqlCmd.Parameters.Add(ParEstadoCivil);

                SqlParameter ParMovil = new SqlParameter();
                ParMovil.ParameterName = "@movil";
                ParMovil.SqlDbType = SqlDbType.VarChar;
                ParMovil.Size = 10;
                ParMovil.Value = dato.Movil;
                SqlCmd.Parameters.Add(ParMovil);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = dato.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 20;
                ParCorreo.Value = dato.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "no se actualizo el registro";

                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string eliminardato(Datos dato)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_dato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = dato.Id;
                SqlCmd.Parameters.Add(ParId);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "no se elimino el registro";

                return rpta;

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;



        }

        public DataTable mostrardato()
        {
            DataTable dtresultado = new DataTable("dato");

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_dato";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqladat = new SqlDataAdapter(SqlCmd);
                sqladat.Fill(dtresultado);



            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return dtresultado;

        }

        public DataTable buscardatonombre(Datos dato)
        {
            DataTable dtresultado = new DataTable("dato");

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Partextobuscar = new SqlParameter();
                Partextobuscar.ParameterName = "@textobuscar";
                Partextobuscar.SqlDbType = SqlDbType.VarChar;
                Partextobuscar.Size = 100;
                Partextobuscar.Value = dato.Textobuscar;
                SqlCmd.Parameters.Add(Partextobuscar);

                SqlDataAdapter sqladat = new SqlDataAdapter(SqlCmd);
                sqladat.Fill(dtresultado);



            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return dtresultado;

        }

        public DataTable buscardatoapellido(Datos dato)
        {
            DataTable dtresultado = new DataTable("dato");

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Partextobuscar = new SqlParameter();
                Partextobuscar.ParameterName = "@textobuscar";
                Partextobuscar.SqlDbType = SqlDbType.VarChar;
                Partextobuscar.Size = 100;
                Partextobuscar.Value = dato.Textobuscar;
                SqlCmd.Parameters.Add(Partextobuscar);

                SqlDataAdapter sqladat = new SqlDataAdapter(SqlCmd);
                sqladat.Fill(dtresultado);



            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return dtresultado;

        }


    }
}
