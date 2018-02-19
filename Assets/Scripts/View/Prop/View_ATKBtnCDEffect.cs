/*
   Title :
   主题：模型层
   功能：
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;



namespace View
{
	public class View_ATKBtnCDEffect :MonoBehaviour
	{
	    public Image ImgCircle;
	    public float FloCDTime=2f;
	    public GameObject ImgWB;
        public Text TxtCountDownNumber;
	    private float Flo_TimerDelta = 0;
	    private bool IsStartTimer = false;
	    private Button BtnSelf;
	    private bool Boo_Enable = false;
        private void Start()
        {
            BtnSelf = this.GetComponent<Button>();
            TxtCountDownNumber.enabled = false;
            EnableSelf();
        }

        private void Update()
        {
            if (Boo_Enable)
            {
                if (IsStartTimer)
                {
                    ImgWB.SetActive(true);
                    Flo_TimerDelta += Time.deltaTime;
                    TxtCountDownNumber.text = Mathf.RoundToInt(FloCDTime - Flo_TimerDelta).ToString();
                    ImgCircle.fillAmount = Flo_TimerDelta / FloCDTime;
                    BtnSelf.interactable = false;
                    if (Flo_TimerDelta >= FloCDTime)
                    {
                        TxtCountDownNumber.enabled = false;
                        IsStartTimer = false;
                        BtnSelf.interactable = true;
                        ImgCircle.fillAmount = 1;
                        Flo_TimerDelta = 0;
                        ImgWB.SetActive(false);
                    }
                }
            }
        }

	    public void ResponseBtnClick()
	    {
            TxtCountDownNumber.enabled = true;
            IsStartTimer = true;
            ImgWB.SetActive(false);
	        BtnSelf.interactable = true;
	    }

        public void EnableSelf()
        {
            Boo_Enable = true;
        }

        public void DisableSelf()
        {
            BtnSelf.interactable = false;
            Boo_Enable = false;
            ImgWB.SetActive(true);
        }

    }
}
