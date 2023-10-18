
namespace TurismoReal.Presentacion
{
    partial class FrmCheckOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Listado = new System.Windows.Forms.TabPage();
            this.LblTotal = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.DGVListar = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Agregar = new System.Windows.Forms.TabPage();
            this.LblMontoMultas = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.LblFirmaCliente = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtRut = new System.Windows.Forms.TextBox();
            this.LblHora = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Listado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListar)).BeginInit();
            this.Agregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Listado);
            this.tabControl1.Controls.Add(this.Agregar);
            this.tabControl1.Location = new System.Drawing.Point(1, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 457);
            this.tabControl1.TabIndex = 6;
            // 
            // Listado
            // 
            this.Listado.Controls.Add(this.LblTotal);
            this.Listado.Controls.Add(this.BtnBuscar);
            this.Listado.Controls.Add(this.TxtBuscar);
            this.Listado.Controls.Add(this.DGVListar);
            this.Listado.Location = new System.Drawing.Point(4, 22);
            this.Listado.Name = "Listado";
            this.Listado.Padding = new System.Windows.Forms.Padding(3);
            this.Listado.Size = new System.Drawing.Size(766, 431);
            this.Listado.TabIndex = 0;
            this.Listado.Text = "Listar";
            this.Listado.UseVisualStyleBackColor = true;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(613, 384);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(34, 13);
            this.LblTotal.TabIndex = 5;
            this.LblTotal.Text = "Total:";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(314, 16);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(107, 26);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(7, 20);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(301, 20);
            this.TxtBuscar.TabIndex = 3;
            // 
            // DGVListar
            // 
            this.DGVListar.AllowUserToAddRows = false;
            this.DGVListar.AllowUserToDeleteRows = false;
            this.DGVListar.AllowUserToOrderColumns = true;
            this.DGVListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.DGVListar.Location = new System.Drawing.Point(7, 54);
            this.DGVListar.Name = "DGVListar";
            this.DGVListar.ReadOnly = true;
            this.DGVListar.Size = new System.Drawing.Size(753, 317);
            this.DGVListar.TabIndex = 0;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // Agregar
            // 
            this.Agregar.Controls.Add(this.LblMontoMultas);
            this.Agregar.Controls.Add(this.LblFecha);
            this.Agregar.Controls.Add(this.metroDateTime1);
            this.Agregar.Controls.Add(this.LblFirmaCliente);
            this.Agregar.Controls.Add(this.textBox1);
            this.Agregar.Controls.Add(this.BtnCancelar);
            this.Agregar.Controls.Add(this.BtnAgregar);
            this.Agregar.Controls.Add(this.TxtNombre);
            this.Agregar.Controls.Add(this.TxtRut);
            this.Agregar.Controls.Add(this.LblHora);
            this.Agregar.Location = new System.Drawing.Point(4, 22);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(766, 385);
            this.Agregar.TabIndex = 1;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            // 
            // LblMontoMultas
            // 
            this.LblMontoMultas.AutoSize = true;
            this.LblMontoMultas.Location = new System.Drawing.Point(79, 134);
            this.LblMontoMultas.Name = "LblMontoMultas";
            this.LblMontoMultas.Size = new System.Drawing.Size(71, 13);
            this.LblMontoMultas.TabIndex = 26;
            this.LblMontoMultas.Text = "Monto Multas";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(113, 97);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(37, 13);
            this.LblFecha.TabIndex = 25;
            this.LblFecha.Text = "Fecha";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(156, 87);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(4, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(178, 29);
            this.metroDateTime1.TabIndex = 24;
            // 
            // LblFirmaCliente
            // 
            this.LblFirmaCliente.AutoSize = true;
            this.LblFirmaCliente.Location = new System.Drawing.Point(83, 169);
            this.LblFirmaCliente.Name = "LblFirmaCliente";
            this.LblFirmaCliente.Size = new System.Drawing.Size(67, 13);
            this.LblFirmaCliente.TabIndex = 21;
            this.LblFirmaCliente.Text = "Firma Cliente";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 20;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(419, 260);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(122, 35);
            this.BtnCancelar.TabIndex = 19;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(234, 260);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(122, 35);
            this.BtnAgregar.TabIndex = 18;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(156, 131);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(178, 20);
            this.TxtNombre.TabIndex = 11;
            // 
            // TxtRut
            // 
            this.TxtRut.Location = new System.Drawing.Point(156, 52);
            this.TxtRut.Name = "TxtRut";
            this.TxtRut.Size = new System.Drawing.Size(178, 20);
            this.TxtRut.TabIndex = 9;
            // 
            // LblHora
            // 
            this.LblHora.AutoSize = true;
            this.LblHora.Location = new System.Drawing.Point(120, 55);
            this.LblHora.Name = "LblHora";
            this.LblHora.Size = new System.Drawing.Size(30, 13);
            this.LblHora.TabIndex = 2;
            this.LblHora.Text = "Hora";
            // 
            // FrmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 534);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCheckOut";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Check Out";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.FrmCheckOut_Load);
            this.tabControl1.ResumeLayout(false);
            this.Listado.ResumeLayout(false);
            this.Listado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListar)).EndInit();
            this.Agregar.ResumeLayout(false);
            this.Agregar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Listado;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView DGVListar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TabPage Agregar;
        private System.Windows.Forms.Label LblFirmaCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtRut;
        private System.Windows.Forms.Label LblHora;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private System.Windows.Forms.Label LblMontoMultas;
        private System.Windows.Forms.Label LblFecha;
    }
}