using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Warehouse model
	/// </summary>
	public class OWHS
	{

		/// <summary>
		/// Gets or sets warehouse code
		/// </summary>
		public string WhsCode { get; set; }

		/// <summary>
		/// Gets or sets warehouse name
		/// </summary>
		public string WhsName { get; set; }

		/// <summary>
		/// Gets or sets inactive warehouse
		/// N - Inactive
		/// Y - Active
		/// </summary>
		public string Inactive { get; set; }

		/// <summary>
		/// Return if is active the warehouse
		/// </summary>
		/// <returns></returns>
		public bool IsActive()
		{
			return "Y".Equals(Inactive, StringComparison.OrdinalIgnoreCase);
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
				OWHS b = (OWHS)obj;
				return
					EqualityComparer<string>.Default.Equals(Inactive, b.Inactive) &&
					EqualityComparer<string>.Default.Equals(WhsCode, b.WhsCode) &&
					EqualityComparer<string>.Default.Equals(WhsName, b.WhsName);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = -1730701478;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WhsCode);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WhsName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Inactive);
			return hashCode;
		}

	}

}
