/* Title:           Charter Inventory Class
 * Date:            6-8-17
 * Author:          Terry Holmes*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace CharterInventoryDLL
{
    public class CharterInventoryClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        CharterInventoryDataSet aCharterInventoryDataSet;
        CharterInventoryDataSetTableAdapters.charterinventoryTableAdapter aCharterInventoryTableAdapter;

        FindCompleteCharterInventoryDataSet aFindCompleteCharterInventoryDataSet;
        FindCompleteCharterInventoryDataSetTableAdapters.FindCompleteCharterInventoryTableAdapter aFindCompleteCharterInventoryTableAdapter;

        FindCharterWarehouseInventoryDataSet aFindCharterWarehouseInventoryDataSet;
        FindCharterWarehouseInventoryDataSetTableAdapters.FindCharterWarehouseInventoryTableAdapter aFindCharterWarehouseInventoryTableAdapter;

        FindCharterWarehouseInventoryForPartDataSet aFindCharterWarehouseInventoryForPartDataSet;
        FindCharterWarehouseInventoryForPartDataSetTableAdapters.FindCharterWarehouseInventoryForPartTableAdapter aFindCharterWarehouseInventoryForPartTableAdapter;

        InsertCharterInventoryDataTableAdapters.QueriesTableAdapter aInsertCharterInventoryTableAdapter;

        UpdateCharterInventoryDataSetTableAdapters.QueriesTableAdapter aUpdateCharterInventoryTableAdapter;

        public bool UpdateCharterInventory(int intTransactionID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateCharterInventoryTableAdapter = new UpdateCharterInventoryDataSetTableAdapters.QueriesTableAdapter();
                aUpdateCharterInventoryTableAdapter.UpdateCharterInventoryPart(intTransactionID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Insert Charter Inventory " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertCharterInventory(int intPartID, int intWarehouseID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aInsertCharterInventoryTableAdapter = new InsertCharterInventoryDataTableAdapters.QueriesTableAdapter();
                aInsertCharterInventoryTableAdapter.InsertCharterInventory(intPartID, intWarehouseID, intQuantity);

            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Insert Charter Inventory " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindCharterWarehouseInventoryForPartDataSet FindCharterWarehouseInventoryForPart(int intPartID, int intWarehouseID)
        {
            try
            {
                aFindCharterWarehouseInventoryForPartDataSet = new FindCharterWarehouseInventoryForPartDataSet();
                aFindCharterWarehouseInventoryForPartTableAdapter = new FindCharterWarehouseInventoryForPartDataSetTableAdapters.FindCharterWarehouseInventoryForPartTableAdapter();
                aFindCharterWarehouseInventoryForPartTableAdapter.Fill(aFindCharterWarehouseInventoryForPartDataSet.FindCharterWarehouseInventoryForPart, intPartID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Find Charter Warehouse Inventory For Part " + Ex.Message);
            }

            return aFindCharterWarehouseInventoryForPartDataSet;
        }
        public FindCharterWarehouseInventoryDataSet FindCharterWarehouseInventory(int intWarehouseID)
        {
            try
            {
                aFindCharterWarehouseInventoryDataSet = new FindCharterWarehouseInventoryDataSet();
                aFindCharterWarehouseInventoryTableAdapter = new FindCharterWarehouseInventoryDataSetTableAdapters.FindCharterWarehouseInventoryTableAdapter();
                aFindCharterWarehouseInventoryTableAdapter.Fill(aFindCharterWarehouseInventoryDataSet.FindCharterWarehouseInventory, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Find Charter Warehouse Inventory " + Ex.Message);
            }

            return aFindCharterWarehouseInventoryDataSet;
        }
        public FindCompleteCharterInventoryDataSet FindCompleteCharterInventory()
        {
            try
            {
                aFindCompleteCharterInventoryDataSet = new FindCompleteCharterInventoryDataSet();
                aFindCompleteCharterInventoryTableAdapter = new FindCompleteCharterInventoryDataSetTableAdapters.FindCompleteCharterInventoryTableAdapter();
                aFindCompleteCharterInventoryTableAdapter.Fill(aFindCompleteCharterInventoryDataSet.FindCompleteCharterInventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Find Complete Charter Inventory " + Ex.Message);
            }

            return aFindCompleteCharterInventoryDataSet;
        }
        public CharterInventoryDataSet GetCharterInventoryInfo()
        {
            try
            {
                aCharterInventoryDataSet = new CharterInventoryDataSet();
                aCharterInventoryTableAdapter = new CharterInventoryDataSetTableAdapters.charterinventoryTableAdapter();
                aCharterInventoryTableAdapter.Fill(aCharterInventoryDataSet.charterinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Get Charter Inventory Info " + Ex.Message);
            }

            return aCharterInventoryDataSet;
        }
        public void UpdateCharterInventoryDB(CharterInventoryDataSet aCharterInventoryDataSet)
        {
            try
            {
                aCharterInventoryTableAdapter = new CharterInventoryDataSetTableAdapters.charterinventoryTableAdapter();
                aCharterInventoryTableAdapter.Update(aCharterInventoryDataSet.charterinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Charter Inventory Class // Update Charter Inventory DB " + Ex.Message);
            }
        }
    }
}
