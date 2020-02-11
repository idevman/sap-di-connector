using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Employee position model
	/// </summary>
	public class OHPS
	{

		/// <summary>
		/// Gets or sets Position id
		/// </summary>
		public int PosId { get; set; }

		/// <summary>
		/// Gets or sets position name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets position desctiption
		/// </summary>
		public string Description { get; set; }

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
				OHPS b = (OHPS)obj;
				return
					EqualityComparer<int>.Default.Equals(PosId, b.PosId) &&
					EqualityComparer<string>.Default.Equals(Name, b.Name) &&
					EqualityComparer<string>.Default.Equals(Description, b.Description);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = 1576781771;
			hashCode = hashCode * -1521134295 + PosId.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
			return hashCode;
		}
	}
}
