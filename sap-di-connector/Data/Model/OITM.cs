using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
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
		public string FrozenFor { get; set; }

		/// <summary>
		/// Gets or sets group code
		/// </summary>
		public int ItmsGrpCod { get; set; }

		/// <summary>
		/// Gets if the item is for inventory
		/// </summary>
		public bool IsInventoryItem
		{
			get => "Y".Equals(InvntItem, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets it the item is for sell
		/// </summary>
		public bool IsSellItem
		{
			get => "Y".Equals(SellItem, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets if the item is for purchase item
		/// </summary>
		public bool IsPurchaseItem
		{
			get => "Y".Equals(PrchseItem, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets if the item is Active
		/// </summary>
		public bool IsActive
		{
			get => "Y".Equals(FrozenFor, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets if the item is managed by batches
		/// </summary>
		/// <returns></returns>
		public bool IsManageByBatches
		{
			get => "Y".Equals(ManBtchNum, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets or sets uoms
		/// </summary>
		public List<OUOM> Ouoms { get; } = new List<OUOM>();

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
				OITM b = (OITM)obj;
				return
					EqualityComparer<string>.Default.Equals(FrozenFor, b.FrozenFor) &&
					EqualityComparer<string>.Default.Equals(InvntItem, b.InvntItem) &&
					EqualityComparer<string>.Default.Equals(ItemCode, b.ItemCode) &&
					EqualityComparer<string>.Default.Equals(ItemName, b.ItemName) &&
					EqualityComparer<string>.Default.Equals(FrozenFor, b.FrozenFor) &&
					EqualityComparer<int>.Default.Equals(ItmsGrpCod, b.ItmsGrpCod) &&
					EqualityComparer<string>.Default.Equals(ManBtchNum, b.ManBtchNum) &&
					EqualityComparer<string>.Default.Equals(PrchseItem, b.PrchseItem) &&
					EqualityComparer<string>.Default.Equals(SellItem, b.SellItem);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns>hash code</returns>
		public override int GetHashCode()
		{
			var hashCode = 435135204;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemCode);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ManBtchNum);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(InvntItem);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SellItem);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrchseItem);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FrozenFor);
			hashCode = hashCode * -1521134295 + ItmsGrpCod.GetHashCode();
			hashCode = hashCode * -1521134295 + IsInventoryItem.GetHashCode();
			hashCode = hashCode * -1521134295 + IsSellItem.GetHashCode();
			hashCode = hashCode * -1521134295 + IsPurchaseItem.GetHashCode();
			hashCode = hashCode * -1521134295 + IsActive.GetHashCode();
			hashCode = hashCode * -1521134295 + IsManageByBatches.GetHashCode();
			return hashCode;
		}
	}
}
