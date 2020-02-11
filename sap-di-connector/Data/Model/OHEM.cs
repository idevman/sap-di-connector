using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Data.Model
{

	/// <summary>
	/// Employee model
	/// </summary>
	public class OHEM
	{

		/// <summary>
		/// Gets or sets employee id
		/// </summary>
		public int EmpId { get; set; }

		/// <summary>
		/// Gets or sets employee first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets employee middle name
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// Gets or sets employee last name
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets employee external employee number
		/// </summary>
		public string ExtEmpNo { get; set; }

		/// <summary>
		/// Gets or sets employee email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets employee position
		/// </summary>
		public int Position { get; set; }

		/// <summary>
		/// Gets or sets employee Department
		/// </summary>
		public int Dept { get; set; }

		/// <summary>
		/// Gets or sets employee manager
		/// </summary>
		public int Manager { get; set; }

		/// <summary>
		/// Gets or sets employee active
		/// Y active
		/// N No active
		/// </summary>
		public string Active { get; set; }

		/// <summary>
		/// Gets if the employee is Active
		/// </summary>
		public bool IsActive
		{
			get => "Y".Equals(Active, StringComparison.OrdinalIgnoreCase);
		}

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
				OHEM b = (OHEM)obj;
				return
					EqualityComparer<int>.Default.Equals(EmpId, b.EmpId) &&
					EqualityComparer<string>.Default.Equals(FirstName, b.FirstName) &&
					EqualityComparer<string>.Default.Equals(MiddleName, b.MiddleName) &&
					EqualityComparer<string>.Default.Equals(LastName, b.LastName) &&
					EqualityComparer<string>.Default.Equals(ExtEmpNo, b.ExtEmpNo) &&
					EqualityComparer<string>.Default.Equals(Email, b.Email) &&
					EqualityComparer<int>.Default.Equals(Position, b.Position) &&
					EqualityComparer<int>.Default.Equals(Dept, b.Dept) &&
					EqualityComparer<int>.Default.Equals(Manager, b.Manager) &&
					EqualityComparer<string>.Default.Equals(Active, b.Active);
			}
		}

		/// <summary>
		/// Generates hash code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = -763092000;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ExtEmpNo);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Active);
			hashCode = hashCode * -1521134295 + Position.GetHashCode();
			hashCode = hashCode * -1521134295 + Dept.GetHashCode();
			hashCode = hashCode * -1521134295 + Manager.GetHashCode();
			return hashCode;
		}
	}
}
