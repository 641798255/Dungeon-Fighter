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
	    private float Flo_TimerDelta = 0;
	    private bool IsStartTimer = false;
	    private Button BtnSelf;
	    private bool Boo_Enable = false;
        private void Start()
        {
            BtnSelf = this.GetComponent<Button>();
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
                    ImgCircle.fillAmount = Flo_TimerDelta / FloCDTime;
                    BtnSelf.interactable = false;
                    if (Flo_TimerDelta >= FloCDTime)
                    {
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
            Boo_Enable = false;
            ImgWB.SetActive(true);
            BtnSelf.interactable = false;
        }

    }
}
