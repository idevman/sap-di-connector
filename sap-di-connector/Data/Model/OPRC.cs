using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Cost center model
	/// </summary>
	public class OPRC
	{

		/// <summary>
		/// Gets or sets prc code
		/// </summary>
		public string PrcCode { get; set; }

		/// <summary>
		/// Gets or sets prc name
		/// </summary>
		public string PrcName { get; set; }

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
                OPRC b = (OPRC)obj;
                return
                    EqualityComparer<string>.Default.Equals(PrcCode, b.PrcCode) &&
                    EqualityComparer<string>.Default.Equals(PrcName, b.PrcName);
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 1769323800;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrcCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrcName);
            return hashCode;
        }
    }
}
