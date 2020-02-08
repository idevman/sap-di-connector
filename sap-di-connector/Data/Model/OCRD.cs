
using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// business partner model
	/// </summary>
	public class OCRD
	{

		/// <summary>
		/// Gets or sets partnership code
		/// </summary>
		public string CardCode { get; set; }

		/// <summary>
		/// Gets or sets parnership name
		/// </summary>
		public string CardName { get; set; }

		/// <summary>
		/// Gets or sets partnership type
		/// C - Customer
		/// L - Lead
		/// S - Vendor
		/// </summary>
		public string CardType { get; set; }

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
                OCRD b = (OCRD)obj;
                return
                    EqualityComparer<string>.Default.Equals(CardCode, b.CardCode) &&
                    EqualityComparer<string>.Default.Equals(CardName, b.CardName) &&
                    EqualityComparer<string>.Default.Equals(CardType, b.CardType);
            }
        }

        /// <summary>
        /// Generates hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 188009777;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardType);
            return hashCode;
        }
    }
}
