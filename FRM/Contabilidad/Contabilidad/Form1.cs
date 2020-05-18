using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaVistaCONTA;

namespace Contabilidad
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			MDI_CONTA mid = new MDI_CONTA();
			mid.Show();
			this.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
