﻿
//#define USE_DATATABLE

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CalculosLib;
using CalculosLib.Iva;


namespace CalculosClienteWeb {

	public partial class Index : Page {

		private RegionInfo regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);

		#region Components Events

		protected void Page_Load(object sender, EventArgs e) {

			// If is the firt time being rendering, init the components
			if(!IsPostBack) {
				InitDropDownItems();
				InitLabelsText();
			}

		}

		protected void BotonCalcular_Click(object sender, EventArgs e) {

			if(!string.IsNullOrWhiteSpace(textBoxTotal.Text)) {

				bool isNumeric = double.TryParse(textBoxTotal.Text, out double precioTotal);
				if(isNumeric) {

					TipoIva tipoIva = (TipoIva)Enum.Parse(typeof(TipoIva), dropDownTipoIva.SelectedItem.Value);
					double precioBruto = Math.Round(CalculoIva.ObtenerPrecioBruto(precioTotal, tipoIva), 2);
					double precioIva = Math.Round(CalculoIva.ObtenerPrecioIva(precioTotal, tipoIva), 2);

					UpdateLabelTotalSinIvaValue(precioBruto);
					UpdateLabelIva(tipoIva);
					UpdateLabelIvaValue(precioIva);

				}

			}

		}

		#endregion

		#region Components Initializations

		protected void InitLabelsText() {
			UpdateLabelTotalSinIvaValue();
			UpdateLabelIvaValue();
		}

		protected void InitDropDownItems() {

#if !USE_DATATABLE

			dropDownTipoIva.DataSource = Enum.GetValues(typeof(TipoIva));

#else

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			dropDownTipoIva.DataSource = CreateDataSource();
			dropDownTipoIva.DataTextField = "TipoIvaName";
			dropDownTipoIva.DataValueField = "TipoIvaValue";

#endif

			// Bind the data to the control
			dropDownTipoIva.DataBind();

			// Set the default selected item
			dropDownTipoIva.SelectedIndex = 0;

			TipoIva tipoIva = (TipoIva)Enum.Parse(typeof(TipoIva), dropDownTipoIva.SelectedItem.Value);
			UpdateLabelIva(tipoIva);

		}

		#endregion

		private void UpdateLabelTotalSinIvaValue(double value = 0.0) {
			labelTotalSinIvaValue.Text = string.Format("{0:0.00} {1}", value, regionInfo.CurrencySymbol);
		}

		private void UpdateLabelIva(TipoIva tipoIva = TipoIva.Ninguno) {
			labelIva.Text = string.Format("IVA ({0}%):", Math.Round(tipoIva.GetValue() * 100, 2));
		}

		private void UpdateLabelIvaValue(double value = 0.0) {
			labelIvaValue.Text = string.Format("{0:0.00} {1}", value, regionInfo.CurrencySymbol);
		}

		private DataView CreateDataSource() {

			// Create a table to store data for the DropDownList control
			DataTable dt = new DataTable();

			#region Table columns

			// Define the columns of the table
			dt.Columns.Add(new DataColumn("TipoIvaName", typeof(string)));
			dt.Columns.Add(new DataColumn("TipoIvaValue", typeof(string)));

			#endregion

			#region Table rows

			List<TipoIva> enumArray = Enum.GetValues(typeof(TipoIva)).Cast<TipoIva>().ToList();
			int size = enumArray.Count;
			for(int i = 0; i < size; i++) {

				TipoIva tipoIva = enumArray[i];

				DataRow dr = dt.NewRow();
				dr[0] = tipoIva.GetName();
				dr[1] = tipoIva;

				dt.Rows.Add(dr);

			}

			#endregion

			// Create a DataView from the DataTable to act as the data source for the DropDownList control
			return new DataView(dt);
		}

	}

}
