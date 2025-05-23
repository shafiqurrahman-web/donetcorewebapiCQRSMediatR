namespace BBBSLI.DSS.MobileApp.Utility.Domain
{
    /// <summary>
    /// Constants to use across the application.
    /// </summary>
    public class GlobalConstants
    {
        /// <summary>
        /// Contains constants representing permissions related to the Administration module.
        /// </summary>
        /// <remarks>
        /// This class defines permission names that are used to control access to specific operations within the Administration module.
        /// </remarks>
        public class AdministrationPermissions
        {
            /// <summary>
            /// Represents the permission to accept BOH (Back of House) settings.
            /// </summary>
            public const string AcceptBOHSettings = "AcceptBOHSettings";

            /// <summary>
            /// Represents the permission to set notifications within the Administration module.
            /// </summary>
            public const string SetNotification = "SetNotification";
        }

        /// <summary>
        /// A static class that provides constant strings for different permissions within the application.
        /// </summary>
        public static class Permission
        {
            public const string AllAuthenticatedUsers = "all_authenticated_users";

            public const string StaticTextRead = "admin_static_content_view";
            public const string StaticTextEdit = "admin_static_content_edit";

            public const string AppSettingRead = "admin_app_settings_view";
            public const string AppSettingEdit = "admin_app_settings_edit";


        }

        /// <summary>
        /// A class that provides static constants for route names used in the application.
        /// </summary>
        public static class RouteConstants
        {
            /// <summary>
            /// Constants for route names associated with various controller actions.
            /// </summary>
            public const string Query = ".query";
            public const string Command = ".command";

            /// <summary>
            /// Constants for route names associated with various application modules.
            /// </summary>
            public static class Modules
            {
                /// <summary>
                /// Constants for the Administration module routes.
                /// </summary>
                public static class Administration
                {
                    /// <summary>
                    /// The root route name for the Administration module.
                    /// </summary>
                    public const string Root = "administration";

                    public const string Settings = $"api/{Root}/modulesettings";
                    public const string Cache = $"api/{Root}/cache";

                }

                /// <summary>
                /// Constants for the Inventory module routes.
                /// </summary>
                public static class Inventory
                {
                    /// <summary>
                    /// The root route name for the Inventory module.
                    /// </summary>
                    public const string Root = "inventory";
                    public const string DailyRequisitionRoot = "dailyrequisition";
                    public const string InventoryItemRoot = "inventoryitem";
                    public const string Inventories = $"api/{Root}/inventories";
                    public const string DailyRequisition = $"api/{Root}/dailyrequisitions";
                    public const string EDRLog = $"api/{Root}/edrlog";
                    public const string AdjustmentRoot = "adjustment";

                    /// <summary>
                    /// The route name for PhysicalInventory within the Inventory module.
                    /// </summary>
                    public const string PhysicalInventoryRoot = "physicalinventory";
                    public const string PhysicalInventory = $"api/{Root}/physicalinventories";

                }

                /// <summary>
                /// Constants for the Production module routes.
                /// </summary>
                public static class Production
                {
                    /// <summary>
                    /// The root route name for the Production module.
                    /// </summary>
                    public const string Root = "production";

                    /// <summary>
                    /// The route name for OccurrenceLogs within the Production module.
                    /// </summary>
                    public const string OccurrenceLogRoot = $"occurrencelogs";
                    public const string OccurrenceLogs = $"api/{Root}/occurrencelogs";
                    public const string OccurrenceIncidentType = $"api/{Root}/occurrenceincidenttypes";

                    /// <summary>
                    /// The route name for Production Dashboard Forms.
                    /// </summary>
                    public const string ProductionRecordsRoot = $"productionrecords";
                    public const string ProductionRecords = $"api/{Root}/productionrecords";

                    /// <summary>
                    /// The route name for Menu APIs.
                    /// </summary>
                    public const string MenuRoot = $"menu";
                    public const string Menu = $"api/{Root}/menu";

                    /// <summary>
                    /// The route name for Menu APIs.
                    /// </summary>
                    public const string SpecialProgramRoot = $"specialprogram";
                    public const string SpecialProgram = $"api/{Root}/specialprogram";
                }

                /// <summary>
                /// Constants for the UserAccess module routes.
                /// </summary>
                public static class UserAccess
                {
                    /// <summary>
                    /// The root route name for the UserAccess module.
                    /// </summary>
                    public const string Root = "useraccess";

                    public const string Users = $"api/{Root}/loggedinuserdetail";
                }

                /// <summary>
                /// Constants for the Reports module routes.
                /// </summary>
                public static class Reports
                {
                    /// <summary>
                    /// The root route name for the Reports module.
                    /// </summary>
                    public const string Root = "reports";

                    public const string InventoryReport = $"api/{Root}/inventories";
                    public const string ProductionReport = $"api/{Root}/productions";
                }
            }
        }

        public class EntityType
        {
            public static string DailyRequisition { get; } = "daily_requisition";
            public static string Adjustment { get; } = "adjustment";
            public static string Edr { get; } = "edr";
            public static string ProductTransfer { get; } = "product_transfer";
            public static string OccurrenceLog { get; } = "occurrence_log";
            public static string PhysicalInventory { get; } = "physical_inventory";
        }
        public class InventoryForms
        {
            public static string DAILYREQUISITION { get; } = "Daily Requisition";
            public static string PHYSICALINVENTORY { get; } = "Physical Inventory";
            public static string PRODUCTTRANSFER { get; } = "Product Transfer";
            public static string ADJUSTMENT { get; } = "Adjustment";
            public static string INVENTORYRECONCILIATION { get; } = "Inventory Reconciliation";
            public static string RECONCILIATIONSTATEMENT { get; } = "Reconciliation Statement";
        }

        public class TransferState
        {
            public static string RECEIVER { get; } = "Received";
            public static string SENDER { get; } = "Sent";
        }

        public class ProductionRecordStructureType
        {
            public static string HighSchool { get; } = "high_school";
            public static string ExpressKTo12 { get; } = "express_k_to_12";
            public static string SchoolTripLunch { get; } = "school_trip_lunch";
            public static string AfterSchoolMeals { get; } = "after_school_meals";
        }

        public class Database
        {
            public static string READWRTIE { get; } = "AppConnectionString";
            public static string READONLY { get; } = "AppReadonlyConnectionString";
        }

        public class DateFormat
        {
            public static string YYYYMMDD { get; } = "YYYY_MM_dd";
        }

        public static class CachePrefixKey
        {
            public static class Module
            {
                public static class UserAccess
                {
                    public static string RBAC_JWT { get; } = "RBAC_JWT";
                }
            }
        }

        public static class AppSettingsKey
        {
            public static string DashboardIncompleteFormsDueDays { get; } = "DashboardIncompleteFormsDueDays";
        }

        public static class NotificationTypeKey
        {
            public static string ProductTransfer { get; } = "product_transfer";
        }

        public static class TransactionType
        {
            public static string In { get; } = "IN";
            public static string Out { get; } = "OUT";
        }

        public static class User
        {
            public static string System { get; } = "System";
        }

        public static class NotificationTriggerType
        {
            public static string System { get; } = "System";
            public static string Custom { get; } = "Custom";
        }

        public static class RegExPattern
        {
            public static string Email { get; } = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        }

        public static int ProcessingBatch { get; } = 10;
        public const string HttpRequestSfCodeHeader = "X-Sf-Code";
        public const string HttpRequestIdTokenHeader = "X-Id-Token";

        public class AuditableEntities
        {
            public static string[] Entities { get; } = new string[]
            {
                "Donor",
                "Donation",
                "DonationDetails",
            };
        }

        #region Workflow
        public class WorkFlowStateId
        {
            public static string Accepted { get; } = "accepted";
            public static string AdditionalInfoSubmitted { get; } = "additional_info_submitted";
            public static string AdminClosure { get; } = "admin_closure";
            public static string Approved { get; } = "approved";
            public static string Completed { get; } = "completed";
            public static string Initiation { get; } = "Initiation";
            public static string Inprogress { get; } = "inprogress";
            public static string NewGenerationRequest { get; } = "new_generation_request";
            public static string NewRequest { get; } = "new_request";
            public static string PendingAcceptance { get; } = "pending_acceptance";
            public static string PendingCorrection { get; } = "pending_correction";
            public static string PendingGeneration { get; } = "pending_generation";
            public static string PendingInfoRequest { get; } = "pending_info_request";
            public static string PendingRequest { get; } = "pending_request";
            public static string PendingReview { get; } = "pending_review";
            public static string PendingDeliveryConfirmation { get; } = "pending_delivery_confirmation";
            public static string PendingVerification { get; } = "pending_verification";
            public static string ServiceInProgress { get; } = "service_in_progress";
            public static string ReconciliationInProgress { get; } = "reconciliation_in_progress";
            public static string PlanningInProgress { get; } = "planning_in_progress";
            public static string PlanningCompleted { get; } = "planning_completed";
            public static string PlanningNotStarted { get; } = "planning_not_started";
            public static string Verified { get; } = "verified";
            public static string Submitted { get; } = "submitted";
            public static string Abandoned { get; } = "abandoned";

            public static string[] AllApprovedStatuses { get; } =
                {
                    Verified,
                    Completed,
                    Approved,
                    Submitted,
                    Abandoned,
                };

            public static string[] AllPendingStatuses { get; } =
                {
                    Inprogress,
                    PendingAcceptance,
                    PendingGeneration,
                    PendingInfoRequest,
                    PendingRequest,
                    PendingReview,
                    PendingVerification,
                    ServiceInProgress,
                    PendingDeliveryConfirmation,
                    PlanningInProgress,
                    PendingCorrection,
                };
        }

        public class WorkFlowCode
        {
            public static string Adjustment { get; } = "adjustment";
            public static string DailyRequisition { get; } = "daily_requisition";
        }

        #endregion
    }
}
