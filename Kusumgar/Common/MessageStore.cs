using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities.Common;
namespace Kusumgar
{
    public class MessageStore
    {
        public static FixedSizeGenericHashTable<string, FriendlyMessageInfo> hash = new FixedSizeGenericHashTable<string, FriendlyMessageInfo>(400);

        static MessageStore()
        {
            #region System

            FriendlyMessageInfo SYS01 = new FriendlyMessageInfo("SYS01", MessageType.Danger, "We are currently unable to process your request, Please try again later or contact system administrator.");
            hash.Add("SYS01", SYS01);

            FriendlyMessageInfo SYS02 = new FriendlyMessageInfo("SYS02", MessageType.Info, "Your session has expired. Please login again.");
            hash.Add("SYS02", SYS02);

            FriendlyMessageInfo SYS03 = new FriendlyMessageInfo("SYS03", MessageType.Danger, "Invalid login credentials. Please login with valid username & password.");
            hash.Add("SYS03", SYS03);

            FriendlyMessageInfo SYS04 = new FriendlyMessageInfo("SYS04", MessageType.Info, "No records found.");
            hash.Add("SYS04", SYS04);

            FriendlyMessageInfo SYS05 = new FriendlyMessageInfo("SYS05", MessageType.Info, "Password has been changed successfully.");
            hash.Add("SYS05", SYS05);

            FriendlyMessageInfo SYS06 = new FriendlyMessageInfo("SYS06", MessageType.Danger, "You dont have online access. Please contact administrator.");
            hash.Add("SYS06", SYS06);

            #endregion

            #region Master

            #region User

            FriendlyMessageInfo UM001 = new FriendlyMessageInfo("UM001", MessageType.Danger, "Username and password does not match. Please Login again.");
            hash.Add("UM001", UM001);

            FriendlyMessageInfo UM002 = new FriendlyMessageInfo("UM002", MessageType.Success, "Employee has been added successfully.");
            hash.Add("UM002", UM002);

            FriendlyMessageInfo UM003 = new FriendlyMessageInfo("UM003", MessageType.Success, "Employee has been updated successfully.");
            hash.Add("UM003", UM003);

            FriendlyMessageInfo UM004 = new FriendlyMessageInfo("UM004", MessageType.Info, "Please check your email for you Registration credentials.");
            hash.Add("UM004", UM004);

            FriendlyMessageInfo UM005 = new FriendlyMessageInfo("UM005", MessageType.Info, "Password link sent to your email address.");
            hash.Add("UM005", UM005);

            FriendlyMessageInfo UM006 = new FriendlyMessageInfo("UM006", MessageType.Info, "Your password has been changed successfully.");
            hash.Add("UM006", UM006);

            FriendlyMessageInfo UM007 = new FriendlyMessageInfo("UM007", MessageType.Info, "Username link sent to your email address.");
            hash.Add("UM007", UM007);

            FriendlyMessageInfo UM008 = new FriendlyMessageInfo("UM008", MessageType.Info, "User not found.");
            hash.Add("UM008", UM008);

            #endregion

            #region Role

            FriendlyMessageInfo RO001 = new FriendlyMessageInfo("RO001", MessageType.Success, "Role has been added successfully.");
            hash.Add("RO001", RO001);

            FriendlyMessageInfo RO002 = new FriendlyMessageInfo("RO002", MessageType.Success, "Role has been updated successfully.");
            hash.Add("RO002", RO002);
            #endregion

            #region RoleAccess
            FriendlyMessageInfo R0001 = new FriendlyMessageInfo("R0001", MessageType.Info, "Role access mapping updated successfully.");
            hash.Add("R0001", R0001);

            #endregion

            #region DefectType

            FriendlyMessageInfo DT011 = new FriendlyMessageInfo("DT011", MessageType.Success, "DefectType has been added successfully.");
            hash.Add("DT011", DT011);

            FriendlyMessageInfo DT012 = new FriendlyMessageInfo("DT012", MessageType.Success, "DefectType has been updated successfully.");
            hash.Add("DT012", DT012);
            #endregion

            #region Defects

            FriendlyMessageInfo D011 = new FriendlyMessageInfo("D011", MessageType.Success, "Defect has been added successfully.");
            hash.Add("D011", D011);

            FriendlyMessageInfo D012 = new FriendlyMessageInfo("D012", MessageType.Success, "Defect has been updated successfully.");
            hash.Add("D012", D012);
            #endregion

            #region TestUnit

            FriendlyMessageInfo TU011 = new FriendlyMessageInfo("TU011", MessageType.Success, "TestUnit has been added successfully.");
            hash.Add("TU011", TU011);

            FriendlyMessageInfo TU012 = new FriendlyMessageInfo("TU012", MessageType.Success, "TestUnit has been updated successfully.");
            hash.Add("TU012", TU012);
            #endregion

            #region Test

            FriendlyMessageInfo T011 = new FriendlyMessageInfo("T011", MessageType.Success, "Test has been added successfully.");
            hash.Add("T011", T011);

            FriendlyMessageInfo T012 = new FriendlyMessageInfo("T012", MessageType.Success, "Test has been updated successfully.");
            hash.Add("T012", T012);
            #endregion

            #region Attribute Code

            FriendlyMessageInfo AC011 = new FriendlyMessageInfo("AC011", MessageType.Success, "Attribute Code has been added successfully.");
            hash.Add("AC011", AC011);

            FriendlyMessageInfo AC012 = new FriendlyMessageInfo("AC012", MessageType.Success, "Attribute Code has been updated successfully.");
            hash.Add("AC012", AC012);
            #endregion

            #region Vendor

            FriendlyMessageInfo V011 = new FriendlyMessageInfo("V011", MessageType.Success, "Vendor has been added successfully.");
            hash.Add("V011", V011);

            FriendlyMessageInfo PS011 = new FriendlyMessageInfo("PS011", MessageType.Success, "Product Services has been added successfully.");
            hash.Add("PS011", PS011);

            FriendlyMessageInfo V012 = new FriendlyMessageInfo("V012", MessageType.Success, "Vendor has been updated successfully.");
            hash.Add("V012", V012);

            FriendlyMessageInfo PS012 = new FriendlyMessageInfo("PS012", MessageType.Success, "Product Services has been updated successfully.");
            hash.Add("PS012", PS012);

            FriendlyMessageInfo PS013 = new FriendlyMessageInfo("PS013 ", MessageType.Success, "Product Services has been deleted successfully.");
            hash.Add("PS013 ", PS013);


            #endregion

            #region Consumable

            FriendlyMessageInfo C011 = new FriendlyMessageInfo("C011", MessageType.Success, "Consumable has been added successfully.");
            hash.Add("C011", C011);

            FriendlyMessageInfo C012 = new FriendlyMessageInfo("C012", MessageType.Success, "Consumable has been updated successfully.");
            hash.Add("C012", C012);

            FriendlyMessageInfo CV011 = new FriendlyMessageInfo("CV011", MessageType.Success, " Vendor has been added successfully.");
            hash.Add("CV011", CV011);

            FriendlyMessageInfo CV012 = new FriendlyMessageInfo("CV012", MessageType.Success, "Vendor Deleted successfully.");
            hash.Add("CV012", CV012);

            FriendlyMessageInfo CU013 = new FriendlyMessageInfo("CU013", MessageType.Success, "Consumable has been updated successfully.");
            hash.Add("CU013", CU013);

            FriendlyMessageInfo CV014 = new FriendlyMessageInfo("CV014", MessageType.Success, " Vendor has been updated successfully.");
            hash.Add("CV014", CV014);

            #endregion

            #region Industrial

            FriendlyMessageInfo IND001 = new FriendlyMessageInfo("IND001", MessageType.Success, "Industrial Master has been added successfully.");
            hash.Add("IND001", IND001);

            FriendlyMessageInfo IND002 = new FriendlyMessageInfo("IND002", MessageType.Success, "Industrial Master has been updated successfully.");
            hash.Add("IND002", IND002);

            FriendlyMessageInfo IND003 = new FriendlyMessageInfo("IND003", MessageType.Success, "Industrial Vendor has been added successfully.");
            hash.Add("IND003", IND003);

            FriendlyMessageInfo IND004 = new FriendlyMessageInfo("IND004", MessageType.Success, "Industrial Vendor has been deleted successfully.");
            hash.Add("IND004", IND004);

            #endregion

            #region YArticle

            FriendlyMessageInfo YA001 = new FriendlyMessageInfo("YA001", MessageType.Success, "Y Article has been added successfully.");
            hash.Add("YA001", YA001);

            FriendlyMessageInfo YA002 = new FriendlyMessageInfo("YA002", MessageType.Success, "Y Article has been updated successfully.");
            hash.Add("YA002", YA002);

            #endregion

            #region VendorContact

            FriendlyMessageInfo VC001 = new FriendlyMessageInfo("VC001", MessageType.Success, "Vendor Contact has been added successfully.");
            hash.Add("VC001", VC001);

            FriendlyMessageInfo VC002 = new FriendlyMessageInfo("VC002", MessageType.Success, "Vendor Custom Field has been added successfully.");
            hash.Add("VC002", VC002);

            FriendlyMessageInfo VC003 = new FriendlyMessageInfo("VC003", MessageType.Success, "Vendor Contact has been updated successfully.");
            hash.Add("VC003", VC003);

            FriendlyMessageInfo VC004 = new FriendlyMessageInfo("VC004", MessageType.Success, "Vendor Custom Field has been updated successfully.");
            hash.Add("VC004", VC004);

            FriendlyMessageInfo VC005 = new FriendlyMessageInfo("VC005", MessageType.Success, "Vendor Contact Deleted successfully.");
            hash.Add("VC005", VC005);

            #endregion

            #region Material

            FriendlyMessageInfo P001 = new FriendlyMessageInfo("P001", MessageType.Success, "Material has been added successfully.");
            hash.Add("P001", P001);

            FriendlyMessageInfo P002 = new FriendlyMessageInfo("P002", MessageType.Success, "Material has been updated successfully.");
            hash.Add("P002", P002);

            FriendlyMessageInfo P003 = new FriendlyMessageInfo("P003", MessageType.Success, "Material Vendor has been added successfully.");
            hash.Add("P003", P003);

            FriendlyMessageInfo P004 = new FriendlyMessageInfo("P004", MessageType.Success, "Material Vendor has been deleted successfully.");
            hash.Add("P004", P004);

            #endregion

            #region WorkCenter

            FriendlyMessageInfo WC001 = new FriendlyMessageInfo("WC001", MessageType.Success, "Work center has been added successfully.");
            hash.Add("WC001", WC001);

            FriendlyMessageInfo WC002 = new FriendlyMessageInfo("WC002", MessageType.Success, "Work center has been updated successfully.");
            hash.Add("WC002", WC002);

            #endregion


            #region QualityCreation

            FriendlyMessageInfo Q011 = new FriendlyMessageInfo("Q011", MessageType.Success, "Quality has been added successfully.");
            hash.Add("Q011", Q011);

            FriendlyMessageInfo Q012 = new FriendlyMessageInfo("Q012", MessageType.Success, "Quality has been updated successfully.");
            hash.Add("Q012", Q012);
            #region VendorContact

            FriendlyMessageInfo CQ001 = new FriendlyMessageInfo("CQ001", MessageType.Success, "Customer Quality has been added successfully.");
            hash.Add("CQ001", CQ001);

            FriendlyMessageInfo CQ002 = new FriendlyMessageInfo("CQ002", MessageType.Success, "Customer Quality has been updated successfully.");
            hash.Add("CQ002", CQ002);


            FriendlyMessageInfo QA011 = new FriendlyMessageInfo("QA011", MessageType.Success, "Quality Application has been added successfully.");
            hash.Add("QA011", QA011);

            FriendlyMessageInfo QA012 = new FriendlyMessageInfo("QA012", MessageType.Success, "Quality Application has been deleted successfully.");
            hash.Add("QA012", QA012);

            FriendlyMessageInfo QS011 = new FriendlyMessageInfo("QS011", MessageType.Success, "Quality Segment has been added successfully.");
            hash.Add("QS011", QS011);

            FriendlyMessageInfo QS012 = new FriendlyMessageInfo("QS012", MessageType.Success, "Quality Segment has been deleted successfully.");
            hash.Add("QS012", QS012);
            #endregion

            #region GArticle

            FriendlyMessageInfo GA001 = new FriendlyMessageInfo("GA001", MessageType.Success, "G Article has been added successfully.");
            hash.Add("GA001", GA001);

            FriendlyMessageInfo GA002 = new FriendlyMessageInfo("GA002", MessageType.Success, "G Article has been updated successfully.");
            hash.Add("GA002", GA002);

            #endregion

            #endregion

            #region P_Article

            FriendlyMessageInfo PA011 = new FriendlyMessageInfo("PA011", MessageType.Success, "PArticle has been added successfully.");
            hash.Add("PA011", PA011);

            FriendlyMessageInfo PA012 = new FriendlyMessageInfo("PA012", MessageType.Success, "PArticle has been updated successfully.");
            hash.Add("PA012", PA012);

            #endregion




            #region WArticle

            FriendlyMessageInfo WA001 = new FriendlyMessageInfo("WA001", MessageType.Success, "W Article has been added successfully.");
            hash.Add("WA001", WA001);

            FriendlyMessageInfo WA002 = new FriendlyMessageInfo("WA002", MessageType.Success, "W Article has been updated successfully.");
            hash.Add("WA002", WA002);

            #endregion

            #region CArticle

            FriendlyMessageInfo CA001 = new FriendlyMessageInfo("CA001", MessageType.Success, "C Article has been added successfully.");
            hash.Add("CA001", CA001);

            FriendlyMessageInfo CA002 = new FriendlyMessageInfo("CA002", MessageType.Success, "C Article has been updated successfully.");
            hash.Add("CA002", CA002);

            #endregion

            #endregion

            #region CRM

            #region Customer

            FriendlyMessageInfo CU001 = new FriendlyMessageInfo("CU001", MessageType.Success, "Customer has been added successfully.");
            hash.Add("CU001", CU001);

            FriendlyMessageInfo CU002 = new FriendlyMessageInfo("CU002", MessageType.Success, "Customer has been updated successfully.");
            hash.Add("CU002", CU002);

            FriendlyMessageInfo CU003 = new FriendlyMessageInfo("CU003", MessageType.Success, "Customer Address has been added successfully.");
            hash.Add("CU003", CU003);

            FriendlyMessageInfo CU004 = new FriendlyMessageInfo("CU004", MessageType.Success, "Customer Address has been updated successfully.");
            hash.Add("CU004", CU004);

            FriendlyMessageInfo CU005 = new FriendlyMessageInfo("CU005", MessageType.Success, "Bank Details has been added successfully.");
            hash.Add("CU005", CU005);

            FriendlyMessageInfo CU006 = new FriendlyMessageInfo("CU006", MessageType.Success, "Bank Details has been updated successfully.");
            hash.Add("CU006", CU006);

            FriendlyMessageInfo CU007 = new FriendlyMessageInfo("CU007", MessageType.Success, "Customer Address Deleted successfully.");
            hash.Add("CU007", CU007);

            #endregion

            #region Contact
            FriendlyMessageInfo CO001 = new FriendlyMessageInfo("CO001", MessageType.Success, "Contact has been added successfully.");
            hash.Add("CO001", CO001);

            FriendlyMessageInfo CO002 = new FriendlyMessageInfo("CO002", MessageType.Success, "Contact has been updated successfully.");
            hash.Add("CO002", CO002);

            FriendlyMessageInfo CO003 = new FriendlyMessageInfo("CO003", MessageType.Success, "Custom Field has been added successfully.");
            hash.Add("CO003", CO003);

            FriendlyMessageInfo CO004 = new FriendlyMessageInfo("CO004", MessageType.Success, "Custom Field has been updated successfully.");
            hash.Add("CO004", CO004);

            FriendlyMessageInfo CO005 = new FriendlyMessageInfo("CO005", MessageType.Success, "Custom Field Deleted successfully.");
            hash.Add("CO005", CO005);
            #endregion

            #region Complaint

            FriendlyMessageInfo COM001 = new FriendlyMessageInfo("COM001", MessageType.Success, "Complaint has been added successfully.");
            hash.Add("COM001", COM001);

            FriendlyMessageInfo COM002 = new FriendlyMessageInfo("COM002", MessageType.Success, "Complaint has been updated successfully.");
            hash.Add("COM002", COM002);

            #endregion

            #endregion

            #region Sales

            FriendlyMessageInfo EQ001 = new FriendlyMessageInfo("EQ001", MessageType.Success, "Enquiry has been added successfully.");
            hash.Add("EQ001", EQ001);

            FriendlyMessageInfo EQ002 = new FriendlyMessageInfo("EQ002", MessageType.Success, "Enquiry has been updated successfully.");
            hash.Add("EQ002", EQ002);

            FriendlyMessageInfo EQ003 = new FriendlyMessageInfo("EQ003", MessageType.Success, "Staggered order has been added successfully.");
            hash.Add("EQ003", EQ003);

            FriendlyMessageInfo EQ004 = new FriendlyMessageInfo("EQ004", MessageType.Success, "Staggered order has been updated successfully.");
            hash.Add("EQ004", EQ004);

            FriendlyMessageInfo EQ005 = new FriendlyMessageInfo("EQ005", MessageType.Success, "Staggered order has been deleted successfully.");
            hash.Add("EQ005", EQ005);

            FriendlyMessageInfo EQ006 = new FriendlyMessageInfo("EQ006", MessageType.Success, "Supporting details has been added successfully.");
            hash.Add("EQ006", EQ006);

            FriendlyMessageInfo EQ007 = new FriendlyMessageInfo("EQ007", MessageType.Success, "Supporting details has been updated successfully.");
            hash.Add("EQ007", EQ007);

            FriendlyMessageInfo EQ008 = new FriendlyMessageInfo("EQ008", MessageType.Success, "Attachment has been added successfully.");
            hash.Add("EQ008", EQ008);

            FriendlyMessageInfo EQ009 = new FriendlyMessageInfo("EQ009", MessageType.Success, "Attachment has been deleted successfully.");
            hash.Add("EQ009", EQ009);

            FriendlyMessageInfo EQ010 = new FriendlyMessageInfo("EQ010", MessageType.Success, "Funcational parameter has been added successfully.");
            hash.Add("EQ010", EQ010);

            FriendlyMessageInfo EQ011 = new FriendlyMessageInfo("EQ011", MessageType.Success, "Funcational parameter has been deleted successfully.");
            hash.Add("EQ011", EQ011);

            FriendlyMessageInfo EQ012 = new FriendlyMessageInfo("EQ012", MessageType.Success, "Visual parameter has been added successfully.");
            hash.Add("EQ012", EQ012);

            FriendlyMessageInfo EQ013 = new FriendlyMessageInfo("EQ013", MessageType.Success, "Visual parameter has been deleted successfully.");
            hash.Add("EQ013", EQ013);




            #endregion

            #region Ajax

            FriendlyMessageInfo AJ001 = new FriendlyMessageInfo("AJ001", MessageType.Success, "Attachments has been added successfully.");
            hash.Add("AJ001", AJ001);

            FriendlyMessageInfo AJ002 = new FriendlyMessageInfo("AJ002", MessageType.Success, "Attachment has been deleted successfully.");
            hash.Add("AJ002", AJ002);

            FriendlyMessageInfo AJ003 = new FriendlyMessageInfo("AJ003", MessageType.Warning, "Attachment already exist.");
            hash.Add("AJ003", AJ003);

            #endregion

        }

        public static FriendlyMessageInfo Get(string code)
        {
            FriendlyMessageInfo message = hash.Find(code);

            return message;
        }

        /// <summary>
        /// struct to hold generic key and value
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks></remarks>
        public struct KeyValue<K, V>
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            /// <remarks></remarks>
            public K Key { get; set; }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            /// <remarks></remarks>
            public V Value { get; set; }
        }

        /// <summary>
        /// FixedSizeGenericHashTable
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
        public class FixedSizeGenericHashTable<K, V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public FixedSizeGenericHashTable(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValue<K, V>>[size];
            }

            protected int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }

            public V Find(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return default(V);
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            /// <remarks></remarks>
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
                linkedList.AddLast(item);
            }

            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <remarks></remarks>
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }

                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }

            /// <summary>
            /// Gets the linked list.
            /// </summary>
            /// <param name="position">The position.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position];
                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }

                return linkedList;
            }
        }
    }
}
