using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Purchase request item model
	/// </summary>
	public class PRQ1
	{

		/// <summary>
		/// Gets doc entry, must be the same of purchase order related
		/// </summary>
		public int DocEntry { get; set; }

		/// <summary>
		/// Gets the line number related to base document
		/// </summary>
		public int LineNum { get; set; }

		/// <summary>
		/// Gets the lines status of the base document
		/// <para>[O] Open</para>
		/// <para>[C] Closed</para>
		/// </summary>
		public char LineStatus { get; set; }

		/// <summary>
		/// Returns true of the line is closed, false if is open
		/// </summary>
		public bool IsClosed
		{
			get => 'C' == LineStatus;
		}

		/// <summary>
		/// Gets or sets the item code of the line
		/// </summary>
		public string ItemCode { get; set; }

		/// <summary>
		/// Gets or sets the description of the line
		/// </summary>
		public string Dscription { get; set; }

		/// <summary>
		/// Item quantity
		/// </summary>
		public decimal Quantity { get; set; }

		/// <summary>
		/// Uom code 
		/// </summary>
		public int UomEntry { get; set; }

		/// <summary>
		/// Gets or sets description
		/// </summary>
		public string Text { get; set; }

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
				PRQ1 b = (PRQ1)obj;
				return
					EqualityComparer<int>.Default.Equals(DocEntry, b.DocEntry) &&
					EqualityComparer<string>.Default.Equals(Dscription, b.Dscription) &&
					EqualityComparer<string>.Default.Equals(ItemCode, b.ItemCode) &&
					EqualityComparer<int>.Default.Equals(LineNum, b.LineNum) &&
					EqualityComparer<char>.Default.Equals(LineStatus, b.LineStatus) &&
					EqualityComparer<decimal>.Default.Equals(Quantity, b.Quantity) &&
					EqualityComparer<string>.Default.Equals(Text, b.Text);
			}
		}

		/// <summary>
		/// Genrates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = 1408203331;
			hashCode = hashCode * -1521134295 + DocEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + LineNum.GetHashCode();
			hashCode = hashCode * -1521134295 + LineStatus.GetHashCode();
			hashCode = hashCode * -1521134295 + IsClosed.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemCode);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dscription);
			hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
			return hashCode;
		}
	}
}
