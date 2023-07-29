using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContextConstant
/// </summary>
public static class ContextConstant
{
	#region Common

	public const string APPLICATION_NAME = ". : : Application Name Here : : .";
	public const string MINIMUM_DATE = "01/01/1901";
	public const string MAXIMUM_DATE = "12/12/9999";

	#endregion
	#region DateFormat

	public const string DATE_FORMAT = "MM/dd/yyyy";
	public const string DATE_FORMAT_WITH_DAY = "dddd, MM/dd/yyyy";
	public const string TIME_FORMAT_12_HOUR = "h:mm tt";
	public const string TIME_FORMAT_24_HOUR = "H:mm tt";

	#endregion
	#region Session

	public const string SBU_ID_OF_LOGGED_IN_USER = "SBU_ID";
	public const string USER_ID_OF_LOGGED_IN_USER = "USER_ID";
	public const string EMPLOYEE_ID_OF_LOGGED_IN_USER = "EMPLOYEE_ID";

	#endregion
	#region Roles

	public const string ROLE_ADMIN = "Administrator";
	//public const string ROLE_ADMIN = "Employee";
	//public const string ROLE_ADMIN = "Consultant";
	//public const string ROLE_ADMIN = "Candidate";
	//public const string ROLE_ADMIN = "Vendor";
	//public const string ROLE_ADMIN = "Client";
	//public const string ROLE_ADMIN = "Partner";

	#endregion

	#region Message

	public const string SAVED_SUCCESS = "Record has been saved successfully";
	public const string UPDATE_SUCCESS = "Record has been updated successfully";
	public const string SAVE_UNSUCCESSFUL = "Record wasn't saved";
	public const string UPDATE_UNSUCCESSFUL = "Record wasn't updated";
	public const string GENERATE_SUCCESS = "Generation completed successfully";
	public const string DOT_HAVE_SAVE_PERMISSION = "You dont have save permission";
	public const string DOT_HAVE_UPDATE_PERMISSION = "You dont have update permission";
	public const string DOT_HAVE_DELETE_PERMISSION = "You dont have delete permission";
	public const string deleted_SUCCESS = "Data has been deleted successfully.";
	public const string TRANSFER_SUCCESS = "Record has been Transfered successfully";
	public const string UPLOAD_SUCCESS = "Your file is uploaded successfully";
	public const string LOCKED_SUCCESS = "Record has been Published successfully";
	#endregion
}
