using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageAnimation : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject imgObject;          //色やA値を変更したい画像があるｵﾌﾞｼﾞｪｸﾄ

    private Image img;

    [SerializeField]
    private float speed = 0.01f;           //透明化の速さ
    [SerializeField]
    [Range(0, 1)]
    private float red, green, blue = 0;    //RGBを操作するための変数
    [SerializeField]
    [Range(0,1)]
    private float alfaMax = 1;             //A値最大値
    [SerializeField]
    [Range(0,1)]
    private float alfaMin = 0;             //A値最小値

    private float alfa;                    //A値を操作するための変数

    private bool enter;                    //ﾏｳｽがｵﾌﾞｼﾞｪｸﾄに乗っているか

    private void Awake()
    {
        //マウスが合うまで非表示
        imgObject.SetActive(false);
    }

    private void Start()
    {
        //色やA値を変更したい画像を取得
        img = imgObject.GetComponent<Image>();

        //最初は透明
        alfa = 0;
    }

    private void Update()
    {
        img.color = new Color(red, green, blue, alfa);

       
        if (enter)
        {
            PointerEnter();
        }
        //外れたら
        else
        {
            PointerExit();
        }
    }

    private void PointerEnter() //ﾏｳｽが乗ったら
    {
        // 範囲内
        if (alfa < alfaMax)
        {
            alfa += speed;
        }
        else
        {
            alfa = alfaMax;
        }
    }
    private void PointerExit() //ﾏｳｽが外れたら
    {
        // 範囲外
        if (alfa <= alfaMin)
        {
            alfa = alfaMin;

            //ｵﾌﾞｼﾞｪｸﾄの非表示
            imgObject.SetActive(false);
        }
        else alfa -= speed;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        imgObject.SetActive(true);
        enter = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        enter = false;
    }
}
