using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Relation model
	/// </summary>
	public class ITM12
	{

		/// <summary>
		/// Item code
		/// </summary>
		public string ItemCode { get; set; }

		/// <summary>
		/// uom entry
		/// </summary>
		public int UomEntry { get; set; }

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
				ITM12 b = (ITM12)obj;
				return
					EqualityComparer<string>.Default.Equals(ItemCode, b.ItemCode) &&
					EqualityComparer<int>.Default.Equals(UomEntry, b.UomEntry);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = -1540471225;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemCode);
			hashCode = hashCode * -1521134295 + UomEntry.GetHashCode();
			return hashCode;
		}

	}
}
