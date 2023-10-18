using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoReal.Presentacion
{
    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        private int childFormNumber = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void administradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrador frm = new FrmAdministrador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionario frm = new FrmFuncionario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartamento frm = new FrmDepartamento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmInventario frm = new FrmInventario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReservas frm = new FrmReservas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCheckIn frm = new FrmCheckIn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void checkOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCheckOut frm = new FrmCheckOut();
            frm.MdiParent = this;
            frm.Show();
        }

        private void transporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransporte frm = new FrmTransporte();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTour frm = new FrmTour();
            frm.MdiParent = this;
            frm.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = new FrmArticulo();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
