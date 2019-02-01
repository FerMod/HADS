using CalculosDinero;
using CalculosDinero.Iva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculosClienteWindows {

	public partial class MainWindow : Form {

		public MainWindow() {
			InitializeComponent();
		}

		private void Application_Load(object sender, EventArgs e) {
			InitDropDownItems();
		}

		protected void InitDropDownItems() {

			cbTipoIva.DataSource = Enum.GetValues(typeof(TipoIva));

		}

		private void BCalcular_Click(object sender, EventArgs e) {

			if(!string.IsNullOrWhiteSpace(mtbTotal.Text)) {

				bool isNumeric = double.TryParse(mtbTotal.Text, out double precioTotal);
				if(isNumeric) {

					TipoIva tipoIva;
					Enum.TryParse<TipoIva>(cbTipoIva.SelectedValue.ToString(), out tipoIva);

					double precioBruto = Math.Round(CalculoIva.ObtenerPrecioBruto(precioTotal, tipoIva), 2);
					double precioIva = Math.Round(CalculoIva.ObtenerPrecioIva(precioTotal, tipoIva), 2);

					tbTotalSinIva.Text = $"{precioBruto:0.00}";
					tbIva.Text = $"{precioIva:0.00}";

				}

			}

		}

	}

}
