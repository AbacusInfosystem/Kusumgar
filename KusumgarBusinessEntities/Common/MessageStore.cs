using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities.Common
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

            FriendlyMessageInfo SYS03 = new FriendlyMessageInfo("SYS03", MessageType.Danger, "Please login with valid Username Password to view this page.");
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

                #region Consumable

                FriendlyMessageInfo C011 = new FriendlyMessageInfo("C011", MessageType.Success, "Consumable has been added successfully.");
                hash.Add("C011", C011);

                FriendlyMessageInfo C012 = new FriendlyMessageInfo("C012", MessageType.Success, "Test has been updated successfully.");
                hash.Add("C012", C012);

                FriendlyMessageInfo CV011 = new FriendlyMessageInfo("CV011", MessageType.Success, "Consumable Vendor has been added successfully.");
                hash.Add("CV011", CV011);

                FriendlyMessageInfo CV012 = new FriendlyMessageInfo("CV012", MessageType.Success, "Vendor Deleted successfully.");
                hash.Add("CV012", CV012);

                FriendlyMessageInfo CU013 = new FriendlyMessageInfo("CU013", MessageType.Success, "Consumable has been updated successfully.");
                hash.Add("CU013", CU013);

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
