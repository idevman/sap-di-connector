using System;
using System.Collections.Generic;
using System.Linq;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Employee Department model
	/// </summary>
	public class OUDP
	{

		/// <summary>
		/// Gets department code
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Gets or sets department name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets department description
		/// </summary>
		public string Remarks { get; set; }

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
				OUDP b = (OUDP)obj;
				return
					EqualityComparer<int>.Default.Equals(Code, b.Code) &&
					EqualityComparer<string>.Default.Equals(Name, b.Name) &&
					EqualityComparer<string>.Default.Equals(Remarks, b.Remarks);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = -570267216;
			hashCode = hashCode * -1521134295 + Code.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Remarks);
			return hashCode;
		}
	}
}
