using UnityEngine;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine.Networking;

public class UploadPlayerSystem: Injects, IEcsRunSystem
{
    private EcsFilter<UploadPlayerEvent> _uploadPlayerEventFilter;

    public void Run()
    {
        foreach (int i in _uploadPlayerEventFilter)
        {
            CoroutineRunner.Instance.StartCoroutine(SaveOrUpdate(_uploadPlayerEventFilter.Get1(i).Nickname));
        }
    }

    private IEnumerator SaveOrUpdate(string nickname)
    {
        string getUrl = "http://localhost/kursgame/get_player.php?nickname=" + UnityWebRequest.EscapeURL(nickname);
        UnityWebRequest getRequest = UnityWebRequest.Get(getUrl);
        yield return getRequest.SendWebRequest();

        bool exists = false;
        int playerId = -1;

        if (getRequest.result == UnityWebRequest.Result.Success)
        {
            string response = getRequest.downloadHandler.text;
            if (!response.StartsWith("error"))
            {
                exists = true;
                string[] parts = response.Split(';');
                foreach (var part in parts)
                {
                    if (part.StartsWith("id:"))
                        playerId = int.Parse(part.Split(':')[1]);
                }
            }
        }
        GameConfig.CommonConfig.Nickname = nickname;
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("score", GameConfig.TapConfig.PointsCount);
        form.AddField("cat_pet", GameConfig.CommonConfig.HavePets[0] ? 1 : 0);
        form.AddField("cat2_pet", GameConfig.CommonConfig.HavePets[0] ? 1 : 0);
        form.AddField("cat3_pet", GameConfig.CommonConfig.HavePets[0] ? 1 : 0);
        form.AddField("skill1", GameConfig.TapConfig.Skills[0].Value);
        form.AddField("skill2", GameConfig.TapConfig.Skills[1].Value);
        form.AddField("skill3", GameConfig.TapConfig.Skills[2].Value);

        string url = exists ? "http://localhost/kursgame/update_player.php" : "http://localhost/kursgame/create_player.php";

        if (exists)
            form.AddField("id_player", playerId); // для update нужен ID

        UnityWebRequest post = UnityWebRequest.Post(url, form);
        yield return post.SendWebRequest();

        if (post.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Ошибка отправки: " + post.error);
        }
        else
        {
            Debug.Log("Ответ сервера: " + post.downloadHandler.text);
        }
    }
}
