using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MemberFamily[] arrayMembers;
    [SerializeField] private MemberFamily[] arrayMembersRaul;
    [SerializeField] private MemberFamily[] arrayMembersMirian;
    [SerializeField] private MemberFamily[] arrayMembersDeker;
    [SerializeField] private MemberFamily[] arrayMembersAstrid;
    [SerializeField] private MemberFamily[] arrayMembersJulieth;

    private Tree<NodeMemberFamily> treeFamily;


    private void Start()
    {
        NodeMemberFamily root = new NodeMemberFamily(arrayMembers[0].NameMember);
        treeFamily = new Tree<NodeMemberFamily>(root);


        for (int i = 1; arrayMembers.Length > i; i++)
        {
            TreeNode<NodeMemberFamily> newNode = new NodeMemberFamily(arrayMembers[i].NameMember);
            root.AddChild(newNode);
        }

        AssignMember(arrayMembersRaul, "Raul");
         AssignMember(arrayMembersMirian, "Mirian");
        AssignMember(arrayMembersDeker, "Deker");
        AssignMember(arrayMembersAstrid, "Astrid");
        AssignMember(arrayMembersJulieth, "Julieth");




        Debug.Log(treeFamily.GetHeight(treeFamily.Root));
        treeFamily.TraversePreOrder(treeFamily.Find(treeFamily.Root, node => node.NameMember == "Julia" ), node =>
        {
            Debug.Log("Member Name: " + node.NameMember);
        });

        Debug.Log("Root children count: " + root.Children.Count);


        
    }


    private void AssignMember(MemberFamily[] arrayMembers, string nameParent)
    {
        for (int i = 0; i < arrayMembers.Length; i++)
        {
            TreeNode<NodeMemberFamily> newNode = new NodeMemberFamily(arrayMembers[i].NameMember);
            treeFamily.Find(treeFamily.Root, node => node.NameMember == nameParent).AddChild(newNode);
        }
    }
}
