using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// uom model
	/// </summary>
	public class OUOM
	{

		/// <summary>
		/// Gets uom entry
		/// </summary>
		public int UomEntry { get; set; }

		/// <summary>
		/// Gets or set uom code
		/// </summary>
		public string UomCode { get; set; }

		/// <summary>
		/// Gets or set uom name
		/// </summary>
		public string UomName { get; set; }

		/// <summary>
		/// Gets or sets if is locked
		/// </summary>
		public string Locked { get; set; }

		/// <summary>
		/// Gets if is locked
		/// </summary>
		public bool IsLocked
		{
			get => "Y".Equals(Locked, StringComparison.OrdinalIgnoreCase);
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
				OUOM b = (OUOM)obj;
				return
					EqualityComparer<int>.Default.Equals(UomEntry, b.UomEntry) &&
					EqualityComparer<string>.Default.Equals(UomCode, b.UomCode) &&
					EqualityComparer<string>.Default.Equals(UomName, b.UomName) &&
					EqualityComparer<string>.Default.Equals(Locked, b.Locked);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = -2085796094;
			hashCode = hashCode * -1521134295 + UomEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UomCode);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UomName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Locked);
			hashCode = hashCode * -1521134295 + IsLocked.GetHashCode();
			return hashCode;
		}
	}
}
