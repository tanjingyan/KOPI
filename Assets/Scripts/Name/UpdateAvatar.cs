using System;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Name
{
    public class UpdateAvatar : MonoBehaviour
    {
        private RealtimeAvatarManager _realtimeAvatarManager;
        private RealtimeAvatar _realtimeAvatar;
        private string _localPlayerName;


        private void Awake() => _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();

        private void OnEnable() => _realtimeAvatarManager.avatarCreated += AvatarCreated;

        private void AvatarCreated(RealtimeAvatarManager avatarmanager, RealtimeAvatar avatar, bool islocalavatar)
        {
            if (islocalavatar)
            {
                _realtimeAvatar = avatar;
            }
        }

        public void SaveLocalPlayerName(Text nameField)
    {
        _localPlayerName = nameField.text;
        _realtimeAvatar.GetComponentInChildren<NameSync>().SetText(_localPlayerName);
        nameField.color = Color.red;
        nameField.text = "Name has been changed to " + _localPlayerName + " successfully!!";

        StartCoroutine(DisplayMessageForSeconds(nameField, 3f));
    }

    private IEnumerator DisplayMessageForSeconds(Text messageText, float seconds)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(seconds);

        // After waiting, clear the text or set it to an empty string
        messageText.text = "";
    }

        

        


    }
}