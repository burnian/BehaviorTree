using System;
using System.Collections;
using System.Collections.Generic;


namespace IBehaviorTree
{
    using MemoryType = Dictionary<string, object>;

    // Blackboard 保存某一个agent的全局信息和每个节点信息
    public class Blackboard
    {
        public Blackboard()
        {
            _baseMemory = new MemoryType(); // used to store global information
            _treeMemory = new MemoryType(); // used to store tree and node information
        }

        private MemoryType _getTreeMemory(string treeID)
        {
            object memory;
            if (!_treeMemory.TryGetValue(treeID, out memory))
            {
                MemoryType temp = new MemoryType();
                temp.Add("nodeMemory", new MemoryType());
                temp.Add("openNodes", new List<BaseNode>());
                memory = temp;
                _treeMemory.Add(treeID, memory);
            }
            return (MemoryType)memory;
        }

        private MemoryType _getNodeMemory(MemoryType treeMemory, string nodeID)
        {
            MemoryType nodeMemory = (MemoryType)treeMemory["nodeMemory"];
            object memory;
            if (!nodeMemory.TryGetValue(nodeID, out memory))
            {
                MemoryType temp = new MemoryType();
                memory = temp;
                nodeMemory.Add(nodeID, memory);
            }
            return (MemoryType)memory;
        }

        private MemoryType _getMemory(string treeID = null, string nodeID = null)
        {
            MemoryType memory = _baseMemory;
            if (treeID != null && treeID != "")
            {
                memory = _getTreeMemory(treeID);
                if (nodeID != null && nodeID != "")
                {
                    memory = _getNodeMemory(memory, nodeID);
                }
            }
            return memory;
        }

        public void Set(string key, object value, string treeID = null, string nodeID = null)
        {
            _getMemory(treeID, nodeID)[key] = value;
        }

        public T Get<T>(string key, string treeID = null, string nodeID = null)
        {
            object value;
            _getMemory(treeID, nodeID).TryGetValue(key, out value);
            if (value == null && typeof(T).IsValueType)
            {
                value = Activator.CreateInstance(typeof(T));
            }
            return (T)value;
        }

        public void Remove(string treeID = null, string nodeID = null)
        {
            if (treeID != null && treeID != "")
            {
                if (nodeID != null && nodeID != "")
                {
                    MemoryType memory = _getTreeMemory(treeID);
                    ((MemoryType)memory["nodeMemory"]).Remove(nodeID);
                }
                else
                {
                    _treeMemory.Remove(treeID);
                }
            }
            else
            {
                _baseMemory = null;
                _treeMemory = null;
            }
        }

        private MemoryType _baseMemory;
        private MemoryType _treeMemory;
    }

}