using System;
using System.Collections.Generic;
using System.Linq;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Purchase request model
	/// </summary>
	public class OPRQ
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
		/// Gets user name
		/// </summary>
		public string ReqName { get; set; }

		/// <summary>
		/// Gets requester type
		/// 12 -> User
		/// 171 -> Employee
		/// </summary>
		public int ReqType { get; set; }

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
		/// Gets required date
		/// </summary>
		public DateTime ReqDate { get; set; }

		/// <summary>
		/// Gets purchase comments
		/// </summary>
		public string Comments { get; set; }

		/// <summary>
		/// Purchase order items related
		/// </summary>
		public List<PRQ1> Items { get; } = new List<PRQ1>();

		/// <summary>
		/// Gets purchase date created
		/// </summary>
		public DateTime PurchaseDate { get; set; }

		/// <summary>
		/// Gets purchase closed date
		/// </summary>
		public DateTime ClosePurchaseDate { get; set; }

		/// <summary>
		/// Gets if has quotation
		/// </summary>
		/// <returns></returns>
		public bool HasQuotation()
		{
			return Items.Where(x => x.BaseType == 17).Any();
		}

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
				OPRQ b = (OPRQ)obj;
				return
					EqualityComparer<DateTime>.Default.Equals(DocDate, b.DocDate) &&
					EqualityComparer<DateTime>.Default.Equals(DocDueDate, b.DocDueDate) &&
					EqualityComparer<int>.Default.Equals(DocEntry, b.DocEntry) &&
					EqualityComparer<int>.Default.Equals(DocNum, b.DocNum) &&
					EqualityComparer<DateTime>.Default.Equals(ReqDate, b.ReqDate) &&
					EqualityComparer<string>.Default.Equals(ReqName, b.ReqName) &&
					((Items == null && b.Items == null) || Items.SequenceEqual(b.Items));
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = 2126638501;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReqName);
			hashCode = hashCode * -1521134295 + ReqType.GetHashCode();
			hashCode = hashCode * -1521134295 + DocEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + DocNum.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDate.GetHashCode();
			hashCode = hashCode * -1521134295 + DocDueDate.GetHashCode();
			hashCode = hashCode * -1521134295 + TaxDate.GetHashCode();
			hashCode = hashCode * -1521134295 + ReqDate.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<List<PRQ1>>.Default.GetHashCode(Items);
			return hashCode;
		}

	}
}
