
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

	}
}
