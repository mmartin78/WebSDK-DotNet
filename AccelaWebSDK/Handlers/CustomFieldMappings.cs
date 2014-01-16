using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Accela.Web.SDK
{
    // This class uses Describe Record ASI to get the information about the ASI for a given record type
    // and uses the description of ASI to translate into a more specific json/object pertatining to a record type

    public static class CustomFieldMappings
    {
        public static IDictionary<string, List<GroupInfo>> customFieldMappings = new Dictionary<string, List<GroupInfo>>();

        //public static void BuildMappings(List<RecordASI> asis, string recordTypeId)
        //{
        //    if (asis != null && asis.Count > 0)
        //    {
        //        if (!customFieldMappings.ContainsKey(recordTypeId))
        //        {
        //            List<GroupInfo> groupInfos = new List<GroupInfo>();
        //            foreach (RecordASI asi in asis)
        //            {
        //                GroupInfo groupInfo = new GroupInfo
        //                {
        //                    groupId = asi.id,
        //                    groupName = asi.display,
        //                    subGroups = new List<SubGroupInfo>()
        //                };

        //                for (int i = 0; i < asi.subGroups.Count; i++)
        //                {
        //                    SubGroupInfo subGroup = new SubGroupInfo
        //                    {
        //                        subGroupId = asi.subGroups[i].id,
        //                        subGroupName = asi.subGroups[i].display,
        //                        items = new List<ItemInfo>()
        //                    };

        //                    for (int j = 0; j < asi.subGroups[i].items.Count; j++)
        //                    {
        //                        ItemInfo item = new ItemInfo
        //                        {
        //                            itemId = asi.subGroups[i].items[j].id,
        //                            itemName = asi.subGroups[i].items[j].display
        //                        };
        //                        subGroup.items.Add(item);
        //                    }
        //                    groupInfo.subGroups.Add(subGroup);
        //                }
        //                groupInfos.Add(groupInfo);
        //                customFieldMappings.Add(recordTypeId, groupInfos);
        //            }
        //        }
        //    }
        //}

        //public static List<RecordASI> BuildRecordCustomFields(string recordTypeId, Object record)
        //{
        //    #region commented
        //    //List<RecordASI> asis = new List<RecordASI>();
        //    //foreach (ASIInfo asiInfo in ASIMappings.asiMappings[recordTypeId])
        //    //{
        //    //    RecordASI asi = new RecordASI
        //    //    {
        //    //        id = asiInfo.ASIId,
        //    //        subGroups = new List<SubGroup>()
        //    //    };

        //    //    for (int i = 0; i < asiInfo.subGroups.Count; i++)
        //    //    {
        //    //        List<Item> items = new List<Item>();
        //    //        for (int j = 0; j < asiInfo.subGroups[i].items.Count; j++)
        //    //        {
        //    //            string value = "";
        //    //            string groupName = asiInfo.subGroups[i].subGroupName.ToString().Replace(" ", "");
        //    //            string itemName = asiInfo.subGroups[i].items[j].itemName.Replace(" ", "");
        //    //            if (record.GetType().GetProperty(groupName) != null)
        //    //            {
        //    //                Object group = record.GetType().GetProperty(groupName).GetValue(record, null);
        //    //                if (group != null)
        //    //                {
        //    //                    if (group.GetType().GetProperty(itemName) != null)
        //    //                    {
        //    //                        Object val = group.GetType().GetProperty(itemName).GetValue(group, null);
        //    //                        if (val != null)
        //    //                            value = val.ToString();
        //    //                    }
        //    //                }
        //    //            }
        //    //            Item item = new Item { id = asiInfo.subGroups[i].items[j].itemId, value = value };
        //    //            items.Add(item);
        //    //        }
        //    //        asi.subGroups.Add(new SubGroup { id = asiInfo.subGroups[i].subGroupId, items = items });
        //    //    }
        //    //    asis.Add(asi);
        //    //}
        //    //return asis;
        //    #endregion

        //    if (ASIMappings.asiMappings.ContainsKey(recordTypeId))
        //    {
        //        if (record.GetType().GetProperty("customAttributes") != null)
        //        {
        //            Dictionary<string, Dictionary<string, Dictionary<string, string>>> customAttributes =
        //                (Dictionary<string, Dictionary<string, Dictionary<string, string>>>)record.GetType().GetProperty("customAttributes").GetValue(record, null);
        //            if (customAttributes != null && customAttributes.Count > 0)
        //                return BuildRecordASIUsingDictionary(recordTypeId, customAttributes);
        //            else
        //                return BuildRecordASIUsingReflection(recordTypeId, record);
        //        }
        //    }
        //    return null;
        //}

        //#region private method
        //private static List<RecordASI> BuildRecordASIUsingReflection(string recordTypeId, Object record)
        //{
        //    List<RecordASI> asis = new List<RecordASI>();
        //    List<GroupInfo> groupInfos = ASIMappings.asiMappings[recordTypeId];

        //    for (int i = 0; i < groupInfos.Count; i++)
        //    {
        //        RecordASI asi = null;
        //        string groupName = groupInfos[i].groupName;
        //        List<SubGroup> subGroups = new List<SubGroup>();

        //        // group matches property name
        //        if (record.GetType().GetProperty(groupName) != null)
        //        {
        //            Object groupObj = record.GetType().GetProperty(groupName).GetValue(record, null);
        //            subGroups = ProcessGroup(groupObj, groupInfos[i]);
        //            asi = new RecordASI { id = groupInfos[i].groupId, subGroups = subGroups };
        //        }
        //        // subgroup matches attribute
        //        else
        //        {
        //            bool found = false;
        //            foreach (PropertyInfo groupProperty in record.GetType().GetProperties())
        //            {
        //                if (found)
        //                    break;
        //                foreach (var attribute in groupProperty.GetCustomAttributes(false))
        //                {
        //                    if ((attribute is CustomFieldName && ((CustomFieldName)attribute).name.Equals(groupName)))
        //                    {
        //                        found = true;
        //                        Object groupObj = groupProperty.GetValue(record, null);
        //                        subGroups = ProcessGroup(groupObj, groupInfos[i]);
        //                        asi = new RecordASI { id = groupInfos[i].groupId, subGroups = subGroups };
        //                        break;
        //                    }
        //                }
        //            }
        //            if (!found && groupInfos.Count == 1)
        //            {
        //                subGroups = ProcessGroup(record, groupInfos[i]);
        //                asi = new RecordASI { id = groupInfos[0].groupId, subGroups = subGroups };
        //            }
        //        }
        //        asis.Add(asi);
        //    }
        //    return asis;
        //}

        //private static List<RecordASI> BuildRecordASIUsingDictionary(string recordTypeId, Dictionary<string, Dictionary<string, Dictionary<string, string>>> customAttributes)
        //{
        //    List<RecordASI> asis = new List<RecordASI>();
        //    List<GroupInfo> groupInfos = ASIMappings.asiMappings[recordTypeId];

        //    for (int i = 0; i < groupInfos.Count; i++)
        //    {
        //        RecordASI asi = new RecordASI { id = groupInfos[i].groupId };
        //        List<SubGroup> subGroups = new List<SubGroup>();
        //        for (int j = 0; j < groupInfos[i].subGroups.Count; j++)
        //        {
        //            SubGroup subGroup = new SubGroup { id = groupInfos[i].subGroups[j].subGroupId };
        //            List<Item> items = new List<Item>();
        //            for (int k = 0; k < groupInfos[i].subGroups[j].items.Count; k++)
        //            {
        //                Item item = new Item { id = groupInfos[i].subGroups[j].items[k].itemId };
        //                if (customAttributes.ContainsKey(groupInfos[i].groupName))
        //                {
        //                    Dictionary<string, Dictionary<string, string>> SubGroupDictionary = customAttributes[groupInfos[i].groupName];
        //                    if (SubGroupDictionary.ContainsKey(groupInfos[i].subGroups[j].subGroupName))
        //                    {
        //                        Dictionary<string, string> itemDictionary = SubGroupDictionary[groupInfos[i].subGroups[j].subGroupName];
        //                        if (itemDictionary.ContainsKey(groupInfos[i].subGroups[j].items[k].itemName))
        //                        {
        //                            item.value = itemDictionary[groupInfos[i].subGroups[j].items[k].itemName];
        //                        }
        //                        else
        //                            item.value = "";
        //                    }
        //                }
        //                items.Add(item);
        //            }
        //            subGroup.items = items;
        //            subGroups.Add(subGroup);
        //            asi.subGroups = subGroups;
        //        }
        //        asis.Add(asi);
        //    }
        //    return asis;
        //}

        //private static List<SubGroup> ProcessGroup(Object groupObj, GroupInfo groupInfo)
        //{
        //    if (groupObj != null)
        //    {
        //        List<SubGroup> subGroups = new List<SubGroup>();
        //        for (int i = 0; i < groupInfo.subGroups.Count; i++)
        //        {
        //            List<Item> items = new List<Item>();
        //            SubGroup subGroup = null;
        //            string subGroupName = groupInfo.subGroups[i].subGroupName;

        //            // subGroup matches property name
        //            if (groupObj.GetType().GetProperty(subGroupName) != null)
        //            {
        //                Object subGroupObj = groupObj.GetType().GetProperty(subGroupName).GetValue(groupObj, null);
        //                items = ProcessSubGroup(subGroupObj, groupInfo.subGroups[i]);
        //                subGroup = new SubGroup { id = groupInfo.subGroups[i].subGroupId, items = items };
        //            }
        //            // subGroup matches attribute
        //            else
        //            {
        //                bool found = false;
        //                foreach (PropertyInfo subGroupProperty in groupObj.GetType().GetProperties())
        //                {
        //                    if (found)
        //                        break;
        //                    foreach (var itemAttribute in subGroupProperty.GetCustomAttributes(false))
        //                    {
        //                        if ((itemAttribute is CustomFieldName && ((CustomFieldName)itemAttribute).name.Equals(subGroupName)))
        //                        {
        //                            found = true;
        //                            Object subGroupObj = subGroupProperty.GetValue(groupObj, null);
        //                            items = ProcessSubGroup(subGroupObj, groupInfo.subGroups[i]);
        //                            subGroup = new SubGroup { id = groupInfo.subGroups[i].subGroupId, items = items };
        //                            break;
        //                        }
        //                    }
        //                }
        //                if (!found)
        //                {
        //                    subGroup = new SubGroup { id = groupInfo.subGroups[i].subGroupId, items = new List<Item>() };
        //                    foreach (ItemInfo itemInfo in groupInfo.subGroups[i].items)
        //                    {
        //                        Item item = new Item { id = itemInfo.itemId, value = "" };
        //                        subGroup.items.Add(item);
        //                    }
        //                }
        //            }
        //            subGroups.Add(subGroup);
        //        }
        //        return subGroups;
        //    }
        //    return null;
        //}

        //private static List<Item> ProcessSubGroup(Object subGroupObj, SubGroupInfo subGroupInfo)
        //{
        //    if (subGroupObj != null)
        //    {
        //        List<Item> items = new List<Item>();
        //        for (int i = 0; i < subGroupInfo.items.Count; i++)
        //        {
        //            string value = "";
        //            string itemName = subGroupInfo.items[i].itemName;

        //            // item matches property name
        //            if (subGroupObj.GetType().GetProperty(itemName) != null)
        //            {
        //                Object val = subGroupObj.GetType().GetProperty(itemName).GetValue(subGroupObj, null);
        //                if (val != null)
        //                    value = val.ToString();
        //            }
        //            // item matches attribute
        //            else
        //            {
        //                bool found = false;
        //                foreach (PropertyInfo itemProperty in subGroupObj.GetType().GetProperties())
        //                {
        //                    if (found)
        //                        break;
        //                    foreach (var itemAttribute in itemProperty.GetCustomAttributes(false))
        //                    {
        //                        if ((itemAttribute is CustomFieldName && ((CustomFieldName)itemAttribute).name.Equals(itemName)))
        //                        {
        //                            found = true;
        //                            Object val = itemProperty.GetValue(subGroupObj, null);
        //                            if (val != null)
        //                            {
        //                                value = val.ToString();
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            Item item = new Item { id = subGroupInfo.items[i].itemId, value = value };
        //            items.Add(item);
        //        }
        //        return items;
        //    }
        //    return null;
        //}
        //#endregion
    }

    public class GroupInfo
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
        public List<SubGroupInfo> subGroups { get; set; }
    }

    public class SubGroupInfo
    {
        public string subGroupId { get; set; }
        public string subGroupName { get; set; }
        public List<ItemInfo> items { get; set; }
    }

    public class ItemInfo
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
    }
}
