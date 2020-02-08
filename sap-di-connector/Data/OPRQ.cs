using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data
{

	/// <summary>
	/// Purchase request model
	/// </summary>
	public class OPRQ
	{

		/// <summary>
		/// Gets user name
		/// </summary>
		public string ReqName { get; set; }

		/// <summary>
		/// Gets requester type
		/// 12 -> User
		/// 171 -> Employee
		/// </summary>
		public int ReqType { get; set; }

		/// <summary>
		/// Gets document entry
		/// </summary>
		public int DocEntry { get; set; }

		/// <summary>
		/// Gets document number
		/// </summary>
		public int DocNum { get; set; }

		/// <summary>
		/// Gets posting date
		/// </summary>
		public DateTime DocDate { get; set; }

		/// <summary>
		/// Gets due date
		/// </summary>
		public DateTime DocDueDate { get; set; }

		/// <summary>
		/// Gets document date
		/// </summary>
		public DateTime TavDate { get; set; }

		/// <summary>
		/// Gets required date
		/// </summary>
		public DateTime ReqDate { get; set; }

	}
}
