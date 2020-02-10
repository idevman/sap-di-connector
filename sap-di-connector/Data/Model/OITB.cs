using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Item group model
	/// </summary>
	public class OITB
	{

		/// <summary>
		/// Gets or sets group code
		/// </summary>
		public int ItmsGrpCod { get; set; }

		/// <summary>
		/// Gets or sets group name
		/// </summary>
		public string ItmsGrpName { get; set; }

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
                OITB b = (OITB)obj;
                return
                    EqualityComparer<int>.Default.Equals(ItmsGrpCod, b.ItmsGrpCod) &&
                    EqualityComparer<string>.Default.Equals(ItmsGrpName, b.ItmsGrpName);
            }
        }

        /// <summary>
        /// Generates hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1078589205;
            hashCode = hashCode * -1521134295 + ItmsGrpCod.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItmsGrpName);
            return hashCode;
        }
    }
}
