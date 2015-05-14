using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KusumgarBusinessEntities.Common;
namespace Kusumgar.Common
{
    public class MessageStore
    {
        public static FixedSizeGenericHashTable<string, FriendlyMessage> hash = new FixedSizeGenericHashTable<string, FriendlyMessage>(400);

        static MessageStore()
        {
            #region System

            FriendlyMessage SYS01 = new FriendlyMessage("SYS01", MessageType.Danger, "We are currently unable to process your request, Please try again later or contact system administrator.");
            hash.Add("SYS01", SYS01);

            FriendlyMessage SYS02 = new FriendlyMessage("SYS02", MessageType.Info, "Your session has expired. Please login again.");
            hash.Add("SYS02", SYS02);

            FriendlyMessage SYS03 = new FriendlyMessage("SYS03", MessageType.Danger, "Please login with valid Username Password to view this page.");
            hash.Add("SYS03", SYS03);

            FriendlyMessage SYS04 = new FriendlyMessage("SYS04", MessageType.Info, "No records found.");
            hash.Add("SYS04", SYS04);

            FriendlyMessage SYS05 = new FriendlyMessage("SYS05", MessageType.Info, "Password has been changed successfully.");
            hash.Add("SYS05", SYS05);

            FriendlyMessage SYS06 = new FriendlyMessage("SYS06", MessageType.Danger, "You dont have online access. Please contact administrator.");
            hash.Add("SYS06", SYS06);

            #endregion

            #region User

            FriendlyMessage UM001 = new FriendlyMessage("UM001", MessageType.Danger, "Username and password does not match. Please Login again.");
            hash.Add("UM001", UM001);

            FriendlyMessage UM002 = new FriendlyMessage("UM002", MessageType.Info, "User has been added successfully.");
            hash.Add("UM002", UM002);

            FriendlyMessage UM003 = new FriendlyMessage("UM003", MessageType.Info, "User has been updated successfully.");
            hash.Add("UM003", UM003);

            FriendlyMessage UM004 = new FriendlyMessage("UM004", MessageType.Info, "Please check your email for you Registration credentials.");
            hash.Add("UM004", UM004);

            FriendlyMessage UM005 = new FriendlyMessage("UM005", MessageType.Info, "Password link sent to your email address.");
            hash.Add("UM005", UM005);

            FriendlyMessage UM006 = new FriendlyMessage("UM006", MessageType.Info, "Your password has been changed successfully.");
            hash.Add("UM006", UM006);

            FriendlyMessage UM007 = new FriendlyMessage("UM007", MessageType.Info, "Username link sent to your email address.");
            hash.Add("UM007", UM007);

            FriendlyMessage UM008 = new FriendlyMessage("UM008", MessageType.Info, "User not found.");
            hash.Add("UM008", UM008);

            FriendlyMessage UM009 = new FriendlyMessage("UM009", MessageType.Info, "No user account is registered with this email id.");
            hash.Add("UM009", UM009);

            FriendlyMessage UM010 = new FriendlyMessage("UM010", MessageType.Info, "Password reset link is not valid or has been expired.");
            hash.Add("UM010", UM010);

            FriendlyMessage UM011 = new FriendlyMessage("UM011", MessageType.Info, "Please select Clinic and ClinicBranch to view Users Listing.");
            hash.Add("UM011", UM011);

            FriendlyMessage UM012 = new FriendlyMessage("UM012", MessageType.Danger, "Sorry, your Clinic dont have Web Access. Please login from Windows Client");
            hash.Add("UM012", UM012);

            //Added by:Pooja Date:03182014
            FriendlyMessage UM013 = new FriendlyMessage("UM013", MessageType.Info, "Password varification link has been sent to your registred email id.");
            hash.Add("UM013", UM013);
            //Addition ends Date:03182014


            #endregion
        }

        public static FriendlyMessage Get(string code)
        {
            FriendlyMessage message = hash.Find(code);

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