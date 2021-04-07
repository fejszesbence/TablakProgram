using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablakProgram
{
    public partial class Form1 : Form
    {

        private List<Auto> autokLista;
        private static DataTable raktarTable;

        public Form1()
        {
            InitializeComponent();
            ini();
        }

        private void ini()
        {
            autokLista = new List<Auto>();
            autokLista.Add(new Auto("Pál", "BMW", "zöld"));
            autokLista.Add(new Auto("Petra", "VW", "piros"));
            autokLista.Add(new Auto("János", "Seat", "narancssárga"));
            autokLista.Add(new Auto("Kitti", "Suzuki", "kék"));

            raktarTable = new DataTable();
            tablaSemaKeszit();
            listabolTablaba();

            //megjelenítés
            dataGridView1.DataSource = raktarTable;
        }

        private void listabolTablaba()
        {
            foreach (Auto auto in autokLista)
            {
                DataRow dr = raktarTable.NewRow();
                dr["Gyártó"] = auto.Gyarto;
                dr["Szín"] = auto.Szin;
                dr["Név"] = auto.Nev;
                raktarTable.Rows.Add(dr);
            }
        }

        static void tablaSemaKeszit()
        {
            DataColumn autoIDColumn = new DataColumn("autoID", typeof(int));
            autoIDColumn.Caption = "Autó ID";
            autoIDColumn.ReadOnly = true;
            autoIDColumn.AllowDBNull = false;
            autoIDColumn.Unique = true;
            autoIDColumn.AutoIncrement = true;
            autoIDColumn.AutoIncrementSeed = 0;
            autoIDColumn.AutoIncrementStep = 1;
            DataColumn gyartoColumn = new DataColumn("Gyártó", typeof(string));
            DataColumn szinColumn = new DataColumn("Szín", typeof(string));
            DataColumn nevColumn = new DataColumn("Név", typeof(string));
            raktarTable.Columns.AddRange(new DataColumn[] 
            {gyartoColumn, szinColumn, nevColumn});
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            try
            {
                raktarTable.Rows[int.Parse(txtTorol.Text)].Delete();
                raktarTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ini();
        }
    }

}
