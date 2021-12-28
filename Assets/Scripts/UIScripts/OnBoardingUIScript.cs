using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class OnBoardingUIScript : MonoBehaviour
{
    [SerializeField] private SVGImage image;
    [SerializeField] private Text headText;
    [SerializeField] private Text description;
    [SerializeField] private OnBoardingItem[] lists = new OnBoardingItem[3];

    private int index;

    public UnityEngine.Events.UnityEvent OnBoardingFinish;

    public void ContinueButton_Click()
    {
        if(index<2)
        {
            index++;
            image.sprite = lists[index].Image;
            headText.text = lists[index].HeadText;
            description.text = lists[index].Description;
        }
        else
        {
            OnBoardingFinish?.Invoke();
        }
    }
}

[System.Serializable]
public class OnBoardingItem
{
    public Sprite Image;
    public string HeadText;
    public string Description;
}


