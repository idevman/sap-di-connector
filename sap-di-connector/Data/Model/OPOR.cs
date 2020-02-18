using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{
	public class OPOR
	{

		/// <summary>
		/// Gets document entry
		/// </summary>
		public int DocEntry { get; set; }

		/// <summary>
		/// Gets document number
		/// </summary>
		public int DocNum { get; set; }

		/// <summary>
		/// Gets posting date
		/// </summary>
		public DateTime DocDate { get; set; }

		/// <summary>
		/// Gets due date
		/// </summary>
		public DateTime DocDueDate { get; set; }

		/// <summary>
		/// Gets document date
		/// </summary>
		public DateTime TaxDate { get; set; }

		/// <summary>
		/// Gets tax date
		/// </summary>
		public string DocStatus { get; set; }

		/// <summary>
		/// Gets update date
		/// </summary>
		public DateTime UpdateDate { get; set; }

		/// <summary>
		/// Gets purchase request id
		/// </summary>
		public int PurchaseRequestId { get; set; }

	}
}
