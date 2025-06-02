using TreeEditor;
using UnityEngine;

public class NodeMemberFamily : TreeNode<NodeMemberFamily>
{
    public string NameMember { get; set; }

    public NodeMemberFamily(string name) : base(null)
    {
        NameMember = name;
        this.Value = this;
    }

}
