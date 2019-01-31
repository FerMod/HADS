using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CalculosDinero;
using CalculosDinero.Iva;

namespace CalculosClienteWeb {

	public partial class Index : Page {

		protected void Page_Load(object sender, EventArgs e) {

			// If is the firt time being rendering, init the components
			if (!IsPostBack) {
				InitDropDownItems();
			}

		}

		// Source: https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.dropdownlist
		protected void InitDropDownItems() {

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			dropDownTipoIva.DataSource = CreateDataSource();
			dropDownTipoIva.DataTextField = "TipoIvaName";
			dropDownTipoIva.DataValueField = "TipoIvaValue";

			// Bind the data to the control.
			dropDownTipoIva.DataBind();

			// Set the default selected item, if desired.
			dropDownTipoIva.SelectedIndex = 0;

		}

		private DataView CreateDataSource() {

			// Create a table to store data for the DropDownList control.
			DataTable dt = new DataTable();

			// Define the columns of the table.
			dt.Columns.Add(new DataColumn("TipoIvaName", typeof(String)));
			dt.Columns.Add(new DataColumn("TipoIvaValue", typeof(String)));

			List<TipoIva> enumArray = Enum.GetValues(typeof(TipoIva)).Cast<TipoIva>().ToList();
			int size = enumArray.Count;
			for (int i = size - 1; i >= 0; i--) {

				TipoIva tipoIva = enumArray[i];

				DataRow dr = dt.NewRow();
				dr[0] = Enum.GetName(typeof(TipoIva), tipoIva);
				dr[1] = tipoIva;

				dt.Rows.Add(dr);

			}

			// Create a DataView from the DataTable to act as the data source for the DropDownList control.
			return new DataView(dt);
		}

		protected void BotonCalcular_Click(object sender, EventArgs e) {
			if (!string.IsNullOrWhiteSpace(textBoxTotal.Text)) {

				bool isNumeric = double.TryParse(textBoxTotal.Text, out double precioTotal);
				if (isNumeric) {

					TipoIva tipoIva = (TipoIva)Enum.Parse(typeof(TipoIva), dropDownTipoIva.SelectedItem.Value);

					double precioBruto = Math.Round(CalculoIva.ObtenerPrecioBruto(precioTotal, tipoIva), 2);				;
					double precioIva = Math.Round(CalculoIva.ObtenerPrecioIva(precioTotal, tipoIva), 2);

					labelTotalSinIva.Text = string.Format("{0:0.00}", precioBruto);
					lablelIva.Text = string.Format("{0:0.00}", precioIva);

				}

			}
		}

	}

}
