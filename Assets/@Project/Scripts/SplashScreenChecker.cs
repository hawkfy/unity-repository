#if !UNITY_EDITOR // .exe �ł݂̂��̃X�N���v�g��L�������܂�

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SplashScreenChecker : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
    private static void RuntimeInitializeBeforeSplashScreen()
    {
        Time.timeScale = 0;
    }

    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void RuntimeInitializeBeforeSceneLoad()
    {
        var go = new GameObject();
        go.AddComponent<SplashScreenChecker>();
    }

    private IEnumerator Start()
    {
        while ( !SplashScreen.isFinished )
        {
            yield return null;
        }

        Time.timeScale = 1;
    }
}

#endif