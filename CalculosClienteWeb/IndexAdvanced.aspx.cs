
#define INIT_FACTURAS

using System;
using System.Globalization;
using System.Web.UI;
using CalculosLib.Iva;
using DataBaseAccess;

namespace CalculosClienteWeb {

	public partial class IndexAdvanced : Page {

		private RegionInfo regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
		private IDataAccess dataAccess = DataAccess.Instance;

		#region Components Events

		protected void Page_Load(object sender, EventArgs e) {

			// If is the firt time being rendering, init the components
			if(!IsPostBack) {
#if INIT_FACTURAS
				dataAccess.Facturas.Add(121212, new Factura(121212, 1000, TipoIva.General));
				dataAccess.Facturas.Add(131313, new Factura(131313, 100, TipoIva.Reducido));
				dataAccess.Facturas.Add(1, new Factura(1, 47, TipoIva.SuperReducido));
				dataAccess.Facturas.Add(2, new Factura(2, 532, TipoIva.General));
#endif
				InitLabelsText();
			}

		}

		protected void BotonBuscar_Click(object sender, EventArgs e) {

			if(!string.IsNullOrWhiteSpace(textBoxCodigoFactura.Text)) {

				bool isNumeric = long.TryParse(textBoxCodigoFactura.Text, out long codigoFactura);
				if(isNumeric) {
					ShowDatosFactura(codigoFactura);
				}

			}

		}

		#endregion

		#region Components Initialization

		protected void InitLabelsText() {
			UpdateLabelTotal();
			UpdateLabelTipoIva();
			UpdateLabelTotalSinIvaValue();
			UpdateLabelIva();
			UpdateLabelIvaValue();
		}

		#endregion

		private void ShowDatosFactura(long codFactura) {

			double total = 0.0;
			TipoIva tipoIva = TipoIva.Ninguno;
			double totalSinIva = 0.0;
			double iva = 0.0;

			if(dataAccess.Facturas.TryGetValue(codFactura, out Factura factura)) {
				total = Math.Round(factura.Total, 2);
				tipoIva = factura.TipoIva;
				totalSinIva = Math.Round(factura.PrecioBruto, 2);
				iva = Math.Round(factura.PrecioIva, 2);
			}

			UpdateLabelTotal(total);
			UpdateLabelTipoIva(tipoIva);
			UpdateLabelTotalSinIvaValue(totalSinIva);
			UpdateLabelIva(tipoIva);
			UpdateLabelIvaValue(iva);

		}

		private void UpdateLabelTotal(double value = 0.0) {
			labelTotal.Text = string.Format("{0:0.00} {1}", value, regionInfo.CurrencySymbol);
		}

		private void UpdateLabelTipoIva(TipoIva tipoIva = TipoIva.Ninguno) {
			labelTipoIva.Text = tipoIva.GetName();
		}

		private void UpdateLabelTotalSinIvaValue(double value = 0.0) {
			labelTotalSinIvaValue.Text = string.Format("{0:0.00} {1}", value, regionInfo.CurrencySymbol);
		}

		private void UpdateLabelIva(TipoIva tipoIva = TipoIva.Ninguno) {
			labelIva.Text = string.Format("IVA ({0}%):", Math.Round(tipoIva.GetValue() * 100, 2));
		}

		private void UpdateLabelIvaValue(double value = 0.0) {
			labelIvaValue.Text = string.Format("{0:0.00} {1}", value, regionInfo.CurrencySymbol);
		}

	}

}
