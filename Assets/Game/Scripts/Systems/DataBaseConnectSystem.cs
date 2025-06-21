using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.Networking;
using System.Collections;
using System.Threading.Tasks;

public class DataBaseConnectSystem: Injects, IEcsInitSystem
{
    
    public void Init()
    {
        
    }

    public async void GetPlayer(string nickname)
    {
        string url = "http://localhost/kursgame/get_player.php?nickname=" + UnityWebRequest.EscapeURL(nickname);
        UnityWebRequest www = UnityWebRequest.Get(url);

        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Ошибка запроса: " + www.error);
            return;
        }

        string response = www.downloadHandler.text;

        if (response.StartsWith("error"))
        {
            Debug.Log("Игрок не найден");
            return;
        }

        string[] parts = response.Split(';');
        foreach (string part in parts)
        {
            Debug.Log(part); // Вывод строк типа id:1, nickname:PlayerOne и т.п.
        }
    }
}
