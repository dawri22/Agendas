using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capanegocio;
namespace capapresentacion
{
    
    public partial class frmDatos : Form
    {
        bool esnuevo = false;
        bool eseditar = false;
        public frmDatos()
        {
            InitializeComponent();
        }

        private void mensajeok(string mensaje)
        {
            MessageBox.Show(mensaje, "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mensajeerror(string mensaje)
        {
            MessageBox.Show(mensaje, "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiar()
        {
            this.txtcodigo.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
            this.txtapellido.Text = string.Empty;
            this.cbosexo.SelectedValue = "MASCULINO";
            this.txtdireccion.Text = string.Empty;
            this.txtestadocivil.Text = string.Empty;
            this.txtmovil.Text = string.Empty;
            this.txttelefono.Text = string.Empty;
            this.txtcorreo.Text = string.Empty;

        }

        private void habilitar(bool valor)
        {
            this.txtcodigo.ReadOnly = true;
            this.txtnombre.ReadOnly = !valor;
            this.txtapellido.ReadOnly = !valor;
            this.txtestadocivil.ReadOnly = !valor;
            this.txtdireccion.ReadOnly = !valor;
            this.cbosexo.Enabled = valor;
            this.txtmovil.Enabled = valor;
            this.txttelefono.Enabled = valor;
            this.txtcorreo.Enabled = valor;
            this.dtfechanacimiento.Enabled = valor;

        }

        private void botones()
        {
            if (esnuevo || this.eseditar)
            {
                habilitar(true);
                btnnuevo.Enabled = false;
                this.btnguardar.Enabled = true;
                this.btneditar.Enabled = false;
                this.btncancelar.Enabled = true;

            }
            else
            {
                habilitar(false);
                btnnuevo.Enabled = true;
                this.btnguardar.Enabled = false;
                this.btneditar.Enabled = true;
                this.btncancelar.Enabled = false;
            }
        }

        private void mostrardatos()
        {
            this.datalistado.DataSource = NDatos.mostrardato();
            this.ocultarcolumnas();
            this.lbltotal.Text = "la cantidad total de clientes es :" + Convert.ToString(datalistado.Rows.Count);
        }

        private void ocultarcolumnas()
        {
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[1].Visible = false;
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmDatos_Load(object sender, EventArgs e)
        {
            this.mostrardatos();
            this.botones();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            esnuevo = true;
            botones();
            limpiar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtnombre.Text == string.Empty || this.txtapellido.Text == string.Empty ||
                    this.txtcorreo.Text == string.Empty)
                {
                    mensajeerror("faltan datos por ingresar seran remarcados");
                    this.iconoerror.SetError(this.txtnombre, "ingresar nombre");
                    this.iconoerror.SetError(this.txtapellido, "ingresar apellidos");
                    this.iconoerror.SetError(this.txtcorreo, "ingresar correo");
                }
                else
                {
                    if (esnuevo)
                    {
                        rpta = NDatos.insertardato(this.txtnombre.Text.Trim().ToUpper(), this.txtapellido.Text.Trim().ToUpper()
                           , this.dtfechanacimiento.Value, this.txtdireccion.Text.Trim().ToUpper(), this.cbosexo.Text,  this.txtestadocivil.Text.Trim(), this.txtmovil.Text, this.txttelefono.Text, this.txtcorreo.Text);
                    }
                    else
                    {
                        rpta = NDatos.editardato(Convert.ToInt32(this.txtcodigo.Text), this.txtnombre.Text.Trim().ToUpper(), this.txtapellido.Text.Trim().ToUpper()
                           , this.dtfechanacimiento.Value, this.txtdireccion.Text.Trim().ToUpper(), this.cbosexo.Text, this.txtestadocivil.Text.Trim(), this.txtmovil.Text, this.txttelefono.Text, this.txtcorreo.Text);
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (esnuevo)
                        {
                            this.mensajeok("se inserto el cliente satisfactoriamente");
                        }
                        else
                        {
                            this.mensajeok("se actualizo el cliente satisfactoriamente");
                        }

                    }
                    else
                    {
                        this.mensajeerror(rpta);
                    }
                    this.esnuevo = false;
                    this.eseditar = false;
                    botones();
                    this.limpiar();
                    this.mostrardatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (!this.txtcodigo.Text.Equals(""))
            {
                this.eseditar = true;
                this.botones();
                this.mostrardatos();
            }
            else
            {
                this.mensajeerror("selleccione el registro a modificar");
            }
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == datalistado.Columns["Eliminar"].Index)
                {
                    DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)datalistado.Rows[e.RowIndex].Cells["Eliminar"];
                    chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
                }
            
        }

        private void datalistado_DoubleClick(object sender, EventArgs e)
        {
            this.txtcodigo.Text = Convert.ToString(datalistado.CurrentRow.Cells["id"].Value);
            this.txtnombre.Text = Convert.ToString(datalistado.CurrentRow.Cells["nombre"].Value);
            this.txtapellido.Text = Convert.ToString(datalistado.CurrentRow.Cells["apellido"].Value);
            this.dtfechanacimiento.Text = Convert.ToString(datalistado.CurrentRow.Cells["fecha_de_nacimiento"].Value);
            this.txtdireccion.Text = Convert.ToString(datalistado.CurrentRow.Cells["direcccion"].Value);
            this.cbosexo.SelectedValue = Convert.ToString(datalistado.CurrentRow.Cells["genero"].Value);            
            this.txtestadocivil.Text = Convert.ToString(datalistado.CurrentRow.Cells["estado_civil"].Value);
            this.txtmovil.Text = Convert.ToString(datalistado.CurrentRow.Cells["movil"].Value);
            this.txttelefono.Text = Convert.ToString(datalistado.CurrentRow.Cells["telefono"].Value);
            this.txtcorreo.Text = Convert.ToString(datalistado.CurrentRow.Cells["correo"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void buscarclientexnombre(string texto)
        {
            this.datalistado.DataSource = NDatos.buscardatonombre(texto);
            this.ocultarcolumnas();
        }

        private void buscarclientexapellidos(string texto)
        {
            this.datalistado.DataSource = NDatos.buscardatonombre(texto);
            this.ocultarcolumnas();
        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.cbobuscar.Text.Equals("NOMBRE"))
            {
                this.buscarclientexnombre(this.txtbuscar.Text);
            }
            if (this.cbobuscar.Text.Equals("APELLIDOS"))
            {
                this.buscarclientexapellidos(this.txtbuscar.Text);
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (this.cbobuscar.Text.Equals("NOMBRE"))
            {
                this.buscarclientexnombre(this.txtbuscar.Text);
            }
            if (this.cbobuscar.Text.Equals("APELLIDOS"))
            {
                this.buscarclientexnombre(this.txtbuscar.Text);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.datalistado.Columns[0].Visible = true;
            }
            else
            {
                this.datalistado.Columns[0].Visible = false;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente quiere eliminar las filas seleccionas?", "sistema de clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    int codigo;
                    string rpta = "";
                    foreach (DataGridViewRow row in datalistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            rpta = NDatos.eliminardato(codigo);

                            if (rpta.Equals("OK"))
                            {
                                this.mensajeok("se elimino el cliente corrextamente");
                            }
                            else
                            {
                                this.mensajeerror(rpta);
                            }
                        }
                    }
                    this.mostrardatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


    }
}
