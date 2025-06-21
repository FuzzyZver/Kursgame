using UnityEngine;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine.Networking;

public class LoadPLayerSystem: Injects, IEcsRunSystem
{
    private EcsFilter<LoadPlayerEvent> _loadPlayerEventFilter;
    public void Run()
    {
        foreach(int i in _loadPlayerEventFilter)
        {
            CoroutineRunner.Instance.StartCoroutine(LoadPlayer(_loadPlayerEventFilter.Get1(i).Nickname));
        }
    }

    private IEnumerator LoadPlayer(string nickname)
    {
        // Шаг 1: Получить данные игрока по нику
        string playerUrl = "http://localhost/kursgame/get_player.php?nickname=" + UnityWebRequest.EscapeURL(nickname);
        UnityWebRequest www = UnityWebRequest.Get(playerUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Ошибка получения игрока: " + www.error);
            yield break;
        }

        Debug.Log($"{nickname}");
        string response = www.downloadHandler.text;
        if (response.StartsWith("error"))
        {
            Debug.LogWarning("Игрок не найден.");
            yield break;
        }

        PlayerInfo player = ParsePlayer(response);
        GameConfig.CommonConfig.Nickname = player.nickname;
        GameConfig.TapConfig.PointsCount = player.score;
        Debug.Log($"Игрок: {player.nickname}, Score: {player.score}, ID: {player.id}");

        // Шаг 2: Получить inventory по id
        string invUrl = "http://localhost/kursgame/get_inventory.php?id_player=" + player.id;
        UnityWebRequest invRequest = UnityWebRequest.Get(invUrl);
        yield return invRequest.SendWebRequest();

        InventoryInfo inventory = ParseInventory(invRequest.downloadHandler.text);
        GameConfig.CommonConfig.HavePets[0] = inventory.cat_pet;
        GameConfig.CommonConfig.HavePets[1] = inventory.cat2_pet;
        GameConfig.CommonConfig.HavePets[2] = inventory.cat3_pet;
        Debug.Log($"Инвентарь: {inventory.cat_pet}, {inventory.cat2_pet}, {inventory.cat3_pet}");

        // Шаг 3: Получить skills по id
        string skillUrl = "http://localhost/kursgame/get_skills.php?id_player=" + player.id;
        UnityWebRequest skillRequest = UnityWebRequest.Get(skillUrl);
        yield return skillRequest.SendWebRequest();

        SkillsInfo skills = ParseSkills(skillRequest.downloadHandler.text);
        GameConfig.TapConfig.Skills[0].Value = skills.first;
        GameConfig.TapConfig.Skills[0].Cost = skills.first;
        GameConfig.TapConfig.Skills[1].Value = skills.second;
        GameConfig.TapConfig.Skills[1].Cost = skills.second;
        GameConfig.TapConfig.Skills[2].Value = skills.third;
        GameConfig.TapConfig.Skills[2].Cost = skills.third;
        Debug.Log($"Навыки: {skills.first}, {skills.second}, {skills.third}");
    }

    private PlayerInfo ParsePlayer(string data)
    {
        PlayerInfo p = new PlayerInfo();
        var parts = data.Split(';');
        foreach (var part in parts)
        {
            var kv = part.Split(':');
            switch (kv[0])
            {
                case "id": p.id = int.Parse(kv[1]); break;
                case "nickname": p.nickname = kv[1]; break;
                case "score": p.score = int.Parse(kv[1]); break;
            }
        }
        return p;
    }

    private InventoryInfo ParseInventory(string data)
    {
        InventoryInfo inv = new InventoryInfo();
        var parts = data.Split(';');
        foreach (var part in parts)
        {
            var kv = part.Split(':');
            bool value = kv[1] == "1" || kv[1].ToLower() == "true";
            switch (kv[0])
            {
                case "cat_pet": inv.cat_pet = value; break;
                case "cat2_pet": inv.cat2_pet = value; break;
                case "cat3_pet": inv.cat3_pet = value; break;
            }
        }
        return inv;
    }

    private SkillsInfo ParseSkills(string data)
    {
        SkillsInfo skills = new SkillsInfo();
        var parts = data.Split(';');
        foreach (var part in parts)
        {
            var kv = part.Split(':');
            switch (kv[0])
            {
                case "first": skills.first = int.Parse(kv[1]); break;
                case "second": skills.second = int.Parse(kv[1]); break;
                case "third": skills.third = int.Parse(kv[1]); break;
            }
        }
        return skills;
    }
}
