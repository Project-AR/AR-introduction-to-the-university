using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VectorGraphics;

public class EmailConfirmUIScript : MonoBehaviour
{
    [SerializeField] private SVGImage image;
    [Space]
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text buttonText;
    [Space]
    [SerializeField] private Sprite approveAcceptImage;
    [SerializeField] private Sprite approveErrorImage;

    public UnityEvent EmailConfirmButton_Click;

    public void setConfirmationResult(bool confirm)
    {
        if (confirm)
        {
            image.sprite = approveAcceptImage;
            descriptionText.text = "��� ������� �����������";
            buttonText.text = "����������";
        }
        else
        {
            image.sprite = approveErrorImage;
            descriptionText.text = "������ �������������";
            buttonText.text = "������� � �����������";
        }
    }
}
