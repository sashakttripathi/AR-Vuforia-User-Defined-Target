using UnityEngine;
using Vuforia;
// при исполнении даного скрипта может появиться ошибка no matching Trackable found in DataSet! 
// решение VuforiaConfiguration->Databases отключить все данные!!!
public class UDTmanaget : MonoBehaviour, IUserDefinedTargetEventHandler
{
    UserDefinedTargetBuildingBehaviour UDT_BuildingBehaviour;
    ObjectTracker ObjTracker;
    DataSet dataSet;
    FrameQualityMeter _farmequalitymeter;
    ImageTargetBuilder.FrameQuality UDT_Quality;
    int targetCount;
    bool TourchDevice=true;
    public ImageTargetBehaviour targetBehaviour;

    void Start() {
        UDT_BuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
        if (UDT_BuildingBehaviour != null) {
            UDT_BuildingBehaviour.RegisterEventHandler(this);
        }
        _farmequalitymeter = FindObjectOfType<FrameQualityMeter>();
    }

    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)// метод отвечающий за качество кадра во время перемещения камеры аналог Update, подробнее по ссылке https://library.vuforia.com/articles/Training/User-Defined-Targets-Guide
    {   // он нужен для определения качества картинки как 5 звезд в Vuforia
        UDT_Quality = frameQuality;
        _farmequalitymeter.SetQuality(frameQuality);
        Debug.Log("Quality");
    }

    public void OnInitialized()// метод инициализации, подробнее по ссылке https://library.vuforia.com/articles/Training/User-Defined-Targets-Guide
    {
        ObjTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();// управление набором данных
        if (ObjTracker != null) { //если дынный обьект есть
            dataSet = ObjTracker.CreateDataSet();// создаем новый набор данных для vuforia
            ObjTracker.ActivateDataSet(dataSet);// активация нового набора данных
        }
    }

    public void OnNewTrackableSource(TrackableSource trackableSource)// метод который отвечает за новую отслеживаемую цель, подробнее по ссылке https://library.vuforia.com/articles/Training/User-Defined-Targets-Guide
    {
        targetCount++;
        ObjTracker.DeactivateDataSet(dataSet);// поскольку мы собираемся использовать новый набор данных нужно Deactivate старый набор.
        dataSet.CreateTrackable(trackableSource, targetBehaviour.gameObject);// узнаем что отслеживается нами// первая переменная это отслеживаемый источник в данный момент, а второй это цель т.е. ImageTraget если не понятно то по ссылке https://library.vuforia.com/articles/Training/User-Defined-Targets-Guide
        ObjTracker.ActivateDataSet(dataSet);// активация нового набора данных
        UDT_BuildingBehaviour.StartScanning(); // начать отслеживание
    }
    public void BuildTarget() {// данный метод будет создвать новуй источник отслеживаня, т.е. при определении высококачественной картинки будет создаваться новая цель. Посути это кнопка!!!
        if (UDT_Quality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH) {// определяем качество картинки
            UDT_BuildingBehaviour.BuildNewTarget(targetCount.ToString(),targetBehaviour.GetSize().x);// targetName можно задать любым String, проблема в том, что всякий раз, когда он находит новуюй источник имя будет всегда одинаковым, это не страшно, однако можно это обойти путем создания int и ++ ее при обнаружении нового источника
            // второй переменной является ширина, задать размеры лучше всего нашего ImageTarget.
        }

    }
    public void Light() {// don't touch me !!
        if (TourchDevice==true)
        {
            CameraDevice.Instance.SetFlashTorchMode(true);
            TourchDevice = false;            
        }
        else if (TourchDevice==false)
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
            TourchDevice = true;
        }
    }
}