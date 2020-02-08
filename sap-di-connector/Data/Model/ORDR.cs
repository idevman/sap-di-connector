using System;
using System.Collections.Generic;
using System.Linq;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Sell order model
	/// </summary>
	public class ORDR
	{

		/// <summary>
		/// Gets customer/ vendor code
		/// </summary>
		public string CardCode { get; set; }

		/// <summary>
		/// Gets customer/ vendor name
		/// </summary>
		public string CardName { get; set; }

		/// <summary>
		/// Gets BP Reference No.
		/// </summary>
		public string NumAtCard { get; set; }

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
		/// Purchase order items related
		/// </summary>
		public List<RDR1> Items { get; } = new List<RDR1>();

		/// <summary>
		/// Check object equality
		/// </summary>
		/// <param name="obj">To compare</param>
		/// <returns>if is equal</returns>
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				ORDR b = (ORDR)obj;
				return
					EqualityComparer<string>.Default.Equals(CardCode, b.CardCode) &&
					EqualityComparer<string>.Default.Equals(CardName, b.CardName) &&
					EqualityComparer<DateTime>.Default.Equals(DocDate, b.DocDate) &&
					EqualityComparer<DateTime>.Default.Equals(DocDueDate, b.DocDueDate) &&
					EqualityComparer<int>.Default.Equals(DocEntry, b.DocEntry) &&
					EqualityComparer<int>.Default.Equals(DocNum, b.DocNum) &&
					EqualityComparer<string>.Default.Equals(NumAtCard, b.NumAtCard) &&
					EqualityComparer<DateTime>.Default.Equals(TaxDate, b.TaxDate) &&
					((Items == null && b.Items == null) || Items.SequenceEqual(b.Items));
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = -144526589;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardCode);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumAtCard);
			hashCode = hashCode * -1521134295 + DocEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + DocNum.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDate.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDueDate.GetHashCode();
			hashCode = hashCode * -1521134295 + TaxDate.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<List<RDR1>>.Default.GetHashCode(Items);
			return hashCode;
		}
	}
}
