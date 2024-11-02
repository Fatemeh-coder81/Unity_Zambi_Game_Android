using UnityEngine;

public class StageManager : MonoBehaviour
{
    // تابعی که وضعیت مرحله را بررسی می‌کند
    public string CheckStageStatus(int stageNumber)
    {
        // بررسی اینکه آیا وضعیت مرحله در PlayerPrefs وجود دارد یا نه
        if (!PlayerPrefs.HasKey("Stage_" + stageNumber))
        {
            // اگر مرحله وجود نداشت، آن را به عنوان بسته تنظیم می‌کند
            PlayerPrefs.SetInt("Stage_" + stageNumber, 0);
            return "Clos";
        }

        // اگر مرحله وجود داشت، وضعیت آن را می‌گیرد
        int status = PlayerPrefs.GetInt("Stage_" + stageNumber);
        return status == 1 ? "Open" : "Clos";
    }

    // تابعی برای باز کردن مرحله (اختیاری)
    public void UnlockStage(int stageNumber)
    {
        PlayerPrefs.SetInt("Stage_" + stageNumber, 1);
       
    }


    // برای تست، می‌توانید از این کد در Start استفاده کنید
    void Start()
    {
        UnlockStage(1);                 // باز کردن مرحله 1
     
    }
}
