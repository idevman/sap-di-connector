using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Purchase request item model
	/// </summary>
	public class POR1
	{

		/// <summary>
		/// Gets or sets base entry
		/// </summary>
		public int BaseEntry { get; set; }

		/// <summary>
		/// Gets or sets base type
		/// </summary>
		public int BaseType { get; set; }

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
				POR1 b = (POR1)obj;
				return
					EqualityComparer<int>.Default.Equals(BaseEntry, b.BaseEntry) &&
					EqualityComparer<int>.Default.Equals(BaseType, b.BaseType);
			}
		}

		public override int GetHashCode()
		{
			var hashCode = -1264449780;
			hashCode = hashCode * -1521134295 + BaseEntry.GetHashCode();
			hashCode = hashCode * -1521134295 + BaseType.GetHashCode();
			return hashCode;
		}
	}
}
