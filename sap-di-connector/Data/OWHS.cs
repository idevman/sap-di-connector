
namespace IDevman.SAPConnector.Data
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
			return "Y".Equals(Inactive);
		}

	}

}
