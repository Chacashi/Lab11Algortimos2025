using UnityEngine;
using UnityEngine.UI;

public class MemberFamily : MonoBehaviour
{
    [SerializeField] private Button myButton;

    [SerializeField] private MemberFamilyData memberFamilyData;

    public string  NameMember => memberFamilyData.nameMember;

    private void Start()
    {

        myButton.onClick.AddListener(ShowInfo);
    }


    void ShowInfo()
    {
        Debug.Log("Member Name: " + NameMember);
    }


    
}
