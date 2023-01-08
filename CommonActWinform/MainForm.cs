using CommonActWinform.Interface.IEnumerable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonActWinform
{
    public partial class CommonAct : Form
    {
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
    }
}
