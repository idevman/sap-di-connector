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

		public override bool Equals(object obj)
		{
			return obj is OPOR oPOR &&
				   DocEntry == oPOR.DocEntry &&
				   DocNum == oPOR.DocNum &&
				   DocDate == oPOR.DocDate &&
				   DocDueDate == oPOR.DocDueDate &&
				   TaxDate == oPOR.TaxDate &&
				   DocStatus == oPOR.DocStatus &&
				   UpdateDate == oPOR.UpdateDate &&
				   PurchaseRequestId == oPOR.PurchaseRequestId;
		}

		public override int GetHashCode()
		{
			int hashCode = 1540013303;
			hashCode = hashCode * -1521134295 + DocEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + DocNum.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDate.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDueDate.GetHashCode();
			hashCode = hashCode * -1521134295 + TaxDate.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DocStatus);
			hashCode = hashCode * -1521134295 + UpdateDate.GetHashCode();
			hashCode = hashCode * -1521134295 + PurchaseRequestId.GetHashCode();
			return hashCode;
		}
	}
}
