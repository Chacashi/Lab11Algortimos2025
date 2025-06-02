using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MemberFamily[] arrayMembers;
    [SerializeField] private MemberFamily[] arrayMembersSecondOrder;
    private Tree<NodeMemberFamily> treeFamily;


    private void Start()
    {
        NodeMemberFamily root = new NodeMemberFamily(arrayMembers[0].NameMember);
        treeFamily = new Tree<NodeMemberFamily>(root);

        for (int i = 1; i < arrayMembers.Length; i++)
        {
            TreeNode<NodeMemberFamily> newNode = new NodeMemberFamily(arrayMembers[i].NameMember);
            treeFamily.Root.AddChild(newNode);
        }

        treeFamily.TraversePreOrder(treeFamily.Root, node =>
        {
            for (int i = 0; i < node.Children.Count; i++)
            {
                node.Children[i].AddChild(new NodeMemberFamily(arrayMembersSecondOrder[i].NameMember));
            }
            
        });

        Debug.Log(treeFamily.GetHeight(treeFamily.Root));
        treeFamily.TraversePreOrder(treeFamily.Root, node =>
        {
            Debug.Log("Member Name: " + node.NameMember);
        });

    }



}
