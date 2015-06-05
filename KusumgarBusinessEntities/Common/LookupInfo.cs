using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KusumgarBusinessEntities.Common
{
    public class LookupInfo
    {
        public static Dictionary<int, string> GetAttributeNames()
        {
            Dictionary<int, string> attributeNames = new Dictionary<int, string>();

            attributeNames.Add(1, AttributeName.Denier.ToString());

            attributeNames.Add(2, AttributeName.TwistMingle.ToString());

            attributeNames.Add(3, AttributeName.Twist_type.ToString());

            attributeNames.Add(4, AttributeName.Ply.ToString());

            attributeNames.Add(5, AttributeName.Yarn_type.ToString());

            attributeNames.Add(6, AttributeName.Shade.ToString());

            attributeNames.Add(7, AttributeName.Filaments.ToString());

            attributeNames.Add(8, AttributeName.Origin.ToString());

            attributeNames.Add(9, AttributeName.Shrinkage.ToString());
            attributeNames.Add(10, AttributeName.Tenasity.ToString());
            attributeNames.Add(11, AttributeName.Chemical_Treatment.ToString());
            attributeNames.Add(12, AttributeName.Colour.ToString());
            attributeNames.Add(13, AttributeName.Supplier.ToString());
            attributeNames.Add(14, AttributeName.Weave.ToString());
            attributeNames.Add(15, AttributeName.Chemical_Finish.ToString());
            attributeNames.Add(16, AttributeName.Mechanical_Finish.ToString());
            attributeNames.Add(17, AttributeName.Type.ToString());
            attributeNames.Add(18, AttributeName.Unit.ToString());
            attributeNames.Add(19, AttributeName.Process.ToString());
            attributeNames.Add(20, AttributeName.Department.ToString());

            return attributeNames;
        }

        public static Dictionary<int, string> Get_Product_Service_Types()
        {
            Dictionary<int, string> GetProductServiceTypes = new Dictionary<int, string>();

            GetProductServiceTypes.Add(1, ProductVendor.ProductType.ToString());

            GetProductServiceTypes.Add(2, ProductVendor.Service.ToString());

            return GetProductServiceTypes;
        }

        public static Dictionary<int, string> Get_ShipMent_Method()
        {
            Dictionary<int, string> GetShipMentMethod = new Dictionary<int, string>();

            GetShipMentMethod.Add(1, ShipmentMethod.method1.ToString());

            GetShipMentMethod.Add(2, ShipmentMethod.method2.ToString());



            return GetShipMentMethod;
        }

        public static Dictionary<int, string> GetGenderTypes()
        {
            Dictionary<int, string> GetGenderTypes = new Dictionary<int, string>();

            GetGenderTypes.Add(1, GenderType.Male.ToString());

            GetGenderTypes.Add(2, GenderType.Female.ToString());

            GetGenderTypes.Add(3, GenderType.Transgender.ToString());

            return GetGenderTypes;
        }

        public static Dictionary<int, string> Get_Compnay_Types()
        {
            Dictionary<int, string> Get_Compnay_Types = new Dictionary<int, string>();

            Get_Compnay_Types.Add(1, CompanyType.Propritory.ToString());

            Get_Compnay_Types.Add(2, CompanyType.Private.ToString());

            Get_Compnay_Types.Add(3, CompanyType.Limited.ToString());

            return Get_Compnay_Types;
        }

        public static Dictionary<int, string> Get_Compnay_Status()
        {
            Dictionary<int, string> Get_Compnay_Status = new Dictionary<int, string>();

            Get_Compnay_Status.Add(1, CompanyStatus.Progressive.ToString());

            Get_Compnay_Status.Add(2, CompanyStatus.Stable.ToString());

            Get_Compnay_Status.Add(3, CompanyStatus.Turmoil.ToString());

            return Get_Compnay_Status;
        }

        public static Dictionary<int, string> Get_Currency_Type()
        {
            Dictionary<int, string> Get_Currency_Type = new Dictionary<int, string>();

            Get_Currency_Type.Add(1, CurrencyType.Rupees.ToString());

            Get_Currency_Type.Add(2, CurrencyType.Dollars.ToString());

            Get_Currency_Type.Add(3, CurrencyType.Euros.ToString());

            Get_Currency_Type.Add(4, CurrencyType.Pounds.ToString());

            return Get_Currency_Type;
        }

        public static Dictionary<int, string> Get_Payment_Terms()
        {
            Dictionary<int, string> Get_Payment_Terms = new Dictionary<int, string>();

            Get_Payment_Terms.Add(1, PaymentTerms.LC.ToString());

            Get_Payment_Terms.Add(2, PaymentTerms.Cash.ToString());

            return Get_Payment_Terms;
        }

        public static Dictionary<int, string> Get_DMU_Status_Role()
        {
            Dictionary<int, string> Get_DMU_Status_Role = new Dictionary<int, string>();

            Get_DMU_Status_Role.Add(1, DMUStatusRole.option1.ToString());

            Get_DMU_Status_Role.Add(2, DMUStatusRole.option2.ToString());

            Get_DMU_Status_Role.Add(3, DMUStatusRole.option3.ToString());

            Get_DMU_Status_Role.Add(4, DMUStatusRole.option4.ToString());

            Get_DMU_Status_Role.Add(5, DMUStatusRole.option5.ToString());

            return Get_DMU_Status_Role;
        }

        public static Dictionary<int, string> Get_DMU_Status_Influence()
        {
            Dictionary<int, string> Get_DMU_Status_Influence = new Dictionary<int, string>();

            Get_DMU_Status_Influence.Add(1, DMUStatusInfluence.option1.ToString());

            Get_DMU_Status_Influence.Add(2, DMUStatusInfluence.option2.ToString());

            Get_DMU_Status_Influence.Add(3, DMUStatusInfluence.option3.ToString());

            Get_DMU_Status_Influence.Add(4, DMUStatusInfluence.option4.ToString());

            Get_DMU_Status_Influence.Add(5, DMUStatusInfluence.option5.ToString());

            return Get_DMU_Status_Influence;
        }

        public static Dictionary<int, string> Get_Priority_Orders()
        {
            Dictionary<int, string> Get_Priority_Orders = new Dictionary<int, string>();

            Get_Priority_Orders.Add(1, PriorityOrder.Primary.ToString());

            Get_Priority_Orders.Add(2, PriorityOrder.Secondary.ToString());

            Get_Priority_Orders.Add(3, PriorityOrder.Last_Option.ToString());

            return Get_Priority_Orders;
        }

        public static Dictionary<int, string> Get_Product_Types()
        {
            Dictionary<int, string> Get_Product_Types = new Dictionary<int, string>();

            Get_Product_Types.Add(1, ProductType.Finish_Product.ToString().Replace('_',' ').ToString());

            Get_Product_Types.Add(2, ProductType.Raw_Material.ToString().Replace('_', ' ').ToString());

            Get_Product_Types.Add(3, ProductType.Service.ToString());

            return Get_Product_Types;
        }

        public static Dictionary<int, string> Get_Enquiry_Types()
        {
            Dictionary<int, string> Get_Enquiry_Types = new Dictionary<int, string>();

            Get_Enquiry_Types.Add(1, EnquiryType.Trial.ToString().Replace('_', ' ').ToString());

            Get_Enquiry_Types.Add(2, EnquiryType.General.ToString().Replace('_', ' ').ToString());

            Get_Enquiry_Types.Add(3, EnquiryType.Stock.ToString().Replace('_', ' ').ToString());

            return Get_Enquiry_Types;
        }

        public static Dictionary<int, string> Get_Enquiry_Status()
        {
            Dictionary<int, string> Get_Enquiry_Status = new Dictionary<int, string>();

            Get_Enquiry_Status.Add(1, EnquiryStatus.Enquiry_Arrived.ToString().Replace('_', ' ').ToString());

            Get_Enquiry_Status.Add(2, EnquiryStatus.Passed_PPC_Check_Point.ToString().Replace('_', ' ').ToString());

            Get_Enquiry_Status.Add(3, EnquiryStatus.Passed_W_Manager_Check_Point.ToString().Replace('_', ' ').ToString());

            Get_Enquiry_Status.Add(4, EnquiryStatus.Passed_P_Manager_Check_Point.ToString().Replace('_', ' ').ToString());
            
            Get_Enquiry_Status.Add(5, EnquiryStatus.Passed_C_Manager_Check_Point.ToString().Replace('_', ' ').ToString());
            
            Get_Enquiry_Status.Add(6, EnquiryStatus.Temp_Quality_Set_Created.ToString().Replace('_', ' ').ToString());
            
            Get_Enquiry_Status.Add(7, EnquiryStatus.Quality_Assigned.ToString().Replace('_', ' ').ToString());
            
            Get_Enquiry_Status.Add(8, EnquiryStatus.Planned.ToString().Replace('_', ' ').ToString());

            return Get_Enquiry_Status;
        }
    }
}
