using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// User model
	/// </summary>
	public class OUSR
	{

		/// <summary>
		/// Gets or sets user id
		/// </summary>
		public int USERID { get; set; }

		/// <summary>
		/// Gets or sets user code
		/// </summary>
		public string USER_CODE { get; set; }

		/// <summary>
		/// Gets or sets user name
		/// </summary>
		public string U_NAME { get; set; }

		/// <summary>
		/// Gets or sets email
		/// </summary>
		public string E_Mail { get; set; }

		/// <summary>
		/// Gets or sets superuser
		/// Y - yes
		/// N - No
		/// </summary>
		public string SUPERUSER { get; set; }

	}
}
