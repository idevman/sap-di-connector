using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Currency data model
	/// </summary>
	public class OCRN
	{

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrCode { get; set; }

        /// <summary>
        /// Currency name
        /// </summary>
        public string CurrName { get; set; }

        /// <summary>
        /// Check object equality
        /// </summary>
        /// <param name="obj">To compare</param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                OCRN i = (OCRN)obj;
                return
                    EqualityComparer<string>.Default.Equals(CurrCode, i.CurrCode) &&
                    EqualityComparer<string>.Default.Equals(CurrName, i.CurrName);
            }
        }

        /// <summary>
        /// Generate hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1955217041;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrName);
            return hashCode;
        }

    }
}
