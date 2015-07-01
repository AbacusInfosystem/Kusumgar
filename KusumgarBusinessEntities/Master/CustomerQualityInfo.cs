using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{

    public class CustomerQualityInfo 
    {
        public CustomerQualityInfo()
        {
            Customers = new List<CustomerInfo>();

            Customer = new CustomerInfo();

            Qualities = new List<QualityInfo>();

            Quality = new QualityInfo();

            Samples = new List<SampleInfo>();

            Sample = new SampleInfo();

            Customer_Quality_Functional_Parameter = new CustomerQualityFunctionalParameterInfo();

            Customer_Quality_Visual_Parameter = new CustomerQualityVisualParameterInfo();


        }

        public List<CustomerInfo> Customers { get; set; }

        public CustomerInfo Customer { get; set; }

        public List<QualityInfo> Qualities { get; set; }

        public QualityInfo Quality { get; set; }

        //public int Customer_Sample_No { get; set; }

        public List<SampleInfo> Samples { get; set; }

        public SampleInfo Sample { get; set; }

        public int Customer_Quality_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Quality_Id { get; set; }

        public string Customer_Roll_Length { get; set; }

        public string Storage { get; set; }

        public string Transport { get; set; }

        public string Lot_Testing { get; set; }

        public string End_Product_Criteria { get; set; }

        public string Testing_Requirements { get; set; }

        public string Inspection_Requirements { get; set; }

        public string Process_Control { get; set; }

        public int Sample_Id { get; set; }

        public string Special_Care_Details { get; set; }

        public string Special_Requirements_Material_Handling { get; set; }

        public string Special_Requirements_Packaging { get; set; }

        public string Special_Requirements_Defect_Defination { get; set; }

        public string Special_Requirements_Verdicting { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public CustomerQualityFunctionalParameterInfo Customer_Quality_Functional_Parameter { get; set; }

        public CustomerQualityVisualParameterInfo Customer_Quality_Visual_Parameter { get; set; }

        #endregion

    }

}


