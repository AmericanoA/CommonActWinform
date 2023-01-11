using CommonActWinform.Interface.IEnumerableFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonActWinform
{
    public partial class CommonAct : Form
    {
        private int selcol;

        private bool bselheader = false;
        public CommonAct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var library = new Library();

            var books = library.GetBooks();

            if (books != null)
            {
                if (books.Any(x => x.출판사 == "명랑"))
                {
                    Console.WriteLine(books.First(x => x.출판사 == "명랑").이름);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new BookEnum();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < 10; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(i);
            }

            dataGridView1.DataSource = dt;

            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Rows[0].Height = 0;
            dataGridView1.DoubleBuffered(true);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Console.WriteLine($"Col : {e.ColumnIndex}, Row: {e.RowIndex} -  Formattion");
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Console.WriteLine($"Col : {e.ColumnIndex}, Row: {e.RowIndex} -  Painting");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine($"Col : {e.ColumnIndex}, Row: {e.RowIndex} -  CellEnter");
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine($"Col : {e.ColumnIndex}, Row: {e.RowIndex} -  CellLeave");
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine($"Col : {e.ColumnIndex}, Row: {e.RowIndex} -  Header Double Click");

            if (bselheader)
            {
                ColumnSelect(selcol,Color.White);
            }
            selcol = e.ColumnIndex;
            ColumnSelect(selcol, Color.Black);
            bselheader = true;

            dataGridView1.ClearSelection();
        }

        private void CommonAct_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (bselheader)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    if (e.KeyCode == Keys.Right)
                    {
                        ColumnSelect(selcol, Color.White);
                        selcol += 1;
                        ColumnSelect(selcol,Color.Black);
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        ColumnSelect(selcol, Color.White);
                        selcol -= 1;
                        ColumnSelect(selcol, Color.Black);
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        ColumnSelect(selcol, Color.White);
                        bselheader = false;
                    }
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[selcol];
                }
            }
        }
        private void ColumnSelect(int colindex, Color color)
        {
            this.Invoke(new Action(() =>
            {
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[selcol].HeaderCell.Style.BackColor = color;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[colindex, i].Style.BackColor = color;
                }
            }));
        }
        
    }
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
