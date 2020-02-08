
namespace IDevman.SAPConnector.Data
{

	/// <summary>
	/// Product model
	/// </summary>
	public class OITM
	{

		/// <summary>
		/// Item code
		/// </summary>
		public string ItemCode { get; set; }

		/// <summary>
		/// Item name
		/// </summary>
		public string ItemName { get; set; }

		/// <summary>
		/// Gets if the item is managed by batches
		/// </summary>
		public string ManBtchNum { get; set; }

		/// <summary>
		/// Warehouse target code
		/// </summary>
		public string WhsCode { get; set; }

		/// <summary>
		/// Gets or sets Inventory item
		/// </summary>
		public string InvntItem { get; set; }

		/// <summary>
		/// Gets or sets Sell item
		/// </summary>
		public string SellItem { get; set; }

		/// <summary>
		/// Gets or sets Purchase item
		/// </summary>
		public string PrchseItem { get; set; }

		/// <summary>
		/// Gets or sets frozen for
		/// </summary>
		public string frozenFor { get; set; }

		/// <summary>
		/// Gets if the item is for inventory
		/// </summary>
		public bool IsInventoryItem
		{
			get => "Y".Equals(InvntItem);
		}

		/// <summary>
		/// Gets it the item is for sell
		/// </summary>
		public bool IsSellItem
		{
			get => "Y".Equals(SellItem);
		}

		/// <summary>
		/// Gets if the item is for purchase item
		/// </summary>
		public bool IsPurchaseItem
		{
			get => "Y".Equals(PrchseItem);
		}

		/// <summary>
		/// Gets if the item is Active
		/// </summary>
		public bool IsActive
		{
			get => "Y".Equals(frozenFor);
		}

		/// <summary>
		/// Gets if the item is managed by batches
		/// </summary>
		/// <returns></returns>
		public bool IsManageByBatches
		{
			get => "Y".Equals(ManBtchNum);
		}

	}
}
